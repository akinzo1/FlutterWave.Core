using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class TransactionsDependencyValidationException : Xeption
    {
        public TransactionsDependencyValidationException(Xeption innerException)
            : base(message: "Transactions dependency validation error occurred, contact support.",
                  innerException)
        { }

        public TransactionsDependencyValidationException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}