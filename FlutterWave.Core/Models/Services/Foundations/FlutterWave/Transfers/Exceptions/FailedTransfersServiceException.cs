using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class FailedTransfersServiceException : Xeption
    {
        public FailedTransfersServiceException(Exception innerException)
            : base(message: "Failed Transfers service error occurred, contact support.",
                  innerException)
        { }

        public FailedTransfersServiceException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}