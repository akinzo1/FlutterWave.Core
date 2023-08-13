using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts
{
    public partial class NullPayoutSubaccountsException : Xeption
    {
        public NullPayoutSubaccountsException()
            : base(message: "PayoutSubaccounts is null.")
        { }

        public NullPayoutSubaccountsException(string message, Exception innerException)
             : base(message: message, innerException)
        { }
    }
}
