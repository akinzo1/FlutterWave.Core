using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization
{
    public class ExcessiveCallPreauthorizationException : Xeption
    {
        public ExcessiveCallPreauthorizationException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallPreauthorizationException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}