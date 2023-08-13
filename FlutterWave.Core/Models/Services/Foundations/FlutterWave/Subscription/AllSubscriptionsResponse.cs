using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions
{
    public class AllSubscriptionsResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public SubscriptionsMeta Meta { get; set; }
        public List<Datum> Data { get; set; }

        public class Customer
        {
            public int Id { get; set; }
            public string CustomerEmail { get; set; }
        }

        public class Datum
        {
            public int Id { get; set; }
            public int Amount { get; set; }
            public Customer Customer { get; set; }
            public int Plan { get; set; }
            public string Status { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public class SubscriptionsMeta
        {
            public PageInfo PageInfo { get; set; }
        }

        public class PageInfo
        {
            public int Total { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
        }

    }
}
