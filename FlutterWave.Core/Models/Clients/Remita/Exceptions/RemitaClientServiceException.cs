using Xeptions;

namespace FlutterWave.Core.Models.Clients.Remita.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the completion client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class RemitaClientServiceException : Xeption
    {
        public RemitaClientServiceException(Xeption innerException)
            : base(message: "Remita client service error occurred, contact support.",
                  innerException)
        { }
    }
}
