



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscription;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Subscriptions
{
    public partial class SubscriptionsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnActivateSubscriptionsRequestIfUrlNotFoundAsync()
        {
            // given
            string someSubscriptionsId = GetRandomString();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationSubscriptionsException =
                new InvalidConfigurationSubscriptionsException(
                    httpResponseUrlNotFoundException);

            var expectedSubscriptionsDependencyException =
                new SubscriptionsDependencyException(
                    invalidConfigurationSubscriptionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostActivateSubscriptionAsync(someSubscriptionsId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Subscription> retrieveSubscriptionsTask =
               this.subscriptionsService.PostActivateSubscriptionAsync(someSubscriptionsId);

            SubscriptionsDependencyException
                actualSubscriptionsDependencyException =
                    await Assert.ThrowsAsync<SubscriptionsDependencyException>(
                        retrieveSubscriptionsTask.AsTask);

            // then
            actualSubscriptionsDependencyException.Should().BeEquivalentTo(
                expectedSubscriptionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostActivateSubscriptionAsync(someSubscriptionsId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnActivateSubscriptionsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string someSubscriptionsId = GetRandomString();

            var unauthorizedSubscriptionsException =
                new UnauthorizedSubscriptionsException(unauthorizedException);

            var expectedSubscriptionsDependencyException =
                new SubscriptionsDependencyException(unauthorizedSubscriptionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostActivateSubscriptionAsync(someSubscriptionsId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<Subscription> retrieveSubscriptionsTask =
               this.subscriptionsService.PostActivateSubscriptionAsync(someSubscriptionsId);

            SubscriptionsDependencyException
                actualSubscriptionsDependencyException =
                    await Assert.ThrowsAsync<SubscriptionsDependencyException>(
                        retrieveSubscriptionsTask.AsTask);

            // then
            actualSubscriptionsDependencyException.Should().BeEquivalentTo(
                expectedSubscriptionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostActivateSubscriptionAsync(someSubscriptionsId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnActivateSubscriptionsRequestIfNotFoundOccurredAsync()
        {
            // given
            string someSubscriptionsId = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundSubscriptionsException =
                new NotFoundSubscriptionsException(
                    httpResponseNotFoundException);

            var expectedSubscriptionsDependencyValidationException =
                new SubscriptionsDependencyValidationException(
                    notFoundSubscriptionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostActivateSubscriptionAsync(someSubscriptionsId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Subscription> retrieveSubscriptionsTask =
               this.subscriptionsService.PostActivateSubscriptionAsync(someSubscriptionsId);

            SubscriptionsDependencyValidationException
                actualSubscriptionsDependencyValidationException =
                    await Assert.ThrowsAsync<SubscriptionsDependencyValidationException>(
                        retrieveSubscriptionsTask.AsTask);

            // then
            actualSubscriptionsDependencyValidationException.Should().BeEquivalentTo(
                expectedSubscriptionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostActivateSubscriptionAsync(someSubscriptionsId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnActivateSubscriptionsRequestIfBadRequestOccurredAsync()
        {
            // given
            string someSubscriptionsId = GetRandomString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidSubscriptionsException =
                new InvalidSubscriptionsException(
                    httpResponseBadRequestException);

            var expectedSubscriptionsDependencyValidationException =
                new SubscriptionsDependencyValidationException(
                    invalidSubscriptionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostActivateSubscriptionAsync(someSubscriptionsId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Subscription> retrieveSubscriptionsTask =
               this.subscriptionsService.PostActivateSubscriptionAsync(someSubscriptionsId);

            SubscriptionsDependencyValidationException
                actualSubscriptionsDependencyValidationException =
                    await Assert.ThrowsAsync<SubscriptionsDependencyValidationException>(
                        retrieveSubscriptionsTask.AsTask);

            // then
            actualSubscriptionsDependencyValidationException.Should().BeEquivalentTo(
                expectedSubscriptionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostActivateSubscriptionAsync(someSubscriptionsId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnActivateSubscriptionsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            string someSubscriptionsId = GetRandomString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallSubscriptionsException =
                new ExcessiveCallSubscriptionsException(
                    httpResponseTooManyRequestsException);

            var expectedSubscriptionsDependencyValidationException =
                new SubscriptionsDependencyValidationException(
                    excessiveCallSubscriptionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostActivateSubscriptionAsync(someSubscriptionsId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Subscription> retrieveSubscriptionsTask =
               this.subscriptionsService.PostActivateSubscriptionAsync(someSubscriptionsId);

            SubscriptionsDependencyValidationException actualSubscriptionsDependencyValidationException =
                await Assert.ThrowsAsync<SubscriptionsDependencyValidationException>(
                    retrieveSubscriptionsTask.AsTask);

            // then
            actualSubscriptionsDependencyValidationException.Should().BeEquivalentTo(
                expectedSubscriptionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostActivateSubscriptionAsync(someSubscriptionsId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnActivateSubscriptionsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            string someSubscriptionsId = GetRandomString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerSubscriptionsException =
                new FailedServerSubscriptionsException(
                    httpResponseException);

            var expectedSubscriptionsDependencyException =
                new SubscriptionsDependencyException(
                    failedServerSubscriptionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostActivateSubscriptionAsync(someSubscriptionsId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Subscription> retrieveSubscriptionsTask =
               this.subscriptionsService.PostActivateSubscriptionAsync(someSubscriptionsId);

            SubscriptionsDependencyException actualSubscriptionsDependencyException =
                await Assert.ThrowsAsync<SubscriptionsDependencyException>(
                    retrieveSubscriptionsTask.AsTask);

            // then
            actualSubscriptionsDependencyException.Should().BeEquivalentTo(
                expectedSubscriptionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostActivateSubscriptionAsync(someSubscriptionsId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnActivateSubscriptionsRequestIfServiceErrorOccurredAsync()
        {
            // given
            string someSubscriptionsId = GetRandomString();
            var serviceException = new Exception();

            var failedSubscriptionsServiceException =
                new FailedSubscriptionsServiceException(serviceException);

            var expectedSubscriptionsServiceException =
                new SubscriptionsServiceException(failedSubscriptionsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostActivateSubscriptionAsync(someSubscriptionsId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Subscription> retrieveSubscriptionsTask =
               this.subscriptionsService.PostActivateSubscriptionAsync(someSubscriptionsId);

            SubscriptionsServiceException actualSubscriptionsServiceException =
                await Assert.ThrowsAsync<SubscriptionsServiceException>(
                    retrieveSubscriptionsTask.AsTask);

            // then
            actualSubscriptionsServiceException.Should().BeEquivalentTo(
                expectedSubscriptionsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostActivateSubscriptionAsync(someSubscriptionsId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}