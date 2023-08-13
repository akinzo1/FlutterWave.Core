using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks
{
    public class NotFoundBanksException : Xeption
    {
        public NotFoundBanksException(Exception innerException)
            : base(message: "Not found Banks error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundBanksException(string message, Exception innerException)
          : base(message: message,
                innerException)
        { }
    }
}