using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc
{
    public class MiscellaneousServiceException : Xeption
    {
        public MiscellaneousServiceException(Xeption innerException)
            : base(message: "Misc service error occurred, contact support.",
                  innerException)
        { }

        public MiscellaneousServiceException(string message, Exception innerException)
          : base(message: message, innerException)
        { }
    }
}