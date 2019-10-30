using System;
using System.Collections.Generic;
using System.Text;

namespace PublisherSubscriberPattternWithEventDelegate
{
    public class Client
    {
        private readonly IPublisher<int> IntPublisher;
        private readonly Subscriber<int> IntSublisher1;

        private readonly Subscriber<int> IntSublisher2;
        public Client()
        {
            IntPublisher = new Publisher<int>();//create publisher of type integer

            IntSublisher1 = new Subscriber<int>(IntPublisher,1);//subscriber 1 subscribe to integer publisher
            //IntSublisher1.Publisher.DataPublisher += publisher_DataPublisher1;//event method to listen publish data

            IntSublisher2 = new Subscriber<int>(IntPublisher,2);//subscriber 2 subscribe to interger publisher
            //IntSublisher2.Publisher.DataPublisher += publisher_DataPublisher2;//event method to listen publish data
            
            IntPublisher.PublishData(10); // publisher publish message
        }
        void publisher_DataPublisher1(object sender, MessageArgument<int> e)
        {
            Console.WriteLine("Subscriber 1 : " + e.Message);
        }
        void publisher_DataPublisher2(object sender, MessageArgument<int> e)
        {
            Console.WriteLine("Subscriber 2 : " + e.Message);
        }
    }
}
