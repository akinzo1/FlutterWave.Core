using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack
{
    public class ChargeBackServiceException : Xeption
    {
        public ChargeBackServiceException(Xeption innerException)
            : base(message: "ChargeBack service error occurred, contact support.",
                  innerException)
        { }

        public ChargeBackServiceException(string message, Exception innerException)
        : base(message: message,
              innerException)
        { }
    }
}