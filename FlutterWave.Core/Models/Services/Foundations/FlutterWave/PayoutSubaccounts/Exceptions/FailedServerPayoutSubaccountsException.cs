using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts
{
    public class FailedServerPayoutSubaccountsException : Xeption
    {
        public FailedServerPayoutSubaccountsException(Exception innerException)
            : base(message: "Failed PayoutSubaccounts server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerPayoutSubaccountsException(string message, Exception innerException)
             : base(message: message, innerException)
        { }
    }
}