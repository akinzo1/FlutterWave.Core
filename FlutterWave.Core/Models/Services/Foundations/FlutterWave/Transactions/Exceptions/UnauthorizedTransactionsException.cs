using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class UnauthorizedTransactionsException : Xeption
    {
        public UnauthorizedTransactionsException(Exception innerException)
            : base(message: "Unauthorized Transactions request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedTransactionsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}