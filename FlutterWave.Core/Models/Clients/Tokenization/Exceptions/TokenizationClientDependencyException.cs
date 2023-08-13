using Xeptions;

namespace FlutterWave.Core.Models.Clients.TokenizedCharge.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the tokenizedCharge client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class TokenizedChargeClientDependencyException : Xeption
    {
        public TokenizedChargeClientDependencyException(Xeption innerException)
            : base(message: "TokenizedCharge dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
