using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnRwandaMobileMoneyIfChargeIsNullAsync()
        {
            // given
            RwandaMobileMoney? nullCharge = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<RwandaMobileMoney> PaymentsTask =
                this.chargeService.PostChargeRwandaMobileMoneyRequestAsync(nullCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeRwandaMobileMoneyAsync(
                    It.IsAny<ExternalRwandaMobileMoneyRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnRwandaMobileMoneyIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new RwandaMobileMoney();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(RwandaMobileMoneyRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<RwandaMobileMoney> RwandaMobileMoneyTask =
                this.chargeService.PostChargeRwandaMobileMoneyRequestAsync(invalidPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    RwandaMobileMoneyTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeRwandaMobileMoneyAsync(
                    It.IsAny<ExternalRwandaMobileMoneyRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null)]
        [InlineData(0, "", "", "")]
        [InlineData(0, "  ", "  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostRwandaMobileMoneyIfRwandaMobileMoneyIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidCurrency,
            string invalidTxRef)
        {
            // given
            var RwandaMobileMoney = new RwandaMobileMoney
            {
                Request = new RwandaMobileMoneyRequest
                {
                    Amount = invalidAmount,
                    Email = invalidEmail,
                    Currency = invalidCurrency,
                    TxRef = invalidTxRef,



                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(RwandaMobileMoneyRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(RwandaMobileMoneyRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(RwandaMobileMoneyRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(RwandaMobileMoneyRequest.Amount),
             values: "Value is required");


            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<RwandaMobileMoney> RwandaMobileMoneyTask =
                this.chargeService.PostChargeRwandaMobileMoneyRequestAsync(RwandaMobileMoney);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(RwandaMobileMoneyTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostRwandaMobileMoneyIfPostRwandaMobileMoneyIsEmptyAsync()
        {
            // given
            var RwandaMobileMoney = new RwandaMobileMoney
            {
                Request = new RwandaMobileMoneyRequest
                {

                    TxRef = string.Empty,
                    Currency = string.Empty,
                    Email = string.Empty,

                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(RwandaMobileMoneyRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(RwandaMobileMoneyRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(RwandaMobileMoneyRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(RwandaMobileMoneyRequest.Amount),
             values: "Value is required");



            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<RwandaMobileMoney> RwandaMobileMoneyTask =
                this.chargeService.PostChargeRwandaMobileMoneyRequestAsync(RwandaMobileMoney);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    RwandaMobileMoneyTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}