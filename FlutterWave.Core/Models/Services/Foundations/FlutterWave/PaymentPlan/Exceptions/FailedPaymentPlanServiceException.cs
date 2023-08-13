using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan
{
    public class FailedPaymentPlanServiceException : Xeption
    {
        public FailedPaymentPlanServiceException(Exception innerException)
            : base(message: "Failed Settlement service error occurred, contact support.",
                  innerException)
        { }

       public FailedPaymentPlanServiceException(string message, Exception innerException)
            : base(message: message, innerException)
        { }
    }
}