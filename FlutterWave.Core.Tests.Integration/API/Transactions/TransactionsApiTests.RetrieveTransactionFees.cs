using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;

namespace FlutterWave.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveTransactionFeesAsync()
        {

            // given
            string currency = Guid.NewGuid().ToString();
            int amount = 2;

            // . when
            TransactionFees responseAIModels =
                await this.flutterWaveClient.Transactions.RetrieveTransactionFeesAsync(amount, currency);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
