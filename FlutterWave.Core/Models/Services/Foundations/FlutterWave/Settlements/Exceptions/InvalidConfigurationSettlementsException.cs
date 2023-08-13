using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements
{
    public class InvalidConfigurationSettlementsException : Xeption
    {
        public InvalidConfigurationSettlementsException(Exception innerException)
            : base(message: "Invalid Settlements configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationSettlementsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}