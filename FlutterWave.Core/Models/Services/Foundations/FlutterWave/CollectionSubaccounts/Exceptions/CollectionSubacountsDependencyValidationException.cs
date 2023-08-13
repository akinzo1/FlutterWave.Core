using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts
{
    public class CollectionSubaccountsDependencyValidationException : Xeption
    {
        public CollectionSubaccountsDependencyValidationException(Xeption innerException)
            : base(message: "CollectionSubaccounts dependency validation error occurred, contact support.",
                  innerException)
        { }
        public CollectionSubaccountsDependencyValidationException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}