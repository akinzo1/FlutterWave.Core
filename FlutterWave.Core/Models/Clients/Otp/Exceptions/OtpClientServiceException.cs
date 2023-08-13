using Xeptions;

namespace FlutterWave.Core.Models.Clients.Otp.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Otp client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class OtpClientServiceException : Xeption
    {
        public OtpClientServiceException(Xeption innerException)
            : base(message: "Otp client service error occurred, contact support.",
                  innerException)
        { }
    }
}
