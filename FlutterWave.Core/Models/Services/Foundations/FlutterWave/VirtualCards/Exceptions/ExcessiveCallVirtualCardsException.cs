using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards
{
    public class ExcessiveCallVirtualCardsException : Xeption
    {
        public ExcessiveCallVirtualCardsException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallVirtualCardsException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}