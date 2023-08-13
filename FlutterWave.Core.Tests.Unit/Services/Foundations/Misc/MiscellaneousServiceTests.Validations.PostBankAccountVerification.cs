



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Miscellaneous
{
    public partial class MiscellaneousServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnBankAccountVerificationIfBankAccountVerificationRequestIsNullAsync()
        {
            // given
            BankAccountVerification? nullBankAccountVerification = null;
            var nullBankAccountVerificationException = new NullMiscellaneousException();

            var exceptedMiscellaneousValidationException =
                new MiscellaneousValidationException(nullBankAccountVerificationException);

            // when
            ValueTask<BankAccountVerification> MiscellaneousTask =
                this.miscellaneousService.PostBankAccountVerificationAsync(nullBankAccountVerification);

            MiscellaneousValidationException actualMiscellaneousValidationException =
                await Assert.ThrowsAsync<MiscellaneousValidationException>(
                    MiscellaneousTask.AsTask);

            // then
            actualMiscellaneousValidationException.Should()
                .BeEquivalentTo(exceptedMiscellaneousValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBankAccountVerificationAsync(
                    It.IsAny<ExternalBankAccountVerificationRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnBankAccountVerificationIfRequestIsNullAsync()
        {
            // given
            var invalidMiscellaneous = new BankAccountVerification();
            invalidMiscellaneous.Request = null;

            var invalidMiscellaneousException =
                new InvalidMiscellaneousException();

            invalidMiscellaneousException.AddData(
                key: nameof(BankAccountVerificationRequest),
                values: "Value is required");


            var expectedMiscellaneousValidationException =
                new MiscellaneousValidationException(
                    invalidMiscellaneousException);

            // when
            ValueTask<BankAccountVerification> BankAccountVerificationTask =
                this.miscellaneousService.PostBankAccountVerificationAsync(invalidMiscellaneous);

            MiscellaneousValidationException actualMiscellaneousValidationException =
                await Assert.ThrowsAsync<MiscellaneousValidationException>(
                    BankAccountVerificationTask.AsTask);

            // then
            actualMiscellaneousValidationException.Should()
                .BeEquivalentTo(expectedMiscellaneousValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBankAccountVerificationAsync(
                    It.IsAny<ExternalBankAccountVerificationRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostBankAccountVerificationIfBankAccountVerificationRequestIsInvalidAsync(
            string invalidAccountBank, string invalidAccountNumber)
        {
            // given
            var BankAccountVerification = new BankAccountVerification
            {
                Request = new BankAccountVerificationRequest
                {
                    AccountBank = invalidAccountBank,
                    AccountNumber = invalidAccountNumber,

                }
            };

            var invalidMiscellaneousException = new InvalidMiscellaneousException();

            invalidMiscellaneousException.AddData(
                   key: nameof(BankAccountVerificationRequest.AccountBank),
                   values: "Value is required");

            invalidMiscellaneousException.AddData(
               key: nameof(BankAccountVerificationRequest.AccountNumber),
               values: "Value is required");



            var expectedMiscellaneousValidationException =
                new MiscellaneousValidationException(invalidMiscellaneousException);

            // when
            ValueTask<BankAccountVerification> BankAccountVerificationTask =
                this.miscellaneousService.PostBankAccountVerificationAsync(BankAccountVerification);

            MiscellaneousValidationException actualMiscellaneousValidationException =
                await Assert.ThrowsAsync<MiscellaneousValidationException>(BankAccountVerificationTask.AsTask);

            // then
            actualMiscellaneousValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostBankAccountVerificationIfBankAccountVerificationRequestIsEmptyAsync()
        {
            // given
            var BankAccountVerification = new BankAccountVerification
            {
                Request = new BankAccountVerificationRequest
                {
                    AccountBank = string.Empty,
                    AccountNumber = string.Empty,


                }
            };

            var invalidMiscellaneousException = new InvalidMiscellaneousException();


            invalidMiscellaneousException.AddData(
                   key: nameof(BankAccountVerificationRequest.AccountBank),
                   values: "Value is required");

            invalidMiscellaneousException.AddData(
               key: nameof(BankAccountVerificationRequest.AccountNumber),
               values: "Value is required");



            var expectedMiscellaneousValidationException =
                new MiscellaneousValidationException(invalidMiscellaneousException);

            // when
            ValueTask<BankAccountVerification> BankAccountVerificationTask =
                this.miscellaneousService.PostBankAccountVerificationAsync(BankAccountVerification);

            MiscellaneousValidationException actualMiscellaneousValidationException =
                await Assert.ThrowsAsync<MiscellaneousValidationException>(
                    BankAccountVerificationTask.AsTask);

            // then
            actualMiscellaneousValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}