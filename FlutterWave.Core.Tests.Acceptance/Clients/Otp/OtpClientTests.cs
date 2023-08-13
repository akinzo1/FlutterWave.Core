using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalOtp;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace FlutterWave.Core.Tests.Acceptance.Clients.OtpClient
{
    public partial class OtpClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IFlutterWaveClient flutterWaveClient;

        public OtpClientTests()
        {
            this.apiKey = CreateRandomString();
            this.wireMockServer = WireMockServer.Start();

            var apiConfigurations = new ApiConfigurations
            {
                ApiUrl = this.wireMockServer.Url,
                ApiKey = this.apiKey,

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }

        private static DateTimeOffset GetRandomDate() =>
             new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static string CreateRandomString() =>
            new MnemonicString().GetValue();
        private static ExternalValidateOtpRequest ConvertToValidateOtpRequest(ValidateOtp otp)
        {
            return new ExternalValidateOtpRequest
            {
                Otp = otp.Request.Otp
            };

        }
        private static ExternalCreateOtpRequest ConvertToCreateOtpRequest(CreateOtp otp)
        {
            return new ExternalCreateOtpRequest
            {
                Customer = new ExternalCreateOtpRequest.ExternalCustomerModel
                {
                    Email = otp.Request.Customer.Email,
                    Name = otp.Request.Customer.Name,
                    Phone = otp.Request.Customer.Phone,
                },
                Expiry = otp.Request.Expiry,
                Length = otp.Request.Length,
                Medium = otp.Request.Medium,
                Send = otp.Request.Send,
                Sender = otp.Request.Sender,
            };


        }
        private static CreateOtp ConvertToOtpResponse(CreateOtp otp, ExternalCreateOtpResponse externalCreateOtpResponse)
        {

            otp.Response = new CreateOtpResponse
            {
                Status = externalCreateOtpResponse.Status,
                Message = externalCreateOtpResponse.Message,
                Data = externalCreateOtpResponse.Data.Select(data =>
                {
                    return new CreateOtpResponse.Datum
                    {
                        Expiry = data.Expiry,
                        Medium = data.Medium,
                        Otp = data.Otp,
                        Reference = data.Reference
                    };
                }).ToList(),
            };
            return otp;


        }
        private static ValidateOtp ConvertToOtpResponse(ValidateOtp otp, ExternalValidateOtpResponse externalValidateOtpResponse)
        {
            otp.Response = new ValidateOtpResponse
            {
                Data = externalValidateOtpResponse.Data,
                Message = externalValidateOtpResponse.Message,
                Status = externalValidateOtpResponse.Status,
            };
            return otp;



        }
        private static ExternalCreateOtpResponse CreateExternalCreateOtpResult() =>
          CreateExternalCreateOtpResponseFiller().Create();
        private static ExternalValidateOtpResponse CreateExternalValidateOtpResult() =>
        CreateExternalValidateOtpResponseFiller().Create();
        private static CreateOtp CreateRandomOtp() =>
           CreateOtpFiller().Create();
        private static ValidateOtp CreateRandomValidateOtp() =>
           CreateValidateOtpFiller().Create();
        private static Filler<ExternalCreateOtpResponse> CreateExternalCreateOtpResponseFiller()
        {
            var filler = new Filler<ExternalCreateOtpResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalValidateOtpResponse> CreateExternalValidateOtpResponseFiller()
        {
            var filler = new Filler<ExternalValidateOtpResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<CreateOtp> CreateOtpFiller()
        {
            var filler = new Filler<CreateOtp>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ValidateOtp> CreateValidateOtpFiller()
        {
            var filler = new Filler<ValidateOtp>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        public void Dispose() => this.wireMockServer.Stop();
    }
}
