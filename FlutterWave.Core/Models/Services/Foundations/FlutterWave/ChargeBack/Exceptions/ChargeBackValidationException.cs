using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack
{
    public class ChargeBackValidationException : Xeption
    {
        public ChargeBackValidationException(Xeption innerException)
            : base(message: "ChargeBack validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public ChargeBackValidationException(string message, Exception innerException)
        : base(message: message,
              innerException)
        { }
    }
}