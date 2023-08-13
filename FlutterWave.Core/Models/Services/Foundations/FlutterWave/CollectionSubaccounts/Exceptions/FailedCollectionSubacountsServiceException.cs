using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts
{
    public class FailedCollectionSubaccountsServiceException : Xeption
    {
        public FailedCollectionSubaccountsServiceException(Exception innerException)
            : base(message: "Failed CollectionSubaccounts service error occurred, contact support.",
                  innerException)
        { }

        public FailedCollectionSubaccountsServiceException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}