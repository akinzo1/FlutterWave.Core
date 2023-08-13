using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks
{
    public class InvalidBanksException : Xeption
    {
        public InvalidBanksException()
            : base(message: "Invalid Banks error occurred, fix errors and try again.")
        { }

        public InvalidBanksException(Exception innerException)
            : base(message: "Invalid Banks error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidBanksException(string message, Exception innerException)
          : base(message: message,
                innerException)
        { }
    }
}