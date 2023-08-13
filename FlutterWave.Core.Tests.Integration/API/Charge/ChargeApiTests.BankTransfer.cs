using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargeBankTransferAsync()
        {

            // given
            var request = new BankTransfer
            {
                Request = new BankTransferRequest
                {
                    TxRef = "YOUR_PAYMENT_REFERErtttNCE",
                    Amount = 600,
                    Email = "user@example.com",
                    PhoneNumber = "08000000000",
                    Currency = "NGN",
                    ClientIp = "154.123.220.1",
                    DeviceFingerprint = "62wd23423rq324323qew1",
                    Narration = "FlW Devs",
                    IsPermanent = false,
                    Meta = new BankTransferRequest.BankTransferMeta
                    {
                        FlightId = "",
                        SideNote = ""

                    },
                    BankTransferOptions = new BankTransferRequest.BankTransferOption
                    {
                        Expires = 10
                    }
                }
            };

            // . when
            BankTransfer responseAIModels =
                await this.flutterWaveClient.Charge.ChargeBankTransferAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
