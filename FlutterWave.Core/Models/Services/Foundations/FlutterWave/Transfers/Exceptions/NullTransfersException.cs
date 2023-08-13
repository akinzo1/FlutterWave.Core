using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public partial class NullTransfersException : Xeption
    {
        public NullTransfersException()
            : base(message: "Transfers is null.")
        { }

        public NullTransfersException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}
