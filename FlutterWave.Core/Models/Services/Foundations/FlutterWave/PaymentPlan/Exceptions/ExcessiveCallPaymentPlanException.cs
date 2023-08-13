using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan
{
    public class ExcessiveCallPaymentPlanException : Xeption
    {
        public ExcessiveCallPaymentPlanException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallPaymentPlanException(string message, Exception innerException)
     : base(message: message, innerException)
        { }
    }
}