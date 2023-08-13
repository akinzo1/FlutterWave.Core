using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Banks
{
    public partial class BanksServiceTests
    {
        [Theory]

        [InlineData(0)]
        public async Task ShouldThrowValidationExceptionOnRetrieveBanksByIdIfBankCodeIsInvalidAsync(int invalidBankCode)
        {
            // given
            var invalidBanksException =
                new InvalidBanksException();

            invalidBanksException.AddData(
                key: nameof(BankBranches),
                values: "Value is required");

            var expectedBanksValidationException =
                new BanksValidationException(invalidBanksException);

            // when
            ValueTask<BankBranches> retrieveBanksByCountryTask =
                this.banksService.GetAllBankBranchesByBankCodeAsync(invalidBankCode);

            BanksValidationException actualBanksValidationException =
                await Assert.ThrowsAsync<BanksValidationException>(
                    retrieveBanksByCountryTask.AsTask);

            // then
            actualBanksValidationException.Should()
                .BeEquivalentTo(expectedBanksValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBankBranchesByIdAsync(
                    It.IsAny<int>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}