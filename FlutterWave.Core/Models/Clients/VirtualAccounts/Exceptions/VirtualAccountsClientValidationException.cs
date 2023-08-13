using Xeptions;

namespace FlutterWave.Core.Models.Clients.VirtualAccounts.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the VirtualAccounts client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class VirtualAccountsClientValidationException : Xeption
    {
        public VirtualAccountsClientValidationException(Xeption innerException)
            : base(message: "VirtualAccounts client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
