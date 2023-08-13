using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Banks
{
    public partial class BanksServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveBanksByCountryIfUrlNotFoundAsync()
        {
            // given
            string someCountryCode = GetRandomString();

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
                broker.GetAllBanksByCountryAsync(someCountryCode))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Bank> retrieveBanksByCountryTask =
               this.banksService.GetAllBanksByCountryAsync(someCountryCode);

            BanksDependencyException
                actualBanksDependencyException =
                    await Assert.ThrowsAsync<BanksDependencyException>(
                        retrieveBanksByCountryTask.AsTask);

            // then
            actualBanksDependencyException.Should().BeEquivalentTo(
                expectedBanksDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBanksByCountryAsync(someCountryCode),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveBanksByCountryIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string someCountryCode = GetRandomString();

            var unauthorizedBanksException =
                new UnauthorizedBanksException(unauthorizedException);

            var expectedBanksDependencyException =
                new BanksDependencyException(unauthorizedBanksException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetAllBanksByCountryAsync(someCountryCode))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<Bank> retrieveBanksByCountryTask =
               this.banksService.GetAllBanksByCountryAsync(someCountryCode);

            BanksDependencyException
                actualBanksDependencyException =
                    await Assert.ThrowsAsync<BanksDependencyException>(
                        retrieveBanksByCountryTask.AsTask);

            // then
            actualBanksDependencyException.Should().BeEquivalentTo(
                expectedBanksDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBanksByCountryAsync(someCountryCode),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveBanksByCountryIfNotFoundOccurredAsync()
        {
            // given
            string someBanksName = GetRandomString();

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
                broker.GetAllBanksByCountryAsync(someBanksName))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Bank> retrieveBanksByCountryTask =
               this.banksService.GetAllBanksByCountryAsync(someBanksName);

            BanksDependencyValidationException
                actualBanksDependencyValidationException =
                    await Assert.ThrowsAsync<BanksDependencyValidationException>(
                        retrieveBanksByCountryTask.AsTask);

            // then
            actualBanksDependencyValidationException.Should().BeEquivalentTo(
                expectedBanksDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBanksByCountryAsync(someBanksName),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveBanksByCountryIfBadRequestOccurredAsync()
        {
            // given
            string someBanksName = GetRandomString();

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
                broker.GetAllBanksByCountryAsync(someBanksName))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Bank> retrieveBanksByCountryTask =
               this.banksService.GetAllBanksByCountryAsync(someBanksName);

            BanksDependencyValidationException
                actualBanksDependencyValidationException =
                    await Assert.ThrowsAsync<BanksDependencyValidationException>(
                        retrieveBanksByCountryTask.AsTask);

            // then
            actualBanksDependencyValidationException.Should().BeEquivalentTo(
                expectedBanksDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBanksByCountryAsync(someBanksName),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveBanksByCountryIfTooManyRequestsOccurredAsync()
        {
            // given
            string someBanksName = GetRandomString();

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
                 broker.GetAllBanksByCountryAsync(someBanksName))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Bank> retrieveBanksByCountryTask =
               this.banksService.GetAllBanksByCountryAsync(someBanksName);

            BanksDependencyValidationException actualBanksDependencyValidationException =
                await Assert.ThrowsAsync<BanksDependencyValidationException>(
                    retrieveBanksByCountryTask.AsTask);

            // then
            actualBanksDependencyValidationException.Should().BeEquivalentTo(
                expectedBanksDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBanksByCountryAsync(someBanksName),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveBanksByCountryIfHttpResponseErrorOccurredAsync()
        {
            // given
            string someBanksName = GetRandomString();

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
                 broker.GetAllBanksByCountryAsync(someBanksName))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Bank> retrieveBanksByCountryTask =
               this.banksService.GetAllBanksByCountryAsync(someBanksName);

            BanksDependencyException actualBanksDependencyException =
                await Assert.ThrowsAsync<BanksDependencyException>(
                    retrieveBanksByCountryTask.AsTask);

            // then
            actualBanksDependencyException.Should().BeEquivalentTo(
                expectedBanksDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBanksByCountryAsync(someBanksName),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveBanksByCountryIfServiceErrorOccurredAsync()
        {
            // given
            string someBanksName = GetRandomString();
            var serviceException = new Exception();

            var failedBanksServiceException =
                new FailedBanksServiceException(serviceException);

            var expectedBanksServiceException =
                new BanksServiceException(failedBanksServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllBanksByCountryAsync(someBanksName))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Bank> retrieveBanksByCountryTask =
               this.banksService.GetAllBanksByCountryAsync(someBanksName);

            BanksServiceException actualBanksServiceException =
                await Assert.ThrowsAsync<BanksServiceException>(
                    retrieveBanksByCountryTask.AsTask);

            // then
            actualBanksServiceException.Should().BeEquivalentTo(
                expectedBanksServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBanksByCountryAsync(someBanksName),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}