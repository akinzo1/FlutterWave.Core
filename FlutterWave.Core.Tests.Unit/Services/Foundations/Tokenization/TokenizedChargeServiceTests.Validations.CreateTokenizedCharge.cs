



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.TokenizedCharge
{
    public partial class TokenizedChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateTokenizedChargeIfTokenizedChargeRequestIsNullAsync()
        {
            // given
            CreateTokenizedCharge? nullTokenizedCharge = null;
            var nullTokenizedChargeException = new NullTokenizedChargeException();

            var exceptedTokenizedChargeValidationException =
                new TokenizedChargeValidationException(nullTokenizedChargeException);

            // when
            ValueTask<CreateTokenizedCharge> PaymentsTask =
                this.tokenizedChargeService.PostCreateTokenizedChargeRequestAsync(nullTokenizedCharge);

            TokenizedChargeValidationException actualTokenizedChargeValidationException =
                await Assert.ThrowsAsync<TokenizedChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualTokenizedChargeValidationException.Should()
                .BeEquivalentTo(exceptedTokenizedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateTokenizedChargeAsync(
                    It.IsAny<ExternalCreateTokenizedChargeRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateTokenizedChargeIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new CreateTokenizedCharge();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidTokenizedChargeException();

            invalidPaymentsException.AddData(
                key: nameof(CreateTokenizedChargeRequest),
                values: "Value is required");

            var expectedTokenizedChargeValidationException =
                new TokenizedChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<CreateTokenizedCharge> CreateTokenizedChargeTask =
                this.tokenizedChargeService.PostCreateTokenizedChargeRequestAsync(invalidPayments);

            TokenizedChargeValidationException actualTokenizedChargeValidationException =
                await Assert.ThrowsAsync<TokenizedChargeValidationException>(
                    CreateTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeValidationException.Should()
                .BeEquivalentTo(expectedTokenizedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateTokenizedChargeAsync(
                    It.IsAny<ExternalCreateTokenizedChargeRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null, null, null)]
        [InlineData(0, "", "", "", "", "")]
        [InlineData(0, "  ", "  ", "  ", " ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostCreateTokenizedChargeIfCreateTokenizedChargeIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidCurrency,
            string invalidCountry, string invalidTxRef, string invalidToken)
        {
            // given
            var CreateTokenizedCharge = new CreateTokenizedCharge
            {
                Request = new CreateTokenizedChargeRequest
                {
                    Amount = invalidAmount,
                    Email = invalidEmail,
                    Currency = invalidCurrency,
                    Country = invalidCountry,
                    TxRef = invalidTxRef,
                    Token = invalidToken,


                }
            };

            var invalidPaymentsException = new InvalidTokenizedChargeException();

            invalidPaymentsException.AddData(
                key: nameof(CreateTokenizedChargeRequest.Amount),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateTokenizedChargeRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(CreateTokenizedChargeRequest.Currency),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(CreateTokenizedChargeRequest.Country),
             values: "Value is required");

            invalidPaymentsException.AddData(
           key: nameof(CreateTokenizedChargeRequest.TxRef),
           values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(CreateTokenizedChargeRequest.Token),
              values: "Value is required");



            var expectedTokenizedChargeValidationException =
                new TokenizedChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<CreateTokenizedCharge> CreateTokenizedChargeTask =
                this.tokenizedChargeService.PostCreateTokenizedChargeRequestAsync(CreateTokenizedCharge);

            TokenizedChargeValidationException actualTokenizedChargeValidationException =
                await Assert.ThrowsAsync<TokenizedChargeValidationException>(CreateTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCreateTokenizedChargeIfPostCreateTokenizedChargeIsEmptyAsync()
        {
            // given
            var CreateTokenizedCharge = new CreateTokenizedCharge
            {
                Request = new CreateTokenizedChargeRequest
                {

                    Email = string.Empty,
                    Currency = string.Empty,
                    Country = string.Empty,
                    TxRef = string.Empty,
                    Token = string.Empty,
                }
            };

            var invalidPaymentsException = new InvalidTokenizedChargeException();

            invalidPaymentsException.AddData(
              key: nameof(CreateTokenizedChargeRequest.Amount),
              values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateTokenizedChargeRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(CreateTokenizedChargeRequest.Currency),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(CreateTokenizedChargeRequest.Country),
             values: "Value is required");

            invalidPaymentsException.AddData(
           key: nameof(CreateTokenizedChargeRequest.TxRef),
           values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(CreateTokenizedChargeRequest.Token),
              values: "Value is required");

            var expectedTokenizedChargeValidationException =
                new TokenizedChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<CreateTokenizedCharge> CreateTokenizedChargeTask =
                this.tokenizedChargeService.PostCreateTokenizedChargeRequestAsync(CreateTokenizedCharge);

            TokenizedChargeValidationException actualTokenizedChargeValidationException =
                await Assert.ThrowsAsync<TokenizedChargeValidationException>(
                    CreateTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}