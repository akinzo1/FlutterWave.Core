using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class TransfersValidationException : Xeption
    {
        public TransfersValidationException(Xeption innerException)
            : base(message: "Transfers validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public TransfersValidationException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}