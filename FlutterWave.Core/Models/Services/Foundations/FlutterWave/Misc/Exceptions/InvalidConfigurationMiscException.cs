using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc
{
    public class InvalidConfigurationMiscException : Xeption
    {
        public InvalidConfigurationMiscException(Exception innerException)
            : base(message: "Invalid Misc configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationMiscException(string message, Exception innerException)
          : base(message: message, innerException)
        { }
    }
}