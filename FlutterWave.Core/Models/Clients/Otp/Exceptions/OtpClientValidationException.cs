using Xeptions;

namespace FlutterWave.Core.Models.Clients.Otp.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the Otp client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class OtpClientValidationException : Xeption
    {
        public OtpClientValidationException(Xeption innerException)
            : base(message: "Otp client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
