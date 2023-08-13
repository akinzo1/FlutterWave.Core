using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnACHPaymentsIfChargeIsNullAsync()
        {
            // given
            ACHPayments? nullCharge = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<ACHPayments> PaymentsTask =
                this.chargeService.PostChargeACHPaymentsRequestAsync(nullCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeACHPaymentsAsync(
                    It.IsAny<ExternalACHPaymentsRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPaymentsIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new ACHPayments();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(ACHPaymentsRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<ACHPayments> ACHPaymentsTask =
                this.chargeService.PostChargeACHPaymentsRequestAsync(invalidPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    ACHPaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeACHPaymentsAsync(
                    It.IsAny<ExternalACHPaymentsRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null)]
        [InlineData(0, "", "", "")]
        [InlineData(0, "  ", "  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostPaymentsIfPaymentsIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidCurrency,
            string invalidTxRef)
        {
            // given
            var ACHPayments = new ACHPayments
            {
                Request = new ACHPaymentsRequest
                {
                    Amount = invalidAmount,
                    Email = invalidEmail,
                    Currency = invalidCurrency,
                    TxRef = invalidTxRef,


                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(ACHPaymentsRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(ACHPaymentsRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(ACHPaymentsRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(ACHPaymentsRequest.Amount),
             values: "Value is required");


            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<ACHPayments> ACHPaymentsTask =
                this.chargeService.PostChargeACHPaymentsRequestAsync(ACHPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(ACHPaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostPaymentsIfPostPaymentsIsEmptyAsync()
        {
            // given
            var ACHPayments = new ACHPayments
            {
                Request = new ACHPaymentsRequest
                {

                    TxRef = string.Empty,
                    Currency = string.Empty,
                    Email = string.Empty,

                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(ACHPaymentsRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(ACHPaymentsRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(ACHPaymentsRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(ACHPaymentsRequest.Amount),
             values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<ACHPayments> ACHPaymentsTask =
                this.chargeService.PostChargeACHPaymentsRequestAsync(ACHPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    ACHPaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}