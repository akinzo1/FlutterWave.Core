



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Miscellaneous
{
    public partial class MiscellaneousServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnStatementRequestIfUrlNotFoundAsync()
        {
            // given


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationMiscException =
                new InvalidConfigurationMiscException(
                    httpResponseUrlNotFoundException);

            var expectedMiscellaneousDependencyException =
                new MiscellaneousDependencyException(
                    invalidConfigurationMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetStatementAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Statement> retrieveMiscTask =
               this.miscellaneousService.GetStatementAsync();

            MiscellaneousDependencyException
                actualMiscellaneousDependencyException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetStatementAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnStatementRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given


            var unauthorizedMiscException =
                new UnauthorizedMiscException(unauthorizedException);

            var expectedMiscellaneousDependencyException =
                new MiscellaneousDependencyException(unauthorizedMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetStatementAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<Statement> retrieveMiscTask =
               this.miscellaneousService.GetStatementAsync();

            MiscellaneousDependencyException
                actualMiscellaneousDependencyException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetStatementAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnStatementRequestIfNotFoundOccurredAsync()
        {
            // given


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundMiscException =
                new NotFoundMiscException(
                    httpResponseNotFoundException);

            var expectedMiscellaneousDependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    notFoundMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetStatementAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Statement> retrieveMiscTask =
               this.miscellaneousService.GetStatementAsync();

            MiscellaneousDependencyValidationException
                actualMiscellaneousDependencyValidationException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetStatementAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnStatementRequestIfBadRequestOccurredAsync()
        {
            // given


            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidMiscException =
                new InvalidMiscellaneousException(
                    httpResponseBadRequestException);

            var expectedMiscellaneousDependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    invalidMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetStatementAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Statement> retrieveMiscTask =
               this.miscellaneousService.GetStatementAsync();

            MiscellaneousDependencyValidationException
                actualMiscellaneousDependencyValidationException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetStatementAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnStatementRequestIfTooManyRequestsOccurredAsync()
        {
            // given


            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallMiscException =
                new ExcessiveCallMiscException(
                    httpResponseTooManyRequestsException);

            var expectedMiscellaneousDependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    excessiveCallMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetStatementAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Statement> retrieveMiscTask =
               this.miscellaneousService.GetStatementAsync();

            MiscellaneousDependencyValidationException actualMiscellaneousDependencyValidationException =
                await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetStatementAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnStatementRequestIfHttpResponseErrorOccurredAsync()
        {
            // given


            var httpResponseException =
                new HttpResponseException();

            var failedServerMiscException =
                new FailedServerMiscException(
                    httpResponseException);

            var expectedMiscellaneousDependencyException =
                new MiscellaneousDependencyException(
                    failedServerMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetStatementAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Statement> retrieveMiscTask =
               this.miscellaneousService.GetStatementAsync();

            MiscellaneousDependencyException actualMiscellaneousDependencyException =
                await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetStatementAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnStatementRequestIfServiceErrorOccurredAsync()
        {
            // given

            var serviceException = new Exception();

            var failedMiscServiceException =
                new FailedMiscServiceException(serviceException);

            var expectedMiscServiceException =
                new MiscellaneousServiceException(failedMiscServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetStatementAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Statement> retrieveMiscTask =
               this.miscellaneousService.GetStatementAsync();

            MiscellaneousServiceException actualMiscServiceException =
                await Assert.ThrowsAsync<MiscellaneousServiceException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscServiceException.Should().BeEquivalentTo(
                expectedMiscServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetStatementAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}