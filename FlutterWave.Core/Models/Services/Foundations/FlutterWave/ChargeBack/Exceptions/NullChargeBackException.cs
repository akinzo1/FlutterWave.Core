using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack
{
    public partial class NullChargeBackException : Xeption
    {
        public NullChargeBackException()
            : base(message: "ChargeBack is null.")
        { }

        public NullChargeBackException(string message, Exception innerException)
     : base(message: message,
           innerException)
        { }
    }
}
