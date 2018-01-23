using System;
using System.Threading.Tasks;
using MagicKadevjo.Dependencies;
using Xamarin.Forms;

namespace MagicKadevjo
{
    public partial class MagicKadevjoPage : ContentPage
    {
        public MagicKadevjoPage()
        {
            InitializeComponent();
            var tap = new TapGestureRecognizer();
            tap.Tapped += async (sender, e) =>
            {
                playButton.IsEnabled = true;
                DependencyService.Get<ISoundPlayer>().Play(RandomAudio());
                await Task.Delay(2000);
                playButton.IsEnabled = true;
            };
            playButton.GestureRecognizers.Add(tap);
        }

        private string RandomAudio()
        {
            var audios = new string[]{
                "culerada.wav",
                "ever.wav",
                "hey_gracias.wav",
                "hey_nombe_hey.wav",
                "igual.wav",
                "lo_que_dijiste_antes.wav",
                "nada.wav",
                "no_lo_otro.wav",
                "nooo.wav",
                "nulll.wav",
                "okay.wav",
                "okok.wav",
                "probablementeeee.wav",
                "siii.wav"
            };
            Random rnd = new Random();
            int index = rnd.Next(audios.Length);
            //return "https://firebasestorage.googleapis.com/v0/b/test-fda21.appspot.com/o/hey_nombe_hey.wav?alt=media&token=4230ede8-f607-4b79-91ca-edda7998f1ff";
            return audios[index];
        }
    }
}
