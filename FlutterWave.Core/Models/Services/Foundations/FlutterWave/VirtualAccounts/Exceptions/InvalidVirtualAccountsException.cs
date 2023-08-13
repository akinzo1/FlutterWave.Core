using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{
    public class InvalidVirtualAccountsException : Xeption
    {
        public InvalidVirtualAccountsException()
            : base(message: "Invalid VirtualAccounts error occurred, fix errors and try again.")
        { }

        public InvalidVirtualAccountsException(Exception innerException)
            : base(message: "Invalid VirtualAccounts error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidVirtualAccountsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}