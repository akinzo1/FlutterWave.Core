using Xeptions;

namespace FlutterWave.Core.Models.Clients.CollectionSubaccounts.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the CollectionSubaccounts client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class CollectionSubaccountsClientDependencyException : Xeption
    {
        public CollectionSubaccountsClientDependencyException(Xeption innerException)
            : base(message: "CollectionSubaccounts dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
