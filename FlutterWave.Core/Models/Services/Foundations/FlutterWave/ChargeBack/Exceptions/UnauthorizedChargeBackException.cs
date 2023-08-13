using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack
{
    public class UnauthorizedChargeBackException : Xeption
    {
        public UnauthorizedChargeBackException(Exception innerException)
            : base(message: "Unauthorized ChargeBack request, fix errors and try again.",
                  innerException)
        { }

     public UnauthorizedChargeBackException(string message, Exception innerException)
            : base(message: message, innerException)
       { }
    }
}