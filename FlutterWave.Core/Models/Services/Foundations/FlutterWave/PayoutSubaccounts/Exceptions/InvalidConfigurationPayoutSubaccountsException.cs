using System;
using Xeptions;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts
{
    public class InvalidConfigurationPayoutSubaccountsException : Xeption
    {
        public InvalidConfigurationPayoutSubaccountsException(Exception innerException)
            : base(message: "Invalid PayoutSubaccounts configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationPayoutSubaccountsException(string message, Exception innerException)
             : base(message: message, innerException)
        { }
    }
}