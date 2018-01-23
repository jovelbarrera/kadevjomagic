using System;
using AudioToolbox;
using Foundation;
using MagicKadevjo.Dependencies;
using MagicKadevjo.iOS.Dependencies;

[assembly: Xamarin.Forms.Dependency(typeof(iOSSoundPlayer))]
namespace MagicKadevjo.iOS.Dependencies
{
    public class iOSSoundPlayer : ISoundPlayer
    {
        //private MediaPlayer m;

        public iOSSoundPlayer()
        {
            //m = new MediaPlayer();
        }

        public void Play(string mediaName)
        {
            var url = NSUrl.FromFilename(@"Sounds/" + mediaName);
            var systemSound = new SystemSound(url);
            systemSound.PlaySystemSound();
        }
    }
}
