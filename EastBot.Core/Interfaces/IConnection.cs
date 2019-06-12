using Eastbot.Objects;
using System.Collections.Generic;

namespace EastBot.Core.Interfaces
{
    public interface IConnection
    {
        void CountAllUnreadMessage();
        void GetAllChannels();
        void GetAllTeamsForUser();
        List<Post> GetUnreadPosts();
        void Login();
        void SendMessage(string ChannelId, string message);
        bool CheckIfPublic(string channelId);
    }
}