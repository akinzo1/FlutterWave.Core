using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan
{
    public class FailedServerPaymentPlanException : Xeption
    {
        public FailedServerPaymentPlanException(Exception innerException)
            : base(message: "Failed PaymentPlan server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerPaymentPlanException(string message, Exception innerException)
     : base(message: message, innerException)
        { }
    }
}