



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
        public async Task ShouldThrowDependencyExceptionOnAllSubscriptionsRequestIfUrlNotFoundAsync()
        {
            // given


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationSubscriptionsException =
                new InvalidConfigurationSubscriptionsException(
                    httpResponseUrlNotFoundException);

            var expectedSubscriptionsDependencyException =
                new SubscriptionsDependencyException(
                    invalidConfigurationSubscriptionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllSubscriptionsAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<AllSubscription> retrieveSubscriptionsTask =
               this.subscriptionsService.GetAllSubscriptionsAsync();

            SubscriptionsDependencyException
                actualSubscriptionsDependencyException =
                    await Assert.ThrowsAsync<SubscriptionsDependencyException>(
                        retrieveSubscriptionsTask.AsTask);

            // then
            actualSubscriptionsDependencyException.Should().BeEquivalentTo(
                expectedSubscriptionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllSubscriptionsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnAllSubscriptionsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given


            var unauthorizedSubscriptionsException =
                new UnauthorizedSubscriptionsException(unauthorizedException);

            var expectedSubscriptionsDependencyException =
                new SubscriptionsDependencyException(unauthorizedSubscriptionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetAllSubscriptionsAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<AllSubscription> retrieveSubscriptionsTask =
               this.subscriptionsService.GetAllSubscriptionsAsync();

            SubscriptionsDependencyException
                actualSubscriptionsDependencyException =
                    await Assert.ThrowsAsync<SubscriptionsDependencyException>(
                        retrieveSubscriptionsTask.AsTask);

            // then
            actualSubscriptionsDependencyException.Should().BeEquivalentTo(
                expectedSubscriptionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllSubscriptionsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllSubscriptionsRequestIfNotFoundOccurredAsync()
        {
            // given


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundSubscriptionsException =
                new NotFoundSubscriptionsException(
                    httpResponseNotFoundException);

            var expectedSubscriptionsDependencyValidationException =
                new SubscriptionsDependencyValidationException(
                    notFoundSubscriptionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllSubscriptionsAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<AllSubscription> retrieveSubscriptionsTask =
               this.subscriptionsService.GetAllSubscriptionsAsync();

            SubscriptionsDependencyValidationException
                actualSubscriptionsDependencyValidationException =
                    await Assert.ThrowsAsync<SubscriptionsDependencyValidationException>(
                        retrieveSubscriptionsTask.AsTask);

            // then
            actualSubscriptionsDependencyValidationException.Should().BeEquivalentTo(
                expectedSubscriptionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllSubscriptionsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllSubscriptionsRequestIfBadRequestOccurredAsync()
        {
            // given


            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidSubscriptionsException =
                new InvalidSubscriptionsException(
                    httpResponseBadRequestException);

            var expectedSubscriptionsDependencyValidationException =
                new SubscriptionsDependencyValidationException(
                    invalidSubscriptionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllSubscriptionsAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<AllSubscription> retrieveSubscriptionsTask =
               this.subscriptionsService.GetAllSubscriptionsAsync();

            SubscriptionsDependencyValidationException
                actualSubscriptionsDependencyValidationException =
                    await Assert.ThrowsAsync<SubscriptionsDependencyValidationException>(
                        retrieveSubscriptionsTask.AsTask);

            // then
            actualSubscriptionsDependencyValidationException.Should().BeEquivalentTo(
                expectedSubscriptionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllSubscriptionsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllSubscriptionsRequestIfTooManyRequestsOccurredAsync()
        {
            // given


            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallSubscriptionsException =
                new ExcessiveCallSubscriptionsException(
                    httpResponseTooManyRequestsException);

            var expectedSubscriptionsDependencyValidationException =
                new SubscriptionsDependencyValidationException(
                    excessiveCallSubscriptionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetAllSubscriptionsAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<AllSubscription> retrieveSubscriptionsTask =
               this.subscriptionsService.GetAllSubscriptionsAsync();

            SubscriptionsDependencyValidationException actualSubscriptionsDependencyValidationException =
                await Assert.ThrowsAsync<SubscriptionsDependencyValidationException>(
                    retrieveSubscriptionsTask.AsTask);

            // then
            actualSubscriptionsDependencyValidationException.Should().BeEquivalentTo(
                expectedSubscriptionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllSubscriptionsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAllSubscriptionsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given


            var httpResponseException =
                new HttpResponseException();

            var failedServerSubscriptionsException =
                new FailedServerSubscriptionsException(
                    httpResponseException);

            var expectedSubscriptionsDependencyException =
                new SubscriptionsDependencyException(
                    failedServerSubscriptionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetAllSubscriptionsAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<AllSubscription> retrieveSubscriptionsTask =
               this.subscriptionsService.GetAllSubscriptionsAsync();

            SubscriptionsDependencyException actualSubscriptionsDependencyException =
                await Assert.ThrowsAsync<SubscriptionsDependencyException>(
                    retrieveSubscriptionsTask.AsTask);

            // then
            actualSubscriptionsDependencyException.Should().BeEquivalentTo(
                expectedSubscriptionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllSubscriptionsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAllSubscriptionsRequestIfServiceErrorOccurredAsync()
        {
            // given

            var serviceException = new Exception();

            var failedSubscriptionsServiceException =
                new FailedSubscriptionsServiceException(serviceException);

            var expectedSubscriptionsServiceException =
                new SubscriptionsServiceException(failedSubscriptionsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllSubscriptionsAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<AllSubscription> retrieveSubscriptionsTask =
               this.subscriptionsService.GetAllSubscriptionsAsync();

            SubscriptionsServiceException actualSubscriptionsServiceException =
                await Assert.ThrowsAsync<SubscriptionsServiceException>(
                    retrieveSubscriptionsTask.AsTask);

            // then
            actualSubscriptionsServiceException.Should().BeEquivalentTo(
                expectedSubscriptionsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllSubscriptionsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}