namespace EastBot.Modules.MopidyMusic.Interfaces
{
    public interface IMopidyService
    {
        T GetCurrentTrack<T>();
        void PauseSong();
        void ResumeSong();
        void NextSong();
        void StopSong();
        void PlaySong();
        T GetState<T>();
        void SetVolume(int value);
        int GetVolume();
        bool GetState(string method);
    }
}
