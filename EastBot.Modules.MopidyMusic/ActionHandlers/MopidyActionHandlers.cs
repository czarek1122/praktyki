using Eastbot.Objects;
using Eastbot.Objects.ModipyObject;
using EastBot.Core.Interfaces;
using EastBot.Modules.MopidyMusic.Interfaces;
using EastBot.Modules.MopidyMusic.ModipyObject;
using System;
using System.Threading;
using System.Threading.Tasks;
using Unity;
using XmlConfig;

namespace EastBot.Modules.MopidySecond.ActionHandlers
{
    public class MopidyActionHandler : IActionHandler
    {
        private IConnection connection;
        private IJsonHelper jsonHelper;
        private IMopidyService mopidyService;
        private ISettingsProvider settingsProvider;
        private ILogHelper logHelper;
        private Elections Elections;
        private bool firstUse;
        private bool nextSong;
        private int voteTime;
        private int numberOfVotes;

        public MopidyActionHandler(IConnection connection, IJsonHelper jsonHelper, IMopidyService mopidyService, 
            ISettingsProvider settingsProvider, ILogHelper logHelper)
        {
            this.connection = connection;
            this.jsonHelper = jsonHelper;
            this.mopidyService = mopidyService;
            this.settingsProvider = settingsProvider;
            this.logHelper = logHelper;
            firstUse = true;
            nextSong = false;
            numberOfVotes = settingsProvider.GetInt("Mopidy", "NumberOfVotes");
            voteTime = settingsProvider.GetInt("Mopidy", "VoteTimeout");
        }

        public bool HandleRequest(Post message)
        {
            if (message.Message.StartsWith("muzyka", StringComparison.InvariantCultureIgnoreCase))
            {
                var splited = message.Message.Split(new char[] { ' ' }, 2);

                if (splited.Length == 2)
                 {
                    if (splited[1].ToLowerInvariant() == "ciszej" && connection.CheckIfPublic(message.Channel))
                    {
                        mopidyService.SetVolume(-2);
                        connection.SendMessage(message.Channel, "**Muzyka przyciszona**");
                        return true;
                    }
                    else if (splited[1].ToLowerInvariant() == "głośniej" && connection.CheckIfPublic(message.Channel))
                    {
                        mopidyService.SetVolume(2);
                        connection.SendMessage(message.Channel, "**Muzyka podgłoszona**");
                        return true;
                    }
                    else if (splited[1].ToLowerInvariant() == "stop" && connection.CheckIfPublic(message.Channel))
                    {
                        Result<string> temp = mopidyService.GetState<Result<string>>();

                        if (temp.Value.ToLowerInvariant() == "paused")
                        {
                            mopidyService.StopSong();
                            connection.SendMessage(message.Channel, "**Odtwarzanie przerwane**");
                        }
                        else
                        {
                            mopidyService.PauseSong();
                            connection.SendMessage(message.Channel, "**Odtwarzanie wstrzymane**");
                        }
                    }
                    else if (splited[1].ToLowerInvariant() == "play" && connection.CheckIfPublic(message.Channel))
                    {
                        Result<string> temp = mopidyService.GetState<Result<string>>();

                        if (temp.Value.ToLowerInvariant() == "playing")
                        {
                            connection.SendMessage(message.Channel, "**Aktualnie muzyka jest odtwarzana**");
                        }
                        else if (temp.Value.ToLowerInvariant() == "stopped")
                        {
                            mopidyService.PlaySong();
                            connection.SendMessage(message.Channel, "**Odtwarzanie rozpoczęte**");
                        }
                        else
                        {
                            mopidyService.ResumeSong();
                            connection.SendMessage(message.Channel, "**Odtwarzanie wznowione**");
                        }
                    }
                    else if (splited[1].ToLowerInvariant() == "następny" && connection.CheckIfPublic(message.Channel))
                    {
                        if (firstUse)
                        {
                            firstUse = false;
                            NextSong(message.Channel, message.UserId);
                        }
                        else if (DateTimeOffset.Now.ToUnixTimeSeconds() > Elections.StartTime)
                        {
                            NextSong(message.Channel, message.UserId);
                        }
                        else if (DateTimeOffset.Now.ToUnixTimeSeconds() < Elections.StartTime)
                        {
                            if (!Elections.UserIdLists.Contains(message.UserId))
                            {
                                Elections.UserIdLists.Add(message.UserId);
                                connection.SendMessage(message.Channel, $"**Brakuje jeszcze {Elections.UserCount - Elections.UserIdLists.Count} głosów.**");
                            }
                        }

                        if (Elections.UserIdLists.Count == Elections.UserCount)
                        {
                            logHelper.Info("Zmiana piosenki po głosowaniu", null);

                            Elections.StartTime = 0;
                            mopidyService.NextSong();
                            nextSong = true;
                            connection.SendMessage(message.Channel, "**Odtwarzanie następnej piosenki**");
                        }
                    }
                    else if (!connection.CheckIfPublic(message.Channel))
                    {
                        connection.SendMessage(message.Channel, "**Funkcja dostępna tylko na kanałach publicznych**");
                    }
                    else
                    {
                        connection.SendMessage(message.Channel, "**Niewłaściwa komenda**");
                    }
                }
                else
                {
                    Result<Track> temp = mopidyService.GetCurrentTrack<Result<Track>>();

                    if (temp == null)
                    {
                        connection.SendMessage(message.Channel, "**Coś poszło nie tak**");
                        return true;
                    }
                    string musicResponse =
                        $"**Nazwa**: {temp.Value.TrackName} \n" +
                        $"**Album**: {temp.Value.Album.AlbumName} \n" +
                        $"**Artysta**: {temp.Value.GetAllArtists() } \n\n";

                    if (mopidyService.GetState("core.tracklist.get_random"))
                        musicResponse = musicResponse + $"**Utwory są odtwarzane losowo.** \n";
                    else
                        musicResponse = musicResponse + $"**Utwory są odtwarzane w ustalonej kolejności.**\n";

                    if (mopidyService.GetState("core.tracklist.get_consume"))
                        musicResponse = musicResponse + $"**Utwory są usuwane z playlisty po odtworzeniu.**\n";
                    else
                        musicResponse = musicResponse + $"**Utwory nie są usuwane z playlisty po odtworzeniu.**\n";

                    if (!mopidyService.GetState("core.tracklist.get_repeat"))
                        musicResponse = musicResponse + $"**Odtwarzanie nie jest zapętlone.**\n";
                    else
                        musicResponse = musicResponse + $"**Odtwarzanie jest zapętlone.**\n";

                    musicResponse = musicResponse + $"**Poziom głośności:** {mopidyService.GetVolume()}";

                    connection.SendMessage(message.Channel, musicResponse);
                }
                return true;
            }

            return false;
        }

        private void NextSong(string channelId, string userId)
        {
            logHelper.Info("Rozpoczynam nowe głosowanie o zmianę piosenki", null);
            Elections = new Elections(numberOfVotes, voteTime);
            Elections.UserIdLists.Add(userId);
            connection.SendMessage(channelId, $"**Przyjąłem wniosek formalny o przełączenie na następny utwór**\n" +
                $"**Potrzeba jeszcze {Elections.UserCount - Elections.UserIdLists.Count} głosów**\n" +
                $"**Czekam 30 sekund.**");
            nextSong = false;


            var t = Task.Run(() =>
            {
                Thread.Sleep(30000);
                if (!nextSong)
                {
                    connection.SendMessage(channelId, "**Czas minął**");
                    logHelper.Info("Koniec czasu głosowania, piosenka nie zostaje zmieniona", null);
                }
            });
        }
    }
}      
