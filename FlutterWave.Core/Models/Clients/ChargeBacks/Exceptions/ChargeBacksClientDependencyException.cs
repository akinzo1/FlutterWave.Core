using Xeptions;

namespace FlutterWave.Core.Models.Clients.ChargeBacks.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the ChargeBacks client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class ChargeBacksClientDependencyException : Xeption
    {
        public ChargeBacksClientDependencyException(Xeption innerException)
            : base(message: "ChargeBacks dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
