using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;

namespace FlutterWave.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        [Fact]
        public async Task ShouldInitiateTransferAsync()
        {

            // given


            var initiateTransfers = new InitiateTransfers
            {
                Request = new InitiateTransferRequest
                {
                    AccountBank = "044",
                    AccountNumber = "0690000040",
                    Amount = 5500,
                    Narration = "Akhlm Pstmn Trnsfr xx007",
                    Currency = "NGN",
                    Reference = "akhlm-pstmnpyt-rfxx007_PMCKDU_1",
                    CallbackUrl = "http =//www.flutterwave.com/ng/",
                    DebitCurrency = "NGN"
                }
            };

            // . when
            InitiateTransfers responseAIModels =
                await this.flutterWaveClient.Transfers.InitiateTransferAsync(initiateTransfers);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
