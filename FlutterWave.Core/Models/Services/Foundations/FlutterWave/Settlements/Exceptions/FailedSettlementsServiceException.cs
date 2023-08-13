using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements
{
    public class FailedSettlementsServiceException : Xeption
    {
        public FailedSettlementsServiceException(Exception innerException)
            : base(message: "Failed Settlement service error occurred, contact support.",
                  innerException)
        { }

        public FailedSettlementsServiceException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}