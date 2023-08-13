using Xeptions;

namespace FlutterWave.Core.Models.Clients.Subscription.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the Subscription client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class SubscriptionClientValidationException : Xeption
    {
        public SubscriptionClientValidationException(Xeption innerException)
            : base(message: "Subscription client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
