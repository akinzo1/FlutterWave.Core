using Xeptions;

namespace FlutterWave.Core.Models.Clients.Charge.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the charge client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class ChargeClientServiceException : Xeption
    {
        public ChargeClientServiceException(Xeption innerException)
            : base(message: "Charge client service error occurred, contact support.",
                  innerException)
        { }
    }
}
