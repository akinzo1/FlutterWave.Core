using Xeptions;

namespace FlutterWave.Core.Models.Clients.Preauthorization.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the Preauthorization client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class PreauthorizationClientValidationException : Xeption
    {
        public PreauthorizationClientValidationException(Xeption innerException)
            : base(message: "Preauthorization client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
