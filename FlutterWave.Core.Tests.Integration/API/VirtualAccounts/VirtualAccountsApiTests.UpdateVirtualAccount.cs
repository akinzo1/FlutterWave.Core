using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;

namespace FlutterWave.Core.Tests.Integration.API.VirtualAccounts
{
    public partial class VirtualAccountsApiTests
    {
        [Fact]
        public async Task ShouldUpdateVirtualAccountsAsync()
        {

            // given
            string orderReference = "1234";

            var updateBvn = new UpdateBvnVirtualAccounts
            {
                Request = new UpdateVirtualAccountBvnRequest
                {
                    Bvn = "12468909876543456789"
                }
            };

            // . when
            UpdateBvnVirtualAccounts responseAIModels =
                await this.flutterWaveClient.VirtualAccounts.UpdateVirtualAccountsBvnAsync(updateBvn, orderReference);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
