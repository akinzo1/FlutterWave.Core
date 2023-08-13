using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements
{
    public class SettlementsDependencyException : Xeption
    {
        public SettlementsDependencyException(Xeption innerException)
            : base(message: "Settlements dependency error occurred, contact support.",
                  innerException)
        { }

        public SettlementsDependencyException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}