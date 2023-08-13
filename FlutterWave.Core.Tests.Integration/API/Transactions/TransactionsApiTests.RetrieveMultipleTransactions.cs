using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;

namespace FlutterWave.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveMultipleTransactionsAsync()
        {

            // given
            string from = Guid.NewGuid().ToString();
            string to = Guid.NewGuid().ToString();
            // . when
            MultipleTransaction responseAIModels =
                await this.flutterWaveClient.Transactions.RetrieveMultipleTransactionAsync(from, to);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
