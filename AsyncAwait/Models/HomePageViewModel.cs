using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;

namespace AsyncAwait.Models
{
    public class HomePageViewModel
    {
        private Stopwatch _watch;
        private ConcurrentQueue<string> _messages; 

        public HomePageViewModel()
        {
            _watch = Stopwatch.StartNew();
            _messages = new ConcurrentQueue<string>();
        }

        public string Headline { get; set; }

        public double Temperature { get; set; }

        public void AddMessage(string message)
        {
            _messages.Enqueue(String.Format("{0} on thread {1}", message, Thread.CurrentThread.ManagedThreadId));
        }

        public IEnumerable<string> Messages
        {
            get { return _messages; }
        }

        public long ElapsedTime
        {
            get { return _watch.ElapsedMilliseconds; }
        }
    }
}