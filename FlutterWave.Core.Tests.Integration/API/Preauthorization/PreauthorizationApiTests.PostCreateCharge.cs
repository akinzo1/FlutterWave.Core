using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;

namespace FlutterWave.Core.Tests.Integration.API.Preauthorization
{
    public partial class PreauthorizationApiTests
    {
        [Fact]
        public async Task ShouldPostCreateChargeAsync()
        {

            // given
            var request = new CreateCharge
            {
                Request = new CreateChargeRequest
                {
                    CardNumber = "5531886652142950",
                    Cvv = "564",
                    ExpiryMonth = 09,
                    ExpiryYear = 32,
                    Currency = "NGN",
                    Amount = 100,
                    FullName = "Yolande Aglaé Colbert",
                    Email = "user@example.com",
                    TxRef = "MC-3243e",
                    RedirectUrl = "https://www,flutterwave.ng",
                    Authorization = new CreateChargeRequest.AuthorizationData
                    {
                        Address = "3563 Huntertown Rd, Allison park, PA",
                        Pin = 3310,
                        City = "San Francisco",
                        Country = "US",
                        State = "California",
                        Mode = "pin",
                        ZipCode = "94105"

                    },
                    Preauthorize = true,
                    Meta = new CreateChargeRequest.CreateChargeMeta
                    {
                        FlightId = "",
                        SideNote = ""
                    },
                    PaymentPlan = "",
                    DeviceFingerprint = "",
                    ClientIp = "127.0.0.1"

                }

            };


            // . when
            CreateCharge responseAIModels =
                await this.flutterWaveClient.Preauthorization.CreateChargeAsync(request, Environment.GetEnvironmentVariable("EncryptionKey"));

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
