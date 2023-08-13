using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class FailedServerTransfersException : Xeption
    {
        public FailedServerTransfersException(Exception innerException)
            : base(message: "Failed Transfers server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerTransfersException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}