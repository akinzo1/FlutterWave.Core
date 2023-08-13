using Xeptions;

namespace FlutterWave.Core.Models.Clients.PaymentPlan.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the completion client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class PaymentPlanClientValidationException : Xeption
    {
        public PaymentPlanClientValidationException(Xeption innerException)
            : base(message: "Completion client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
