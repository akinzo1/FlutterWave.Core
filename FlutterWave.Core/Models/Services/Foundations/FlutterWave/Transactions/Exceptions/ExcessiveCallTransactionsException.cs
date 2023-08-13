using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class ExcessiveCallTransactionsException : Xeption
    {
        public ExcessiveCallTransactionsException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallTransactionsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}