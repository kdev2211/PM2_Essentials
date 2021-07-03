using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using Plugin.Geolocator;

namespace XamarinEss
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mapas : ContentPage
    {
        public mapas()
        {
            InitializeComponent();
        }


        protected async  override void OnAppearing()
        {
            base.OnAppearing();

            var localizacion = CrossGeolocator.Current;

            if (localizacion != null)
            {
                localizacion.PositionChanged += Localizacion_PositionChanged;


                if (localizacion.IsListening)
                {
                    await localizacion.StartListeningAsync(TimeSpan.FromSeconds(10), 100);
                }

                var posicion = await localizacion.GetPositionAsync();
                var centromapa = new Position(posicion.Latitude, posicion.Longitude);

                mapEss.MoveToRegion(new MapSpan(centromapa, 1, 1));
            }
        else
            {
                await localizacion.GetLastKnownLocationAsync();
                var posicion = await localizacion.GetPositionAsync();
                var centromapa = new Position(posicion.Latitude, posicion.Longitude);
                mapEss.MoveToRegion(new MapSpan(centromapa, 1, 1));
            }
        }

        private void Localizacion_PositionChanged(Object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var centromapa = new Position(e.Position.Latitude, e.Position.Longitude);
            mapEss.MoveToRegion(new MapSpan(centromapa, 1, 1));
        }
    }
}