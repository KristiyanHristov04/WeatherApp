namespace WeatherApp
{
    public partial class MainForm : Form
    {
        public static string cityName = string.Empty;
        public static string weatherResponse = string.Empty;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cityName = textBox1.Text;
            bool isCityNameValid = ValidateCityName();

            if (isCityNameValid)
            {
                this.Hide();
                WeatherInfoForm weatherInfoForm = new WeatherInfoForm();
                weatherInfoForm.Show();
            }
            else
            {
                label2.Visible = true;
            }
        }

        private bool ValidateCityName()
        {
            bool isCityNameValid = true;

            HttpClient client = new HttpClient();

            string apiKey = APIConfiguration.APIKey;

            string cityName = MainForm.cityName.ToLower();

            string URI = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric";

            try
            {
                weatherResponse = client.GetStringAsync(URI).Result;
                isCityNameValid = true;
            }
            catch (Exception)
            {
                isCityNameValid = false;
            }

            return isCityNameValid;
        }
    }
}