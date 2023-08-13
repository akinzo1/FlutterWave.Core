using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class InvalidTransfersException : Xeption
    {
        public InvalidTransfersException()
            : base(message: "Invalid Transfers error occurred, fix errors and try again.")
        { }

        public InvalidTransfersException(Exception innerException)
            : base(message: "Invalid Transfers error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidTransfersException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}