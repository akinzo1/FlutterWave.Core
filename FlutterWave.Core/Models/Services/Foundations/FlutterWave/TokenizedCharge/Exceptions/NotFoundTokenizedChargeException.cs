using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge
{
    public class NotFoundTokenizedChargeException : Xeption
    {
        public NotFoundTokenizedChargeException(Exception innerException)
            : base(message: "Not found TokenizedCharge error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundTokenizedChargeException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}