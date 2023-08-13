using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc
{
    public class MiscellaneousDependencyException : Xeption
    {
        public MiscellaneousDependencyException(Xeption innerException)
            : base(message: "Misc dependency error occurred, contact support.",
                  innerException)
        { }

        public MiscellaneousDependencyException(string message, Exception innerException)
          : base(message: message, innerException)
        { }
    }
}