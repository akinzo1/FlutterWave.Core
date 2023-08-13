using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements
{
    public class ExcessiveCallSettlementsException : Xeption
    {
        public ExcessiveCallSettlementsException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallSettlementsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}