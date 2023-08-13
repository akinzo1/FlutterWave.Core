using Xeptions;

namespace FlutterWave.Core.Models.Clients.ChargeBacks.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the ChargeBacks client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class ChargeBacksClientValidationException : Xeption
    {
        public ChargeBacksClientValidationException(Xeption innerException)
            : base(message: "ChargeBacks client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
