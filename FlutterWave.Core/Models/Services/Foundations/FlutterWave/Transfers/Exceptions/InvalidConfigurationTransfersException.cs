using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class InvalidConfigurationTransfersException : Xeption
    {
        public InvalidConfigurationTransfersException(Exception innerException)
            : base(message: "Invalid Transfers configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationTransfersException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}