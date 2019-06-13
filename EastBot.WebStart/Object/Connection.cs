using EastBot.Core.Interfaces;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using XmlConfig;

namespace Eastbot.Objects
{
    public class Connection : IConnection
    {
        private User User { get; set; }
        private string Token;
        private List<Team> TeamList;
        private List<Channel2> ChannelList;
        private List<Channel> ChanellListWithMsgCount;
        private IJsonHelper jsonHelper;
        private ISettingsProvider settingsProvider;
        private ILogHelper logHelper;
        private string connectionURL;

        public Connection(IJsonHelper jsonHelper, ISettingsProvider settingsProvider, ILogHelper logHelper)
        {
            this.jsonHelper = jsonHelper;
            this.settingsProvider = settingsProvider;
            this.logHelper = logHelper;
            User = new User(settingsProvider.GetString("MattermostLogin"), settingsProvider.GetString("MattermostPassword"));
            connectionURL = $"{settingsProvider.GetString("MattermostURL")}";
            TeamList = new List<Team>();
            ChannelList = new List<Channel2>();
            ChanellListWithMsgCount = new List<Channel>();
        }

        public void Login()
        {
            logHelper.Info($"Logowanie na użytkownika {User.Login}@{connectionURL}.", null);
            HttpWebResponse httpresponse = jsonHelper.SendPostRequest(User, $"{connectionURL}/api/v4/users/login");
            string responseString = new StreamReader(httpresponse.GetResponseStream()).ReadToEnd();

            Token = httpresponse.Headers.Get("Token");
            JObject rss = JObject.Parse(responseString);
            User.Id = (string)rss["id"];

            logHelper.Info("Zalgowałem się.", null);
        }

        public void GetAllTeamsForUser()
        {
            TeamList = jsonHelper.SendGetRequest<List<Team>>($"{connectionURL}/api/v4/users/{User.Id}/teams", Token);
        }

        public void GetAllChannels()
        {
            //logHelper.Info("Sprawdzenie", null); //test
            ChannelList = new List<Channel2>();
            foreach (var item in TeamList)
            {

                List<Channel2> temp = jsonHelper.SendGetRequest<List<Channel2>>($"{connectionURL}/api/v4/users/{User.Id}/teams/{item.Id}/channels", Token);
                if (temp == null)
                {
                    logHelper.Error(null, "Coś poszło nie tak bo lista kanałów jest pusta");
                    Thread.Sleep(1000);
                    temp = jsonHelper.SendGetRequest<List<Channel2>>($"{connectionURL}/api/v4/users/{User.Id}/teams/{item.Id}/channels", Token);
                    if (temp == null)
                        logHelper.Error(null, "I dalej jest pusta");
                }
                ChannelList.AddRange(temp);
            }
        }

        public void CountAllUnreadMessage()
        {
            ChanellListWithMsgCount = new List<Channel>();

            foreach (var item in ChannelList)
            {
                Channel temp = jsonHelper.SendGetRequest<Channel>($"{connectionURL}/api/v4/users/{User.Id}/channels/{item.ChannelId}/unread", Token);

                if (temp != null)
                    ChanellListWithMsgCount.Add(temp);
            }
        }

        private Post GetValueOfMessage(string PostId)
        {
            return jsonHelper.SendGetRequest<Post>($"{connectionURL}/api/v4/posts/{PostId}", Token);
        }

        public void SendMessage(string ChannelId, string Message)
        {
            jsonHelper.SendPostRequest(new Post(ChannelId, Message), $"{connectionURL}/api/v4/posts", Token);
            logHelper.Info($"Wysyłam wiadomość, kanał:{ChannelId}, wiadomość:\n{Message}", null);
        }


        public List<Post> GetUnreadPosts()
        {
            List<Post> posts = new List<Post>();

            if (ChanellListWithMsgCount != null)
                foreach (var item in ChanellListWithMsgCount)
                {
                    if (item.UnreadMessageCount == 0)
                    {
                        continue;
                    }

                    PostsList temp = jsonHelper.SendGetRequest<PostsList>($"{connectionURL}/api/v4/channels/{item.ChannelId}/posts", Token);
                    //
                    jsonHelper.SendPostRequest(new Post(item.ChannelId), $"{connectionURL}/api/v4/channels/members/{User.Id}/view", Token);

                    for (int i = 0; i < item.UnreadMessageCount; i++)
                    {
                        posts.Add(GetValueOfMessage(temp.PostId[i]));
                    }

                    item.UnreadMessageCount = 0;
                }
            else
                logHelper.Info("ChanellListWithMsgCount jest nulem", null);

            return posts;
        }

        public bool CheckIfPublic(string channelId)
        {
            Channel2 temp = jsonHelper.SendGetRequest<Channel2>($"{connectionURL}/api/v4/channels/{channelId}", Token);

            if (temp.Type == "O")
                return true;
            else
                return false;
        }
    }
}
