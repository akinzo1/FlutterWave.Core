using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class TransfersDependencyValidationException : Xeption
    {
        public TransfersDependencyValidationException(Xeption innerException)
            : base(message: "Transfers dependency validation error occurred, contact support.",
                  innerException)
        { }

        public TransfersDependencyValidationException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}