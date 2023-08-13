using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan
{
    public class InvalidConfigurationPaymentPlanException : Xeption
    {
        public InvalidConfigurationPaymentPlanException(Exception innerException)
            : base(message: "Invalid PaymentPlan configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationPaymentPlanException(string message, Exception innerException)
     : base(message: message, innerException)
        { }
    }
}