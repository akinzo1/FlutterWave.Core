



using Xeptions;

namespace FlutterWave.Core.Models.Clients.Settlement.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the Settlement client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class SettlementClientValidationException : Xeption
    {
        public SettlementClientValidationException(Xeption innerException)
            : base(message: "Settlement client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
