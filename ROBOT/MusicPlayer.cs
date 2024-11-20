using System.IO;
using WMPLib;

namespace ROBOT
{
    internal class MusicPlayer
    {
        private static WindowsMediaPlayer player;

        public static void PlayMusicFromResources()
        {
            if (player == null)
            {
                player = new WindowsMediaPlayer();

                string tempFile = Path.GetTempFileName() + ".mp3";
                File.WriteAllBytes(tempFile, Properties.Resources.Musica);

                player.URL = tempFile; 
                player.settings.setMode("loop", true); 
                player.controls.play(); 
            }
        }

        public static void StopMusic()
        {
            player?.controls.stop(); 
        }
    }
}
