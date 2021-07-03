using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinEss
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btntexto_Clicked(object sender , EventArgs e)
        {
            await Navigation.PushAsync(new SpeechPage());
        }

        private async void btnmapas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new mapas());
        }


        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FotoPage());
        }

        private async void btnSQLite_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SQLitePage());
        }
    }
}
