using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack
{
    public class ChargeBackDependencyValidationException : Xeption
    {
        public ChargeBackDependencyValidationException(Xeption innerException)
            : base(message: "ChargeBack dependency validation error occurred, contact support.",
                  innerException)
        { }

        public ChargeBackDependencyValidationException(string message, Exception innerException)
        : base(message: message,
              innerException)
        { }
    }
}