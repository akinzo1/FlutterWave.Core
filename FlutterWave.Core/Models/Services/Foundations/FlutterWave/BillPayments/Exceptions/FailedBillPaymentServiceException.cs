using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayment
{
    public class FailedBillPaymentServiceException : Xeption
    {
        public FailedBillPaymentServiceException(Exception innerException)
            : base(message: "Failed BillPayment service error occurred, contact support.",
                  innerException)
        { }

        public FailedBillPaymentServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}