



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PayoutSubaccount
{
    public partial class PayoutSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreatePayoutSubaccountIfPayoutSubaccountsRequestIsNullAsync()
        {
            // given
            CreatePayoutSubaccount? nullPayoutSubaccounts = null;
            var nullPayoutSubaccountsException = new NullPayoutSubaccountsException();

            var exceptedPayoutSubaccountsValidationException =
                new PayoutSubaccountsValidationException(nullPayoutSubaccountsException);

            // when
            ValueTask<CreatePayoutSubaccount> PaymentsTask =
                this.payoutSubaccountService.PostCreatePayoutSubaccountRequestAsync(nullPayoutSubaccounts);

            PayoutSubaccountsValidationException actualPayoutSubaccountsValidationException =
                await Assert.ThrowsAsync<PayoutSubaccountsValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualPayoutSubaccountsValidationException.Should()
                .BeEquivalentTo(exceptedPayoutSubaccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePayoutSubaccountAsync(
                    It.IsAny<ExternalCreatePayoutSubaccountRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreatePayoutSubaccountIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new CreatePayoutSubaccount();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidPayoutSubaccountsException();

            invalidPaymentsException.AddData(
                key: nameof(CreatePayoutSubaccountRequest),
                values: "Value is required");

            var expectedPayoutSubaccountsValidationException =
                new PayoutSubaccountsValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<CreatePayoutSubaccount> CreatePayoutSubaccountTask =
                this.payoutSubaccountService.PostCreatePayoutSubaccountRequestAsync(invalidPayments);

            PayoutSubaccountsValidationException actualPayoutSubaccountsValidationException =
                await Assert.ThrowsAsync<PayoutSubaccountsValidationException>(
                    CreatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsValidationException.Should()
                .BeEquivalentTo(expectedPayoutSubaccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePayoutSubaccountAsync(
                    It.IsAny<ExternalCreatePayoutSubaccountRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, null, null)]
        [InlineData("", "", "", "")]
        [InlineData(" ", "  ", "  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostCreatePayoutSubaccountIfCreatePayoutSubaccountIsInvalidAsync(
            string invalidAccountName, string invalidCountry, string invalidEmail,
            string invalidMobileNumber)
        {
            // given
            var CreatePayoutSubaccount = new CreatePayoutSubaccount
            {
                Request = new CreatePayoutSubaccountRequest
                {
                    AccountName = invalidAccountName,
                    Country = invalidCountry,
                    Email = invalidEmail,
                    MobileNumber = invalidMobileNumber,



                }
            };

            var invalidPaymentsException = new InvalidPayoutSubaccountsException();

            invalidPaymentsException.AddData(
                key: nameof(CreatePayoutSubaccountRequest.AccountName),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreatePayoutSubaccountRequest.Country),
                values: "Value is required");


            invalidPaymentsException.AddData(
             key: nameof(CreatePayoutSubaccountRequest.Email),
             values: "Value is required");

            invalidPaymentsException.AddData(
           key: nameof(CreatePayoutSubaccountRequest.MobileNumber),
           values: "Value is required");




            var expectedPayoutSubaccountsValidationException =
                new PayoutSubaccountsValidationException(invalidPaymentsException);

            // when
            ValueTask<CreatePayoutSubaccount> CreatePayoutSubaccountTask =
                this.payoutSubaccountService.PostCreatePayoutSubaccountRequestAsync(CreatePayoutSubaccount);

            PayoutSubaccountsValidationException actualPayoutSubaccountsValidationException =
                await Assert.ThrowsAsync<PayoutSubaccountsValidationException>(CreatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsValidationException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCreatePayoutSubaccountIfPostCreatePayoutSubaccountIsEmptyAsync()
        {
            // given
            var CreatePayoutSubaccount = new CreatePayoutSubaccount
            {
                Request = new CreatePayoutSubaccountRequest
                {

                    Country = string.Empty,
                    MobileNumber = string.Empty,
                    Email = string.Empty,
                    AccountName = string.Empty,
                }
            };

            var invalidPaymentsException = new InvalidPayoutSubaccountsException();

            invalidPaymentsException.AddData(
                key: nameof(CreatePayoutSubaccountRequest.AccountName),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreatePayoutSubaccountRequest.Country),
                values: "Value is required");


            invalidPaymentsException.AddData(
             key: nameof(CreatePayoutSubaccountRequest.Email),
             values: "Value is required");

            invalidPaymentsException.AddData(
           key: nameof(CreatePayoutSubaccountRequest.MobileNumber),
           values: "Value is required");

            var expectedPayoutSubaccountsValidationException =
                new PayoutSubaccountsValidationException(invalidPaymentsException);

            // when
            ValueTask<CreatePayoutSubaccount> CreatePayoutSubaccountTask =
                this.payoutSubaccountService.PostCreatePayoutSubaccountRequestAsync(CreatePayoutSubaccount);

            PayoutSubaccountsValidationException actualPayoutSubaccountsValidationException =
                await Assert.ThrowsAsync<PayoutSubaccountsValidationException>(
                    CreatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsValidationException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}