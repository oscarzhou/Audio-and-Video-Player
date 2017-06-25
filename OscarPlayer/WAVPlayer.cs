using System;
using System.Media;

namespace OscarPlayer
{
    class WAVPlayer:IPlayer
    {
        private readonly SoundPlayer _objPlayer;

        public WAVPlayer()
        {
            _objPlayer = new SoundPlayer();
        }
        public void PlaySound(string url)
        {
            _objPlayer.SoundLocation = url;
            _objPlayer.Load();
            _objPlayer.Play();  

        }

        public void PauseSound()
        {
            throw new NotImplementedException();
        }

        public void ResumeSound()
        {
            throw new NotImplementedException();
        }

        public void StopSound()
        {
            
        }
    }
}
