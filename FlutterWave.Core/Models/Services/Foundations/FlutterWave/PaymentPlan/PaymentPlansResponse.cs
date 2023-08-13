using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan
{
    public class PaymentPlansResponse
    {

        public string Status { get; set; }
        public string Message { get; set; }
        public PaymentPlansMeta Meta { get; set; }
        public List<Datum> Data { get; set; }

        public class Datum
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Amount { get; set; }
            public string Interval { get; set; }
            public int Duration { get; set; }
            public string Status { get; set; }
            public string Currency { get; set; }
            public string PlanToken { get; set; }
            public DateTime CreatedAt { get; set; }
        }


        public class PageInfo
        {
            public int Total { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
        }


        public class PaymentPlansMeta
        {
            public PageInfo PageInfo { get; set; }
        }



    }
}
