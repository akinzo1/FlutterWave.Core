using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks
{
    public class FailedServerBanksException : Xeption
    {
        public FailedServerBanksException(Exception innerException)
            : base(message: "Failed Bank server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerBanksException(string message, Exception innerException)
          : base(message: message,
                innerException)
        { }
    }
}