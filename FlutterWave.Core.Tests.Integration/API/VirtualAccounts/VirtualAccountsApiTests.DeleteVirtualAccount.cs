using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;

namespace FlutterWave.Core.Tests.Integration.API.VirtualAccounts
{
    public partial class VirtualAccountsApiTests
    {
        [Fact]
        public async Task ShouldDeleteVirtualAccountsAsync()
        {

            // given
            string orderReference = "URF_1628865217526_1284135";

            var deleteVirtualAccounts = new DeleteVirtualAccounts
            {
                Request = new DeleteVirtualAccountRequest
                {

                    Status = "inactive"
                }
            };

            // . when
            DeleteVirtualAccounts responseAIModels =
                await this.flutterWaveClient.VirtualAccounts.RemoveVirtualAccountsAsync(deleteVirtualAccounts, orderReference);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
