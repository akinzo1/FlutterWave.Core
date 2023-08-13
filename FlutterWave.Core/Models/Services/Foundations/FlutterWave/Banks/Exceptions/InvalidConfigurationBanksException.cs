using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks
{
    public class InvalidConfigurationBanksException : Xeption
    {
        public InvalidConfigurationBanksException(Exception innerException)
            : base(message: "Invalid Banks configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationBanksException(string message, Exception innerException)
          : base(message: message,
                innerException)
        { }
    }
}