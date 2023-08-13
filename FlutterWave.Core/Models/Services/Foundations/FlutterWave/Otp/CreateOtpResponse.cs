using System;
using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp
{
    public class CreateOtpResponse
    {

        public string Status { get; set; }
        public string Message { get; set; }
        public List<Datum> Data { get; set; }

        public class Datum
        {
            public string Medium { get; set; }
            public string Reference { get; set; }
            public string Otp { get; set; }
            public DateTime Expiry { get; set; }
        }

    }
}
