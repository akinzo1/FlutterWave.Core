



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.TokenizedCharge
{
    public partial class TokenizedChargeServiceTests
    {
        [Theory]
        [InlineData(0)]
        public async Task ShouldThrowValidationExceptionOnRetrieveBulkTokenizedChargeWithBulkTokenizedChargeIdDataIsInvalidAsync(
            int invalidBulkTokenizedChargeId)
        {
            // given
            var invalidTokenizedChargeException =
                new InvalidTokenizedChargeException();

            invalidTokenizedChargeException.AddData(
                key: nameof(FetchBulkTokenizedCharge),
                values: "Value is required");

            var expectedTokenizedChargeValidationException =
                new TokenizedChargeValidationException(invalidTokenizedChargeException);

            // when
            ValueTask<FetchBulkTokenizedCharge> retrieveTokenizedChargeTask =
                this.tokenizedChargeService.GetBulkTokenizedChargesRequestAsync(invalidBulkTokenizedChargeId);

            TokenizedChargeValidationException actualTokenizedChargeValidationException =
                await Assert.ThrowsAsync<TokenizedChargeValidationException>(
                    retrieveTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeValidationException.Should()
                .BeEquivalentTo(expectedTokenizedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedChargesAsync(
                    It.IsAny<int>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}