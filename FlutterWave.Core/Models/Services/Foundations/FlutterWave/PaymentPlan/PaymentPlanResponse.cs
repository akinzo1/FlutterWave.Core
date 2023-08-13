using System;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan
{
    public class PaymentPlanResponse
    {

        public string Status { get; set; }
        public string Message { get; set; }
        public Datum Data { get; set; }

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









    }
}
