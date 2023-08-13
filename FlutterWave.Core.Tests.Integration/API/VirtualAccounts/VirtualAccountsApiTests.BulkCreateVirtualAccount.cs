using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;

namespace FlutterWave.Core.Tests.Integration.API.VirtualAccounts
{
    public partial class VirtualAccountsApiTests
    {
        [Fact]
        public async Task ShouldCreateBulkVirtualAccountsAsync()
        {

            // given


            var bulkCreateVirtualAccounts = new BulkCreateVirtualAccounts
            {
                Request = new BulkCreateVirtualAccountsRequest
                {
                    Email = "developers@flutterwavego.com",
                    IsPermanent = true,
                    Accounts = 5,
                    TxRef = "jhn-mndkn-012439283422"
                }
            };

            // . when
            BulkCreateVirtualAccounts responseAIModels =
                await this.flutterWaveClient.VirtualAccounts.BulkCreateVirtualAccountsAsync(bulkCreateVirtualAccounts);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
