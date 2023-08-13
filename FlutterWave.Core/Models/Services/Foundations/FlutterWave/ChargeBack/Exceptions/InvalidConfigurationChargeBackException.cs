using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack
{
    public class InvalidConfigurationChargeBackException : Xeption
    {
        public InvalidConfigurationChargeBackException(Exception innerException)
            : base(message: "Invalid ChargeBack configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationChargeBackException(string message, Exception innerException)
        : base(message: message,
              innerException)
        { }
    }
}