using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack
{
    public class ChargeBackDependencyException : Xeption
    {
        public ChargeBackDependencyException(Xeption innerException)
            : base(message: "ChargeBack dependency error occurred, contact support.",
                  innerException)
        { }

        public ChargeBackDependencyException(string message, Exception innerException)
        : base(message: message,
              innerException)
        { }
    }
}