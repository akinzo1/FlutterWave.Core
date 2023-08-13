



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Settlements;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Settlements
{
    public partial class SettlementsServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnRetrieveSettlementWithSettlementIdDataIsInvalidAsync(
            string invalidSettlementId)
        {
            // given
            var invalidSettlementException =
                new InvalidSettlementsException();

            invalidSettlementException.AddData(
                key: nameof(Settlement),
                values: "Value is required");

            var expectedSettlementValidationException =
                new SettlementsValidationException(invalidSettlementException);

            // when
            ValueTask<Settlement> retrieveSettlementTask =
                this.settlementsService.GetSettlementsByIdAsync(invalidSettlementId);

            SettlementsValidationException actualSettlementValidationException =
                await Assert.ThrowsAsync<SettlementsValidationException>(
                    retrieveSettlementTask.AsTask);

            // then
            actualSettlementValidationException.Should()
                .BeEquivalentTo(expectedSettlementValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSettlementByIdAsync(
                    It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}