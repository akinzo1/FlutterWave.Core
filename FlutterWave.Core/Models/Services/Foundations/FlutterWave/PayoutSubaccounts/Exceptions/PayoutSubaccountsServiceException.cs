using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts
{
    public class PayoutSubaccountsServiceException : Xeption
    {
        public PayoutSubaccountsServiceException(Xeption innerException)
            : base(message: "PayoutSubaccounts service error occurred, contact support.",
                  innerException)
        { }

        public PayoutSubaccountsServiceException(string message, Exception innerException)
             : base(message: message, innerException)
        { }
    }
}