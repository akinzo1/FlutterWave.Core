using Xeptions;

namespace FlutterWave.Core.Models.Clients.BillPayments.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the BillPayments client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class BillPaymentsClientValidationException : Xeption
    {
        public BillPaymentsClientValidationException(Xeption innerException)
            : base(message: "BillPayments client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
