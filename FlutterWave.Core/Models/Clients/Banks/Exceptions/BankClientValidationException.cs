using Xeptions;

namespace FlutterWave.Core.Models.Clients.Banks.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the completion client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class BankClientValidationException : Xeption
    {
        public BankClientValidationException(Xeption innerException)
            : base(message: "Banks client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
