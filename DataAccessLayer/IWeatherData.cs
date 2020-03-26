using Data;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IWeatherData 
    {
        Task<Weather> GetWeather(string city);
    }
}
