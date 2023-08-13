using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements
{
    public class FailedServerSettlementsException : Xeption
    {
        public FailedServerSettlementsException(Exception innerException)
            : base(message: "Failed Settlement server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerSettlementsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}