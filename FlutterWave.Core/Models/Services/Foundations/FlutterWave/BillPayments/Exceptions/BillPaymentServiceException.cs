using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayment
{
    public class BillPaymentServiceException : Xeption
    {
        public BillPaymentServiceException(Xeption innerException)
            : base(message: "BillPayment service error occurred, contact support.",
                  innerException)
        { }

        public BillPaymentServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}