using System.ServiceModel;

namespace NewsAndWeather
{    
    [ServiceContract]
    public interface IWeatherService
    {
        [OperationContract]
        double GetCurrentTemperature();
    }
}
