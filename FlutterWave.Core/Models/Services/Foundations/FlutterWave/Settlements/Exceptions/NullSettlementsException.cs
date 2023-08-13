using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements
{
    public partial class NullSettlementsException : Xeption
    {
        public NullSettlementsException()
            : base(message: "Settlements is null.")
        { }

        public NullSettlementsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}
