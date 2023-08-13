using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayment
{
    public class BillPaymentDependencyException : Xeption
    {
        public BillPaymentDependencyException(Xeption innerException)
            : base(message: "BillPayment dependency error occurred, contact support.",
                  innerException)
        { }

        public BillPaymentDependencyException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}