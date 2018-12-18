using System;
using System.Net;
using System.Text;

namespace Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            //ввод нужного города с консоли
            string city = Console.ReadLine();
            GetWeather(city);
        }

        public static void GetWeather(string city)
        {
            var url = "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather." +
                "forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text" +
                "%3D%22" + city +
                "%22)&format=xml&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";

            WebClient client = new WebClient
            {
                Encoding = Encoding.UTF8
            };

            //парсинг xml
            var b = ParseXML(client.DownloadString(url));
            //перевод в цельсии
            Console.WriteLine("Темперетура в " + city + " : " + ConvertToСelsius(b));
        }

        //парсинг xml
        private static int ParseXML(string xml)
        {
            //разделение по тегам
            string[] dates = xml.Split('<');
            //под 45 тегом сегодняшняя погода
            string a = dates[45];
            //разделение по полям
            dates = a.Split('=');
            //в 'a' будет: "11" text 
            //18 декабря
            a = dates[4];
            //для получения температуры
            dates = a.Split('"');
            //в 'a' будет 11
            a = dates[1];
            var b = Convert.ToInt16(a);
            return b;
        }

        //конверт в градусы по цельсии
        public static int ConvertToСelsius(int temperature)
        {
            return ((temperature - 32) * 5) / 9;
        }
    }
}