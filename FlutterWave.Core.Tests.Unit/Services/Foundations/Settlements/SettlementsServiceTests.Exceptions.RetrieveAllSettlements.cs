



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
        public async Task ShouldThrowDependencyExceptionOnAllSettlementsRequestIfUrlNotFoundAsync()
        {
            // given


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationSettlementsException =
                new InvalidConfigurationSettlementsException(
                    httpResponseUrlNotFoundException);

            var expectedSettlementsDependencyException =
                new SettlementsDependencyException(
                    invalidConfigurationSettlementsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllSettlementsAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<AllSettlements> retrieveSettlementsTask =
               this.settlementsService.GetAllSettlementsAsync();

            SettlementsDependencyException
                actualSettlementsDependencyException =
                    await Assert.ThrowsAsync<SettlementsDependencyException>(
                        retrieveSettlementsTask.AsTask);

            // then
            actualSettlementsDependencyException.Should().BeEquivalentTo(
                expectedSettlementsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllSettlementsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnAllSettlementsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given


            var unauthorizedSettlementsException =
                new UnauthorizedSettlementsException(unauthorizedException);

            var expectedSettlementsDependencyException =
                new SettlementsDependencyException(unauthorizedSettlementsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetAllSettlementsAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<AllSettlements> retrieveSettlementsTask =
               this.settlementsService.GetAllSettlementsAsync();

            SettlementsDependencyException
                actualSettlementsDependencyException =
                    await Assert.ThrowsAsync<SettlementsDependencyException>(
                        retrieveSettlementsTask.AsTask);

            // then
            actualSettlementsDependencyException.Should().BeEquivalentTo(
                expectedSettlementsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllSettlementsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllSettlementsRequestIfNotFoundOccurredAsync()
        {
            // given


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundSettlementsException =
                new NotFoundSettlementsException(
                    httpResponseNotFoundException);

            var expectedSettlementsDependencyValidationException =
                new SettlementsDependencyValidationException(
                    notFoundSettlementsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllSettlementsAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<AllSettlements> retrieveSettlementsTask =
               this.settlementsService.GetAllSettlementsAsync();

            SettlementsDependencyValidationException
                actualSettlementsDependencyValidationException =
                    await Assert.ThrowsAsync<SettlementsDependencyValidationException>(
                        retrieveSettlementsTask.AsTask);

            // then
            actualSettlementsDependencyValidationException.Should().BeEquivalentTo(
                expectedSettlementsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllSettlementsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllSettlementsRequestIfBadRequestOccurredAsync()
        {
            // given


            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidSettlementsException =
                new InvalidSettlementsException(
                    httpResponseBadRequestException);

            var expectedSettlementsDependencyValidationException =
                new SettlementsDependencyValidationException(
                    invalidSettlementsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllSettlementsAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<AllSettlements> retrieveSettlementsTask =
               this.settlementsService.GetAllSettlementsAsync();

            SettlementsDependencyValidationException
                actualSettlementsDependencyValidationException =
                    await Assert.ThrowsAsync<SettlementsDependencyValidationException>(
                        retrieveSettlementsTask.AsTask);

            // then
            actualSettlementsDependencyValidationException.Should().BeEquivalentTo(
                expectedSettlementsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllSettlementsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllSettlementsRequestIfTooManyRequestsOccurredAsync()
        {
            // given


            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallSettlementsException =
                new ExcessiveCallSettlementsException(
                    httpResponseTooManyRequestsException);

            var expectedSettlementsDependencyValidationException =
                new SettlementsDependencyValidationException(
                    excessiveCallSettlementsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetAllSettlementsAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<AllSettlements> retrieveSettlementsTask =
               this.settlementsService.GetAllSettlementsAsync();

            SettlementsDependencyValidationException actualSettlementsDependencyValidationException =
                await Assert.ThrowsAsync<SettlementsDependencyValidationException>(
                    retrieveSettlementsTask.AsTask);

            // then
            actualSettlementsDependencyValidationException.Should().BeEquivalentTo(
                expectedSettlementsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllSettlementsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAllSettlementsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given


            var httpResponseException =
                new HttpResponseException();

            var failedServerSettlementsException =
                new FailedServerSettlementsException(
                    httpResponseException);

            var expectedSettlementsDependencyException =
                new SettlementsDependencyException(
                    failedServerSettlementsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetAllSettlementsAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<AllSettlements> retrieveSettlementsTask =
               this.settlementsService.GetAllSettlementsAsync();

            SettlementsDependencyException actualSettlementsDependencyException =
                await Assert.ThrowsAsync<SettlementsDependencyException>(
                    retrieveSettlementsTask.AsTask);

            // then
            actualSettlementsDependencyException.Should().BeEquivalentTo(
                expectedSettlementsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllSettlementsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAllSettlementsRequestIfServiceErrorOccurredAsync()
        {
            // given

            var serviceException = new Exception();

            var failedSettlementsServiceException =
                new FailedSettlementsServiceException(serviceException);

            var expectedSettlementsServiceException =
                new SettlementsServiceException(failedSettlementsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllSettlementsAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<AllSettlements> retrieveSettlementsTask =
               this.settlementsService.GetAllSettlementsAsync();

            SettlementsServiceException actualSettlementsServiceException =
                await Assert.ThrowsAsync<SettlementsServiceException>(
                    retrieveSettlementsTask.AsTask);

            // then
            actualSettlementsServiceException.Should().BeEquivalentTo(
                expectedSettlementsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllSettlementsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}