using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.TextToSpeech;
namespace XamarinEss
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpeechPage : ContentPage
    {
        public SpeechPage()
        {
            InitializeComponent();
        }

        private void btnspeed_Clicked(object sender, EventArgs e)
        {
            TextToSpeech.SpeakAsync(txtnota.Text);
        }

        private async void btnspeech1_Clicked(object sender, EventArgs e)
        {
            await CrossTextToSpeech.Current.Speak(txtnota.Text, null, (float)Sltono.Value, (float)Slspeed.Value, (float)Slvolumen.Value);
        }

    }
}