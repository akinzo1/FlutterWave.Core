using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc
{
    public class UnauthorizedMiscException : Xeption
    {
        public UnauthorizedMiscException(Exception innerException)
            : base(message: "Unauthorized Misc request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedMiscException(string message, Exception innerException)
          : base(message: message, innerException)
        { }
    }
}