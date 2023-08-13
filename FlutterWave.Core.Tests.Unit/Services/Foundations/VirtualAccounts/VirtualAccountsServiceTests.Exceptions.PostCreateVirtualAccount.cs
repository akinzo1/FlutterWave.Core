



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
        public async Task ShouldThrowDependencyExceptionOnPostVirtualAccountsIfUrlNotFoundAsync()
        {
            // given
            CreateVirtualAccounts inputRandomCreateVirtualAccounts = CreateRandomPostVirtualAccount();


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationVirtualAccountsException =
                new InvalidConfigurationVirtualAccountsException(
                    httpResponseUrlNotFoundException);

            var expectedVirtualAccountsDependencyException =
                new VirtualAccountsDependencyException(
                    invalidConfigurationVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateVirtualAccountRequestAsync(It.IsAny<ExternalCreateVirtualAccountRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreateVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.PostCreateVirtualAccountRequestAsync(inputRandomCreateVirtualAccounts);

            VirtualAccountsDependencyException
                actualVirtualAccountsDependencyException =
                    await Assert.ThrowsAsync<VirtualAccountsDependencyException>(
                        retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualAccountRequestAsync(It.IsAny<ExternalCreateVirtualAccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostVirtualAccountsIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            CreateVirtualAccounts inputRandomCreateVirtualAccounts = CreateRandomPostVirtualAccount();


            var unauthorizedVirtualAccountsException =
                new UnauthorizedVirtualAccountsException(unauthorizedException);

            var expectedVirtualAccountsDependencyException =
                new VirtualAccountsDependencyException(unauthorizedVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateVirtualAccountRequestAsync(It.IsAny<ExternalCreateVirtualAccountRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreateVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.PostCreateVirtualAccountRequestAsync(inputRandomCreateVirtualAccounts);

            VirtualAccountsDependencyException
                actualVirtualAccountsDependencyException =
                    await Assert.ThrowsAsync<VirtualAccountsDependencyException>(
                        retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualAccountRequestAsync(It.IsAny<ExternalCreateVirtualAccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostVirtualAccountsIfNotFoundOccurredAsync()
        {
            // given
            CreateVirtualAccounts inputRandomCreateVirtualAccounts = CreateRandomPostVirtualAccount();


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundVirtualAccountsException =
                new NotFoundVirtualAccountsException(
                    httpResponseNotFoundException);

            var expectedVirtualAccountsDependencyValidationException =
                new VirtualAccountsDependencyValidationException(
                    notFoundVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateVirtualAccountRequestAsync(It.IsAny<ExternalCreateVirtualAccountRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreateVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.PostCreateVirtualAccountRequestAsync(inputRandomCreateVirtualAccounts);

            VirtualAccountsDependencyValidationException
                actualVirtualAccountsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualAccountsDependencyValidationException>(
                        retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualAccountRequestAsync(It.IsAny<ExternalCreateVirtualAccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostVirtualAccountsIfBadRequestOccurredAsync()
        {
            // given
            CreateVirtualAccounts inputRandomCreateVirtualAccounts = CreateRandomPostVirtualAccount();


            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidVirtualAccountsException =
                new InvalidVirtualAccountsException(
                    httpResponseBadRequestException);

            var expectedVirtualAccountsDependencyValidationException =
                new VirtualAccountsDependencyValidationException(
                    invalidVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateVirtualAccountRequestAsync(It.IsAny<ExternalCreateVirtualAccountRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreateVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.PostCreateVirtualAccountRequestAsync(inputRandomCreateVirtualAccounts);

            VirtualAccountsDependencyValidationException
                actualVirtualAccountsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualAccountsDependencyValidationException>(
                        retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualAccountRequestAsync(It.IsAny<ExternalCreateVirtualAccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostVirtualAccountsIfTooManyRequestsOccurredAsync()
        {
            // given
            CreateVirtualAccounts inputRandomCreateVirtualAccounts = CreateRandomPostVirtualAccount();


            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallVirtualAccountsException =
                new ExcessiveCallVirtualAccountsException(
                    httpResponseTooManyRequestsException);

            var expectedVirtualAccountsDependencyValidationException =
                new VirtualAccountsDependencyValidationException(
                    excessiveCallVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateVirtualAccountRequestAsync(It.IsAny<ExternalCreateVirtualAccountRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreateVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.PostCreateVirtualAccountRequestAsync(inputRandomCreateVirtualAccounts);

            VirtualAccountsDependencyValidationException actualVirtualAccountsDependencyValidationException =
                await Assert.ThrowsAsync<VirtualAccountsDependencyValidationException>(
                    retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualAccountRequestAsync(It.IsAny<ExternalCreateVirtualAccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostVirtualAccountsIfHttpResponseErrorOccurredAsync()
        {
            // given
            CreateVirtualAccounts inputRandomCreateVirtualAccounts = CreateRandomPostVirtualAccount();


            var httpResponseException =
                new HttpResponseException();

            var failedServerVirtualAccountsException =
                new FailedServerVirtualAccountsException(
                    httpResponseException);

            var expectedVirtualAccountsDependencyException =
                new VirtualAccountsDependencyException(
                    failedServerVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateVirtualAccountRequestAsync(It.IsAny<ExternalCreateVirtualAccountRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreateVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.PostCreateVirtualAccountRequestAsync(inputRandomCreateVirtualAccounts);

            VirtualAccountsDependencyException actualVirtualAccountsDependencyException =
                await Assert.ThrowsAsync<VirtualAccountsDependencyException>(
                    retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualAccountRequestAsync(It.IsAny<ExternalCreateVirtualAccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostVirtualAccountsIfServiceErrorOccurredAsync()
        {
            // given
            CreateVirtualAccounts inputRandomCreateVirtualAccounts = CreateRandomPostVirtualAccount();

            var serviceException = new Exception();

            var failedVirtualAccountsServiceException =
                new FailedVirtualAccountsServiceException(serviceException);

            var expectedVirtualAccountsServiceException =
                new VirtualAccountsServiceException(failedVirtualAccountsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateVirtualAccountRequestAsync(It.IsAny<ExternalCreateVirtualAccountRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreateVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.PostCreateVirtualAccountRequestAsync(inputRandomCreateVirtualAccounts);

            VirtualAccountsServiceException actualVirtualAccountsServiceException =
                await Assert.ThrowsAsync<VirtualAccountsServiceException>(
                    retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsServiceException.Should().BeEquivalentTo(
                expectedVirtualAccountsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualAccountRequestAsync(It.IsAny<ExternalCreateVirtualAccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}