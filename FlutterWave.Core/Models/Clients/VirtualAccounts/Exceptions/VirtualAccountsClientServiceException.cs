using Xeptions;

namespace FlutterWave.Core.Models.Clients.VirtualAccounts.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the VirtualAccounts client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class VirtualAccountsClientServiceException : Xeption
    {
        public VirtualAccountsClientServiceException(Xeption innerException)
            : base(message: "VirtualAccounts client service error occurred, contact support.",
                  innerException)
        { }
    }
}
