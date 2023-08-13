using Xeptions;

namespace FlutterWave.Core.Models.Clients.Charge.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the charge client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class ChargeClientValidationException : Xeption
    {
        public ChargeClientValidationException(Xeption innerException)
            : base(message: "Charge client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
