using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions
{
    public partial class NullTransactionsException : Xeption
    {
        public NullTransactionsException()
            : base(message: "Transactions is null.")
        { }

        public NullTransactionsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}
