



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
        public async Task ShouldThrowDependencyExceptionOnPostBulkVirtualAccountsIfUrlNotFoundAsync()
        {
            // given
            BulkCreateVirtualAccounts inputRandomBulkCreateVirtualAccounts = CreateRandomBulkVirtualAccount();


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationVirtualAccountsException =
                new InvalidConfigurationVirtualAccountsException(
                    httpResponseUrlNotFoundException);

            var expectedVirtualAccountsDependencyException =
                new VirtualAccountsDependencyException(
                    invalidConfigurationVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBulkCreateVirtualAccountsRequestAsync(It.IsAny<ExternalCreateBulkVirtualAccountsRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BulkCreateVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.PostBulkCreateVirtualAccountsRequestAsync(inputRandomBulkCreateVirtualAccounts);

            VirtualAccountsDependencyException
                actualVirtualAccountsDependencyException =
                    await Assert.ThrowsAsync<VirtualAccountsDependencyException>(
                        retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBulkCreateVirtualAccountsRequestAsync(It.IsAny<ExternalCreateBulkVirtualAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostBulkVirtualAccountsIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            BulkCreateVirtualAccounts inputRandomBulkCreateVirtualAccounts = CreateRandomBulkVirtualAccount();


            var unauthorizedVirtualAccountsException =
                new UnauthorizedVirtualAccountsException(unauthorizedException);

            var expectedVirtualAccountsDependencyException =
                new VirtualAccountsDependencyException(unauthorizedVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostBulkCreateVirtualAccountsRequestAsync(It.IsAny<ExternalCreateBulkVirtualAccountsRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BulkCreateVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.PostBulkCreateVirtualAccountsRequestAsync(inputRandomBulkCreateVirtualAccounts);

            VirtualAccountsDependencyException
                actualVirtualAccountsDependencyException =
                    await Assert.ThrowsAsync<VirtualAccountsDependencyException>(
                        retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBulkCreateVirtualAccountsRequestAsync(It.IsAny<ExternalCreateBulkVirtualAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostBulkVirtualAccountsIfNotFoundOccurredAsync()
        {
            // given
            BulkCreateVirtualAccounts inputRandomBulkCreateVirtualAccounts = CreateRandomBulkVirtualAccount();


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundVirtualAccountsException =
                new NotFoundVirtualAccountsException(
                    httpResponseNotFoundException);

            var expectedVirtualAccountsDependencyValidationException =
                new VirtualAccountsDependencyValidationException(
                    notFoundVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBulkCreateVirtualAccountsRequestAsync(It.IsAny<ExternalCreateBulkVirtualAccountsRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BulkCreateVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.PostBulkCreateVirtualAccountsRequestAsync(inputRandomBulkCreateVirtualAccounts);

            VirtualAccountsDependencyValidationException
                actualVirtualAccountsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualAccountsDependencyValidationException>(
                        retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBulkCreateVirtualAccountsRequestAsync(It.IsAny<ExternalCreateBulkVirtualAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostBulkVirtualAccountsIfBadRequestOccurredAsync()
        {
            // given
            BulkCreateVirtualAccounts inputRandomBulkCreateVirtualAccounts = CreateRandomBulkVirtualAccount();


            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidVirtualAccountsException =
                new InvalidVirtualAccountsException(
                    httpResponseBadRequestException);

            var expectedVirtualAccountsDependencyValidationException =
                new VirtualAccountsDependencyValidationException(
                    invalidVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBulkCreateVirtualAccountsRequestAsync(It.IsAny<ExternalCreateBulkVirtualAccountsRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BulkCreateVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.PostBulkCreateVirtualAccountsRequestAsync(inputRandomBulkCreateVirtualAccounts);

            VirtualAccountsDependencyValidationException
                actualVirtualAccountsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualAccountsDependencyValidationException>(
                        retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBulkCreateVirtualAccountsRequestAsync(It.IsAny<ExternalCreateBulkVirtualAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostBulkVirtualAccountsIfTooManyRequestsOccurredAsync()
        {
            // given
            BulkCreateVirtualAccounts inputRandomBulkCreateVirtualAccounts = CreateRandomBulkVirtualAccount();


            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallVirtualAccountsException =
                new ExcessiveCallVirtualAccountsException(
                    httpResponseTooManyRequestsException);

            var expectedVirtualAccountsDependencyValidationException =
                new VirtualAccountsDependencyValidationException(
                    excessiveCallVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostBulkCreateVirtualAccountsRequestAsync(It.IsAny<ExternalCreateBulkVirtualAccountsRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BulkCreateVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.PostBulkCreateVirtualAccountsRequestAsync(inputRandomBulkCreateVirtualAccounts);

            VirtualAccountsDependencyValidationException actualVirtualAccountsDependencyValidationException =
                await Assert.ThrowsAsync<VirtualAccountsDependencyValidationException>(
                    retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBulkCreateVirtualAccountsRequestAsync(It.IsAny<ExternalCreateBulkVirtualAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostBulkVirtualAccountsIfHttpResponseErrorOccurredAsync()
        {
            // given
            BulkCreateVirtualAccounts inputRandomBulkCreateVirtualAccounts = CreateRandomBulkVirtualAccount();


            var httpResponseException =
                new HttpResponseException();

            var failedServerVirtualAccountsException =
                new FailedServerVirtualAccountsException(
                    httpResponseException);

            var expectedVirtualAccountsDependencyException =
                new VirtualAccountsDependencyException(
                    failedServerVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostBulkCreateVirtualAccountsRequestAsync(It.IsAny<ExternalCreateBulkVirtualAccountsRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BulkCreateVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.PostBulkCreateVirtualAccountsRequestAsync(inputRandomBulkCreateVirtualAccounts);

            VirtualAccountsDependencyException actualVirtualAccountsDependencyException =
                await Assert.ThrowsAsync<VirtualAccountsDependencyException>(
                    retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBulkCreateVirtualAccountsRequestAsync(It.IsAny<ExternalCreateBulkVirtualAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostBulkVirtualAccountsIfServiceErrorOccurredAsync()
        {
            // given
            BulkCreateVirtualAccounts inputRandomBulkCreateVirtualAccounts = CreateRandomBulkVirtualAccount();

            var serviceException = new Exception();

            var failedVirtualAccountsServiceException =
                new FailedVirtualAccountsServiceException(serviceException);

            var expectedVirtualAccountsServiceException =
                new VirtualAccountsServiceException(failedVirtualAccountsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBulkCreateVirtualAccountsRequestAsync(It.IsAny<ExternalCreateBulkVirtualAccountsRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BulkCreateVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.PostBulkCreateVirtualAccountsRequestAsync(inputRandomBulkCreateVirtualAccounts);

            VirtualAccountsServiceException actualVirtualAccountsServiceException =
                await Assert.ThrowsAsync<VirtualAccountsServiceException>(
                    retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsServiceException.Should().BeEquivalentTo(
                expectedVirtualAccountsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBulkCreateVirtualAccountsRequestAsync(It.IsAny<ExternalCreateBulkVirtualAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}