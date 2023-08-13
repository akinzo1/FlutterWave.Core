using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class NotFoundTransactionsException : Xeption
    {
        public NotFoundTransactionsException(Exception innerException)
            : base(message: "Not found Transactions error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundTransactionsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}