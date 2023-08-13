using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous;

namespace FlutterWave.Core.Tests.Integration.API.Miscellaneous
{
    public partial class MiscellaneousApiTests
    {
        [Fact]
        public async Task ShouldVerifyBankAccountAsync()
        {
            // given
            var bankAccount = new BankAccountVerification
            {
                Request = new BankAccountVerificationRequest
                {
                    AccountBank = "Access Bank",
                    AccountNumber = "0812158322"
                }
            };

            // when
            BankAccountVerification retrievedAIModel =
              await this.flutterWaveClient.Miscellaneous.BankAccountVerificationAsync(bankAccount);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}