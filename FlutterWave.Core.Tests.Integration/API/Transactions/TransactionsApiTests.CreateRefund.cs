using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;

namespace FlutterWave.Core.Tests.Integration.API.Transactions
{
    public partial class TransactionsApiTests
    {
        [Fact]
        public async Task ShouldCreateRefundAsync()
        {

            // given
            int transactionId = 908790;



            // . when
            CreateRefund responseAIModels =
                await this.flutterWaveClient.Transactions.CreateRefundRequestAsync(transactionId);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
