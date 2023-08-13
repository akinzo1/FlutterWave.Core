using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements
{
    public class SettlementsValidationException : Xeption
    {
        public SettlementsValidationException(Xeption innerException)
            : base(message: "Settlements validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public SettlementsValidationException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}