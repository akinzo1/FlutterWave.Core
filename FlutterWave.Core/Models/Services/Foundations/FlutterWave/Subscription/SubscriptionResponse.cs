using System;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions
{
    public class SubscriptionResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public SubscriptionData Data { get; set; }

        public class Customer
        {
            public int Id { get; set; }
            public string CustomerEmail { get; set; }
        }

        public class SubscriptionData
        {
            public int Id { get; set; }
            public int Amount { get; set; }
            public Customer Customer { get; set; }
            public int Plan { get; set; }
            public string Status { get; set; }
            public DateTime CreatedAt { get; set; }
        }

    }
}
