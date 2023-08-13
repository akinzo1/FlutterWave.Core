using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts
{
    public partial class NullVirtualAccountsException : Xeption
    {
        public NullVirtualAccountsException()
            : base(message: "VirtualAccounts is null.")
        { }

        public NullVirtualAccountsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}
