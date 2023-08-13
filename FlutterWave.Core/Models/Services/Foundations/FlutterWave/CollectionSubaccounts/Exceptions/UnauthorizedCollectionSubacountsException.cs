using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts
{
    public class UnauthorizedCollectionSubaccountsException : Xeption
    {
        public UnauthorizedCollectionSubaccountsException(Exception innerException)
            : base(message: "Unauthorized CollectionSubaccounts request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedCollectionSubaccountsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}