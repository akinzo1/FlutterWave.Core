using Xeptions;

namespace FlutterWave.Core.Models.Clients.PayoutSubaccounts.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the PayoutSubaccounts client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class PayoutSubaccountsClientDependencyException : Xeption
    {
        public PayoutSubaccountsClientDependencyException(Xeption innerException)
            : base(message: "PayoutSubaccounts dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
