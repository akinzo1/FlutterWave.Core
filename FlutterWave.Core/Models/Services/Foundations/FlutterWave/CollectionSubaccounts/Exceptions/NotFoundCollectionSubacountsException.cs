using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts
{
    public class NotFoundCollectionSubaccountsException : Xeption
    {
        public NotFoundCollectionSubaccountsException(Exception innerException)
            : base(message: "Not found CollectionSubaccounts error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundCollectionSubaccountsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}