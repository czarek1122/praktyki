using Eastbot.Objects;
using EastBot.Core.Interfaces;
using EastBot.Modules.MopidyMusic.Interfaces;
using EastBot.Modules.MopidyMusic.ModipyObject;
using System.Collections.Generic;
using XmlConfig;

namespace EastBot.Modules.MopidyMusic.Services
{
    public class MopidyService : IMopidyService
    {
        private string addressURL;
        private IJsonHelper jsonHelper;
        private ISettingsProvider settingsProvider;

        public MopidyService(IJsonHelper jsonHelper, ISettingsProvider settingsProvider)
        {
            this.jsonHelper = jsonHelper;
            this.settingsProvider = settingsProvider;
            addressURL = settingsProvider.GetString("Mopidy","RPCAddress");
        }

        public T GetCurrentTrack<T>()
        {
            return jsonHelper.SendPostRequest<T>(new Request("core.playback.get_current_track"), addressURL);
        }

        public T GetState<T>()
        {
            return jsonHelper.SendPostRequest<T>(new Request("core.playback.get_state"), addressURL);
        }

        public void NextSong()
        {
            jsonHelper.SendPostRequest(new Request("core.playback.next"), addressURL, null);
        }

        public void PauseSong()
        {
            jsonHelper.SendPostRequest(new Request("core.playback.pause"), addressURL, null);
        }

        public void PlaySong()
        {
            jsonHelper.SendPostRequest(new Request("core.playback.play"), addressURL, null);
        }

        public void ResumeSong()
        {
            jsonHelper.SendPostRequest(new Request("core.playback.resume"), addressURL, null);
        }

        public void StopSong()
        {
            jsonHelper.SendPostRequest(new Request("core.playback.stop"), addressURL, null);
        }

        public int GetVolume()
        {
            Result<int> temp = jsonHelper.SendPostRequest<Result<int>>(new Request("core.playback.get_volume"), addressURL);

            return temp.Value;
        }
        public void SetVolume(int value)
        {
            int temp = GetVolume();
            List<object> objectList = new List<object>();
            int volume;

            if (temp + value < 0)
            {
                volume = 0;
            }
            else if (temp + value > 100)
            {
                volume = 100;
            }
            else
            {
                volume = temp + value;
            }

            objectList.Add(volume);

            jsonHelper.SendPostRequest(new Request("core.playback.set_volume", objectList), addressURL, null);
        }

        public bool GetState(string method)
        {
            Result<bool> temp = jsonHelper.SendPostRequest<Result<bool>>(new Request(method), addressURL);

            return temp.Value;
        }
    }
}
