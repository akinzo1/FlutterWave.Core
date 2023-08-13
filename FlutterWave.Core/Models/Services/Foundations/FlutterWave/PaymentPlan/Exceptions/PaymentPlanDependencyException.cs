using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan
{
    public class PaymentPlanDependencyException : Xeption
    {
        public PaymentPlanDependencyException(Xeption innerException)
            : base(message: "PaymentPlan dependency error occurred, contact support.",
                  innerException)
        { }

        public PaymentPlanDependencyException(string message, Exception innerException)
     : base(message: message, innerException)
        { }
    }
}