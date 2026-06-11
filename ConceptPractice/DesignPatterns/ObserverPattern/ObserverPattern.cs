using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptPractice.DesignPatterns.ObserverPattern
{
    public class ObserverPattern
    {
        public interface ISubscriber
        {
            void Update();
        }

        public interface IChannel
        {
            void Subscribe(ISubscriber subscriber);
            void Unsubscribe(ISubscriber subscriber);
            void NotifySubscribers();
        }

        public class Channel : IChannel
        {
            private readonly List<ISubscriber> _subscribers;
            private readonly string _name;
            private string _latestVideo;

            public Channel(string name)
            {
                _name = name;
                _subscribers = new List<ISubscriber>();
            }

            public void Subscribe(ISubscriber subscriber)
            {
                if (!_subscribers.Contains(subscriber))
                    _subscribers.Add(subscriber);
            }


            public void Unsubscribe(ISubscriber subscriber)
            {
                _subscribers.Remove(subscriber);
            }

            public void NotifySubscribers()
            {
                foreach(var sub in _subscribers)
                {
                    sub.Update();
                }
            }

            public void UploadVideo(string title)
            {
                _latestVideo = title;

                Console.WriteLine($"\n[{_name} uploaded \"{title}\"]");

                NotifySubscribers();
            }

            public string GetVideoData()
            {
                return $"\nCheckout our new Video : {_latestVideo}\n";
            }
        }

        public class Subscriber : ISubscriber
        {
            private readonly string _name;
            private readonly Channel _channel;

            public Subscriber(string name, Channel channel)
            {
                _name = name;
                _channel = channel;
            }

            public void Update()
            {
                Console.WriteLine($"Hey {_name},{_channel.GetVideoData()}");
            }
        }

        public static void Run()
        {

            // Create a channel and subscribers
            Channel channel = new Channel("CodeArmy");

            Subscriber subscriber1 = new Subscriber("Varun", channel);

            Subscriber subscriber2 = new Subscriber("Tarun", channel);

            // Subscribe to the channel
            channel.Subscribe(subscriber1);
            channel.Subscribe(subscriber2);


            // Both subscribers are notified
            channel.UploadVideo("Observer Pattern Tutorial");

            // Varun unsubscribes
            channel.Unsubscribe(subscriber1);

            // Only Tarun is notified
            channel.UploadVideo("Decorator Patterns Tutorial");

            Console.ReadLine();
        }
    }
}
