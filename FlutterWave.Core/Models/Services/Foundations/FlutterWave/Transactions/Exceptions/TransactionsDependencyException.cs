using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public class TransactionsDependencyException : Xeption
    {
        public TransactionsDependencyException(Xeption innerException)
            : base(message: "Transactions dependency error occurred, contact support.",
                  innerException)
        { }

        public TransactionsDependencyException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}