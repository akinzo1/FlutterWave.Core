using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnENairaIfChargeIsNullAsync()
        {
            // given
            ENaira? nullCharge = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<ENaira> PaymentsTask =
                this.chargeService.PostChargeENairaRequestAsync(nullCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeENairaAsync(
                    It.IsAny<ExternalENairaRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnENairaIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new ENaira();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(ENairaRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<ENaira> ENairaTask =
                this.chargeService.PostChargeENairaRequestAsync(invalidPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    ENairaTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeENairaAsync(
                    It.IsAny<ExternalENairaRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null)]
        [InlineData(0, "", "", "")]
        [InlineData(0, "  ", "  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostENairaIfENairaIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidCurrency,
            string invalidTxRef)
        {
            // given
            var ENaira = new ENaira
            {
                Request = new ENairaRequest
                {
                    Amount = invalidAmount,
                    Email = invalidEmail,
                    Currency = invalidCurrency,
                    TxRef = invalidTxRef,


                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(ENairaRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(ENairaRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(ENairaRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(ENairaRequest.Amount),
             values: "Value is required");


            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<ENaira> ENairaTask =
                this.chargeService.PostChargeENairaRequestAsync(ENaira);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(ENairaTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostENairaIfPostENairaIsEmptyAsync()
        {
            // given
            var ENaira = new ENaira
            {
                Request = new ENairaRequest
                {

                    TxRef = string.Empty,
                    Currency = string.Empty,
                    Email = string.Empty,

                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(ENairaRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(ENairaRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(ENairaRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(ENairaRequest.Amount),
             values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<ENaira> ENairaTask =
                this.chargeService.PostChargeENairaRequestAsync(ENaira);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    ENairaTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}