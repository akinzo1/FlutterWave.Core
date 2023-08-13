using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class TransactionsValidationException : Xeption
    {
        public TransactionsValidationException(Xeption innerException)
            : base(message: "Transactions validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public TransactionsValidationException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}