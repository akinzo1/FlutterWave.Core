using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{
    public class UnauthorizedVirtualAccountsException : Xeption
    {
        public UnauthorizedVirtualAccountsException(Exception innerException)
            : base(message: "Unauthorized VirtualAccounts request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedVirtualAccountsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}