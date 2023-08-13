using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers
{
    public class TransfersDependencyException : Xeption
    {
        public TransfersDependencyException(Xeption innerException)
            : base(message: "Transfers dependency error occurred, contact support.",
                  innerException)
        { }

        public TransfersDependencyException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}