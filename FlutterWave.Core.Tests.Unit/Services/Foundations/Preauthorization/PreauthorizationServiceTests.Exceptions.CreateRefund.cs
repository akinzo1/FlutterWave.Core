



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Preauthorization
{
    public partial class PreauthorizationServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostCreateRefundRequestIfUrlNotFoundAsync()
        {
            // given
            var flwRef = GetRandomString();

            dynamic createRandomCreatePreauthorizationRefundRequestProperties =
            CreateRandomCreatePreauthorizationRefundRequestProperties();

            var randomCreateRefund = new CreatePreauthorizationRefund
            {
                Request = new CreatePreauthorizationRefundRequest
                {
                    Amount = createRandomCreatePreauthorizationRefundRequestProperties.Amount,
                }
            };


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationPreauthorizationException =
                new InvalidConfigurationPreauthorizationException(
                    httpResponseUrlNotFoundException);

            var expectedPreauthorizationDependencyException =
                new PreauthorizationDependencyException(
                    invalidConfigurationPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateRefundAsync(flwRef, It.IsAny<ExternalCreatePreauthorizationRefundRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreatePreauthorizationRefund> retrievePreauthorizationTask =
               this.preauthorizationService.PostCreateRefundRequestAsync(flwRef, randomCreateRefund);

            PreauthorizationDependencyException
                actualPreauthorizationDependencyException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyException>(
                        retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundAsync(flwRef, It.IsAny<ExternalCreatePreauthorizationRefundRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostCreateRefundRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var flwRef = GetRandomString();

            dynamic createRandomCreatePreauthorizationRefundRequestProperties =
            CreateRandomCreatePreauthorizationRefundRequestProperties();

            var randomCreateRefund = new CreatePreauthorizationRefund
            {
                Request = new CreatePreauthorizationRefundRequest
                {
                    Amount = createRandomCreatePreauthorizationRefundRequestProperties.Amount,
                }
            };

            var unauthorizedPreauthorizationException =
                new UnauthorizedPreauthorizationException(unauthorizedException);

            var expectedPreauthorizationDependencyException =
                new PreauthorizationDependencyException(unauthorizedPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateRefundAsync(flwRef, It.IsAny<ExternalCreatePreauthorizationRefundRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreatePreauthorizationRefund> retrievePreauthorizationTask =
               this.preauthorizationService.PostCreateRefundRequestAsync(flwRef, randomCreateRefund);

            PreauthorizationDependencyException
                actualPreauthorizationDependencyException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyException>(
                        retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundAsync(flwRef, It.IsAny<ExternalCreatePreauthorizationRefundRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateRefundRequestIfNotFoundOccurredAsync()
        {
            // given
            var flwRef = GetRandomString();

            dynamic createRandomCreatePreauthorizationRefundRequestProperties =
            CreateRandomCreatePreauthorizationRefundRequestProperties();
            var randomCreateRefund = new CreatePreauthorizationRefund
            {
                Request = new CreatePreauthorizationRefundRequest
                {
                    Amount = createRandomCreatePreauthorizationRefundRequestProperties.Amount,
                }
            };
            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundPreauthorizationException =
                new NotFoundPreauthorizationException(
                    httpResponseNotFoundException);

            var expectedPreauthorizationDependencyValidationException =
                new PreauthorizationDependencyValidationException(
                    notFoundPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateRefundAsync(flwRef, It.IsAny<ExternalCreatePreauthorizationRefundRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreatePreauthorizationRefund> retrievePreauthorizationTask =
               this.preauthorizationService.PostCreateRefundRequestAsync(flwRef, randomCreateRefund);

            PreauthorizationDependencyValidationException
                actualPreauthorizationDependencyValidationException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyValidationException>(
                        retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundAsync(flwRef, It.IsAny<ExternalCreatePreauthorizationRefundRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateRefundRequestIfBadRequestOccurredAsync()
        {
            // given
            var flwRef = GetRandomString();

            dynamic createRandomCreatePreauthorizationRefundRequestProperties =
            CreateRandomCreatePreauthorizationRefundRequestProperties();
            var randomCreateRefund = new CreatePreauthorizationRefund
            {
                Request = new CreatePreauthorizationRefundRequest
                {
                    Amount = createRandomCreatePreauthorizationRefundRequestProperties.Amount,
                }
            };
            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidPreauthorizationException =
                new InvalidPreauthorizationException(
                    httpResponseBadRequestException);

            var expectedPreauthorizationDependencyValidationException =
                new PreauthorizationDependencyValidationException(
                    invalidPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateRefundAsync(flwRef, It.IsAny<ExternalCreatePreauthorizationRefundRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreatePreauthorizationRefund> retrievePreauthorizationTask =
               this.preauthorizationService.PostCreateRefundRequestAsync(flwRef, randomCreateRefund);

            PreauthorizationDependencyValidationException
                actualPreauthorizationDependencyValidationException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyValidationException>(
                        retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundAsync(flwRef, It.IsAny<ExternalCreatePreauthorizationRefundRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateRefundRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var flwRef = GetRandomString();

            dynamic createRandomCreatePreauthorizationRefundRequestProperties =
            CreateRandomCreatePreauthorizationRefundRequestProperties();
            var randomCreateRefund = new CreatePreauthorizationRefund
            {
                Request = new CreatePreauthorizationRefundRequest
                {
                    Amount = createRandomCreatePreauthorizationRefundRequestProperties.Amount,
                }
            };
            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallPreauthorizationException =
                new ExcessiveCallPreauthorizationException(
                    httpResponseTooManyRequestsException);

            var expectedPreauthorizationDependencyValidationException =
                new PreauthorizationDependencyValidationException(
                    excessiveCallPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateRefundAsync(flwRef, It.IsAny<ExternalCreatePreauthorizationRefundRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreatePreauthorizationRefund> retrievePreauthorizationTask =
               this.preauthorizationService.PostCreateRefundRequestAsync(flwRef, randomCreateRefund);

            PreauthorizationDependencyValidationException actualPreauthorizationDependencyValidationException =
                await Assert.ThrowsAsync<PreauthorizationDependencyValidationException>(
                    retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundAsync(flwRef, It.IsAny<ExternalCreatePreauthorizationRefundRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostCreateRefundRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var flwRef = GetRandomString();

            dynamic createRandomCreatePreauthorizationRefundRequestProperties =
            CreateRandomCreatePreauthorizationRefundRequestProperties();
            var randomCreateRefund = new CreatePreauthorizationRefund
            {
                Request = new CreatePreauthorizationRefundRequest
                {
                    Amount = createRandomCreatePreauthorizationRefundRequestProperties.Amount,
                }
            };
            var httpResponseException =
                new HttpResponseException();

            var failedServerPreauthorizationException =
                new FailedServerPreauthorizationException(
                    httpResponseException);

            var expectedPreauthorizationDependencyException =
                new PreauthorizationDependencyException(
                    failedServerPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateRefundAsync(flwRef, It.IsAny<ExternalCreatePreauthorizationRefundRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreatePreauthorizationRefund> retrievePreauthorizationTask =
               this.preauthorizationService.PostCreateRefundRequestAsync(flwRef, randomCreateRefund);

            PreauthorizationDependencyException actualPreauthorizationDependencyException =
                await Assert.ThrowsAsync<PreauthorizationDependencyException>(
                    retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundAsync(flwRef, It.IsAny<ExternalCreatePreauthorizationRefundRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostCreateRefundRequestIfServiceErrorOccurredAsync()
        {
            // given
            var flwRef = GetRandomString();

            dynamic createRandomCreatePreauthorizationRefundRequestProperties =
            CreateRandomCreatePreauthorizationRefundRequestProperties();

            var randomCreateRefund = new CreatePreauthorizationRefund
            {
                Request = new CreatePreauthorizationRefundRequest
                {
                    Amount = createRandomCreatePreauthorizationRefundRequestProperties.Amount,
                }
            };
            var serviceException = new Exception();

            var failedPreauthorizationServiceException =
                new FailedPreauthorizationServiceException(serviceException);

            var expectedPreauthorizationServiceException =
                new PreauthorizationServiceException(failedPreauthorizationServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateRefundAsync(flwRef, It.IsAny<ExternalCreatePreauthorizationRefundRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreatePreauthorizationRefund> retrievePreauthorizationTask =
               this.preauthorizationService.PostCreateRefundRequestAsync(flwRef, randomCreateRefund);

            PreauthorizationServiceException actualPreauthorizationServiceException =
                await Assert.ThrowsAsync<PreauthorizationServiceException>(
                    retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationServiceException.Should().BeEquivalentTo(
                expectedPreauthorizationServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundAsync(flwRef, It.IsAny<ExternalCreatePreauthorizationRefundRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}