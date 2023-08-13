using Xeptions;

namespace FlutterWave.Core.Models.Clients.BillPayments.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the BillPayments client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class BillPaymentsClientDependencyException : Xeption
    {
        public BillPaymentsClientDependencyException(Xeption innerException)
            : base(message: "BillPayments dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
