using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc
{
    public class NotFoundMiscException : Xeption
    {
        public NotFoundMiscException(Exception innerException)
            : base(message: "Not found Misc error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundMiscException(string message, Exception innerException)
          : base(message: message, innerException)
        { }
    }
}