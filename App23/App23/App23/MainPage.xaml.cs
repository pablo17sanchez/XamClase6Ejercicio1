using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using App23.Entidades;
using App23.Models;
using AutoMapper;
using Newtonsoft.Json;
using Plugin.Toast;
using Xamarin.Forms;

namespace App23
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }




        public void Handle_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbxCity.Text))
            {
                SearchWeather(tbxCity.Text);



            }
        }


        private void SearchWeather(string city)
        {
            try
            {
                var client = new WebClient();
                var encodedParameter = HttpUtility.UrlEncode(city);
                var formattedUrl = string.Format("https://api.apixu.com/v1/current.json?key=f4a33bfe56d84a7b895210819181510&q={0}", encodedParameter);
                var url = new Uri(formattedUrl);
                var resultString = client.DownloadString(url);
                var resultObject = JsonConvert.DeserializeObject<WeatherResponse>(resultString);
                client.Dispose();

                BindingContext = resultObject;

                /*
                                Mapper.Initialize(config =>
                                {
                                    config.CreateMap<WeatherResponse, ClimaModel>().ForMember(dest => dest.City, opt => opt.MapFrom(src => src.location.name)).
                                    ForMember(dest => dest.celcius, opt => opt.MapFrom(src => src.current.celcius)).
                                    ForMember(dest => dest.fahrenheit, opt => opt.MapFrom(src => src.current.fahrenheit)).
                                    ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.location.country)).
                                    ForMember(dest => dest.isday, opt => opt.MapFrom(src => src.current.isday));





                                });

                                    var result=  Mapper.Map<ClimaModel>(ClimaModel);
                                */




                var clima = new ClimaModel();


                clima.City = resultObject.location.name;

                clima.celcius = resultObject.current.celcius;
                clima.Country = resultObject.location.country;

                clima.fahrenheit = resultObject.current.fahrenheit;

                clima.Urlicon = resultObject.current.condition.IconUrl;

                //clima. = resultObject.current.fahrenheit;

                if (clima.Climaid > 0)
                {
                    App.Database.Update(clima);

                }
                else
                {
                    App.Database.Insert(clima);
                    CrossToastPopUp.Current.ShowToastMessage("To Do Item added successfully");
                }

            }

            catch (WebException ex) {
                DisplayAlert("Error", "La ciudad que estas buscando no esta disponible", "ok");

            }

            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "ok");
            }
        }

        private async void creados_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ListPage());



        }
    }
}
