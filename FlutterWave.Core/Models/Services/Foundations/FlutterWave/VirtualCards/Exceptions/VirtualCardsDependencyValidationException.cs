using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards
{
    public class VirtualCardsDependencyValidationException : Xeption
    {
        public VirtualCardsDependencyValidationException(Xeption innerException)
            : base(message: "VirtualCards dependency validation error occurred, contact support.",
                  innerException)
        { }

        public VirtualCardsDependencyValidationException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}