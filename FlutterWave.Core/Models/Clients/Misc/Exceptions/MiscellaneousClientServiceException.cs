using Xeptions;

namespace FlutterWave.Core.Models.Clients.Misc.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Miscellaneous client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class MiscellaneousClientServiceException : Xeption
    {
        public MiscellaneousClientServiceException(Xeption innerException)
            : base(message: "Miscellaneous client service error occurred, contact support.",
                  innerException)
        { }
    }
}
