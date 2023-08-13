using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{
    public class ExcessiveCallVirtualAccountsException : Xeption
    {
        public ExcessiveCallVirtualAccountsException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallVirtualAccountsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}