using Xeptions;

namespace FlutterWave.Core.Models.Clients.VirtualAccounts.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the VirtualAccounts client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class VirtualAccountsClientDependencyException : Xeption
    {
        public VirtualAccountsClientDependencyException(Xeption innerException)
            : base(message: "VirtualAccounts dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
