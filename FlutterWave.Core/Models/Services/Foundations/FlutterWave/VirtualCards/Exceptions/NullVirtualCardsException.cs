using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards
{
    public partial class NullVirtualCardsException : Xeption
    {
        public NullVirtualCardsException()
            : base(message: "VirtualCards is null.")
        { }

        public NullVirtualCardsException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}
