using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization
{
    public partial class NullPreauthorizationException : Xeption
    {
        public NullPreauthorizationException()
            : base(message: "Preauthorization is null.")
        { }

        public NullPreauthorizationException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}
