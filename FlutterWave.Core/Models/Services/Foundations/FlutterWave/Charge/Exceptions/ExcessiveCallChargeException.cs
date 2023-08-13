using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public class ExcessiveCallChargeException : Xeption
    {
        public ExcessiveCallChargeException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallChargeException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}