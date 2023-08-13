using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards
{
    public class VirtualCardsValidationException : Xeption
    {
        public VirtualCardsValidationException(Xeption innerException)
            : base(message: "VirtualCards validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public VirtualCardsValidationException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}