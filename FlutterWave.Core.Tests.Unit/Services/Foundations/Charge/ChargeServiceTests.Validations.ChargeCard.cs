using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnCardChargeIfChargeIsNullAsync()
        {
            // given
            CardCharge? nullCharge = null;
            string? nullEncryptionKey = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<CardCharge> PaymentsTask =
                this.chargeService.PostChargeCardRequestAsync(nullCharge, nullEncryptionKey);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeCardAsync(
                    It.IsAny<ExternalEncryptedChargeRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCardChargeIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new CardCharge();
            invalidPayments.Request = null;
            string? nullEncryptionKey = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(CardChargeRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<CardCharge> CardChargeTask =
                this.chargeService.PostChargeCardRequestAsync(invalidPayments, nullEncryptionKey);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    CardChargeTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeCardAsync(
                    It.IsAny<ExternalEncryptedChargeRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null, 0, null, 0, null)]
        [InlineData(0, "", "", "", 0, "", 0, "")]
        [InlineData(0, "  ", " ", "  ", 0, " ", 0, " ")]
        public async Task ShouldThrowValidationExceptionOnPostCardChargeIfPaymentsIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidCardNumber,
            string invalidTxRef, int invalidExpiryMonth, string invalidCvv, int invalidExpiryYear, string invalidEncryptionKey)
        {
            // given
            var CardCharge = new CardCharge
            {
                Request = new CardChargeRequest
                {
                    Amount = invalidAmount,
                    Email = invalidEmail,
                    TxRef = invalidTxRef,
                    CardNumber = invalidCardNumber,
                    ExpiryMonth = invalidExpiryMonth,
                    Cvv = invalidCvv,
                    ExpiryYear = invalidExpiryYear


                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(CardChargeRequest.CardNumber),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CardChargeRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(CardChargeRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(CardChargeRequest.Amount),
             values: "Value is required");

            invalidPaymentsException.AddData(
         key: nameof(CardChargeRequest.ExpiryMonth),
         values: "Value is required");

            invalidPaymentsException.AddData(
         key: nameof(CardChargeRequest.ExpiryYear),
         values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(CardChargeRequest.Cvv),
              values: "Value is required");


            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<CardCharge> CardChargeTask =
                this.chargeService.PostChargeCardRequestAsync(CardCharge, invalidEncryptionKey);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(CardChargeTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostChargeCardIfPostChargeCardIsEmptyAsync()
        {
            // given
            var CardCharge = new CardCharge
            {
                Request = new CardChargeRequest
                {

                    TxRef = string.Empty,
                    Email = string.Empty,

                }
            };
            string emptyEncryptionKey = string.Empty;

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(CardChargeRequest.CardNumber),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CardChargeRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(CardChargeRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(CardChargeRequest.Amount),
             values: "Value is required");

            invalidPaymentsException.AddData(
         key: nameof(CardChargeRequest.ExpiryMonth),
         values: "Value is required");

            invalidPaymentsException.AddData(
         key: nameof(CardChargeRequest.ExpiryYear),
         values: "Value is required");

            invalidPaymentsException.AddData(
         key: nameof(CardChargeRequest.Cvv),
         values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<CardCharge> CardChargeTask =
                this.chargeService.PostChargeCardRequestAsync(CardCharge, emptyEncryptionKey);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    CardChargeTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}