using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class FailedServerTransactionsException : Xeption
    {
        public FailedServerTransactionsException(Exception innerException)
            : base(message: "Failed Transaction server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerTransactionsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}