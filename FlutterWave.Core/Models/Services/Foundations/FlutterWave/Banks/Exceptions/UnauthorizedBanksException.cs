using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks
{
    public class UnauthorizedBanksException : Xeption
    {
        public UnauthorizedBanksException(Exception innerException)
            : base(message: "Unauthorized Banks request, fix errors and try again.",
                  innerException)
        { }
        public UnauthorizedBanksException(string message, Exception innerException)
          : base(message: message,
                innerException)
        { }
    }
}