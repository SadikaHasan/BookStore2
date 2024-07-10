using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.BL.Serialization;
using BookStore.Models.Models;
using Confluent.Kafka;

namespace BookStore.BL.Background
{
    public class BookProducer: IBookProducer
    {
        private static IProducer<Guid, Book> _producer;
        
        public BookProducer()
        {
            var config = new ProducerConf()
            {
                BootstrapServers = "pkc-7xoy1.eu-central-1.aws.confluent.cloud:9092",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslUsername = "YWULFRPB3FUBKXZ6",
                SaslPassword = "3xYVjpimzsKS+XK5lYUYpG2kkQx7SIUTMFtMUdqwBJuocQWa4BzyCBbEOJroNVBf",
                SaslMechanism = SaslMechanism.Plain
            };

            _producer = new ProducerBuilder<Guid, Book>((IEnumerable<KeyValuePair<string, string>>)config)
                .SetKeySerializer(new MsgPackSerializer<Guid>())
                .SetValueSerializer(new MsgPackSerializer<Book>())
            .Build();
            
        }

        public Task Produce(Book book)
        {
            var msg = new Message<Guid, Book>()
            {
                Key = Guid.NewGuid(),
                Value = book

            };

            _producer.Produce("book", msg);

            return Task.CompletedTask;
        }

        


    }
}
