
namespace OscarPlayer
{
    interface IPlayer
    {
        void PlaySound(string url);

        void PauseSound();

        void ResumeSound();

        void StopSound();
    }
}
