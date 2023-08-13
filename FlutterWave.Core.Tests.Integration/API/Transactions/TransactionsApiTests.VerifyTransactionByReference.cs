using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;

namespace FlutterWave.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact]
        public async Task ShouldVerifyTransactionByReferenceAsync()
        {

            // given
            string transactionReference = Guid.NewGuid().ToString();
            // . when
            VerifyTransaction responseAIModels =
                await this.flutterWaveClient.Transactions.VerifyTransactionAsync(transactionReference);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
