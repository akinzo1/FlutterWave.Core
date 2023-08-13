using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks
{
    public class BanksDependencyException : Xeption
    {
        public BanksDependencyException(Xeption innerException)
            : base(message: "Banks dependency error occurred, contact support.",
                  innerException)
        { }

        public BanksDependencyException(string message,Exception innerException)
           : base(message: message,
                 innerException)
        { }
    }
}