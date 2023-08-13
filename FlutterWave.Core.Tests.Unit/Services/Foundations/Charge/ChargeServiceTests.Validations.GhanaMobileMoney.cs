using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnGhanaMobileMoneyIfChargeIsNullAsync()
        {
            // given
            GhanaMobileMoney? nullCharge = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<GhanaMobileMoney> PaymentsTask =
                this.chargeService.PostChargeGhanaMobileMoneyRequestAsync(nullCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGhanaMobileMoneyAsync(
                    It.IsAny<ExternalGhanaMobileMoneyRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnGhanaMobileMoneyIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new GhanaMobileMoney();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(GhanaMobileMoneyRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<GhanaMobileMoney> GhanaMobileMoneyTask =
                this.chargeService.PostChargeGhanaMobileMoneyRequestAsync(invalidPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    GhanaMobileMoneyTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGhanaMobileMoneyAsync(
                    It.IsAny<ExternalGhanaMobileMoneyRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null, null, null)]
        [InlineData(0, "", "", "", "", "")]
        [InlineData(0, "  ", "  ", "  ", " ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostGhanaMobileMoneyIfGhanaMobileMoneyIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidCurrency,
            string invalidTxRef, string invalidPhoneNumber, string invalidNetwork)
        {
            // given
            var GhanaMobileMoney = new GhanaMobileMoney
            {
                Request = new GhanaMobileMoneyRequest
                {
                    Amount = invalidAmount,
                    Email = invalidEmail,
                    Currency = invalidCurrency,
                    TxRef = invalidTxRef,
                    PhoneNumber = invalidPhoneNumber,
                    Network = invalidNetwork


                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(GhanaMobileMoneyRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(GhanaMobileMoneyRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(GhanaMobileMoneyRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(GhanaMobileMoneyRequest.Amount),
             values: "Value is required");

            invalidPaymentsException.AddData(
           key: nameof(GhanaMobileMoneyRequest.PhoneNumber),
           values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(GhanaMobileMoneyRequest.Network),
               values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<GhanaMobileMoney> GhanaMobileMoneyTask =
                this.chargeService.PostChargeGhanaMobileMoneyRequestAsync(GhanaMobileMoney);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(GhanaMobileMoneyTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostGhanaMobileMoneyIfPostGhanaMobileMoneyIsEmptyAsync()
        {
            // given
            var GhanaMobileMoney = new GhanaMobileMoney
            {
                Request = new GhanaMobileMoneyRequest
                {

                    TxRef = string.Empty,
                    Currency = string.Empty,
                    Email = string.Empty,
                    PhoneNumber = string.Empty,
                    Network = string.Empty,

                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(GhanaMobileMoneyRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(GhanaMobileMoneyRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(GhanaMobileMoneyRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(GhanaMobileMoneyRequest.Amount),
             values: "Value is required");


            invalidPaymentsException.AddData(
           key: nameof(GhanaMobileMoneyRequest.PhoneNumber),
           values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(GhanaMobileMoneyRequest.Network),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<GhanaMobileMoney> GhanaMobileMoneyTask =
                this.chargeService.PostChargeGhanaMobileMoneyRequestAsync(GhanaMobileMoney);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    GhanaMobileMoneyTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}