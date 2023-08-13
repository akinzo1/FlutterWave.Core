using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc
{
    public class InvalidMiscellaneousException : Xeption
    {
        public InvalidMiscellaneousException()
            : base(message: "Invalid Misc error occurred, fix errors and try again.")
        { }

        public InvalidMiscellaneousException(Exception innerException)
            : base(message: "Invalid Misc error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidMiscellaneousException(string message, Exception innerException)
        : base(message: message, innerException)
        { }
    }
}