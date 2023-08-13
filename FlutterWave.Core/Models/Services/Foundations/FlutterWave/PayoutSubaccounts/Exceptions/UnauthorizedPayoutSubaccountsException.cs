using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts
{
    public class UnauthorizedPayoutSubaccountsException : Xeption
    {
        public UnauthorizedPayoutSubaccountsException(Exception innerException)
            : base(message: "Unauthorized PayoutSubaccounts request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedPayoutSubaccountsException(string message, Exception innerException)
             : base(message: message, innerException)
        { }
    }
}