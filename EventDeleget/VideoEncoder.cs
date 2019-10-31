using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EventDeleget
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }
    public class VideoEncoder
    {
        // 1. Define the deleget 
        // 2. Define a event based on that deleget
        // 3. Raise event

        //public delegate void VideoEncodedEventHandler(Object obj, VideoEventArgs args);
        //public event VideoEncodedEventHandler VideoEncoded;

        // EventHandler
        //public event VideoEventArgs VideoEncoded;
        // EventHandler<TEventArgs>

        public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine($"{video.Title } is encoding ........!");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
            //if (VideoEncoded != null)
            //{
            //    VideoEncoded(this, new VideoEventArgs { Video = video });
            //}

        }
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
            {
                VideoEncoded(this, new VideoEventArgs { Video = video });
            }
        }
    }
}
