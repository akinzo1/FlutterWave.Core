using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Banks
{
    public partial class BanksServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveBanksByBankCodeIfUrlNotFoundAsync()
        {
            // given
            int someBankCode = GetRandomNumber();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationBanksException =
                new InvalidConfigurationBanksException(
                    message: "Invalid Banks configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedBanksDependencyException =
                new BanksDependencyException(
                    message: "Banks dependency error occurred, contact support.",
                    invalidConfigurationBanksException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllBankBranchesByIdAsync(someBankCode))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BankBranches> retrieveBanksByBankTask =
               this.banksService.GetAllBankBranchesByBankCodeAsync(someBankCode);

            BanksDependencyException
                actualBanksDependencyException =
                    await Assert.ThrowsAsync<BanksDependencyException>(
                        retrieveBanksByBankTask.AsTask);

            // then
            actualBanksDependencyException.Should().BeEquivalentTo(
                expectedBanksDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBankBranchesByIdAsync(someBankCode),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveBanksByBankCodeIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            int someBankCode = GetRandomNumber();

            var unauthorizedBanksException =
                new UnauthorizedBanksException(unauthorizedException);

            var expectedBanksDependencyException =
                new BanksDependencyException(unauthorizedBanksException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetAllBankBranchesByIdAsync(someBankCode))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BankBranches> retrieveBanksByBankTask =
               this.banksService.GetAllBankBranchesByBankCodeAsync(someBankCode);

            BanksDependencyException
                actualBanksDependencyException =
                    await Assert.ThrowsAsync<BanksDependencyException>(
                        retrieveBanksByBankTask.AsTask);

            // then
            actualBanksDependencyException.Should().BeEquivalentTo(
                expectedBanksDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBankBranchesByIdAsync(someBankCode),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveBanksByBankCodeIfNotFoundOccurredAsync()
        {
            // given
            int someBanksName = GetRandomNumber();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundBanksException =
                new NotFoundBanksException(
                    message: "Not found Banks error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedBanksDependencyValidationException =
                new BanksDependencyValidationException(
                    message: "Banks dependency validation error occurred, contact support.",
                    notFoundBanksException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllBankBranchesByIdAsync(someBanksName))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BankBranches> retrieveBanksByBankTask =
               this.banksService.GetAllBankBranchesByBankCodeAsync(someBanksName);

            BanksDependencyValidationException
                actualBanksDependencyValidationException =
                    await Assert.ThrowsAsync<BanksDependencyValidationException>(
                        retrieveBanksByBankTask.AsTask);

            // then
            actualBanksDependencyValidationException.Should().BeEquivalentTo(
                expectedBanksDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBankBranchesByIdAsync(someBanksName),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveBanksByBankCodeIfBadRequestOccurredAsync()
        {
            // given
            int someBanksName = GetRandomNumber();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidBanksException =
                new InvalidBanksException(
                    message: "Invalid Banks error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedBanksDependencyValidationException =
                new BanksDependencyValidationException(
                    message: "Banks dependency validation error occurred, contact support.",
                    invalidBanksException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllBankBranchesByIdAsync(someBanksName))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BankBranches> retrieveBanksByBankTask =
               this.banksService.GetAllBankBranchesByBankCodeAsync(someBanksName);

            BanksDependencyValidationException
                actualBanksDependencyValidationException =
                    await Assert.ThrowsAsync<BanksDependencyValidationException>(
                        retrieveBanksByBankTask.AsTask);

            // then
            actualBanksDependencyValidationException.Should().BeEquivalentTo(
                expectedBanksDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBankBranchesByIdAsync(someBanksName),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveBanksByBankCodeIfTooManyRequestsOccurredAsync()
        {
            // given
            int someBanksName = GetRandomNumber();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallBanksException =
                new ExcessiveCallBanksException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedBanksDependencyValidationException =
                new BanksDependencyValidationException(
                    message: "Banks dependency validation error occurred, contact support.",
                    excessiveCallBanksException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetAllBankBranchesByIdAsync(someBanksName))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BankBranches> retrieveBanksByBankTask =
               this.banksService.GetAllBankBranchesByBankCodeAsync(someBanksName);

            BanksDependencyValidationException actualBanksDependencyValidationException =
                await Assert.ThrowsAsync<BanksDependencyValidationException>(
                    retrieveBanksByBankTask.AsTask);

            // then
            actualBanksDependencyValidationException.Should().BeEquivalentTo(
                expectedBanksDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBankBranchesByIdAsync(someBanksName),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveBanksByBankCodeIfHttpResponseErrorOccurredAsync()
        {
            // given
            int someBanksName = GetRandomNumber();

            var httpResponseException =
                new HttpResponseException();

            var failedServerBanksException =
                new FailedServerBanksException(
                    message: "Failed Bank server error occurred, contact support.",
                    httpResponseException);

            var expectedBanksDependencyException =
                new BanksDependencyException(
                    message: "Banks dependency error occurred, contact support.",
                    failedServerBanksException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetAllBankBranchesByIdAsync(someBanksName))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BankBranches> retrieveBanksByBankTask =
               this.banksService.GetAllBankBranchesByBankCodeAsync(someBanksName);

            BanksDependencyException actualBanksDependencyException =
                await Assert.ThrowsAsync<BanksDependencyException>(
                    retrieveBanksByBankTask.AsTask);

            // then
            actualBanksDependencyException.Should().BeEquivalentTo(
                expectedBanksDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBankBranchesByIdAsync(someBanksName),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveBanksByBankCodeIfServiceErrorOccurredAsync()
        {
            // given
            int someBanksName = GetRandomNumber();
            var serviceException = new Exception();

            var failedBanksServiceException =
                new FailedBanksServiceException(serviceException);

            var expectedBanksServiceException =
                new BanksServiceException(failedBanksServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllBankBranchesByIdAsync(someBanksName))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BankBranches> retrieveBanksByBankTask =
               this.banksService.GetAllBankBranchesByBankCodeAsync(someBanksName);

            BanksServiceException actualBanksServiceException =
                await Assert.ThrowsAsync<BanksServiceException>(
                    retrieveBanksByBankTask.AsTask);

            // then
            actualBanksServiceException.Should().BeEquivalentTo(
                expectedBanksServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBankBranchesByIdAsync(someBanksName),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}