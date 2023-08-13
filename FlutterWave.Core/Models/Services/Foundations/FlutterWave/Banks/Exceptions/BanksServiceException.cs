using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks
{
    public class BanksServiceException : Xeption
    {
        public BanksServiceException(Xeption innerException)
            : base(message: "Banks service error occurred, contact support.",
                  innerException)
        { }

        public BanksServiceException(string message, Exception innerException)
          : base(message: message,
                innerException)
        { }
    }
}