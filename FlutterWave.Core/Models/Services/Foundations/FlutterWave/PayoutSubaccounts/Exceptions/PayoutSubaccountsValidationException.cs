using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts
{
    public class PayoutSubaccountsValidationException : Xeption
    {
        public PayoutSubaccountsValidationException(Xeption innerException)
            : base(message: "PayoutSubaccounts validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public PayoutSubaccountsValidationException(string message, Exception innerException)
             : base(message: message, innerException)
        { }
    }
}