using Xeptions;

namespace FlutterWave.Core.Models.Clients.VirtualCards.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the VirtualCards client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class VirtualCardsClientValidationException : Xeption
    {
        public VirtualCardsClientValidationException(Xeption innerException)
            : base(message: "VirtualCards client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
