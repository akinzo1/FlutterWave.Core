using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements
{
    public class NotFoundSettlementsException : Xeption
    {
        public NotFoundSettlementsException(Exception innerException)
            : base(message: "Not found Settlements error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundSettlementsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}