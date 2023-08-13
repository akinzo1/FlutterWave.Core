using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements
{
    public class SettlementsDependencyValidationException : Xeption
    {
        public SettlementsDependencyValidationException(Xeption innerException)
            : base(message: "Settlements dependency validation error occurred, contact support.",
                  innerException)
        { }

        public SettlementsDependencyValidationException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}