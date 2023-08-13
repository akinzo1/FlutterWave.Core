using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts
{
    public class FailedPayoutSubaccountsServiceException : Xeption
    {
        public FailedPayoutSubaccountsServiceException(Exception innerException)
            : base(message: "Failed PayoutSubaccounts service error occurred, contact support.",
                  innerException)
        { }

        public FailedPayoutSubaccountsServiceException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}