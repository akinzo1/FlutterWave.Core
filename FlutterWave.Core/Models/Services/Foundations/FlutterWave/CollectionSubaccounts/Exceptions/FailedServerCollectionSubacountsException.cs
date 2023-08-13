using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts
{
    public class FailedServerCollectionSubaccountsException : Xeption
    {
        public FailedServerCollectionSubaccountsException(Exception innerException)
            : base(message: "Failed CollectionSubaccounts server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerCollectionSubaccountsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}