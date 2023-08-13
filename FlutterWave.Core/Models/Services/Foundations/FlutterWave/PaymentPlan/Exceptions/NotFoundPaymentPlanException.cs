using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan
{
    public class NotFoundPaymentPlanException : Xeption
    {
        public NotFoundPaymentPlanException(Exception innerException)
            : base(message: "Not found PaymentPlan error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundPaymentPlanException(string message, Exception innerException)
     : base(message: message, innerException)
        { }
    }
}