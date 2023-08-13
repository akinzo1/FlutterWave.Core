using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;

namespace FlutterWave.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact]
        public async Task ShouldCancelPaymentPlanAsync()
        {

            // given
            int transactionId = 1;
            // . when
            VerifyTransaction responseAIModels =
                await this.flutterWaveClient.Transactions.VerifyTransactionAsync(transactionId);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
