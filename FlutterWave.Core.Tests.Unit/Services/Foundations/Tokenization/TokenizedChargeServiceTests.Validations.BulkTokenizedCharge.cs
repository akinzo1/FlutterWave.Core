



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.TokenizedCharge
{
    public partial class TokenizedChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateBulkTokenizedChargeIfTokenizedChargeRequestIsNullAsync()
        {
            // given
            CreateBulkTokenizedCharge? nullTokenizedCharge = null;
            var nullTokenizedChargeException = new NullTokenizedChargeException();

            var exceptedTokenizedChargeValidationException =
                new TokenizedChargeValidationException(nullTokenizedChargeException);

            // when
            ValueTask<CreateBulkTokenizedCharge> PaymentsTask =
                this.tokenizedChargeService.PostCreateBulkTokenizedChargeRequestAsync(nullTokenizedCharge);

            TokenizedChargeValidationException actualTokenizedChargeValidationException =
                await Assert.ThrowsAsync<TokenizedChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualTokenizedChargeValidationException.Should()
                .BeEquivalentTo(exceptedTokenizedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTokenizedChargeAsync(
                    It.IsAny<ExternalCreateBulkTokenizedChargeRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateBulkTokenizedChargeIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new CreateBulkTokenizedCharge();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidTokenizedChargeException();

            invalidPaymentsException.AddData(
                key: nameof(CreateBulkTokenizedChargeRequest),
                values: "Value is required");

            var expectedTokenizedChargeValidationException =
                new TokenizedChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<CreateBulkTokenizedCharge> CreateBulkTokenizedChargeTask =
                this.tokenizedChargeService.PostCreateBulkTokenizedChargeRequestAsync(invalidPayments);

            TokenizedChargeValidationException actualTokenizedChargeValidationException =
                await Assert.ThrowsAsync<TokenizedChargeValidationException>(
                    CreateBulkTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeValidationException.Should()
                .BeEquivalentTo(expectedTokenizedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTokenizedChargeAsync(
                    It.IsAny<ExternalCreateBulkTokenizedChargeRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }




    }
}