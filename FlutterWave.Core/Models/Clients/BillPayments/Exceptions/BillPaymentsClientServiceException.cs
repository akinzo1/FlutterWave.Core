using Xeptions;

namespace FlutterWave.Core.Models.Clients.BillPayments.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the BillPayments client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class BillPaymentsClientServiceException : Xeption
    {
        public BillPaymentsClientServiceException(Xeption innerException)
            : base(message: "BillPayments client service error occurred, contact support.",
                  innerException)
        { }
    }
}
