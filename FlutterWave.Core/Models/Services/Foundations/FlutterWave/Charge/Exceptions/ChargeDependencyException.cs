using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public class ChargeDependencyException : Xeption
    {
        public ChargeDependencyException(Xeption innerException)
            : base(message: "Charge dependency error occurred, contact support.",
                  innerException)
        { }

        public ChargeDependencyException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}