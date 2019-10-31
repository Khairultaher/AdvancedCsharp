using System;
using System.Threading;

namespace EventDelegateNew
{
    public class News : EventArgs
    {
        public string Title { get; set; }
    }
    public class NewsPublisher
    {
        public delegate void NewsPublished(Object sender, News args);
        public event NewsPublished NewsPublishedEvent;
        public NewsPublisher()
        {
        }

        public void PublishNews()
        {
            News news = new News();
            news.Title = "A Great News For All...";
            Console.WriteLine("News is publishing to the subscibers");
            Thread.Sleep(2000);

            if (NewsPublishedEvent != null)
            {
                Published(news);
            }

            Console.WriteLine("Published successfully !!");
        }

        public void Published(News news)
        {
            NewsPublishedEvent(this, news);
        }
    }
    public class NewsSubscriber
    {
        private readonly NewsPublisher _newsPublisher;
        private int _number;

        public NewsSubscriber(int number)
        {
            _number = number;
        }
        public NewsSubscriber(int number, NewsPublisher newsPublisher)
        {
            _number = number;
            _newsPublisher = newsPublisher;
            _newsPublisher.NewsPublishedEvent += Replay;
        }

        public void Replay(Object sender, News news)
        {
            Console.WriteLine($"Thanks from subscriber{_number} for the news -- {news.Title}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            NewsPublisher newsPublisher = new NewsPublisher();

            //NewsSubscriber newsSubscriber1 = new NewsSubscriber(1,newsPublisher);
            //NewsSubscriber newsSubscriber2 = new NewsSubscriber(2,newsPublisher);

            NewsSubscriber newsSubscriber1 = new NewsSubscriber(1);
            newsPublisher.NewsPublishedEvent += newsSubscriber1.Replay;

            NewsSubscriber newsSubscriber2 = new NewsSubscriber(2);
            newsPublisher.NewsPublishedEvent += newsSubscriber2.Replay;

            newsPublisher.PublishNews();

            Console.ReadLine();
        }
    }
}
