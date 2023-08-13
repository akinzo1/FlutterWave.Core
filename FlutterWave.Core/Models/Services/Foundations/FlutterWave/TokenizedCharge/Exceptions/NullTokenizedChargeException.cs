using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge
{
    public partial class NullTokenizedChargeException : Xeption
    {
        public NullTokenizedChargeException()
            : base(message: "TokenizedCharge is null.")
        { }

        public NullTokenizedChargeException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}
