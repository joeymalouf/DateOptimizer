using System.Collections.Generic;
using dateOptimizer.domain.models;

namespace dateOptimizer.domain.interfaces
{
    public interface IWeatherService
    {   
        IEnumerable<WeatherForecast> GetForecast();
    }
}