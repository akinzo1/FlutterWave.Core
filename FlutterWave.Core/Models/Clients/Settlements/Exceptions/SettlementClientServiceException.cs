using Xeptions;

namespace FlutterWave.Core.Models.Clients.Settlement.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Settlement client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class SettlementClientServiceException : Xeption
    {
        public SettlementClientServiceException(Xeption innerException)
            : base(message: "Settlement client service error occurred, contact support.",
                  innerException)
        { }
    }
}
