using Xeptions;

namespace FlutterWave.Core.Models.Clients.Misc.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Miscellaneous client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class MiscellaneousClientDependencyException : Xeption
    {
        public MiscellaneousClientDependencyException(Xeption innerException)
            : base(message: "Miscellaneous dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
