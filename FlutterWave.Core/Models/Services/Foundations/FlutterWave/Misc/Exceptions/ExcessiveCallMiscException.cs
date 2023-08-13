using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc
{
    public class ExcessiveCallMiscException : Xeption
    {
        public ExcessiveCallMiscException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallMiscException(string message, Exception innerException)
          : base(message: message, innerException)
        { }
    }
}