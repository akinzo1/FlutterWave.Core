using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments
{
    internal class ExternalBillPaymentsResponse
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Datum Data { get; set; }

        public class Datum
        {
            [JsonProperty("summary")]
            public List<Summary> Summary { get; set; }

            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("total_pages")]
            public int TotalPages { get; set; }

            [JsonProperty("reference")]
            public object Reference { get; set; }
        }


        public class Summary
        {
            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("sum_bills")]
            public double SumBills { get; set; }

            [JsonProperty("sum_commission")]
            public double SumCommission { get; set; }

            [JsonProperty("sum_dstv")]
            public int SumDstv { get; set; }

            [JsonProperty("sum_airtime")]
            public int SumAirtime { get; set; }

            [JsonProperty("count_dstv")]
            public int CountDstv { get; set; }

            [JsonProperty("count_airtime")]
            public int CountAirtime { get; set; }
        }


    }
}
