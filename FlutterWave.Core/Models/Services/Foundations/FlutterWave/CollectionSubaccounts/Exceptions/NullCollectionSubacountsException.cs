using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts
{
    public partial class NullCollectionSubaccountsException : Xeption
    {
        public NullCollectionSubaccountsException()
            : base(message: "CollectionSubaccounts is null.")
        { }

        public NullCollectionSubaccountsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}
