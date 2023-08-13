using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts
{
    public class InvalidCollectionSubaccountsException : Xeption
    {
        public InvalidCollectionSubaccountsException()
            : base(message: "Invalid CollectionSubaccounts error occurred, fix errors and try again.")
        { }

        public InvalidCollectionSubaccountsException(Exception innerException)
            : base(message: "Invalid CollectionSubaccounts error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidCollectionSubaccountsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}