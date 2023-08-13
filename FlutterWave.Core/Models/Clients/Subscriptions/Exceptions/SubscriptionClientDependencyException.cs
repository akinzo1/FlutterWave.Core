using Xeptions;

namespace FlutterWave.Core.Models.Clients.Subscription.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Subscription client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class SubscriptionClientDependencyException : Xeption
    {
        public SubscriptionClientDependencyException(Xeption innerException)
            : base(message: "Subscription dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
