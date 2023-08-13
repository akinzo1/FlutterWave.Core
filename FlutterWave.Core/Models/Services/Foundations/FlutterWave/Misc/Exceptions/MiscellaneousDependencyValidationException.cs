using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc
{
    public class MiscellaneousDependencyValidationException : Xeption
    {
        public MiscellaneousDependencyValidationException(Xeption innerException)
            : base(message: "Misc dependency validation error occurred, contact support.",
                  innerException)
        { }

        public MiscellaneousDependencyValidationException(string message, Exception innerException)
          : base(message: message, innerException)
        { }
    }
}