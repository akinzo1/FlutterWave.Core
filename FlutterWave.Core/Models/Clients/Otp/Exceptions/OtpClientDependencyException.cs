using Xeptions;

namespace FlutterWave.Core.Models.Clients.Otp.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Otp client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class OtpClientDependencyException : Xeption
    {
        public OtpClientDependencyException(Xeption innerException)
            : base(message: "Otp dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
