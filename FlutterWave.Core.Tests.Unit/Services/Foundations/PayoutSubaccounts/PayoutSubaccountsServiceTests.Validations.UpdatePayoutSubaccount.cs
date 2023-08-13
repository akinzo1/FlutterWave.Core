



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PayoutSubaccount
{
    public partial class PayoutSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdatePayoutSubaccountIfUpdatePayoutSubaccountIsNullAsync()
        {
            // given
            UpdatePayoutSubaccount? nullPayoutSubaccounts = null;
            var nullPayoutSubaccountsException = new NullPayoutSubaccountsException();

            var exceptedPayoutSubaccountsValidationException =
                new PayoutSubaccountsValidationException(nullPayoutSubaccountsException);

            // when
            ValueTask<UpdatePayoutSubaccount> PaymentsTask =
                this.payoutSubaccountService.PostUpdatePayoutSubaccountRequestAsync(It.IsAny<string>(), nullPayoutSubaccounts);

            PayoutSubaccountsValidationException actualPayoutSubaccountsValidationException =
                await Assert.ThrowsAsync<PayoutSubaccountsValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualPayoutSubaccountsValidationException.Should()
                .BeEquivalentTo(exceptedPayoutSubaccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(),
                    It.IsAny<ExternalUpdatePayoutSubaccountRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdatePayoutSubaccountIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new UpdatePayoutSubaccount();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidPayoutSubaccountsException();

            invalidPaymentsException.AddData(
                key: nameof(UpdatePayoutSubaccountRequest),
                values: "Value is required");

            var expectedPayoutSubaccountsValidationException =
                new PayoutSubaccountsValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<UpdatePayoutSubaccount> UpdatePayoutSubaccountTask =
                this.payoutSubaccountService.PostUpdatePayoutSubaccountRequestAsync(It.IsAny<string>(), invalidPayments);

            PayoutSubaccountsValidationException actualPayoutSubaccountsValidationException =
                await Assert.ThrowsAsync<PayoutSubaccountsValidationException>(
                    UpdatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsValidationException.Should()
                .BeEquivalentTo(expectedPayoutSubaccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(),
                    It.IsAny<ExternalUpdatePayoutSubaccountRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, null, null, null)]
        [InlineData("", "", "", "", "")]
        [InlineData(" ", " ", " ", " ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostUpdatePayoutSubaccountIfUpdatePayoutSubaccountIsInvalidAsync(
            string invalidCountry, string invalidAccountName, string invalidEmail, string invalidMobilenumber, string invalidSubaccountId)
        {
            // given
            var updatePayoutSubaccount = new UpdatePayoutSubaccount
            {
                Request = new UpdatePayoutSubaccountRequest
                {
                    Country = invalidCountry,
                    AccountName = invalidAccountName,
                    Email = invalidEmail,
                    MobileNumber = invalidMobilenumber

                }
            };



            var invalidPaymentsException = new InvalidPayoutSubaccountsException();

            invalidPaymentsException.AddData(
                key: nameof(UpdatePayoutSubaccountRequest),
                values: "Value is required");

            invalidPaymentsException.AddData(
                    key: nameof(UpdatePayoutSubaccountRequest.AccountName),
                    values: "Value is required");

            invalidPaymentsException.AddData(
            key: nameof(UpdatePayoutSubaccountRequest.Email),
            values: "Value is required");

            invalidPaymentsException.AddData(
            key: nameof(UpdatePayoutSubaccountRequest.MobileNumber),
            values: "Value is required");





            var expectedPayoutSubaccountsValidationException =
                new PayoutSubaccountsValidationException(invalidPaymentsException);

            // when
            ValueTask<UpdatePayoutSubaccount> UpdatePayoutSubaccountTask =
                this.payoutSubaccountService.PostUpdatePayoutSubaccountRequestAsync(invalidSubaccountId, updatePayoutSubaccount);

            PayoutSubaccountsValidationException actualPayoutSubaccountsValidationException =
                await Assert.ThrowsAsync<PayoutSubaccountsValidationException>(UpdatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsValidationException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostUpdatePayoutSubaccountIfPostUpdatePayoutSubaccountIsEmptyAsync()
        {
            // given
            var updatePayoutSubaccount = new UpdatePayoutSubaccount
            {
                Request = new UpdatePayoutSubaccountRequest
                {

                    Country = string.Empty,
                    MobileNumber = string.Empty,
                    Email = string.Empty,
                    AccountName = string.Empty

                }
            };

            var subaccountId = GetRandomString();

            var invalidPaymentsException = new InvalidPayoutSubaccountsException();

            invalidPaymentsException.AddData(
                     key: nameof(UpdatePayoutSubaccountRequest),
                     values: "Value is required");

            invalidPaymentsException.AddData(
                    key: nameof(UpdatePayoutSubaccountRequest.AccountName),
                    values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(UpdatePayoutSubaccountRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(UpdatePayoutSubaccountRequest.MobileNumber),
                values: "Value is required");



            var expectedPayoutSubaccountsValidationException =
                new PayoutSubaccountsValidationException(invalidPaymentsException);

            // when
            ValueTask<UpdatePayoutSubaccount> UpdatePayoutSubaccountTask =
                this.payoutSubaccountService.PostUpdatePayoutSubaccountRequestAsync(string.Empty, updatePayoutSubaccount);

            PayoutSubaccountsValidationException actualPayoutSubaccountsValidationException =
                await Assert.ThrowsAsync<PayoutSubaccountsValidationException>(
                    UpdatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsValidationException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}