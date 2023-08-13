using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayment
{
    public partial class NullBillPaymentException : Xeption
    {
        public NullBillPaymentException()
            : base(message: "BillPayment is null.")
        { }

        public NullBillPaymentException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}
