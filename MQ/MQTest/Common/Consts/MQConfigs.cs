using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Consts
{
    public static class MQConfigs
    {
        public static MessageQueueConfig OrderConfig = new MessageQueueConfig()
        { 
            ExchangeName = "OrderExchange",
            QueueName = "OrderQueue",
            RoutingKey = "OrderRouting"
        };

        public static MessageQueueConfig CustomerConfig = new MessageQueueConfig()
        {
            ExchangeName = "CustomerExchange",
            QueueName = "CustomerQueue",
            RoutingKey = "CustomerRouting"
        };

        public static MessageQueueConfig ProjectConfig = new MessageQueueConfig()
        {
            ExchangeName = "ProjectExchange",
            QueueName = "ProjectQueue",
            RoutingKey = "ProjectRouting"
        };
    }

}
