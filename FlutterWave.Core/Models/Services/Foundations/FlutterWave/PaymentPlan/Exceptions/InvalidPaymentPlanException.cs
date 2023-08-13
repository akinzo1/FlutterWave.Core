using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan
{
    public class InvalidPaymentPlanException : Xeption
    {
        public InvalidPaymentPlanException()
            : base(message: "Invalid PaymentPlan error occurred, fix errors and try again.")
        { }

        public InvalidPaymentPlanException(Exception innerException)
            : base(message: "Invalid PaymentPlan error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidPaymentPlanException(string message, Exception innerException)
     : base(message: message, innerException)
        { }
    }
}