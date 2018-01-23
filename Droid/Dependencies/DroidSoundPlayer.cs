using System;
using Android.Content.Res;
using Android.Media;
using MagicKadevjo.Dependencies;
using MagicKadevjo.Droid.Dependencies;

[assembly: Xamarin.Forms.Dependency(typeof(DroidSoundPlayer))]
namespace MagicKadevjo.Droid.Dependencies
{
    public class DroidSoundPlayer : ISoundPlayer
    {
        private MediaPlayer m;

        public DroidSoundPlayer()
        {
            m = new MediaPlayer();
        }

        public void Play(string mediaName)
        {

            //_mp = MediaPlayer.Create(this, R.raw.blah);

            try
            {
                //if (m.IsPlaying)
                {
                    m.Stop();
                    m.Release();
                    m = new MediaPlayer();
                }

                AssetFileDescriptor descriptor = Xamarin.Forms.Forms.Context.Assets.OpenFd(mediaName);
                m.SetDataSource(descriptor.FileDescriptor, descriptor.StartOffset, descriptor.Length);
                descriptor.Close();

                m.Prepare();
                m.SetVolume(1f, 1f);
                //m.Looping = true;
                m.Start();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }
    }
}
