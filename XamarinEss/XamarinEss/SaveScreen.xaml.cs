using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace XamarinEss
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaveScreen : ContentPage
    {
        Byte[] StringA { get; set; }

        Plugin.Media.Abstractions.MediaFile foto { get; set; }

        public SaveScreen(Byte[] imagen)
        {
            InitializeComponent();




            potrait.Source = ImageSource.FromStream(() => new MemoryStream(imagen));



            StringA = imagen;
         

        }


        private async void tomaBtn_Clicked(object sender, EventArgs e)
        {

            var tomarfoto = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MiApp",
                Name = "Prueba.jpg",
                SaveToAlbum = true
                
            });







            if (tomarfoto != null)
            {
                potrait.Source = ImageSource.FromStream(() =>
                {
                    return tomarfoto.GetStream();
                });
            }




            byte[] imageArray = null;

            //Insercion de mapa de bytes
            using (MemoryStream memory = new MemoryStream())
            {

                Stream stream = tomarfoto.GetStream();
                stream.CopyTo(memory);
                imageArray = memory.ToArray();
            }

            StringA = imageArray;
            foto = tomarfoto;
        }


        public async void sqliteBtn_Clicked(object sender, EventArgs e)
        {

            Byte[] imagen = StringA;
            MemoryStream data = new MemoryStream(imagen);

     


            var img = new Imagenes
            {
                Content = StringA,
                FileName = nombre.Text,
                Descripcion = descripcion.Text

            };

            if (String.IsNullOrWhiteSpace(nombre.Text))
            {
               await DisplayAlert("Advertencia", "Asegurese de llenar los campos obligatorios", "OK");

            }
            else if (String.IsNullOrWhiteSpace(descripcion.Text))
            {
              await  DisplayAlert("Advertencia", "Asegurese de llenar los campos obligatorios", "OK");

            }
            else
            {

                Task<int> resultado = App.InstanciaDB.InsertarImagen(img);
                await DisplayAlert("Advertencia", "Imagen Guardada en SQLite Exitosamente", "OK");

                await Navigation.PopAsync();





            }

        }

    }
}