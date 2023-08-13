using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;

namespace FlutterWave.Core.Tests.Integration.API.VirtualAccounts
{
    public partial class VirtualAccountsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveVirtualAccountNumberAsync()
        {

            // given
            string orderReference = Guid.NewGuid().ToString();
            // . when
            FetchVirtualAccounts responseAIModels =
                await this.flutterWaveClient.VirtualAccounts.RetrieveVirtualAccountNumberAsync(orderReference);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
