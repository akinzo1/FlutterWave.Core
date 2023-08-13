using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge
{
    public class UnauthorizedTokenizedChargeException : Xeption
    {
        public UnauthorizedTokenizedChargeException(Exception innerException)
            : base(message: "Unauthorized TokenizedCharge request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedTokenizedChargeException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}