using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan
{
    public class PaymentPlanServiceException : Xeption
    {
        public PaymentPlanServiceException(Xeption innerException)
            : base(message: "PaymentPlan service error occurred, contact support.",
                  innerException)
        { }

        public PaymentPlanServiceException(string message, Exception innerException)
     : base(message: message, innerException)
        { }
    }
}