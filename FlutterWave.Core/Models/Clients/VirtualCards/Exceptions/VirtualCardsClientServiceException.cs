using Xeptions;

namespace FlutterWave.Core.Models.Clients.VirtualCards.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the VirtualCards client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class VirtualCardsClientServiceException : Xeption
    {
        public VirtualCardsClientServiceException(Xeption innerException)
            : base(message: "VirtualCards client service error occurred, contact support.",
                  innerException)
        { }
    }
}
