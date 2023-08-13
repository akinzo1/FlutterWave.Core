



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Preauthorization
{
    public partial class PreauthorizationServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostVoidPayPalChargeRequestIfUrlNotFoundAsync()
        {
            // given
            var flwRef = GetRandomString();



            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationPreauthorizationException =
                new InvalidConfigurationPreauthorizationException(
                    httpResponseUrlNotFoundException);

            var expectedPreauthorizationDependencyException =
                new PreauthorizationDependencyException(
                    invalidConfigurationPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostVoidPayPalChargeAsync(flwRef))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<VoidPayPalCharge> retrievePreauthorizationTask =
               this.preauthorizationService.PostVoidPayPalChargeRequestAsync(flwRef);

            PreauthorizationDependencyException
                actualPreauthorizationDependencyException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyException>(
                        retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVoidPayPalChargeAsync(flwRef),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveVoidPayPalChargeRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var flwRef = GetRandomString();




            var unauthorizedPreauthorizationException =
                new UnauthorizedPreauthorizationException(unauthorizedException);

            var expectedPreauthorizationDependencyException =
                new PreauthorizationDependencyException(unauthorizedPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostVoidPayPalChargeAsync(flwRef))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<VoidPayPalCharge> retrievePreauthorizationTask =
               this.preauthorizationService.PostVoidPayPalChargeRequestAsync(flwRef);

            PreauthorizationDependencyException
                actualPreauthorizationDependencyException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyException>(
                        retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVoidPayPalChargeAsync(flwRef),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveVoidPayPalChargeRequestIfNotFoundOccurredAsync()
        {
            // given
            var flwRef = GetRandomString();



            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundPreauthorizationException =
                new NotFoundPreauthorizationException(
                    httpResponseNotFoundException);

            var expectedPreauthorizationDependencyValidationException =
                new PreauthorizationDependencyValidationException(
                    notFoundPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostVoidPayPalChargeAsync(flwRef))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<VoidPayPalCharge> retrievePreauthorizationTask =
               this.preauthorizationService.PostVoidPayPalChargeRequestAsync(flwRef);

            PreauthorizationDependencyValidationException
                actualPreauthorizationDependencyValidationException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyValidationException>(
                        retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVoidPayPalChargeAsync(flwRef),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveVoidPayPalChargeRequestIfBadRequestOccurredAsync()
        {
            // given
            var flwRef = GetRandomString();



            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidPreauthorizationException =
                new InvalidPreauthorizationException(
                    httpResponseBadRequestException);

            var expectedPreauthorizationDependencyValidationException =
                new PreauthorizationDependencyValidationException(
                    invalidPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostVoidPayPalChargeAsync(flwRef))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<VoidPayPalCharge> retrievePreauthorizationTask =
               this.preauthorizationService.PostVoidPayPalChargeRequestAsync(flwRef);

            PreauthorizationDependencyValidationException
                actualPreauthorizationDependencyValidationException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyValidationException>(
                        retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVoidPayPalChargeAsync(flwRef),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveVoidPayPalChargeRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var flwRef = GetRandomString();



            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallPreauthorizationException =
                new ExcessiveCallPreauthorizationException(
                    httpResponseTooManyRequestsException);

            var expectedPreauthorizationDependencyValidationException =
                new PreauthorizationDependencyValidationException(
                    excessiveCallPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostVoidPayPalChargeAsync(flwRef))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<VoidPayPalCharge> retrievePreauthorizationTask =
               this.preauthorizationService.PostVoidPayPalChargeRequestAsync(flwRef);

            PreauthorizationDependencyValidationException actualPreauthorizationDependencyValidationException =
                await Assert.ThrowsAsync<PreauthorizationDependencyValidationException>(
                    retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVoidPayPalChargeAsync(flwRef),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveVoidPayPalChargeRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var flwRef = GetRandomString();



            var httpResponseException =
                new HttpResponseException();

            var failedServerPreauthorizationException =
                new FailedServerPreauthorizationException(
                    httpResponseException);

            var expectedPreauthorizationDependencyException =
                new PreauthorizationDependencyException(
                    failedServerPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostVoidPayPalChargeAsync(flwRef))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<VoidPayPalCharge> retrievePreauthorizationTask =
               this.preauthorizationService.PostVoidPayPalChargeRequestAsync(flwRef);

            PreauthorizationDependencyException actualPreauthorizationDependencyException =
                await Assert.ThrowsAsync<PreauthorizationDependencyException>(
                    retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVoidPayPalChargeAsync(flwRef),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveVoidPayPalChargeRequestIfServiceErrorOccurredAsync()
        {
            // given
            var flwRef = GetRandomString();


            var serviceException = new Exception();

            var failedPreauthorizationServiceException =
                new FailedPreauthorizationServiceException(serviceException);

            var expectedPreauthorizationServiceException =
                new PreauthorizationServiceException(failedPreauthorizationServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostVoidPayPalChargeAsync(flwRef))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<VoidPayPalCharge> retrievePreauthorizationTask =
               this.preauthorizationService.PostVoidPayPalChargeRequestAsync(flwRef);

            PreauthorizationServiceException actualPreauthorizationServiceException =
                await Assert.ThrowsAsync<PreauthorizationServiceException>(
                    retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationServiceException.Should().BeEquivalentTo(
                expectedPreauthorizationServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVoidPayPalChargeAsync(flwRef),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}