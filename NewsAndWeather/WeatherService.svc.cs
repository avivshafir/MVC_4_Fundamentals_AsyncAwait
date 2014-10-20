using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace NewsAndWeather
{    
    public class WeatherService : IWeatherService
    {
        public double GetCurrentTemperature()
        {
            Thread.Sleep(2000);
            return 19.1;
        }
    }
}
