using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class TransfersServiceException : Xeption
    {
        public TransfersServiceException(Xeption innerException)
            : base(message: "Transfers service error occurred, contact support.",
                  innerException)
        { }

        public TransfersServiceException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}