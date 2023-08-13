using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts
{
    public class ExcessiveCallCollectionSubaccountsException : Xeption
    {
        public ExcessiveCallCollectionSubaccountsException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallCollectionSubaccountsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}