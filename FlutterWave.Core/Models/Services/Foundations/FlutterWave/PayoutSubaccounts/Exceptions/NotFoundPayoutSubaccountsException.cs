using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts
{
    public class NotFoundPayoutSubaccountsException : Xeption
    {
        public NotFoundPayoutSubaccountsException(Exception innerException)
            : base(message: "Not found PayoutSubaccounts error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundPayoutSubaccountsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}