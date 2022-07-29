using Common.Models;

namespace MQTest.Producer
{
    public interface IMessageProducer
    {
        void SendMessage<T> (T message, MessageQueueConfig config);
    }
}
