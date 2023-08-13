using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnZambiaMobileMoneyIfChargeIsNullAsync()
        {
            // given
            ZambiaMobileMoney? nullCharge = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<ZambiaMobileMoney> PaymentsTask =
                this.chargeService.PostChargeZambiaMobileMoneyRequestAsync(nullCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeZambiaMobileMoneyAsync(
                    It.IsAny<ExternalZambiaMobileMoneyRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnZambiaMobileMoneyIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new ZambiaMobileMoney();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(ZambiaMobileMoneyRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<ZambiaMobileMoney> ZambiaMobileMoneyTask =
                this.chargeService.PostChargeZambiaMobileMoneyRequestAsync(invalidPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    ZambiaMobileMoneyTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeZambiaMobileMoneyAsync(
                    It.IsAny<ExternalZambiaMobileMoneyRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null, null, null)]
        [InlineData(0, "", "", "", "", "")]
        [InlineData(0, "  ", "  ", "  ", " ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostZambiaMobileMoneyIfZambiaMobileMoneyIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidCurrency,
            string invalidTxRef, string invalidPhoneNumber, string invalidNetwork)
        {
            // given
            var ZambiaMobileMoney = new ZambiaMobileMoney
            {
                Request = new ZambiaMobileMoneyRequest
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
                key: nameof(ZambiaMobileMoneyRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(ZambiaMobileMoneyRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(ZambiaMobileMoneyRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(ZambiaMobileMoneyRequest.Amount),
             values: "Value is required");

            invalidPaymentsException.AddData(
           key: nameof(ZambiaMobileMoneyRequest.PhoneNumber),
           values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(ZambiaMobileMoneyRequest.Network),
              values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<ZambiaMobileMoney> ZambiaMobileMoneyTask =
                this.chargeService.PostChargeZambiaMobileMoneyRequestAsync(ZambiaMobileMoney);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(ZambiaMobileMoneyTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostZambiaMobileMoneyIfPostZambiaMobileMoneyIsEmptyAsync()
        {
            // given
            var ZambiaMobileMoney = new ZambiaMobileMoney
            {
                Request = new ZambiaMobileMoneyRequest
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
                key: nameof(ZambiaMobileMoneyRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(ZambiaMobileMoneyRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(ZambiaMobileMoneyRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(ZambiaMobileMoneyRequest.Amount),
             values: "Value is required");


            invalidPaymentsException.AddData(
           key: nameof(ZambiaMobileMoneyRequest.PhoneNumber),
           values: "Value is required");


            invalidPaymentsException.AddData(
              key: nameof(ZambiaMobileMoneyRequest.Network),
              values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<ZambiaMobileMoney> ZambiaMobileMoneyTask =
                this.chargeService.PostChargeZambiaMobileMoneyRequestAsync(ZambiaMobileMoney);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    ZambiaMobileMoneyTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}