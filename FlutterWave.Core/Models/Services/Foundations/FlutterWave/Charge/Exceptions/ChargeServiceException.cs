using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public class ChargeServiceException : Xeption
    {
        public ChargeServiceException(Xeption innerException)
            : base(message: "Charge service error occurred, contact support.",
                  innerException)
        { }

        public ChargeServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}