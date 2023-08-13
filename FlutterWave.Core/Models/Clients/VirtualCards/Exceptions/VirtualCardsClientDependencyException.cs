using Xeptions;

namespace FlutterWave.Core.Models.Clients.VirtualCards.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the VirtualCards client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class VirtualCardsClientDependencyException : Xeption
    {
        public VirtualCardsClientDependencyException(Xeption innerException)
            : base(message: "VirtualCards dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
