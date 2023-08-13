using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{
    public class VirtualAccountsDependencyValidationException : Xeption
    {
        public VirtualAccountsDependencyValidationException(Xeption innerException)
            : base(message: "VirtualAccounts dependency validation error occurred, contact support.",
                  innerException)
        { }

        public VirtualAccountsDependencyValidationException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}