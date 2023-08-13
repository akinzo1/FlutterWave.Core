using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnFrancophoneMobileMoneyIfChargeIsNullAsync()
        {
            // given
            FrancophoneMobileMoney? nullCharge = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<FrancophoneMobileMoney> PaymentsTask =
                this.chargeService.PostChargeFrancophoneMobileMoneyRequestAsync(nullCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFrancophoneMobileMoneyAsync(
                    It.IsAny<ExternalFrancophoneMobileMoneyRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnFrancophoneMobileMoneyIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new FrancophoneMobileMoney();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(FrancophoneMobileMoneyRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<FrancophoneMobileMoney> FrancophoneMobileMoneyTask =
                this.chargeService.PostChargeFrancophoneMobileMoneyRequestAsync(invalidPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    FrancophoneMobileMoneyTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFrancophoneMobileMoneyAsync(
                    It.IsAny<ExternalFrancophoneMobileMoneyRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null, null)]
        [InlineData(0, "", "", "", "")]
        [InlineData(0, "  ", "  ", "  ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostFrancophoneMobileMoneyIfFrancophoneMobileMoneyIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidCurrency,
            string invalidTxRef, string invalidPhoneNumber)
        {
            // given
            var FrancophoneMobileMoney = new FrancophoneMobileMoney
            {
                Request = new FrancophoneMobileMoneyRequest
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
                key: nameof(FrancophoneMobileMoneyRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(FrancophoneMobileMoneyRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(FrancophoneMobileMoneyRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(FrancophoneMobileMoneyRequest.Amount),
             values: "Value is required");

            invalidPaymentsException.AddData(
           key: nameof(FrancophoneMobileMoneyRequest.PhoneNumber),
           values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<FrancophoneMobileMoney> FrancophoneMobileMoneyTask =
                this.chargeService.PostChargeFrancophoneMobileMoneyRequestAsync(FrancophoneMobileMoney);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(FrancophoneMobileMoneyTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostFrancophoneMobileMoneyIfPostFrancophoneMobileMoneyIsEmptyAsync()
        {
            // given
            var FrancophoneMobileMoney = new FrancophoneMobileMoney
            {
                Request = new FrancophoneMobileMoneyRequest
                {

                    TxRef = string.Empty,
                    Currency = string.Empty,
                    Email = string.Empty,
                    PhoneNumber = string.Empty
                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(FrancophoneMobileMoneyRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(FrancophoneMobileMoneyRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(FrancophoneMobileMoneyRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(FrancophoneMobileMoneyRequest.Amount),
             values: "Value is required");


            invalidPaymentsException.AddData(
           key: nameof(FrancophoneMobileMoneyRequest.PhoneNumber),
           values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<FrancophoneMobileMoney> FrancophoneMobileMoneyTask =
                this.chargeService.PostChargeFrancophoneMobileMoneyRequestAsync(FrancophoneMobileMoney);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    FrancophoneMobileMoneyTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}