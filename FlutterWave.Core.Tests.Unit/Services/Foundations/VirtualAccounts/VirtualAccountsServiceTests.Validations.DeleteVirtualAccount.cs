



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualAccounts
{
    public partial class VirtualAccountsServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnDeleteVirtualAccountsIfDeleteVirtualAccountRequestIsNullAsync()
        {
            // given
            string inputVirtualAccountsReference = GetRandomString();


            DeleteVirtualAccounts? nullDeleteVirtualAccounts = null;
            var nullDeleteVirtualAccountsException = new NullVirtualAccountsException();

            var exceptedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(nullDeleteVirtualAccountsException);

            // when
            ValueTask<DeleteVirtualAccounts> VirtualAccountsTask =
                this.virtualAccountsService.DeleteVirtualAccountsRequestAsync(nullDeleteVirtualAccounts, inputVirtualAccountsReference);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(
                    VirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should()
                .BeEquivalentTo(exceptedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteVirtualAccountsRequestAsync(
                    It.IsAny<ExternalDeleteVirtualAccountRequest>(), inputVirtualAccountsReference),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnDeleteVirtualAccountsIfRequestIsNullAsync()
        {
            // given
            string inputVirtualAccountsReference = GetRandomString();

            var invalidVirtualAccounts = new DeleteVirtualAccounts();
            invalidVirtualAccounts.Request = null;

            var invalidVirtualAccountsException =
                new InvalidVirtualAccountsException();

            invalidVirtualAccountsException.AddData(
                key: nameof(DeleteVirtualAccountRequest),
                values: "Value is required");


            var expectedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(
                    invalidVirtualAccountsException);

            // when
            ValueTask<DeleteVirtualAccounts> DeleteVirtualAccountsTask =
                this.virtualAccountsService.DeleteVirtualAccountsRequestAsync(invalidVirtualAccounts, inputVirtualAccountsReference);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(
                    DeleteVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should()
                .BeEquivalentTo(expectedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteVirtualAccountsRequestAsync(
                    It.IsAny<ExternalDeleteVirtualAccountRequest>(), inputVirtualAccountsReference),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnPostDeleteVirtualAccountsIfDeleteVirtualAccountRequestIsInvalidAsync(
            string invalidStatus

            )
        {
            // given
            string inputVirtualAccountsReference = GetRandomString();

            var validateVirtualAccounts = new DeleteVirtualAccounts
            {
                Request = new DeleteVirtualAccountRequest
                {

                    Status = invalidStatus

                }
            };

            var invalidVirtualAccountsException = new InvalidVirtualAccountsException();

            invalidVirtualAccountsException.AddData(
                   key: nameof(DeleteVirtualAccountRequest.Status),
                   values: "Value is required");



            var expectedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(invalidVirtualAccountsException);

            // when
            ValueTask<DeleteVirtualAccounts> DeleteVirtualAccountsTask =
                this.virtualAccountsService.DeleteVirtualAccountsRequestAsync(validateVirtualAccounts, inputVirtualAccountsReference);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(DeleteVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostDeleteVirtualAccountsIfDeleteVirtualAccountRequestIsEmptyAsync()
        {
            // given
            string inputVirtualAccountsReference = GetRandomString();

            var validateVirtualAccounts = new DeleteVirtualAccounts
            {
                Request = new DeleteVirtualAccountRequest
                {

                    Status = string.Empty

                }
            };

            var invalidVirtualAccountsException = new InvalidVirtualAccountsException();


            invalidVirtualAccountsException.AddData(
                   key: nameof(DeleteVirtualAccountRequest.Status),
                   values: "Value is required");



            var expectedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(invalidVirtualAccountsException);

            // when
            ValueTask<DeleteVirtualAccounts> DeleteVirtualAccountsTask =
                this.virtualAccountsService.DeleteVirtualAccountsRequestAsync(validateVirtualAccounts, inputVirtualAccountsReference);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(
                    DeleteVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}