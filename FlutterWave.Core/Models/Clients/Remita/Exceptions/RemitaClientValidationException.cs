using Xeptions;

namespace FlutterWave.Core.Models.Clients.Remita.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the completion client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class RemitaClientValidationException : Xeption
    {
        public RemitaClientValidationException(Xeption innerException)
            : base(message: "Remita client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
