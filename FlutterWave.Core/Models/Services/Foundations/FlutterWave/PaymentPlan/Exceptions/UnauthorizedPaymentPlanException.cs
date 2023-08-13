using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan
{
    public class UnauthorizedPaymentPlanException : Xeption
    {
        public UnauthorizedPaymentPlanException(Exception innerException)
            : base(message: "Unauthorized PaymentPlan request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedPaymentPlanException(string message, Exception innerException)
     : base(message: message, innerException)
        { }
    }
}