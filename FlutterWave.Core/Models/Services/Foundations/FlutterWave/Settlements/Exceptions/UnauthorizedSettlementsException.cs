using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements
{
    public class UnauthorizedSettlementsException : Xeption
    {
        public UnauthorizedSettlementsException(Exception innerException)
            : base(message: "Unauthorized Settlements request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedSettlementsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}