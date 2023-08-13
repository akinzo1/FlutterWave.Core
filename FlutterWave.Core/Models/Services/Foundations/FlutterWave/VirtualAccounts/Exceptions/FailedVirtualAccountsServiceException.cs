using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{
    public class FailedVirtualAccountsServiceException : Xeption
    {
        public FailedVirtualAccountsServiceException(Exception innerException)
            : base(message: "Failed VirtualAccounts service error occurred, contact support.",
                  innerException)
        { }

        public FailedVirtualAccountsServiceException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}