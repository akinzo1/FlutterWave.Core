using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts
{
    public class ExcessiveCallPayoutSubaccountsException : Xeption
    {
        public ExcessiveCallPayoutSubaccountsException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallPayoutSubaccountsException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}