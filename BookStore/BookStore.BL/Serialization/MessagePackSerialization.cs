using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using MessagePack;

namespace BookStore.BL.Serialization
{
    public class MessagePackDeserializer<T> : IDeserializer<T>
    {
        public T Deserialize(
            ReadOnlySpan<byte> data,
            bool isNull,
            SerializationContext context)
        {
            return
                MessagePackSerializer
                    .Deserialize<T>(data.ToArray());
        }
    }
}
