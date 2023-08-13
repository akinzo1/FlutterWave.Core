using Xeptions;

namespace FlutterWave.Core.Models.Clients.TokenizedCharge.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the tokenizedCharge client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class TokenizedChargeClientServiceException : Xeption
    {
        public TokenizedChargeClientServiceException(Xeption innerException)
            : base(message: "TokenizedCharge client service error occurred, contact support.",
                  innerException)
        { }
    }
}
