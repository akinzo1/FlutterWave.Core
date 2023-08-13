using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class InvalidTransactionsException : Xeption
    {
        public InvalidTransactionsException()
            : base(message: "Invalid Transactions error occurred, fix errors and try again.")
        { }

        public InvalidTransactionsException(Exception innerException)
            : base(message: "Invalid Transactions error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidTransactionsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}