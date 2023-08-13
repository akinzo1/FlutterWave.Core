using Xeptions;

namespace FlutterWave.Core.Models.Clients.Subscription.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Subscription client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class SubscriptionClientServiceException : Xeption
    {
        public SubscriptionClientServiceException(Xeption innerException)
            : base(message: "Subscription client service error occurred, contact support.",
                  innerException)
        { }
    }
}
