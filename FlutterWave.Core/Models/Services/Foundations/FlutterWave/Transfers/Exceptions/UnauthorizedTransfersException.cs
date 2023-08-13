using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class UnauthorizedTransfersException : Xeption
    {
        public UnauthorizedTransfersException(Exception innerException)
            : base(message: "Unauthorized Transfers request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedTransfersException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}