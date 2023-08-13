using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts
{
    public class InvalidPayoutSubaccountsException : Xeption
    {
        public InvalidPayoutSubaccountsException()
            : base(message: "Invalid PayoutSubaccounts error occurred, fix errors and try again.")
        { }

        public InvalidPayoutSubaccountsException(Exception innerException)
            : base(message: "Invalid PayoutSubaccounts error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidPayoutSubaccountsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}