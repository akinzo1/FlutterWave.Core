using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts
{
    public class CollectionSubaccountsServiceException : Xeption
    {
        public CollectionSubaccountsServiceException(Xeption innerException)
            : base(message: "CollectionSubaccounts service error occurred, contact support.",
                  innerException)
        { }
        public CollectionSubaccountsServiceException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}