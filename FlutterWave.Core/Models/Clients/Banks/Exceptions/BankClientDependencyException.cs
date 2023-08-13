using Xeptions;

namespace FlutterWave.Core.Models.Clients.Banks.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Bank client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class BankClientDependencyException : Xeption
    {
        public BankClientDependencyException(Xeption innerException)
            : base(message: "Bank dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
