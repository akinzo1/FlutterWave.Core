using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayment
{
    public class FailedServerBillPaymentException : Xeption
    {
        public FailedServerBillPaymentException(Exception innerException)
            : base(message: "Failed BillPayment server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerBillPaymentException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}