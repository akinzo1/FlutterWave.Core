using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts
{
    public class PayoutSubaccountsDependencyException : Xeption
    {
        public PayoutSubaccountsDependencyException(Xeption innerException)
            : base(message: "PayoutSubaccounts dependency error occurred, contact support.",
                  innerException)
        { }

        public PayoutSubaccountsDependencyException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}