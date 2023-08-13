using Xeptions;

namespace FlutterWave.Core.Models.Clients.Remita.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the completion client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class RemitaClientDependencyException : Xeption
    {
        public RemitaClientDependencyException(Xeption innerException)
            : base(message: "Remita dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
