using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KostinPr18
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ButtonResult_Clicked(object sender, EventArgs e)
        {
            staclLayout.Children.Clear();
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    HttpClient client = new HttpClient();
                    HttpResponseMessage response = await client.GetAsync($"https://rickandmortyapi.com/api/character/{entryNumber.Text.Replace(".", "")}");
                    HttpContent responseContent = response.Content;
                    string json = await responseContent.ReadAsStringAsync();
                    RicAndMorty ricAndMorty = JsonConvert.DeserializeObject<RicAndMorty>(json);
                    staclLayout.Children.Add(new Label() { Text = "ID: " + ricAndMorty.id.ToString(), FontSize = 20 });
                    staclLayout.Children.Add(new Label() { Text = "Имя: " + ricAndMorty.name.ToString(), FontSize = 20 });
                    staclLayout.Children.Add(new Label() { Text = "Статус: " + ricAndMorty.status.ToString(), FontSize = 20 });
                    staclLayout.Children.Add(new Label() { Text = "Вид: " + ricAndMorty.species.ToString(), FontSize = 20 });
                    staclLayout.Children.Add(new Label() { Text = "Тип: " + ricAndMorty.type.ToString(), FontSize = 20 });
                    staclLayout.Children.Add(new Label() { Text = "Пол: " + ricAndMorty.gender.ToString(), FontSize = 20 });
                    staclLayout.Children.Add(new Label() { Text = "Происхождение: " + ricAndMorty.origin.name.ToString(), FontSize = 20 });
                    staclLayout.Children.Add(new Label() { Text = "Местоположение: " + ricAndMorty.location.name.ToString(), FontSize = 20 });

                }
                catch (Exception ex)
                {
                    var error = new Label() { Text = ex.Message, TextColor = Color.Red };
                    staclLayout.Children.Add(error);
                }

            }
        }
    }
}
