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
    public partial class SQLitePage : ContentPage
    {
        public SQLitePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                ListaSitios.ItemsSource = await App.InstanciaDB.ObtenerSitios();
            }
            catch (Exception ex)
            {

            }
        }

        private void OnSelection_Change(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddSitiosPage());
        }

        private async void ToolbarItem_Clicked_2(object sender, EventArgs e)
        {

        }

        private void ListaSitios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var sitio = (Sitios)e.Item;
        
        }



    }
}