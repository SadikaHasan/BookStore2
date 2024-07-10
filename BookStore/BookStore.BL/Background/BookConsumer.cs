using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Transform;
using BookStore.BL.Serialization;
using BookStore.DL.InMemoryDb;
using BookStore.Models.Models;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;

namespace BookStore.BL.Background
{
    public class BookConsumer :BackgroundService
    {
        private static IConsumer<Guid, Book> _consumer;
        private readonly string user;
        private bool _running = true;

     

        public BookConsumer(string user)
        {
            var cfg = new ConsumerConfig
            {
                BootstrapServers = "pkc-7xoy1.eu-central-1.aws.confluent.cloud:9092",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslUsername = "YWULFRPB3FUBKXZ6",
                SaslPassword = "3xYVjpimzsKS+XK5lYUYpG2kkQx7SIUTMFtMUdqwBJuocQWa4BzyCBbEOJroNVBf",
                SaslMechanism = SaslMechanism.Plain,
                GroupId = $"Sadika.{Guid.NewGuid()}",
                AutoOffsetReset = AutoOffsetReset.Latest
            };

            _consumer = new ConsumerBuilder<Guid, Book>((IEnumerable<KeyValuePair<string, string>>)cfg)
                .SetKeyDeserializer(new MessagePackDeserializer<Guid>())
                .SetValueDeserializer(new MessagePackDeserializer<Book>())
                .Build();

            var topics = new List<string>()
            {
                "book"
            };
            _consumer.Subscribe(topics);
            this.user = user;
        }
      
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
           
                while (!stoppingToken.IsCancellationRequested)
                {
                    var result = _consumer.Consume();
                    if (result.Message == null)
                    {
                    continue;
                    }
                    StaticData.KafkaBooks.TryAdd(result.Message.Key, result.Message.Value);
                    
                }
                return Task.CompletedTask;

        }
    }
}
