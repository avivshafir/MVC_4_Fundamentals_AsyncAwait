using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using AsyncAwait.Models;
using AsyncAwait.NewsServiceReference;
using AsyncAwait.WeatherServiceReference;

namespace AsyncAwait.Controllers
{
    public class HomeController : Controller
    {
        //[AsyncTimeout(3200)] 
        //[HandleError(ExceptionType=typeof(TimeoutException), View="Timeout")]             
        public async Task<ActionResult> Index()
        {
            var model = new HomePageViewModel();
            
            model.AddMessage("Starting action");
            
            var headlineTask = GetHeadlineAsync(model);
            var temperatureTask = GetCurrentTemperatureAsync(model);
            
            await Task.WhenAll(headlineTask, temperatureTask);
            
            model.AddMessage("Finished action");
            return View(model);
        }

        async Task GetCurrentTemperatureAsync(HomePageViewModel model)
        {
            model.AddMessage("Starting weather");
            var weatherClient = new WeatherServiceClient();
            model.Temperature = await weatherClient.GetCurrentTemperatureAsync();
            model.AddMessage("Finished weather");
        }

        async Task GetHeadlineAsync(HomePageViewModel model)
        {
            model.AddMessage("Starting GetHeadline");
            var newsClient = new NewsServiceClient();
            model.Headline = await newsClient.GetHeadlineAsync();
            model.AddMessage("Finished GetHeadline");
        }
    }
}





















//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Net.Http;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using Mvc4.Api;
//using Mvc4.Models;
//using Mvc4.WeatherServiceProxy;
//using CurrentWeather = Mvc4.WeatherServiceProxy.WeatherReport;

//namespace Mvc4.Controllers
//{
//    public class HomeController : Controller
//    {
//        //WeatherServiceClient weatherServiceClient = new WeatherServiceClient();
//        //NewsClient newsClient = new NewsClient();

//        public async Task<ActionResult> Index()
//        {
//            var model = new HomePageViewModel()
//            {
//         //       WeatherReport = await weatherServiceClient.GetWeatherReportAsync(),
////                NewsItems = await newsClient.GetNewsAsync()
//            };

//            return View(model);
//        }

//        [AsyncTimeout(5500)]
//        [HandleError(ExceptionType = typeof(TimeoutException), View = "TimeOut")]        
//        public async Task<ActionResult> Index2(CancellationToken token)
//        {            
//            Debug.Print("Starting Index2 on thread {0}", Thread.CurrentThread.ManagedThreadId);

//            var model = new HomePageViewModel()
//            {
//                  WeatherReport = await GetWeatherAsync(),
//                  NewsItems = await GetNewsAsync()
//            };
//            Debug.Print("End Index2 on thread {0}", Thread.CurrentThread.ManagedThreadId);
//            return View("Index", model);            
//        }

//        public async Task<ActionResult> Index3()
//        {
//            Debug.Print("Starting Index3 on thread {0}", Thread.CurrentThread.ManagedThreadId);
//            var model = await GetHomePageViewModel();
//            Debug.Print("End Index3 on thread {0}", Thread.CurrentThread.ManagedThreadId);
//            return View("Index", model);
//        }

//        public async Task<ActionResult> Index5()
//        {
//            Debug.Print("Starting Index5 on thread {0}", Thread.CurrentThread.ManagedThreadId);
//            var weatherTask = GetWeatherAsync();
//            var newsTask = GetNewsAsync();

//            var model = new HomePageViewModel
//            {
//                NewsItems = await newsTask,
//                WeatherReport = await weatherTask
//            };

//            Debug.Print("End Index5 on thread {0}", Thread.CurrentThread.ManagedThreadId);
//            return View("Index", model);
//        }

//        public ActionResult Index4()
//        {
//            Debug.Print("Starting Index4 on thread {0}", Thread.CurrentThread.ManagedThreadId);
//            var model = new HomePageViewModel
//            {
//                WeatherReport = GetWeather(),
//                NewsItems = GetNews()
//            };
//            Debug.Print("End Index4 on thread {0}", Thread.CurrentThread.ManagedThreadId);
//            return View("Index", model);
//        }

//        CurrentWeather GetWeather()
//        {
//            Debug.Print("Starting GetWeather on thread {0}", Thread.CurrentThread.ManagedThreadId);
//            Thread.Sleep(2500);
//            return new CurrentWeather { HiTemperature = 100, LowTemperature = 32 };
//        }

//        IEnumerable<NewsItem> GetNews()
//        {
//            Debug.Print("Starting GetNews on thread {0}", Thread.CurrentThread.ManagedThreadId);
//            Thread.Sleep(2000);
//            return new List<NewsItem>() {
//                new NewsItem { Title = "News A" },
//                new NewsItem { Title = "News B" },
//            };
//        }

//        async Task<CurrentWeather> GetWeatherAsync()
//        {
//            Debug.Print("Starting GetWeatherAsync on thread {0}", Thread.CurrentThread.ManagedThreadId);
//            await Task.Delay(2000);
//            return new CurrentWeather { HiTemperature = 100, LowTemperature = 32 };
//        }

//        async Task<IEnumerable<NewsItem>> GetNewsAsync()
//        {
//            Debug.Print("Starting GetNewsAsync on thread {0}", Thread.CurrentThread.ManagedThreadId);
//            await Task.Delay(2000);
//            return new List<NewsItem>() {
//                new NewsItem { Title = "News A" },
//                new NewsItem { Title = "News B" },
//            };
//        }

//        async Task<HomePageViewModel> GetHomePageViewModel()
//        {
//            var model = new HomePageViewModel();
//            var weatherTask = Task.Run(() => model.WeatherReport = GetWeather());
//            var newsTask = Task.Run(() => model.NewsItems = GetNews());

//            await Task.WhenAll(newsTask, weatherTask);

//            return model;
//        }
//    }
//}