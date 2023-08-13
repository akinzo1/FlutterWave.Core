using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public class UnauthorizedChargeException : Xeption
    {
        public UnauthorizedChargeException(Exception innerException)
            : base(message: "Unauthorized Charge request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedChargeException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}