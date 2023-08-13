using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts
{
    public class CollectionSubaccountsValidationException : Xeption
    {
        public CollectionSubaccountsValidationException(Xeption innerException)
            : base(message: "CollectionSubaccounts validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public CollectionSubaccountsValidationException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}