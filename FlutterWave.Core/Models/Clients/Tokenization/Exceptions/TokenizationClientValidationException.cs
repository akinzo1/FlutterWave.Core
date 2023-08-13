using Xeptions;

namespace FlutterWave.Core.Models.Clients.TokenizedCharge.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the TokenizedCharge client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class TokenizedChargeClientValidationException : Xeption
    {
        public TokenizedChargeClientValidationException(Xeption innerException)
            : base(message: "TokenizedCharge client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
