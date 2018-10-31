using System;
using System.IO;
using App23.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App23
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

         //   MainPage = new MainPage();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        static MyDatabase database;

        public static MyDatabase Database
        {
            get
            {
                if (database == null)
                {
                    var dbpath =
                        Path.Combine(
                            Environment.GetFolderPath(
                                Environment.SpecialFolder.LocalApplicationData), "MyDatabase.db3");

                    database = new MyDatabase(dbpath);
                }
                return database;

            }
        }


    }
}
