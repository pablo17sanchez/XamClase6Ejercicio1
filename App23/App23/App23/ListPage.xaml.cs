using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App23
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListPage : ContentPage
	{
		public ListPage ()
		{
			InitializeComponent ();


        }

        protected override async void OnAppearing()
        {

            var items = await App.Database.GetItems();
            listadeciudades.ItemsSource = items;



        }

        private void borrar_Clicked(object sender, EventArgs e)
        {
            listadeciudades.BeginRefresh();

            App.Database.DeleteAll();

            listadeciudades.EndRefresh();
        }
    }
}