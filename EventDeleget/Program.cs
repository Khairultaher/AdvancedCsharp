using System;

namespace EventDeleget
{
    class Program
    {
        static void Main(string[] args)
        {
            Video video = new Video() { Title = "Video_1" };
            VideoEncoder videoEncoder = new VideoEncoder(); //Publisher
            MailServer mailServer = new MailServer(); // Subscriber
            videoEncoder.VideoEncoded += mailServer.OnVideoEncoded;
 
            SMSServer sMSServer = new SMSServer(); // Subscriber
            videoEncoder.VideoEncoded += sMSServer.OnVideoEncoded;

            videoEncoder.Encode(video);
            Console.ReadLine();
        }
    }

    public class MailServer
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine($"{ args.Video.Title} is encoded  now sending mail....");
        }
    }

    public class SMSServer
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine($"{args.Video.Title} is encoded now sending SMS....");
        }
    }

}
