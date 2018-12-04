using System;
using StackExchange.Redis;
namespace Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("trezenetredis.redis.cache.windows.net:6380,password=ftXkXFGfHf9Pf4sIJ8LVIgSQTAmU7I38nnRf96qmipE=,ssl=True,abortConnect=False");
            var db = redis.GetDatabase();

            Console.WriteLine("qual seu nome?");
            var nome = Console.ReadLine();

            var pubsub = redis.GetSubscriber();
            pubsub.Subscribe("13net", (channel, message) => Console.WriteLine(message.ToString()));
            db.Publish("13net", $"{nome} entrou na sala");

            while (1 != 2)
            {
                var msg = Console.ReadLine();
                db.Publish("13net", msg);
            }
        }
    }
}
