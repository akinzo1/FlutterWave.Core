using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargeMpesaAsync()
        {

            // given
            var request = new Mpesa
            {
                Request = new MpesaRequest
                {
                    TxRef = "MC-15852113s09v5050e8",
                    Amount = 400,
                    Currency = "KES",
                    Email = "user@example.com",
                    PhoneNumber = "25454709929220",
                    FullName = "Yolande Aglaé Colbert",
                    ClientIp = "127.0.0.1",
                    Meta = new MpesaRequest.MpesaMeta
                    {
                        SideNote = "",
                        FlightId = ""
                    },
                    DeviceFingerprint = "wer"


                }
            };

            // . when
            Mpesa responseAIModels =
                await this.flutterWaveClient.Charge.ChargeMpesaAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
