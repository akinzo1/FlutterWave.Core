using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnMpesaIfChargeIsNullAsync()
        {
            // given
            Mpesa? nullCharge = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<Mpesa> PaymentsTask =
                this.chargeService.PostChargeMpesaRequestAsync(nullCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeMpesaAsync(
                    It.IsAny<ExternalMpesaRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnMpesaIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new Mpesa();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(MpesaRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<Mpesa> MpesaTask =
                this.chargeService.PostChargeMpesaRequestAsync(invalidPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    MpesaTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeMpesaAsync(
                    It.IsAny<ExternalMpesaRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null, null)]
        [InlineData(0, "", "", "", "")]
        [InlineData(0, "  ", "  ", "  ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostMpesaIfMpesaIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidCurrency,
            string invalidTxRef, string invalidPhoneNumber)
        {
            // given
            var Mpesa = new Mpesa
            {
                Request = new MpesaRequest
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
                key: nameof(MpesaRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(MpesaRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(MpesaRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(MpesaRequest.Amount),
             values: "Value is required");

            invalidPaymentsException.AddData(
           key: nameof(MpesaRequest.PhoneNumber),
           values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<Mpesa> MpesaTask =
                this.chargeService.PostChargeMpesaRequestAsync(Mpesa);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(MpesaTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostMpesaIfPostMpesaIsEmptyAsync()
        {
            // given
            var Mpesa = new Mpesa
            {
                Request = new MpesaRequest
                {

                    TxRef = string.Empty,
                    Currency = string.Empty,
                    Email = string.Empty,
                    PhoneNumber = string.Empty
                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(MpesaRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(MpesaRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(MpesaRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(MpesaRequest.Amount),
             values: "Value is required");


            invalidPaymentsException.AddData(
           key: nameof(MpesaRequest.PhoneNumber),
           values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<Mpesa> MpesaTask =
                this.chargeService.PostChargeMpesaRequestAsync(Mpesa);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    MpesaTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}