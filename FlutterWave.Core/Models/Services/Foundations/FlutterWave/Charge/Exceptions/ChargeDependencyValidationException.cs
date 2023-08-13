using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public class ChargeDependencyValidationException : Xeption
    {
        public ChargeDependencyValidationException(Xeption innerException)
            : base(message: "Charge dependency validation error occurred, contact support.",
                  innerException)
        { }
        public ChargeDependencyValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}