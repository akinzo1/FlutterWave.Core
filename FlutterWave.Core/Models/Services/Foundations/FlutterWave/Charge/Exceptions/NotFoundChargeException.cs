using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public class NotFoundChargeException : Xeption
    {
        public NotFoundChargeException(Exception innerException)
            : base(message: "Not found Charge error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundChargeException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}