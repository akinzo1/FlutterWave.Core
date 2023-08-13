



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
        public async Task ShouldThrowDependencyExceptionOnUpdateVirtualAccountsIfUrlNotFoundAsync()
        {
            // given
            UpdateBvnVirtualAccounts inputRandomUpdateBvnVirtualAccounts = CreateRandomUpdateBvnVirtualAccount();
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
                broker.UpdateVirtualAccountsBvnRequestAsync(It.IsAny<ExternalUpdateVirtualAccountBvnRequest>(), inputOrderReference))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<UpdateBvnVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.UpdateVirtualAccountsBvnRequestAsync(inputRandomUpdateBvnVirtualAccounts, inputOrderReference);

            VirtualAccountsDependencyException
                actualVirtualAccountsDependencyException =
                    await Assert.ThrowsAsync<VirtualAccountsDependencyException>(
                        retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdateVirtualAccountsBvnRequestAsync(It.IsAny<ExternalUpdateVirtualAccountBvnRequest>(), inputOrderReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnUpdateVirtualAccountsIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            UpdateBvnVirtualAccounts inputRandomUpdateBvnVirtualAccounts = CreateRandomUpdateBvnVirtualAccount();
            string inputOrderReference = GetRandomString();

            var unauthorizedVirtualAccountsException =
                new UnauthorizedVirtualAccountsException(unauthorizedException);

            var expectedVirtualAccountsDependencyException =
                new VirtualAccountsDependencyException(unauthorizedVirtualAccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.UpdateVirtualAccountsBvnRequestAsync(It.IsAny<ExternalUpdateVirtualAccountBvnRequest>(), inputOrderReference))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<UpdateBvnVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.UpdateVirtualAccountsBvnRequestAsync(inputRandomUpdateBvnVirtualAccounts, inputOrderReference);

            VirtualAccountsDependencyException
                actualVirtualAccountsDependencyException =
                    await Assert.ThrowsAsync<VirtualAccountsDependencyException>(
                        retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdateVirtualAccountsBvnRequestAsync(It.IsAny<ExternalUpdateVirtualAccountBvnRequest>(), inputOrderReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUpdateVirtualAccountsIfNotFoundOccurredAsync()
        {
            // given
            UpdateBvnVirtualAccounts inputRandomUpdateBvnVirtualAccounts = CreateRandomUpdateBvnVirtualAccount();
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
                broker.UpdateVirtualAccountsBvnRequestAsync(It.IsAny<ExternalUpdateVirtualAccountBvnRequest>(), inputOrderReference))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<UpdateBvnVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.UpdateVirtualAccountsBvnRequestAsync(inputRandomUpdateBvnVirtualAccounts, inputOrderReference);

            VirtualAccountsDependencyValidationException
                actualVirtualAccountsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualAccountsDependencyValidationException>(
                        retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdateVirtualAccountsBvnRequestAsync(It.IsAny<ExternalUpdateVirtualAccountBvnRequest>(), inputOrderReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUpdateVirtualAccountsIfBadRequestOccurredAsync()
        {
            // given
            UpdateBvnVirtualAccounts inputRandomUpdateBvnVirtualAccounts = CreateRandomUpdateBvnVirtualAccount();
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
                broker.UpdateVirtualAccountsBvnRequestAsync(It.IsAny<ExternalUpdateVirtualAccountBvnRequest>(), inputOrderReference))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<UpdateBvnVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.UpdateVirtualAccountsBvnRequestAsync(inputRandomUpdateBvnVirtualAccounts, inputOrderReference);

            VirtualAccountsDependencyValidationException
                actualVirtualAccountsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualAccountsDependencyValidationException>(
                        retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdateVirtualAccountsBvnRequestAsync(It.IsAny<ExternalUpdateVirtualAccountBvnRequest>(), inputOrderReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUpdateVirtualAccountsIfTooManyRequestsOccurredAsync()
        {
            // given
            UpdateBvnVirtualAccounts inputRandomUpdateBvnVirtualAccounts = CreateRandomUpdateBvnVirtualAccount();
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
                 broker.UpdateVirtualAccountsBvnRequestAsync(It.IsAny<ExternalUpdateVirtualAccountBvnRequest>(), inputOrderReference))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<UpdateBvnVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.UpdateVirtualAccountsBvnRequestAsync(inputRandomUpdateBvnVirtualAccounts, inputOrderReference);

            VirtualAccountsDependencyValidationException actualVirtualAccountsDependencyValidationException =
                await Assert.ThrowsAsync<VirtualAccountsDependencyValidationException>(
                    retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdateVirtualAccountsBvnRequestAsync(It.IsAny<ExternalUpdateVirtualAccountBvnRequest>(), inputOrderReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnUpdateVirtualAccountsIfHttpResponseErrorOccurredAsync()
        {
            // given
            UpdateBvnVirtualAccounts inputRandomUpdateBvnVirtualAccounts = CreateRandomUpdateBvnVirtualAccount();
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
                 broker.UpdateVirtualAccountsBvnRequestAsync(It.IsAny<ExternalUpdateVirtualAccountBvnRequest>(), inputOrderReference))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<UpdateBvnVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.UpdateVirtualAccountsBvnRequestAsync(inputRandomUpdateBvnVirtualAccounts, inputOrderReference);

            VirtualAccountsDependencyException actualVirtualAccountsDependencyException =
                await Assert.ThrowsAsync<VirtualAccountsDependencyException>(
                    retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsDependencyException.Should().BeEquivalentTo(
                expectedVirtualAccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdateVirtualAccountsBvnRequestAsync(It.IsAny<ExternalUpdateVirtualAccountBvnRequest>(), inputOrderReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnUpdateVirtualAccountsIfServiceErrorOccurredAsync()
        {
            // given
            UpdateBvnVirtualAccounts inputRandomUpdateBvnVirtualAccounts = CreateRandomUpdateBvnVirtualAccount();
            string inputOrderReference = GetRandomString();
            var serviceException = new Exception();

            var failedVirtualAccountsServiceException =
                new FailedVirtualAccountsServiceException(serviceException);

            var expectedVirtualAccountsServiceException =
                new VirtualAccountsServiceException(failedVirtualAccountsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.UpdateVirtualAccountsBvnRequestAsync(It.IsAny<ExternalUpdateVirtualAccountBvnRequest>(), inputOrderReference))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<UpdateBvnVirtualAccounts> retrieveVirtualAccountsTask =
               this.virtualAccountsService.UpdateVirtualAccountsBvnRequestAsync(inputRandomUpdateBvnVirtualAccounts, inputOrderReference);

            VirtualAccountsServiceException actualVirtualAccountsServiceException =
                await Assert.ThrowsAsync<VirtualAccountsServiceException>(
                    retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsServiceException.Should().BeEquivalentTo(
                expectedVirtualAccountsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdateVirtualAccountsBvnRequestAsync(It.IsAny<ExternalUpdateVirtualAccountBvnRequest>(), inputOrderReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}