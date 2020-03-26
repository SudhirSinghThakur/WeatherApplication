using Data;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// WeatherData
    /// </summary>
    public class WeatherData : IWeatherData
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Counstruct which takes the the http client as parameter input.
        /// The dependency will be resolved by registering it in to DI container.
        /// </summary>
        /// <param name="httpClient"></param>
        public WeatherData(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Read the data from the https://openweathermap.org/ by calling there APIs.
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<Weather> GetWeather(string city)
        {
            Weather temp = null;
            string url = $"/data/2.5/weather?" + "q=" + city + "&appid=b6907d289e10d714a6e88b30761fae22";

            using (HttpResponseMessage res = await _httpClient.GetAsync(url))
            using (HttpContent content = res.Content)
            {
                string data = await content.ReadAsStringAsync();
                if (res.IsSuccessStatusCode && data != null)
                {
                    var result = JObject.Parse(data);
                    temp = new Weather
                    {
                        Teamperature = Convert.ToInt32(result["main"]["temp"]),
                        Name = result["name"].ToString(),
                        Index = Convert.ToInt64(result["id"])
                    };
                }
            }
            return temp;
        }
    }
}
