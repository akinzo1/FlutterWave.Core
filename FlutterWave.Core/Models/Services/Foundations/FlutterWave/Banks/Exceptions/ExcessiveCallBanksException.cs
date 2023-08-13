using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks
{
    public class ExcessiveCallBanksException : Xeption
    {
        public ExcessiveCallBanksException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallBanksException(string message, Exception innerException)
          : base(message: message,
                innerException)
        { }
    }
}