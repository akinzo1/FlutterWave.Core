using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayment
{
    public class InvalidConfigurationBillPaymentException : Xeption
    {
        public InvalidConfigurationBillPaymentException(Exception innerException)
            : base(message: "Invalid BillPayment configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationBillPaymentException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}