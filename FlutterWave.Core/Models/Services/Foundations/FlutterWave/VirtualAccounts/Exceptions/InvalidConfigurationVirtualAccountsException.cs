using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{
    public class InvalidConfigurationVirtualAccountsException : Xeption
    {
        public InvalidConfigurationVirtualAccountsException(Exception innerException)
            : base(message: "Invalid VirtualAccounts configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationVirtualAccountsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}