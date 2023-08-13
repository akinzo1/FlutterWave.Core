using Xeptions;

namespace FlutterWave.Core.Models.Clients.Preauthorization.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Preauthorization client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class PreauthorizationClientDependencyException : Xeption
    {
        public PreauthorizationClientDependencyException(Xeption innerException)
            : base(message: "Preauthorization dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
