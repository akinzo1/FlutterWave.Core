using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks
{
    public class BanksDependencyValidationException : Xeption
    {
        public BanksDependencyValidationException(Xeption innerException)
            : base(message: "Banks dependency validation error occurred, contact support.",
                  innerException)
        { }

        public BanksDependencyValidationException(string message, Exception innerException)
          : base(message: message,
                innerException)
        { }
    }
}