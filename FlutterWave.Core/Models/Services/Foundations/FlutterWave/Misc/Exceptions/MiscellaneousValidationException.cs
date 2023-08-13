using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc
{
    public class MiscellaneousValidationException : Xeption
    {
        public MiscellaneousValidationException(Xeption innerException)
            : base(message: "Misc validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public MiscellaneousValidationException(string message, Exception innerException)
          : base(message: message, innerException)
        { }
    }
}