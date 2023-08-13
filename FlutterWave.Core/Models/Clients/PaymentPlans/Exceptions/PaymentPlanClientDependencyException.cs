using Xeptions;

namespace FlutterWave.Core.Models.Clients.PaymentPlan.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the completion client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class PaymentPlanClientDependencyException : Xeption
    {
        public PaymentPlanClientDependencyException(Xeption innerException)
            : base(message: "Completion dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
