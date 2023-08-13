using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{
    public class VirtualAccountsServiceException : Xeption
    {
        public VirtualAccountsServiceException(Xeption innerException)
            : base(message: "VirtualAccounts service error occurred, contact support.",
                  innerException)
        { }

        public VirtualAccountsServiceException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}