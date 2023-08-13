using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{
    public class NotFoundVirtualAccountsException : Xeption
    {
        public NotFoundVirtualAccountsException(Exception innerException)
            : base(message: "Not found VirtualAccounts error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundVirtualAccountsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}