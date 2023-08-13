using Xeptions;

namespace FlutterWave.Core.Models.Clients.CollectionSubaccounts.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the CollectionSubaccounts client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class CollectionSubaccountsClientServiceException : Xeption
    {
        public CollectionSubaccountsClientServiceException(Xeption innerException)
            : base(message: "CollectionSubaccounts client service error occurred, contact support.",
                  innerException)
        { }
    }
}
