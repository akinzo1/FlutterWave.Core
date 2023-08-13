using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnUkEuBankAccountsIfChargeIsNullAsync()
        {
            // given
            UkEuBankAccounts? nullCharge = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<UkEuBankAccounts> PaymentsTask =
                this.chargeService.PostChargeUkEuBankAccountsRequestAsync(nullCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUkEuBankAccountsAsync(
                    It.IsAny<ExternalUkEuBankAccountsRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnUkEuBankAccountsIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new UkEuBankAccounts();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(UkEuBankAccountsRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<UkEuBankAccounts> UkEuBankAccountsTask =
                this.chargeService.PostChargeUkEuBankAccountsRequestAsync(invalidPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    UkEuBankAccountsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUkEuBankAccountsAsync(
                    It.IsAny<ExternalUkEuBankAccountsRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null)]
        [InlineData(0, "", "", "")]
        [InlineData(0, "  ", "  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostUkEuBankAccountsIfUkEuBankAccountsIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidCurrency,
            string invalidTxRef)
        {
            // given
            var UkEuBankAccounts = new UkEuBankAccounts
            {
                Request = new UkEuBankAccountsRequest
                {
                    Amount = invalidAmount,
                    Email = invalidEmail,
                    Currency = invalidCurrency,
                    TxRef = invalidTxRef,



                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(UkEuBankAccountsRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(UkEuBankAccountsRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(UkEuBankAccountsRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(UkEuBankAccountsRequest.Amount),
             values: "Value is required");



            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<UkEuBankAccounts> UkEuBankAccountsTask =
                this.chargeService.PostChargeUkEuBankAccountsRequestAsync(UkEuBankAccounts);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(UkEuBankAccountsTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostUkEuBankAccountsIfPostUkEuBankAccountsIsEmptyAsync()
        {
            // given
            var UkEuBankAccounts = new UkEuBankAccounts
            {
                Request = new UkEuBankAccountsRequest
                {

                    TxRef = string.Empty,
                    Currency = string.Empty,
                    Email = string.Empty,


                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(UkEuBankAccountsRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(UkEuBankAccountsRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(UkEuBankAccountsRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(UkEuBankAccountsRequest.Amount),
             values: "Value is required");





            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<UkEuBankAccounts> UkEuBankAccountsTask =
                this.chargeService.PostChargeUkEuBankAccountsRequestAsync(UkEuBankAccounts);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    UkEuBankAccountsTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}