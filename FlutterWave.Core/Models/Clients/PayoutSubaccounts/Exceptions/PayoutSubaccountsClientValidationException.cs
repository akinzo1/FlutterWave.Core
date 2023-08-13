using Xeptions;

namespace FlutterWave.Core.Models.Clients.PayoutSubaccounts.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the PayoutSubaccounts client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class PayoutSubaccountsClientValidationException : Xeption
    {
        public PayoutSubaccountsClientValidationException(Xeption innerException)
            : base(message: "PayoutSubaccounts client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
