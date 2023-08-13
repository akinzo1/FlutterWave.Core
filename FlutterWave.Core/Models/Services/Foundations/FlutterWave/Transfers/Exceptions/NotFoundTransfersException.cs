using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class NotFoundTransfersException : Xeption
    {
        public NotFoundTransfersException(Exception innerException)
            : base(message: "Not found Transfers error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundTransfersException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}