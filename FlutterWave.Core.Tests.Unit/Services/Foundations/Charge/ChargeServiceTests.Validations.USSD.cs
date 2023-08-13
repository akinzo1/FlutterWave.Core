using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnUSSDIfChargeIsNullAsync()
        {
            // given
            USSD? nullCharge = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<USSD> PaymentsTask =
                this.chargeService.PostChargeUSSDRequestAsync(nullCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUSSDAsync(
                    It.IsAny<ExternalUSSDRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnUSSDIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new USSD();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(USSDRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<USSD> USSDTask =
                this.chargeService.PostChargeUSSDRequestAsync(invalidPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    USSDTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUSSDAsync(
                    It.IsAny<ExternalUSSDRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null)]
        [InlineData(0, "", "", "")]
        [InlineData(0, "  ", "  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostUSSDIfUSSDIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidCurrency,
            string invalidTxRef)
        {
            // given
            var USSD = new USSD
            {
                Request = new USSDRequest
                {
                    Amount = invalidAmount,
                    Email = invalidEmail,
                    Currency = invalidCurrency,
                    TxRef = invalidTxRef,



                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(USSDRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(USSDRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(USSDRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(USSDRequest.Amount),
             values: "Value is required");



            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<USSD> USSDTask =
                this.chargeService.PostChargeUSSDRequestAsync(USSD);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(USSDTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostUSSDIfPostUSSDIsEmptyAsync()
        {
            // given
            var USSD = new USSD
            {
                Request = new USSDRequest
                {

                    TxRef = string.Empty,
                    Currency = string.Empty,
                    Email = string.Empty,

                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(USSDRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(USSDRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(USSDRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(USSDRequest.Amount),
             values: "Value is required");



            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<USSD> USSDTask =
                this.chargeService.PostChargeUSSDRequestAsync(USSD);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    USSDTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}