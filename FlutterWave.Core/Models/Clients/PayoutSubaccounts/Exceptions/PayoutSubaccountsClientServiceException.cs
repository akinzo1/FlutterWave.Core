using Xeptions;

namespace FlutterWave.Core.Models.Clients.PayoutSubaccounts.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the PayoutSubaccounts client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class PayoutSubaccountsClientServiceException : Xeption
    {
        public PayoutSubaccountsClientServiceException(Xeption innerException)
            : base(message: "PayoutSubaccounts client service error occurred, contact support.",
                  innerException)
        { }
    }
}
