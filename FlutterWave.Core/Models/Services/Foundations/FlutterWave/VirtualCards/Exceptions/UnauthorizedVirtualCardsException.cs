using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards
{
    public class UnauthorizedVirtualCardsException : Xeption
    {
        public UnauthorizedVirtualCardsException(Exception innerException)
            : base(message: "Unauthorized VirtualCards request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedVirtualCardsException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}