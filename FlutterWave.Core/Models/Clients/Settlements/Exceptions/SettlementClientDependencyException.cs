using Xeptions;

namespace FlutterWave.Core.Models.Clients.Settlement.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Settlement client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class SettlementClientDependencyException : Xeption
    {
        public SettlementClientDependencyException(Xeption innerException)
            : base(message: "Settlement dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
