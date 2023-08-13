



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualAccounts
{
    public partial class VirtualAccountsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnDeleteVirtualAccountIfUrlNotFoundAsync()
        {
            // given
            DeleteVirtualAccounts inputRandomDeleteVirtualAccounts = CreateRandomDeleteVirtualAccount();
            string inputOrderReference = GetRandomString();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationVirtualAccountsException =
                new InvalidConfigurationVirtualAccountsException(
                    httpResponseUrlNotFoundException);

            var expectedVirtualAccountsDependencyException =
                new VirtualAccountsDependencyException(
                    invalidConfigurationVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.DeleteVirtualAccountsRequestAsync(It.IsAny<ExternalDeleteVirtualAccountRequest>(), inputOrderReference))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<DeleteVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.DeleteVirtualAccountsRequestAsync(inputRandomDeleteVirtualAccounts, inputOrderReference);

            VirtualAccountsDependencyException
                actualVirtualAccountsDependencyException =
                    await Assert.ThrowsAsync<VirtualAccountsDependencyException>(
                        retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteVirtualAccountsRequestAsync(It.IsAny<ExternalDeleteVirtualAccountRequest>(), inputOrderReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnDeleteVirtualAccountIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            DeleteVirtualAccounts inputRandomDeleteVirtualAccounts = CreateRandomDeleteVirtualAccount();
            string inputOrderReference = GetRandomString();

            var unauthorizedVirtualAccountsException =
                new UnauthorizedVirtualAccountsException(unauthorizedException);

            var expectedVirtualAccountsDependencyException =
                new VirtualAccountsDependencyException(unauthorizedVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.DeleteVirtualAccountsRequestAsync(It.IsAny<ExternalDeleteVirtualAccountRequest>(), inputOrderReference))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<DeleteVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.DeleteVirtualAccountsRequestAsync(inputRandomDeleteVirtualAccounts, inputOrderReference);

            VirtualAccountsDependencyException
                actualVirtualAccountsDependencyException =
                    await Assert.ThrowsAsync<VirtualAccountsDependencyException>(
                        retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteVirtualAccountsRequestAsync(It.IsAny<ExternalDeleteVirtualAccountRequest>(), inputOrderReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDeleteVirtualAccountIfNotFoundOccurredAsync()
        {
            // given
            DeleteVirtualAccounts inputRandomDeleteVirtualAccounts = CreateRandomDeleteVirtualAccount();
            string inputOrderReference = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundVirtualAccountsException =
                new NotFoundVirtualAccountsException(
                    httpResponseNotFoundException);

            var expectedVirtualAccountsDependencyValidationException =
                new VirtualAccountsDependencyValidationException(
                    notFoundVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.DeleteVirtualAccountsRequestAsync(It.IsAny<ExternalDeleteVirtualAccountRequest>(), inputOrderReference))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<DeleteVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.DeleteVirtualAccountsRequestAsync(inputRandomDeleteVirtualAccounts, inputOrderReference);

            VirtualAccountsDependencyValidationException
                actualVirtualAccountsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualAccountsDependencyValidationException>(
                        retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteVirtualAccountsRequestAsync(It.IsAny<ExternalDeleteVirtualAccountRequest>(), inputOrderReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDeleteVirtualAccountIfBadRequestOccurredAsync()
        {
            // given
            DeleteVirtualAccounts inputRandomDeleteVirtualAccounts = CreateRandomDeleteVirtualAccount();
            string inputOrderReference = GetRandomString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidVirtualAccountsException =
                new InvalidVirtualAccountsException(
                    httpResponseBadRequestException);

            var expectedVirtualAccountsDependencyValidationException =
                new VirtualAccountsDependencyValidationException(
                    invalidVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.DeleteVirtualAccountsRequestAsync(It.IsAny<ExternalDeleteVirtualAccountRequest>(), inputOrderReference))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<DeleteVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.DeleteVirtualAccountsRequestAsync(inputRandomDeleteVirtualAccounts, inputOrderReference);

            VirtualAccountsDependencyValidationException
                actualVirtualAccountsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualAccountsDependencyValidationException>(
                        retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteVirtualAccountsRequestAsync(It.IsAny<ExternalDeleteVirtualAccountRequest>(), inputOrderReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDeleteVirtualAccountIfTooManyRequestsOccurredAsync()
        {
            // given
            DeleteVirtualAccounts inputRandomDeleteVirtualAccounts = CreateRandomDeleteVirtualAccount();
            string inputOrderReference = GetRandomString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallVirtualAccountsException =
                new ExcessiveCallVirtualAccountsException(
                    httpResponseTooManyRequestsException);

            var expectedVirtualAccountsDependencyValidationException =
                new VirtualAccountsDependencyValidationException(
                    excessiveCallVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.DeleteVirtualAccountsRequestAsync(It.IsAny<ExternalDeleteVirtualAccountRequest>(), inputOrderReference))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<DeleteVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.DeleteVirtualAccountsRequestAsync(inputRandomDeleteVirtualAccounts, inputOrderReference);

            VirtualAccountsDependencyValidationException actualVirtualAccountsDependencyValidationException =
                await Assert.ThrowsAsync<VirtualAccountsDependencyValidationException>(
                    retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteVirtualAccountsRequestAsync(It.IsAny<ExternalDeleteVirtualAccountRequest>(), inputOrderReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnDeleteVirtualAccountIfHttpResponseErrorOccurredAsync()
        {
            // given
            DeleteVirtualAccounts inputRandomDeleteVirtualAccounts = CreateRandomDeleteVirtualAccount();
            string inputOrderReference = GetRandomString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerVirtualAccountsException =
                new FailedServerVirtualAccountsException(
                    httpResponseException);

            var expectedVirtualAccountsDependencyException =
                new VirtualAccountsDependencyException(
                    failedServerVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.DeleteVirtualAccountsRequestAsync(It.IsAny<ExternalDeleteVirtualAccountRequest>(), inputOrderReference))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<DeleteVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.DeleteVirtualAccountsRequestAsync(inputRandomDeleteVirtualAccounts, inputOrderReference);

            VirtualAccountsDependencyException actualVirtualAccountsDependencyException =
                await Assert.ThrowsAsync<VirtualAccountsDependencyException>(
                    retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteVirtualAccountsRequestAsync(It.IsAny<ExternalDeleteVirtualAccountRequest>(), inputOrderReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnDeleteVirtualAccountIfServiceErrorOccurredAsync()
        {
            // given
            DeleteVirtualAccounts inputRandomDeleteVirtualAccounts = CreateRandomDeleteVirtualAccount();
            string inputOrderReference = GetRandomString();
            var serviceException = new Exception();

            var failedVirtualAccountsServiceException =
                new FailedVirtualAccountsServiceException(serviceException);

            var expectedVirtualAccountsServiceException =
                new VirtualAccountsServiceException(failedVirtualAccountsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.DeleteVirtualAccountsRequestAsync(It.IsAny<ExternalDeleteVirtualAccountRequest>(), inputOrderReference))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<DeleteVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.DeleteVirtualAccountsRequestAsync(inputRandomDeleteVirtualAccounts, inputOrderReference);

            VirtualAccountsServiceException actualVirtualAccountsServiceException =
                await Assert.ThrowsAsync<VirtualAccountsServiceException>(
                    retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsServiceException.Should().BeEquivalentTo(
                expectedVirtualAccountsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteVirtualAccountsRequestAsync(It.IsAny<ExternalDeleteVirtualAccountRequest>(), inputOrderReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}