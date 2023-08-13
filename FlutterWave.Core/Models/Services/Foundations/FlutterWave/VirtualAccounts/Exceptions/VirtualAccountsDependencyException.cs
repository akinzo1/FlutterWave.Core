using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{
    public class VirtualAccountsDependencyException : Xeption
    {
        public VirtualAccountsDependencyException(Xeption innerException)
            : base(message: "VirtualAccounts dependency error occurred, contact support.",
                  innerException)
        { }

        public VirtualAccountsDependencyException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}