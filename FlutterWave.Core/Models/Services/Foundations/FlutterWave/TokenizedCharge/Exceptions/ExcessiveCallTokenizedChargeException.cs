using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge
{
    public class ExcessiveCallTokenizedChargeException : Xeption
    {
        public ExcessiveCallTokenizedChargeException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallTokenizedChargeException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}