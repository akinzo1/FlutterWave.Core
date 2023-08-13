



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualAccounts
{
    public partial class VirtualAccountsServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdateBvnVirtualAccountsIfUpdateVirtualAccountBvnRequestIsNullAsync()
        {
            // given
            string inputVirtualAccountsReference = GetRandomString();


            UpdateBvnVirtualAccounts? nullUpdateBvnVirtualAccounts = null;
            var nullUpdateBvnVirtualAccountsException = new NullVirtualAccountsException();

            var exceptedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(nullUpdateBvnVirtualAccountsException);

            // when
            ValueTask<UpdateBvnVirtualAccounts> VirtualAccountsTask =
                this.virtualAccountsService.UpdateVirtualAccountsBvnRequestAsync(nullUpdateBvnVirtualAccounts, inputVirtualAccountsReference);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(
                    VirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should()
                .BeEquivalentTo(exceptedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdateVirtualAccountsBvnRequestAsync(
                    It.IsAny<ExternalUpdateVirtualAccountBvnRequest>(), inputVirtualAccountsReference),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdateBvnVirtualAccountsIfRequestIsNullAsync()
        {
            // given
            string inputVirtualAccountsReference = GetRandomString();

            var invalidVirtualAccounts = new UpdateBvnVirtualAccounts();
            invalidVirtualAccounts.Request = null;

            var invalidVirtualAccountsException =
                new InvalidVirtualAccountsException();

            invalidVirtualAccountsException.AddData(
                key: nameof(UpdateVirtualAccountBvnRequest),
                values: "Value is required");


            var expectedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(
                    invalidVirtualAccountsException);

            // when
            ValueTask<UpdateBvnVirtualAccounts> UpdateBvnVirtualAccountsTask =
                this.virtualAccountsService.UpdateVirtualAccountsBvnRequestAsync(invalidVirtualAccounts, inputVirtualAccountsReference);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(
                    UpdateBvnVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should()
                .BeEquivalentTo(expectedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdateVirtualAccountsBvnRequestAsync(
                    It.IsAny<ExternalUpdateVirtualAccountBvnRequest>(), inputVirtualAccountsReference),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnPostUpdateBvnVirtualAccountsIfUpdateVirtualAccountBvnRequestIsInvalidAsync(
            string invalidBvn

            )
        {
            // given
            string inputVirtualAccountsReference = GetRandomString();

            var validateVirtualAccounts = new UpdateBvnVirtualAccounts
            {
                Request = new UpdateVirtualAccountBvnRequest
                {

                    Bvn = invalidBvn

                }
            };

            var invalidVirtualAccountsException = new InvalidVirtualAccountsException();

            invalidVirtualAccountsException.AddData(
                   key: nameof(UpdateVirtualAccountBvnRequest.Bvn),
                   values: "Value is required");



            var expectedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(invalidVirtualAccountsException);

            // when
            ValueTask<UpdateBvnVirtualAccounts> UpdateBvnVirtualAccountsTask =
                this.virtualAccountsService.UpdateVirtualAccountsBvnRequestAsync(validateVirtualAccounts, inputVirtualAccountsReference);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(UpdateBvnVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostUpdateBvnVirtualAccountsIfUpdateVirtualAccountBvnRequestIsEmptyAsync()
        {
            // given
            string inputVirtualAccountsReference = GetRandomString();

            var validateVirtualAccounts = new UpdateBvnVirtualAccounts
            {
                Request = new UpdateVirtualAccountBvnRequest
                {

                    Bvn = string.Empty

                }
            };

            var invalidVirtualAccountsException = new InvalidVirtualAccountsException();


            invalidVirtualAccountsException.AddData(
                   key: nameof(UpdateVirtualAccountBvnRequest.Bvn),
                   values: "Value is required");



            var expectedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(invalidVirtualAccountsException);

            // when
            ValueTask<UpdateBvnVirtualAccounts> UpdateBvnVirtualAccountsTask =
                this.virtualAccountsService.UpdateVirtualAccountsBvnRequestAsync(validateVirtualAccounts, inputVirtualAccountsReference);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(
                    UpdateBvnVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}