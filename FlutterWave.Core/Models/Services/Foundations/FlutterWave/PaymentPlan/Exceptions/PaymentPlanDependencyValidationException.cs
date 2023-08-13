using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan
{
    public class PaymentPlanDependencyValidationException : Xeption
    {
        public PaymentPlanDependencyValidationException(Xeption innerException)
            : base(message: "PaymentPlan dependency validation error occurred, contact support.",
                  innerException)
        { }

        public PaymentPlanDependencyValidationException(string message, Exception innerException)
     : base(message: message, innerException)
        { }
    }
}