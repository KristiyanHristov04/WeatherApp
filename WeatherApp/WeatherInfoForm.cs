using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class WeatherInfoForm : Form
    {
        public WeatherInfoForm()
        {
            InitializeComponent();

            string weatherResponse = MainForm.weatherResponse;

            string responseMain = JObject.Parse(weatherResponse).GetValue("main").ToString();
            string responseWeather = JObject.Parse(weatherResponse).GetValue("weather").ToString();
            string responseSys = JObject.Parse(weatherResponse).GetValue("sys").ToString();

            GetTemperature(responseMain);
            GetHumidity(responseMain);
            GetFeelsLike(responseMain);
            GetDescription(responseWeather);
            GetCityName(weatherResponse);
            GetCountry(responseSys);
            SetImage(responseWeather, pictureBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void GetTemperature(string responseMain)
        {
            string temperature = JObject.Parse(responseMain).GetValue("temp").ToString();
            double temperatureFormatted = Math.Round(double.Parse(temperature));
            textBox2.Text = temperatureFormatted.ToString() + "°C";
        }

        private void GetHumidity(string responseMain)
        {
            string humidity = JObject.Parse(responseMain).GetValue("humidity").ToString();
            label5.Text = humidity + "%";
        }

        private void GetFeelsLike(string responseMain)
        {
            string feelsLike = JObject.Parse(responseMain).GetValue("feels_like").ToString();
            double feelsLikeFormatted = Math.Round(double.Parse(feelsLike));
            label7.Text = feelsLikeFormatted.ToString() + "°";
        }

        private void GetDescription(string responseWeather)
        {
            Weather[] weather = JsonConvert.DeserializeObject<Weather[]>(responseWeather);
            string description = weather[0].Description;
            textBox3.Text = description;
        }

        private void GetCityName(string weatherResponse)
        {
            string cityName = JObject.Parse(weatherResponse).GetValue("name").ToString();
            textBox1.Text = cityName;
        }

        private void SetImage(string responseWeather, PictureBox pictureBox)
        {
            Weather[] weather = JsonConvert.DeserializeObject<Weather[]>(responseWeather);
            int id = weather[0].Id;
            if (id == 800)
            {
                pictureBox.Image = Image.FromFile("../../../Resources/800clear.png");
            }
            else if (id >= 801 && id <= 804)
            {
                pictureBox.Image = Image.FromFile("../../../Resources/801-804clouds.png");
            }
            else if (id >= 701 && id <= 781)
            {
                pictureBox.Image = Image.FromFile("../../../Resources/701-781atmosphere.png");
            }
            else if (id >= 600 && id <= 622)
            {
                pictureBox.Image = Image.FromFile("../../../Resources/600-622snow.png");
            }
            else if (id >= 500 && id <= 531)
            {
                pictureBox.Image = Image.FromFile("../../../Resources/500-531rain.png");
            }
            else if (id >= 300 && id <= 321)
            {
                pictureBox.Image = Image.FromFile("../../../Resources/300-321drizzle.png");
            }
            else if (id >= 200 && id <= 232)
            {
                pictureBox.Image = Image.FromFile("../../../Resources/200-232storm.png");
            }
        }

        private void GetCountry(string responseSys)
        {
            try
            {
                string country = JObject.Parse(responseSys).GetValue("country").ToString();
                textBox1.Text += ", " + country;
            }
            catch (Exception)
            {

            }
        }

        private void WeatherInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
