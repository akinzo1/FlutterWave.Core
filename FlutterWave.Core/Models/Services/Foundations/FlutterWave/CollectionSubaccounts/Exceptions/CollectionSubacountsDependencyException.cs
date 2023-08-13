using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts
{
    public class CollectionSubaccountsDependencyException : Xeption
    {
        public CollectionSubaccountsDependencyException(Xeption innerException)
            : base(message: "CollectionSubaccounts dependency error occurred, contact support.",
                  innerException)
        { }

        public CollectionSubaccountsDependencyException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}