using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack
{
    public class ExcessiveCallChargeBackException : Xeption
    {
        public ExcessiveCallChargeBackException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallChargeBackException(string message, Exception innerException)
        : base(message: message,
              innerException)
        { }
    }
}