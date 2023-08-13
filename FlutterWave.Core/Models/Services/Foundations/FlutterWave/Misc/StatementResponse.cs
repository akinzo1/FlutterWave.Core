using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous
{
    public class StatementResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public StatementResult Data { get; set; }
        public class StatementResult
        {
            public StatementsPageInfo PageInfo { get; set; }
            public List<TansactionStatement> Transactions { get; set; }

        }

        public class StatementsPageInfo
        {

            public int Total { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
        }

        public class TansactionStatement
        {

            public string Type { get; set; }
            public int Amount { get; set; }
            public string Currency { get; set; }
            public int BalanceBefore { get; set; }
            public int BalanceAfter { get; set; }
            public string Reference { get; set; }
            public DateTime Date { get; set; }
            public string Remarks { get; set; }
            public string SentCurrency { get; set; }
            public int RateUsed { get; set; }
            public int SentAmount { get; set; }
            public string StatementType { get; set; }
        }
    }
}
