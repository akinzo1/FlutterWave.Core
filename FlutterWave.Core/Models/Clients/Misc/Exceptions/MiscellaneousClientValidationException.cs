using Xeptions;

namespace FlutterWave.Core.Models.Clients.Miscellaneous.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the Miscellaneous client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class MiscellaneousClientValidationException : Xeption
    {
        public MiscellaneousClientValidationException(Xeption innerException)
            : base(message: "Miscellaneous client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
