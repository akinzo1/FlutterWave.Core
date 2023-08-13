using Xeptions;

namespace FlutterWave.Core.Models.Clients.CollectionSubaccounts.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the CollectionSubaccounts client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class CollectionSubaccountsClientValidationException : Xeption
    {
        public CollectionSubaccountsClientValidationException(Xeption innerException)
            : base(message: "CollectionSubaccounts client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
