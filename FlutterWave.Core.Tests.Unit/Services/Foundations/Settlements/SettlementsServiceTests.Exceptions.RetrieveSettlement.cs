



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Settlements;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Settlements
{
    public partial class SettlementsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnSettlementsRequestIfUrlNotFoundAsync()
        {
            // given
            string someSettlementsId = GetRandomString();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationSettlementsException =
                new InvalidConfigurationSettlementsException(
                    httpResponseUrlNotFoundException);

            var expectedSettlementsDependencyException =
                new SettlementsDependencyException(
                    invalidConfigurationSettlementsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetSettlementByIdAsync(someSettlementsId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Settlement> retrieveSettlementsTask =
               this.settlementsService.GetSettlementsByIdAsync(someSettlementsId);

            SettlementsDependencyException
                actualSettlementsDependencyException =
                    await Assert.ThrowsAsync<SettlementsDependencyException>(
                        retrieveSettlementsTask.AsTask);

            // then
            actualSettlementsDependencyException.Should().BeEquivalentTo(
                expectedSettlementsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSettlementByIdAsync(someSettlementsId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnSettlementsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string someSettlementsId = GetRandomString();

            var unauthorizedSettlementsException =
                new UnauthorizedSettlementsException(unauthorizedException);

            var expectedSettlementsDependencyException =
                new SettlementsDependencyException(unauthorizedSettlementsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetSettlementByIdAsync(someSettlementsId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<Settlement> retrieveSettlementsTask =
               this.settlementsService.GetSettlementsByIdAsync(someSettlementsId);

            SettlementsDependencyException
                actualSettlementsDependencyException =
                    await Assert.ThrowsAsync<SettlementsDependencyException>(
                        retrieveSettlementsTask.AsTask);

            // then
            actualSettlementsDependencyException.Should().BeEquivalentTo(
                expectedSettlementsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSettlementByIdAsync(someSettlementsId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnSettlementsRequestIfNotFoundOccurredAsync()
        {
            // given
            string someSettlementsId = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundSettlementsException =
                new NotFoundSettlementsException(
                    httpResponseNotFoundException);

            var expectedSettlementsDependencyValidationException =
                new SettlementsDependencyValidationException(
                    notFoundSettlementsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetSettlementByIdAsync(someSettlementsId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Settlement> retrieveSettlementsTask =
               this.settlementsService.GetSettlementsByIdAsync(someSettlementsId);

            SettlementsDependencyValidationException
                actualSettlementsDependencyValidationException =
                    await Assert.ThrowsAsync<SettlementsDependencyValidationException>(
                        retrieveSettlementsTask.AsTask);

            // then
            actualSettlementsDependencyValidationException.Should().BeEquivalentTo(
                expectedSettlementsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSettlementByIdAsync(someSettlementsId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnSettlementsRequestIfBadRequestOccurredAsync()
        {
            // given
            string someSettlementsId = GetRandomString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidSettlementsException =
                new InvalidSettlementsException(
                    httpResponseBadRequestException);

            var expectedSettlementsDependencyValidationException =
                new SettlementsDependencyValidationException(
                    invalidSettlementsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetSettlementByIdAsync(someSettlementsId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Settlement> retrieveSettlementsTask =
               this.settlementsService.GetSettlementsByIdAsync(someSettlementsId);

            SettlementsDependencyValidationException
                actualSettlementsDependencyValidationException =
                    await Assert.ThrowsAsync<SettlementsDependencyValidationException>(
                        retrieveSettlementsTask.AsTask);

            // then
            actualSettlementsDependencyValidationException.Should().BeEquivalentTo(
                expectedSettlementsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSettlementByIdAsync(someSettlementsId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnSettlementsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            string someSettlementsId = GetRandomString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallSettlementsException =
                new ExcessiveCallSettlementsException(
                    httpResponseTooManyRequestsException);

            var expectedSettlementsDependencyValidationException =
                new SettlementsDependencyValidationException(
                    excessiveCallSettlementsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetSettlementByIdAsync(someSettlementsId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Settlement> retrieveSettlementsTask =
               this.settlementsService.GetSettlementsByIdAsync(someSettlementsId);

            SettlementsDependencyValidationException actualSettlementsDependencyValidationException =
                await Assert.ThrowsAsync<SettlementsDependencyValidationException>(
                    retrieveSettlementsTask.AsTask);

            // then
            actualSettlementsDependencyValidationException.Should().BeEquivalentTo(
                expectedSettlementsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSettlementByIdAsync(someSettlementsId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnSettlementsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            string someSettlementsId = GetRandomString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerSettlementsException =
                new FailedServerSettlementsException(
                    httpResponseException);

            var expectedSettlementsDependencyException =
                new SettlementsDependencyException(
                    failedServerSettlementsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetSettlementByIdAsync(someSettlementsId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Settlement> retrieveSettlementsTask =
               this.settlementsService.GetSettlementsByIdAsync(someSettlementsId);

            SettlementsDependencyException actualSettlementsDependencyException =
                await Assert.ThrowsAsync<SettlementsDependencyException>(
                    retrieveSettlementsTask.AsTask);

            // then
            actualSettlementsDependencyException.Should().BeEquivalentTo(
                expectedSettlementsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSettlementByIdAsync(someSettlementsId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnSettlementsRequestIfServiceErrorOccurredAsync()
        {
            // given
            string someSettlementsId = GetRandomString();
            var serviceException = new Exception();

            var failedSettlementsServiceException =
                new FailedSettlementsServiceException(serviceException);

            var expectedSettlementsServiceException =
                new SettlementsServiceException(failedSettlementsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetSettlementByIdAsync(someSettlementsId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Settlement> retrieveSettlementsTask =
               this.settlementsService.GetSettlementsByIdAsync(someSettlementsId);

            SettlementsServiceException actualSettlementsServiceException =
                await Assert.ThrowsAsync<SettlementsServiceException>(
                    retrieveSettlementsTask.AsTask);

            // then
            actualSettlementsServiceException.Should().BeEquivalentTo(
                expectedSettlementsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSettlementByIdAsync(someSettlementsId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}