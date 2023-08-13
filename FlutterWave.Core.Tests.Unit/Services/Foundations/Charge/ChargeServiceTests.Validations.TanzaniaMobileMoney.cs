using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnTanzaniaMobileMoneyIfChargeIsNullAsync()
        {
            // given
            TanzaniaMobileMoney? nullCharge = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<TanzaniaMobileMoney> PaymentsTask =
                this.chargeService.PostChargeTanzaniaMobileMoneyRequestAsync(nullCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeTanzaniaMobileMoneyAsync(
                    It.IsAny<ExternalTanzaniaMobileMoneyRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnTanzaniaMobileMoneyIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new TanzaniaMobileMoney();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(TanzaniaMobileMoneyRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<TanzaniaMobileMoney> TanzaniaMobileMoneyTask =
                this.chargeService.PostChargeTanzaniaMobileMoneyRequestAsync(invalidPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    TanzaniaMobileMoneyTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeTanzaniaMobileMoneyAsync(
                    It.IsAny<ExternalTanzaniaMobileMoneyRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null, null)]
        [InlineData(0, "", "", "", "")]
        [InlineData(0, "  ", "  ", "  ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostTanzaniaMobileMoneyIfTanzaniaMobileMoneyIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidCurrency,
            string invalidTxRef, string invalidPhoneNumber)
        {
            // given
            var TanzaniaMobileMoney = new TanzaniaMobileMoney
            {
                Request = new TanzaniaMobileMoneyRequest
                {
                    Amount = invalidAmount,
                    Email = invalidEmail,
                    Currency = invalidCurrency,
                    TxRef = invalidTxRef,
                    PhoneNumber = invalidPhoneNumber


                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(TanzaniaMobileMoneyRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(TanzaniaMobileMoneyRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(TanzaniaMobileMoneyRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(TanzaniaMobileMoneyRequest.Amount),
             values: "Value is required");

            invalidPaymentsException.AddData(
           key: nameof(TanzaniaMobileMoneyRequest.PhoneNumber),
           values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<TanzaniaMobileMoney> TanzaniaMobileMoneyTask =
                this.chargeService.PostChargeTanzaniaMobileMoneyRequestAsync(TanzaniaMobileMoney);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(TanzaniaMobileMoneyTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostTanzaniaMobileMoneyIfPostTanzaniaMobileMoneyIsEmptyAsync()
        {
            // given
            var TanzaniaMobileMoney = new TanzaniaMobileMoney
            {
                Request = new TanzaniaMobileMoneyRequest
                {

                    TxRef = string.Empty,
                    Currency = string.Empty,
                    Email = string.Empty,
                    PhoneNumber = string.Empty
                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(TanzaniaMobileMoneyRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(TanzaniaMobileMoneyRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(TanzaniaMobileMoneyRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(TanzaniaMobileMoneyRequest.Amount),
             values: "Value is required");


            invalidPaymentsException.AddData(
           key: nameof(TanzaniaMobileMoneyRequest.PhoneNumber),
           values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<TanzaniaMobileMoney> TanzaniaMobileMoneyTask =
                this.chargeService.PostChargeTanzaniaMobileMoneyRequestAsync(TanzaniaMobileMoney);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    TanzaniaMobileMoneyTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}