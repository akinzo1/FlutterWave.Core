using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge
{
    public partial class NullChargeException : Xeption
    {
        public NullChargeException()
            : base(message: "Charge is null.")
        { }

        public NullChargeException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}
