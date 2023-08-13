using Xeptions;

namespace FlutterWave.Core.Models.Clients.Preauthorization.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Preauthorization client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class PreauthorizationClientServiceException : Xeption
    {
        public PreauthorizationClientServiceException(Xeption innerException)
            : base(message: "Preauthorization client service error occurred, contact support.",
                  innerException)
        { }
    }
}
