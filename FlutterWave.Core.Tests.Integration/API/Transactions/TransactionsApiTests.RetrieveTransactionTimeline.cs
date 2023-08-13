using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;

namespace FlutterWave.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveTransactionTimelineAsync()
        {

            // given
            string transactionId = Guid.NewGuid().ToString();
            // . when
            TransactionTimeline responseAIModels =
                await this.flutterWaveClient.Transactions.RetrieveTransactionTimelineAsync(transactionId);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
