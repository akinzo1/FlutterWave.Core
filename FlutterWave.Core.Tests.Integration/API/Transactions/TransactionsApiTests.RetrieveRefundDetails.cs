using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;

namespace FlutterWave.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveRefundDetailsAsync()
        {
            // given
            string transactionId = "yuyutr";

            // when
            RefundDetails retrievedAIModel =
              await this.flutterWaveClient.Transactions.RetrieveRefundDetailsAsync(transactionId);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}