using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan
{
    public partial class NullPaymentPlanException : Xeption
    {
        public NullPaymentPlanException()
            : base(message: "PaymentPlan is null.")
        { }

        public NullPaymentPlanException(string message, Exception innerException)
     : base(message: message, innerException)
        { }
    }
}
