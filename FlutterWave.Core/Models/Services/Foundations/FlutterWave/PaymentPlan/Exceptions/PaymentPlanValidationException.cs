using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan
{
    public class PaymentPlanValidationException : Xeption
    {
        public PaymentPlanValidationException(Xeption innerException)
            : base(message: "PaymentPlan validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public PaymentPlanValidationException(string message, Exception innerException)
     : base(message: message, innerException)
        { }
    }
}