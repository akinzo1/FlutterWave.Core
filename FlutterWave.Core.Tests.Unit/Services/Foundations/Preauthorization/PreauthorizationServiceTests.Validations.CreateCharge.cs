



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Preauthorization
{
    public partial class PreauthorizationServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateChargeIfCreateChargeRequestIsNullAsync()
        {
            // given
            CreateCharge? nullPreauthorization = null;
            var nullPreauthorizationException = new NullPreauthorizationException();

            var exceptedPreauthorizationValidationException =
                new PreauthorizationValidationException(nullPreauthorizationException);

            // when
            ValueTask<CreateCharge> PaymentsTask =
                this.preauthorizationService.PostCreateChargeRequestAsync(nullPreauthorization, It.IsAny<string>());

            PreauthorizationValidationException actualPreauthorizationValidationException =
                await Assert.ThrowsAsync<PreauthorizationValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualPreauthorizationValidationException.Should()
                .BeEquivalentTo(exceptedPreauthorizationValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateChargeAsync(
                    It.IsAny<ExternalEncryptedChargeRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateChargeIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new CreateCharge();
            invalidPayments.Request = null;
            string? invalidEncryptionKey = null;
            var invalidPaymentsException =
                new InvalidPreauthorizationException();

            invalidPaymentsException.AddData(
                key: nameof(CreateChargeRequest),
                values: "Value is required");

            var expectedPreauthorizationValidationException =
                new PreauthorizationValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<CreateCharge> CreateChargeTask =
                this.preauthorizationService.PostCreateChargeRequestAsync(invalidPayments, invalidEncryptionKey);

            PreauthorizationValidationException actualPreauthorizationValidationException =
                await Assert.ThrowsAsync<PreauthorizationValidationException>(
                    CreateChargeTask.AsTask);

            // then
            actualPreauthorizationValidationException.Should()
                .BeEquivalentTo(expectedPreauthorizationValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateChargeAsync(
                    It.IsAny<ExternalEncryptedChargeRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, " ", null, null, null, null, 0, null)]
        [InlineData(0, " ", "", "", "", "", 0, "")]
        [InlineData(0, " ", "  ", "  ", " ", " ", 0, " ")]
        public async Task ShouldThrowValidationExceptionOnPostCreateChargeIfCreateChargeIsInvalidAsync(
            int invalidAmount, string invalidCardNumber,
            string invalidTxRef, string invalidCurrency, string invalidCvv,
            string invalidEmail, int invalidExpiryMonth, string invalidEncryptionKey)
        {
            // given
            var CreateCharge = new CreateCharge
            {
                Request = new CreateChargeRequest
                {
                    Amount = invalidAmount,
                    TxRef = invalidTxRef,
                    CardNumber = invalidCardNumber,
                    Cvv = invalidCvv,
                    Email = invalidEmail,
                    ExpiryMonth = invalidExpiryMonth,
                    Currency = invalidCurrency,




                }
            };

            var invalidPaymentsException = new InvalidPreauthorizationException();

            invalidPaymentsException.AddData(
                key: nameof(CreateChargeRequest.Amount),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateChargeRequest.TxRef),
                values: "Value is required");


            invalidPaymentsException.AddData(
                 key: nameof(CreateChargeRequest.Email),
                 values: "Value is required");

            invalidPaymentsException.AddData(
                    key: nameof(CreateChargeRequest.Cvv),
                    values: "Value is required");

            invalidPaymentsException.AddData(
                  key: nameof(CreateChargeRequest.CardNumber),
                  values: "Value is required");

            invalidPaymentsException.AddData(
                  key: nameof(CreateChargeRequest.ExpiryMonth),
                  values: "Value is required");

            invalidPaymentsException.AddData(
                  key: nameof(CreateChargeRequest.Currency),
                  values: "Value is required");





            var expectedPreauthorizationValidationException =
                new PreauthorizationValidationException(invalidPaymentsException);

            // when
            ValueTask<CreateCharge> CreateChargeTask =
                this.preauthorizationService.PostCreateChargeRequestAsync(CreateCharge, invalidEncryptionKey);

            PreauthorizationValidationException actualPreauthorizationValidationException =
                await Assert.ThrowsAsync<PreauthorizationValidationException>(CreateChargeTask.AsTask);

            // then
            actualPreauthorizationValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCreateChargeIfPostCreateChargeIsEmptyAsync()
        {
            // given
            var CreateCharge = new CreateCharge
            {
                Request = new CreateChargeRequest
                {

                    TxRef = string.Empty,
                    Email = string.Empty,
                    Currency = string.Empty


                }
            };

            var invalidPaymentsException = new InvalidPreauthorizationException();

            invalidPaymentsException.AddData(
                  key: nameof(CreateChargeRequest.Amount),
                  values: "Value is required");

            invalidPaymentsException.AddData(
                 key: nameof(CreateChargeRequest.TxRef),
                 values: "Value is required");


            invalidPaymentsException.AddData(
              key: nameof(CreateChargeRequest.Email),
              values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateChargeRequest.Cvv),
                values: "Value is required");

            invalidPaymentsException.AddData(
                  key: nameof(CreateChargeRequest.CardNumber),
                  values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateChargeRequest.ExpiryMonth),
                values: "Value is required");

            invalidPaymentsException.AddData(
                  key: nameof(CreateChargeRequest.Currency),
                  values: "Value is required");



            var expectedPreauthorizationValidationException =
                new PreauthorizationValidationException(invalidPaymentsException);

            // when
            ValueTask<CreateCharge> CreateChargeTask =
                this.preauthorizationService.PostCreateChargeRequestAsync(CreateCharge, string.Empty);

            PreauthorizationValidationException actualPreauthorizationValidationException =
                await Assert.ThrowsAsync<PreauthorizationValidationException>(
                    CreateChargeTask.AsTask);

            // then
            actualPreauthorizationValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}