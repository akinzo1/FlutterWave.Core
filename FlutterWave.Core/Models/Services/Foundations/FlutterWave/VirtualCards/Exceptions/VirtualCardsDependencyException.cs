using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards
{
    public class VirtualCardsDependencyException : Xeption
    {
        public VirtualCardsDependencyException(Xeption innerException)
            : base(message: "VirtualCards dependency error occurred, contact support.",
                  innerException)
        { }

        public VirtualCardsDependencyException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}