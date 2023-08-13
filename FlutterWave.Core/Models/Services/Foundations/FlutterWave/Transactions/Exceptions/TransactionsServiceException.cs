using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class TransactionsServiceException : Xeption
    {
        public TransactionsServiceException(Xeption innerException)
            : base(message: "Transactions service error occurred, contact support.",
                  innerException)
        { }

        public TransactionsServiceException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}