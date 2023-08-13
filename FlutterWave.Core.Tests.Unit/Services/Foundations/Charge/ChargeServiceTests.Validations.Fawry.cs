using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnFawryIfChargeIsNullAsync()
        {
            // given
            Fawry? nullCharge = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<Fawry> PaymentsTask =
                this.chargeService.PostChargeFawryRequestAsync(nullCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFawryAsync(
                    It.IsAny<ExternalFawryRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnFawryIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new Fawry();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(FawryRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<Fawry> FawryTask =
                this.chargeService.PostChargeFawryRequestAsync(invalidPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    FawryTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFawryAsync(
                    It.IsAny<ExternalFawryRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null, null)]
        [InlineData(0, "", "", "", "")]
        [InlineData(0, "  ", "  ", "  ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostFawryIfFawryIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidCurrency,
            string invalidTxRef, string invalidPhoneNumber)
        {
            // given
            var Fawry = new Fawry
            {
                Request = new FawryRequest
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
                key: nameof(FawryRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(FawryRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(FawryRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(FawryRequest.Amount),
             values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(FawryRequest.PhoneNumber),
             values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<Fawry> FawryTask =
                this.chargeService.PostChargeFawryRequestAsync(Fawry);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(FawryTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostFawryIfPostFawryIsEmptyAsync()
        {
            // given
            var Fawry = new Fawry
            {
                Request = new FawryRequest
                {

                    TxRef = string.Empty,
                    Currency = string.Empty,
                    Email = string.Empty,
                    PhoneNumber = string.Empty,

                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(FawryRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(FawryRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(FawryRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(FawryRequest.Amount),
             values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(FawryRequest.PhoneNumber),
             values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<Fawry> FawryTask =
                this.chargeService.PostChargeFawryRequestAsync(Fawry);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    FawryTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}