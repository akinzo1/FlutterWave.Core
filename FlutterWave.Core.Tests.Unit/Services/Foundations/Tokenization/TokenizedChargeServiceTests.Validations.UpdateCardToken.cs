



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.TokenizedCharge
{
    public partial class TokenizedChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdateCardTokenIfUpdateCardTokenIsNullAsync()
        {
            // given
            UpdateCardToken? nullTokenizedCharge = null;
            var nullTokenizedChargeException = new NullTokenizedChargeException();

            var exceptedTokenizedChargeValidationException =
                new TokenizedChargeValidationException(nullTokenizedChargeException);

            // when
            ValueTask<UpdateCardToken> PaymentsTask =
                this.tokenizedChargeService.PostUpdateCardTokenRequestAsync(It.IsAny<string>(), nullTokenizedCharge);

            TokenizedChargeValidationException actualTokenizedChargeValidationException =
                await Assert.ThrowsAsync<TokenizedChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualTokenizedChargeValidationException.Should()
                .BeEquivalentTo(exceptedTokenizedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCardTokenAsync(It.IsAny<string>(),
                    It.IsAny<ExternalUpdateCardTokenRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdateCardTokenIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new UpdateCardToken();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidTokenizedChargeException();

            invalidPaymentsException.AddData(
                key: nameof(UpdateCardTokenRequest),
                values: "Value is required");

            var expectedTokenizedChargeValidationException =
                new TokenizedChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<UpdateCardToken> UpdateCardTokenTask =
                this.tokenizedChargeService.PostUpdateCardTokenRequestAsync(It.IsAny<string>(), invalidPayments);

            TokenizedChargeValidationException actualTokenizedChargeValidationException =
                await Assert.ThrowsAsync<TokenizedChargeValidationException>(
                    UpdateCardTokenTask.AsTask);

            // then
            actualTokenizedChargeValidationException.Should()
                .BeEquivalentTo(expectedTokenizedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCardTokenAsync(It.IsAny<string>(),
                    It.IsAny<ExternalUpdateCardTokenRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("", "", "")]
        [InlineData(" ", "  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostUpdateCardTokenIfUpdateCardTokenIsInvalidAsync(
            string invalidPhoneNumber, string invalidEmail, string invalidFullName)
        {
            // given
            var UpdateCardToken = new UpdateCardToken
            {
                Request = new UpdateCardTokenRequest
                {
                    Email = invalidEmail,
                    PhoneNumber = invalidPhoneNumber,
                    FullName = invalidFullName




                }
            };

            var token = GetRandomString();

            var invalidPaymentsException = new InvalidTokenizedChargeException();

            invalidPaymentsException.AddData(
                key: nameof(UpdateCardTokenRequest.PhoneNumber),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(UpdateCardTokenRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(UpdateCardTokenRequest.FullName),
               values: "Value is required");





            var expectedTokenizedChargeValidationException =
                new TokenizedChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<UpdateCardToken> UpdateCardTokenTask =
                this.tokenizedChargeService.PostUpdateCardTokenRequestAsync(token, UpdateCardToken);

            TokenizedChargeValidationException actualTokenizedChargeValidationException =
                await Assert.ThrowsAsync<TokenizedChargeValidationException>(UpdateCardTokenTask.AsTask);

            // then
            actualTokenizedChargeValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostUpdateCardTokenIfPostUpdateCardTokenIsEmptyAsync()
        {
            // given
            var UpdateCardToken = new UpdateCardToken
            {
                Request = new UpdateCardTokenRequest
                {

                    Email = string.Empty,
                    PhoneNumber = string.Empty,
                    FullName = string.Empty,

                }
            };

            var token = GetRandomString();

            var invalidPaymentsException = new InvalidTokenizedChargeException();

            invalidPaymentsException.AddData(
           key: nameof(UpdateCardTokenRequest.PhoneNumber),
           values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(UpdateCardTokenRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(UpdateCardTokenRequest.FullName),
               values: "Value is required");

            var expectedTokenizedChargeValidationException =
                new TokenizedChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<UpdateCardToken> UpdateCardTokenTask =
                this.tokenizedChargeService.PostUpdateCardTokenRequestAsync(token, UpdateCardToken);

            TokenizedChargeValidationException actualTokenizedChargeValidationException =
                await Assert.ThrowsAsync<TokenizedChargeValidationException>(
                    UpdateCardTokenTask.AsTask);

            // then
            actualTokenizedChargeValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}