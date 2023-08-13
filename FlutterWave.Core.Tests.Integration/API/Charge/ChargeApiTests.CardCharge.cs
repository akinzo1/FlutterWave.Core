using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargeCardChargeAsync()
        {

            // given
            var request = new CardCharge
            {
                Request = new CardChargeRequest
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
                    Authorization = new CardChargeRequest.AuthorizationData
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
                    Meta = new CardChargeRequest.CardMeta
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
            CardCharge responseAIModels =
                await this.flutterWaveClient.Charge.ChargeCardAsync(request, Environment.GetEnvironmentVariable("EncryptionKey"));

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
