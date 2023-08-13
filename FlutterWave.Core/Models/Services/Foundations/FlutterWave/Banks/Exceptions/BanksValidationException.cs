using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks
{
    public class BanksValidationException : Xeption
    {
        public BanksValidationException(Xeption innerException)
            : base(message: "Banks validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public BanksValidationException(string message, Exception innerException)
          : base(message: message,
                innerException)
        { }
    }
}