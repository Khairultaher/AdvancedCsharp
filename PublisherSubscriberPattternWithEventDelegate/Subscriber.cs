using System;
using System.Collections.Generic;
using System.Text;

namespace PublisherSubscriberPattternWithEventDelegate
{
    public class Subscriber<T>
    {
        public IPublisher<T> Publisher { get; private set; }
        public int SubscriberNo { get; private set; }
        public Subscriber(IPublisher<T> publisher,int subscriberNo)
        {
            SubscriberNo = subscriberNo;
            Publisher = publisher;
            Publisher.DataPublisher += publisher_DataPublisher;
        }
        void publisher_DataPublisher(object sender, MessageArgument<T> e)
        {
            Console.WriteLine($"Subscriber {SubscriberNo} : " + e.Message);
        }
    }
}
