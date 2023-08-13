using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks
{
    public partial class NullBanksException : Xeption
    {
        public NullBanksException()
            : base(message: "Banks is null.")
        { }

        public NullBanksException(string message, Exception innerException)
          : base(message: message,
                innerException)
        { }
    }
}
