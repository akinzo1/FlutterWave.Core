using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnNGBankAccountsIfChargeIsNullAsync()
        {
            // given
            NGBankAccounts? nullCharge = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<NGBankAccounts> PaymentsTask =
                this.chargeService.PostChargeNGBankAccountRequestAsync(nullCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeNGBankAccountAsync(
                    It.IsAny<ExternalNGBankAccountsRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnNGBankAccountsIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new NGBankAccounts();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(NGBankAccountsRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<NGBankAccounts> NGBankAccountsTask =
                this.chargeService.PostChargeNGBankAccountRequestAsync(invalidPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    NGBankAccountsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeNGBankAccountAsync(
                    It.IsAny<ExternalNGBankAccountsRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null)]
        [InlineData(0, "", "")]
        [InlineData(0, "  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostNGBankAccountsIfNGBankAccountsIsInvalidAsync(
            int invalidAmount, string invalidEmail,
            string invalidTxRef)
        {
            // given
            var NGBankAccounts = new NGBankAccounts
            {
                Request = new NGBankAccountsRequest
                {
                    Amount = invalidAmount,
                    Email = invalidEmail,
                    TxRef = invalidTxRef,



                }
            };

            var invalidPaymentsException = new InvalidChargeException();



            invalidPaymentsException.AddData(
                key: nameof(NGBankAccountsRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(NGBankAccountsRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(NGBankAccountsRequest.Amount),
             values: "Value is required");



            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<NGBankAccounts> NGBankAccountsTask =
                this.chargeService.PostChargeNGBankAccountRequestAsync(NGBankAccounts);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(NGBankAccountsTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostNGBankAccountsIfPostNGBankAccountsIsEmptyAsync()
        {
            // given
            var NGBankAccounts = new NGBankAccounts
            {
                Request = new NGBankAccountsRequest
                {

                    TxRef = string.Empty,
                    Email = string.Empty,

                }
            };

            var invalidPaymentsException = new InvalidChargeException();



            invalidPaymentsException.AddData(
                key: nameof(NGBankAccountsRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(NGBankAccountsRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(NGBankAccountsRequest.Amount),
             values: "Value is required");



            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<NGBankAccounts> NGBankAccountsTask =
                this.chargeService.PostChargeNGBankAccountRequestAsync(NGBankAccounts);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    NGBankAccountsTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}