using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements
{
    public class SettlementsServiceException : Xeption
    {
        public SettlementsServiceException(Xeption innerException)
            : base(message: "Settlements service error occurred, contact support.",
                  innerException)
        { }

        public SettlementsServiceException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}