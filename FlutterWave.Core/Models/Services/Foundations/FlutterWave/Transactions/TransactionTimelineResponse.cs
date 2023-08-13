using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class TransactionTimelineResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<Datum> Data { get; set; }

        public class Datum
        {
            public string Note { get; set; }
            public string Actor { get; set; }
            public string Object { get; set; }
            public string Action { get; set; }
            public string Context { get; set; }
            public DateTime CreatedAt { get; set; }
        }






    }
}
