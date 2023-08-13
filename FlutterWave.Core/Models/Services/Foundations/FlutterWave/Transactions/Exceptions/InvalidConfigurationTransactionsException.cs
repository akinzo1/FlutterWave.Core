using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class InvalidConfigurationTransactionsException : Xeption
    {
        public InvalidConfigurationTransactionsException(Exception innerException)
            : base(message: "Invalid Transactions configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationTransactionsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}