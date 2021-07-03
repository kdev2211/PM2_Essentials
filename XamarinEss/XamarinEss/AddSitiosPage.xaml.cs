using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinEss
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddSitiosPage : ContentPage
    {
        public AddSitiosPage()
        {
            InitializeComponent();
        }

        private void btnadd_Clicked(object sender, EventArgs e)
        {
            var sitio = new Sitios
            {
                nombre = txtnombre.Text
            };


            Task<int> resultado = App.InstanciaDB.InsertarSitio(sitio);
        }
    }
}