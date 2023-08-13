using Xeptions;

namespace FlutterWave.Core.Models.Clients.PaymentPlan.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the PaymentPlan client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class PaymentPlanClientServiceException : Xeption
    {
        public PaymentPlanClientServiceException(Xeption innerException)
            : base(message: "PaymentPlan client service error occurred, contact support.",
                  innerException)
        { }
    }
}
