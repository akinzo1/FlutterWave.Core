using Xeptions;

namespace FlutterWave.Core.Models.Clients.Banks.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Bank client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class BankClientServiceException : Xeption
    {
        public BankClientServiceException(Xeption innerException)
            : base(message: "Bank client service error occurred, contact support.",
                  innerException)
        { }
    }
}
