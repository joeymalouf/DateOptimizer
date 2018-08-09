using System;
using System.Linq;
using Xunit;
using dateOptimizer.domain.models;
using dateOptimizer.domain.services;

namespace myapp.test.domain.services
{
    public class WeatherServiceTests
    {
        [Fact]
        public void WeatherService_WeatherForecasts_ShouldReturnFiveItems()
        {
            // Arrange
            var target = new WeatherService();
            
            // Act
            var result = target.GetForecast();

            // Assert
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public void WeatherService_WeatherForecasts_ForecastDataIsPopulated()
        {
            // Arrange
            var target = new WeatherService();
            
            // Act
            var result = target.GetForecast();

            // Assert
            Assert.NotNull(result.FirstOrDefault().DateFormatted);
            Assert.NotNull(result.FirstOrDefault().Summary);
        }
    }
}