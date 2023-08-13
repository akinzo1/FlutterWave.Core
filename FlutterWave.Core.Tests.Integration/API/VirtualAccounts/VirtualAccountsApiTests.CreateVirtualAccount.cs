using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;

namespace FlutterWave.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        [Fact]
        public async Task ShouldCreateVirtualAccountAsync()
        {
            // given

            var virtualAccount = new CreateVirtualAccounts
            {
                Request = new CreateVirtualAccountRequest
                {
                    Email = "developers@flutterwavego.com",
                    IsPermanent = true,
                    Bvn = "12345678901",
                    TxRef = "VA12",
                    PhoneNumber = "08109328188",
                    FirstName = "Angela",
                    LastName = "Ashley",
                    Narration = "Angela Ashley-Osuzoka"
                }
            };

            // when
            CreateVirtualAccounts retrievedAIModel =
              await this.flutterWaveClient.VirtualAccounts.CreateVirtualAccountAsync(virtualAccount);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}