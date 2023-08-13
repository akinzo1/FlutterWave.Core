using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts
{
    public class PayoutSubaccountsDependencyValidationException : Xeption
    {
        public PayoutSubaccountsDependencyValidationException(Xeption innerException)
            : base(message: "PayoutSubaccounts dependency validation error occurred, contact support.",
                  innerException)
        { }

        public PayoutSubaccountsDependencyValidationException(string message, Exception innerException)
              : base(message: message, innerException)
        { }
    }
}