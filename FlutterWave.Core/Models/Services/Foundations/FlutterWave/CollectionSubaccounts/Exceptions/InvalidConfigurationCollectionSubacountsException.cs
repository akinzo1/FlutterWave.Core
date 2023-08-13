using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts
{
    public class InvalidConfigurationCollectionSubaccountsException : Xeption
    {
        public InvalidConfigurationCollectionSubaccountsException(Exception innerException)
            : base(message: "Invalid CollectionSubaccounts configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationCollectionSubaccountsException(string message, Exception innerException)
           : base(message: message, innerException)
        { }
    }
}