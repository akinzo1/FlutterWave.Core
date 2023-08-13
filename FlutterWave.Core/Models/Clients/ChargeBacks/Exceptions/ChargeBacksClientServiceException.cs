using Xeptions;

namespace FlutterWave.Core.Models.Clients.ChargeBacks.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the ChargeBacks client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class ChargeBacksClientServiceException : Xeption
    {
        public ChargeBacksClientServiceException(Xeption innerException)
            : base(message: "ChargeBacks client service error occurred, contact support.",
                  innerException)
        { }
    }
}
