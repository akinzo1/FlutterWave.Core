using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack
{
    public class NotFoundChargeBackException : Xeption
    {
        public NotFoundChargeBackException(Exception innerException)
            : base(message: "Not found ChargeBack error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundChargeBackException(string message, Exception innerException)
     : base(message: message,
           innerException)
        { }
    }
}