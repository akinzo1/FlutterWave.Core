using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{
    public class VirtualAccountsValidationException : Xeption
    {
        public VirtualAccountsValidationException(Xeption innerException)
            : base(message: "VirtualAccounts validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public VirtualAccountsValidationException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}