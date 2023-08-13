using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;

namespace FlutterWave.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveMultipleRefundsAsync()
        {

            // given
            string from = Guid.NewGuid().ToString();
            string to = Guid.NewGuid().ToString();
            // . when
            MultipleRefundTransaction responseAIModels =
                await this.flutterWaveClient.Transactions.RetrieveMultipleRefundsAsync(from, to);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
