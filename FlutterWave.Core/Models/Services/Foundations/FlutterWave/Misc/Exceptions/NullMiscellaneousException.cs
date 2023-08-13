using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc
{
    public partial class NullMiscellaneousException : Xeption
    {
        public NullMiscellaneousException()
            : base(message: "Misc is null.")
        { }

        public NullMiscellaneousException(string message, Exception innerException)
          : base(message: message, innerException)
        { }
    }
}
