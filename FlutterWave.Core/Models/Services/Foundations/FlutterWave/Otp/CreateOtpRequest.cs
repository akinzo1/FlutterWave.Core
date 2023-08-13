using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp
{
    public class CreateOtpRequest
    {
        public int Length { get; set; }
        public CustomerModel Customer { get; set; }
        public string Sender { get; set; }
        public bool Send { get; set; }
        public List<string> Medium { get; set; }
        public int Expiry { get; set; }
        public class CustomerModel
        {

            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }


    }
}
