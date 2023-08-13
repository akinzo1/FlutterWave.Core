using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Banks
{
    public partial class BanksServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnRetrieveBanksByCountryIfCountryIsInvalidAsync(string invalidCountry)
        {
            // given
            var invalidBanksException =
                new InvalidBanksException();

            invalidBanksException.AddData(
                key: nameof(Bank),
                values: "Value is required");

            var expectedBanksValidationException =
                new BanksValidationException(invalidBanksException);

            // when
            ValueTask<Bank> retrieveBanksByCountryTask =
                this.banksService.GetAllBanksByCountryAsync(invalidCountry);

            BanksValidationException actualBanksValidationException =
                await Assert.ThrowsAsync<BanksValidationException>(
                    retrieveBanksByCountryTask.AsTask);

            // then
            actualBanksValidationException.Should()
                .BeEquivalentTo(expectedBanksValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBanksByCountryAsync(
                    It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}