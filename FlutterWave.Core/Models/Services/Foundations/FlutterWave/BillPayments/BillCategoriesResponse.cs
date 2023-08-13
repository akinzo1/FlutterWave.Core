using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments
{
    public class BillCategoriesResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<Datum> Data { get; set; }

        public class Datum
        {
            public int Id { get; set; }
            public string BillerCode { get; set; }
            public string Name { get; set; }
            public double DefaultCommission { get; set; }
            public DateTime DateAdded { get; set; }
            public string Country { get; set; }
            public bool IsAirtime { get; set; }
            public string BillerName { get; set; }
            public string ItemCode { get; set; }
            public string ShortName { get; set; }
            public int Fee { get; set; }
            public bool CommissionOnFee { get; set; }
            public string LabelName { get; set; }
            public int Amount { get; set; }
        }





    }
}
