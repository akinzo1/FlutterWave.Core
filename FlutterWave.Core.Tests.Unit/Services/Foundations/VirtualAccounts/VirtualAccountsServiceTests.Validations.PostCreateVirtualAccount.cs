



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualAccounts
{
    public partial class VirtualAccountsServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateVirtualAccountsIfCreateVirtualAccountRequestIsNullAsync()
        {
            // given



            CreateVirtualAccounts? nullCreateVirtualAccounts = null;
            var nullCreateVirtualAccountsException = new NullVirtualAccountsException();

            var exceptedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(nullCreateVirtualAccountsException);

            // when
            ValueTask<CreateVirtualAccounts> VirtualAccountsTask =
                this.virtualAccountsService.PostCreateVirtualAccountRequestAsync(nullCreateVirtualAccounts);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(
                    VirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should()
                .BeEquivalentTo(exceptedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualAccountRequestAsync(
                    It.IsAny<ExternalCreateVirtualAccountRequest>()),
                    Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateVirtualAccountsIfRequestIsNullAsync()
        {
            // given


            var invalidVirtualAccounts = new CreateVirtualAccounts();
            invalidVirtualAccounts.Request = null;

            var invalidVirtualAccountsException =
                new InvalidVirtualAccountsException();

            invalidVirtualAccountsException.AddData(
                key: nameof(CreateVirtualAccountRequest),
                values: "Value is required");


            var expectedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(
                    invalidVirtualAccountsException);

            // when
            ValueTask<CreateVirtualAccounts> CreateVirtualAccountsTask =
                this.virtualAccountsService.PostCreateVirtualAccountRequestAsync(invalidVirtualAccounts);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(
                    CreateVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should()
                .BeEquivalentTo(expectedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualAccountRequestAsync(
                    It.IsAny<ExternalCreateVirtualAccountRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, null, false, null, null, null, null)]
        [InlineData("", "", "", false, "", "", "", "")]
        [InlineData(" ", " ", " ", false, " ", " ", " ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostCreateVirtualAccountsIfCreateVirtualAccountRequestIsInvalidAsync(
            string invalidStatus, string invalidEmail, string invalidFirstName, bool invalidIsPermanent, string invalidLastName,
            string invalidNarration, string invalidPhoneNumber, string invalidTxRef

            )
        {
            // given


            var validateVirtualAccounts = new CreateVirtualAccounts
            {
                Request = new CreateVirtualAccountRequest
                {

                    Bvn = invalidStatus,
                    Email = invalidEmail,
                    FirstName = invalidFirstName,
                    IsPermanent = invalidIsPermanent,
                    LastName = invalidLastName,
                    Narration = invalidNarration,
                    PhoneNumber = invalidPhoneNumber,
                    TxRef = invalidTxRef

                }
            };

            var invalidVirtualAccountsException = new InvalidVirtualAccountsException();

            invalidVirtualAccountsException.AddData(
                   key: nameof(CreateVirtualAccountRequest.TxRef),
                   values: "Value is required");

            invalidVirtualAccountsException.AddData(
                   key: nameof(CreateVirtualAccountRequest.Narration),
                   values: "Value is required");

            invalidVirtualAccountsException.AddData(
                   key: nameof(CreateVirtualAccountRequest.PhoneNumber),
                   values: "Value is required");



            invalidVirtualAccountsException.AddData(
                   key: nameof(CreateVirtualAccountRequest.Email),
                   values: "Value is required");

            invalidVirtualAccountsException.AddData(
                   key: nameof(CreateVirtualAccountRequest.LastName),
                   values: "Value is required");

            invalidVirtualAccountsException.AddData(
                   key: nameof(CreateVirtualAccountRequest.FirstName),
                   values: "Value is required");

            invalidVirtualAccountsException.AddData(
                   key: nameof(CreateVirtualAccountRequest.Bvn),
                   values: "Value is required");


            var expectedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(invalidVirtualAccountsException);

            // when
            ValueTask<CreateVirtualAccounts> CreateVirtualAccountsTask =
                this.virtualAccountsService.PostCreateVirtualAccountRequestAsync(validateVirtualAccounts);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(CreateVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCreateVirtualAccountsIfCreateVirtualAccountRequestIsEmptyAsync()
        {
            // given


            var validateVirtualAccounts = new CreateVirtualAccounts
            {
                Request = new CreateVirtualAccountRequest
                {

                    Bvn = string.Empty,
                    Email = string.Empty,
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    Narration = string.Empty,
                    PhoneNumber = string.Empty,
                    TxRef = string.Empty

                }
            };

            var invalidVirtualAccountsException = new InvalidVirtualAccountsException();


            invalidVirtualAccountsException.AddData(
                     key: nameof(CreateVirtualAccountRequest.TxRef),
                     values: "Value is required");

            invalidVirtualAccountsException.AddData(
                      key: nameof(CreateVirtualAccountRequest.PhoneNumber),
                      values: "Value is required");

            invalidVirtualAccountsException.AddData(
                   key: nameof(CreateVirtualAccountRequest.Narration),
                   values: "Value is required");


            invalidVirtualAccountsException.AddData(
                   key: nameof(CreateVirtualAccountRequest.Email),
                   values: "Value is required");

            invalidVirtualAccountsException.AddData(
                   key: nameof(CreateVirtualAccountRequest.LastName),
                   values: "Value is required");

            invalidVirtualAccountsException.AddData(
                   key: nameof(CreateVirtualAccountRequest.FirstName),
                   values: "Value is required");

            invalidVirtualAccountsException.AddData(
                   key: nameof(CreateVirtualAccountRequest.Bvn),
                   values: "Value is required");



            var expectedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(invalidVirtualAccountsException);

            // when
            ValueTask<CreateVirtualAccounts> CreateVirtualAccountsTask =
                this.virtualAccountsService.PostCreateVirtualAccountRequestAsync(validateVirtualAccounts);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(
                    CreateVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}