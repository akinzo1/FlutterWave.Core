using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization
{
    public class NotFoundPreauthorizationException : Xeption
    {
        public NotFoundPreauthorizationException(Exception innerException)
            : base(message: "Not found Preauthorization error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundPreauthorizationException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}