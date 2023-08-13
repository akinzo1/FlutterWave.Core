using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayment
{
    public class ExcessiveCallBillPaymentException : Xeption
    {
        public ExcessiveCallBillPaymentException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallBillPaymentException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}