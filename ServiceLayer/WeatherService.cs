using Data;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer
{
    /// <summary>
    /// WeatherService
    /// </summary>
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherData _weatherData;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="weatherData"></param>
        public WeatherService(IWeatherData weatherData)
        {
            _weatherData = weatherData;
        }

        /// <summary>
        /// GetTempretures
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public async Task<List<Weather>> GetTempretures(List<string> cityName)
        {
            List<Weather> test = new List<Weather>();
            foreach (var city in cityName)
            {
                var temp = await _weatherData.GetWeather(city).ConfigureAwait(false);
                if(temp != null)
                {
                    test.Add(temp);
                }
            }
            return test.OrderByDescending(t => t.Teamperature).ToList();
        }
    }
}
