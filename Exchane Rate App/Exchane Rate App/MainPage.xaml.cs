using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Exchane_Rate_App
{
    class Rates
    {
        public static bool Import() // Импорт данных из сайта.
        {
            try
            {
                String URLString = "https://v6.exchangerate-api.com/v6/YOUR-API-KEY/latest/RUB";
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(URLString);
                    API_Obj Test = JsonConvert.DeserializeObject<API_Obj>(json);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    public class API_Obj // Переменные для курсов.
    {
        public string result { get; set; }
        public string documentation { get; set; }
        public string terms_of_use { get; set; }
        public string time_last_update_unix { get; set; }
        public string time_last_update_utc { get; set; }
        public string time_next_update_unix { get; set; }
        public string time_next_update_utc { get; set; }
        public string base_code { get; set; }
        public ConversionRate conversion_rates { get; set; }
    }
    public partial class ConversionRate // Курс обмена.
    {
        public static double CNY { get; set; }
        public static double EUR { get; set; }
        public static double RUB { get; set; }
        public static double USD { get; set; } 
        
    }
    public partial class MainPage : ContentPage
    {
        double exchangeRate; //Коэффициент обмена в зависимости от выбранной валюты.
        public MainPage()
        {
            InitializeComponent();
            firstEntry.Text = ConversionRate.RUB.ToString(); //Здесь я должен проверить работу API но нихуя не работает я хочу убить себя
        }

        public void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (valutePicker.SelectedIndex==0)
            {
                exchangeRate = ConversionRate.RUB;
                double firstSum = Convert.ToDouble(firstEntry.Text);
                secondEntry.Text = (exchangeRate * firstSum).ToString();
            }
            else if (valutePicker.SelectedIndex == 1)
            {
                exchangeRate = ConversionRate.USD;
                double firstSum = Convert.ToDouble(firstEntry.Text);
                secondEntry.Text = (exchangeRate * firstSum).ToString();
            }
            else if (valutePicker.SelectedIndex == 2)
            {
                exchangeRate = ConversionRate.EUR;
                double firstSum = Convert.ToDouble(firstEntry.Text);
                secondEntry.Text = (exchangeRate * firstSum).ToString();
            }
            else if (valutePicker.SelectedIndex == 3)
            {
                exchangeRate = ConversionRate.CNY;
                double firstSum = Convert.ToDouble(firstEntry.Text);
                secondEntry.Text = (exchangeRate * firstSum).ToString();
            }
        }
    }
}
