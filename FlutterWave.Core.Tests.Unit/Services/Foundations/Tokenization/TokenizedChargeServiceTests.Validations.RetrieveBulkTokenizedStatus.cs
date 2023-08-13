



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.TokenizedCharge
{
    public partial class TokenizedChargeServiceTests
    {
        [Theory]
        [InlineData(0)]
        public async Task ShouldThrowValidationExceptionOnRetrieveBulkTokenizedStatusWithBulkTokenizedStatusIdDataIsInvalidAsync(
            int invalidBulkTokenizedStatusId)
        {
            // given
            var invalidTokenizedChargeException =
                new InvalidTokenizedChargeException();

            invalidTokenizedChargeException.AddData(
                key: nameof(BulkTokenizedStatus),
                values: "Value is required");

            var expectedTokenizedChargeValidationException =
                new TokenizedChargeValidationException(invalidTokenizedChargeException);

            // when
            ValueTask<BulkTokenizedStatus> retrieveTokenizedChargeTask =
                this.tokenizedChargeService.GetBulkTokenizedStatusRequestAsync(invalidBulkTokenizedStatusId);

            TokenizedChargeValidationException actualTokenizedChargeValidationException =
                await Assert.ThrowsAsync<TokenizedChargeValidationException>(
                    retrieveTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeValidationException.Should()
                .BeEquivalentTo(expectedTokenizedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedStatusAsync(
                    It.IsAny<int>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}