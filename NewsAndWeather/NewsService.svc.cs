using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace NewsAndWeather
{    
    public class NewsService : INewsService
    {
        public string GetHeadline()
        {
            Thread.Sleep(2000);
            return "MVC 4 is here!";
        }
    }
}
