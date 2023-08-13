using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements
{
    public class InvalidSettlementsException : Xeption
    {
        public InvalidSettlementsException()
            : base(message: "Invalid Settlements error occurred, fix errors and try again.")
        { }

        public InvalidSettlementsException(Exception innerException)
            : base(message: "Invalid Settlements error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidSettlementsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}