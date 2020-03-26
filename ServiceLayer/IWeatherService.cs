using Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IWeatherService
    {
        Task<List<Weather>> GetTempretures(List<string> cityName);
    }
}
