using Xeptions;

namespace FlutterWave.Core.Models.Clients.Charge.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the charge client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class ChargeClientDependencyException : Xeption
    {
        public ChargeClientDependencyException(Xeption innerException)
            : base(message: "Charge dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
