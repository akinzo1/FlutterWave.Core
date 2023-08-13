using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{
    public class FailedServerVirtualAccountsException : Xeption
    {
        public FailedServerVirtualAccountsException(Exception innerException)
            : base(message: "Failed VirtualAccounts server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerVirtualAccountsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }


    }
}