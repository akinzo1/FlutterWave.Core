using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalChargeBack;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.ChargeBacks
{
    public partial class ChargeBackServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostAcceptDeclineChargeBackRequestIfUrlNotFoundAsync()
        {
            // given
            string randomAction = GetRandomString();
            string randomComment = GetRandomString();
            string inputAmount = randomAction;
            string inputBillerName = randomComment;
            string randomId = GetRandomString();
            string inputChargeBackId = randomId;




            var someRandomCreateChargeBackRequest = new AcceptDeclineChargeBack
            {
                Request = new AcceptDeclineChargeBackRequest
                {
                    Comment = inputAmount,
                    Action = inputBillerName
                },



            };



            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationChargeBackException =
                new InvalidConfigurationChargeBackException(
                    httpResponseUrlNotFoundException);

            var expectedChargeBackDependencyException =
                new ChargeBackDependencyException(
                    invalidConfigurationChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(), It.IsAny<ExternalAcceptDeclineChargeBackRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<AcceptDeclineChargeBack> retrieveChargeBackTask =
               this.chargeBackService.PostAcceptDeclineChargeBacksAsync(inputChargeBackId, someRandomCreateChargeBackRequest);

            ChargeBackDependencyException
                actualChargeBackDependencyException =
                    await Assert.ThrowsAsync<ChargeBackDependencyException>(
                        retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyException.Should().BeEquivalentTo(
                expectedChargeBackDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(), It.IsAny<ExternalAcceptDeclineChargeBackRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostAcceptDeclineChargeBackRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string randomAction = GetRandomString();
            string randomComment = GetRandomString();
            string inputAmount = randomAction;
            string inputBillerName = randomComment;
            string randomId = GetRandomString();
            string inputChargeBackId = randomId;



            var someRandomCreateChargeBackRequest = new AcceptDeclineChargeBack
            {
                Request = new AcceptDeclineChargeBackRequest
                {
                    Comment = inputAmount,
                    Action = inputBillerName
                },



            };

            var unauthorizedChargeBackException =
                new UnauthorizedChargeBackException(unauthorizedException);

            var expectedChargeBackDependencyException =
                new ChargeBackDependencyException(unauthorizedChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(), It.IsAny<ExternalAcceptDeclineChargeBackRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<AcceptDeclineChargeBack> retrieveChargeBackTask =
               this.chargeBackService.PostAcceptDeclineChargeBacksAsync(inputChargeBackId, someRandomCreateChargeBackRequest);

            ChargeBackDependencyException
                actualChargeBackDependencyException =
                    await Assert.ThrowsAsync<ChargeBackDependencyException>(
                        retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyException.Should().BeEquivalentTo(
                expectedChargeBackDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(), It.IsAny<ExternalAcceptDeclineChargeBackRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostAcceptDeclineChargeBackRequestIfNotFoundOccurredAsync()
        {
            // given
            string randomAction = GetRandomString();
            string randomComment = GetRandomString();
            string inputAmount = randomAction;
            string inputBillerName = randomComment;
            string randomId = GetRandomString();
            string inputChargeBackId = randomId;



            var someRandomCreateChargeBackRequest = new AcceptDeclineChargeBack
            {
                Request = new AcceptDeclineChargeBackRequest
                {
                    Comment = inputAmount,
                    Action = inputBillerName
                },



            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundChargeBackException =
                new NotFoundChargeBackException(
                    httpResponseNotFoundException);

            var expectedChargeBackDependencyValidationException =
                new ChargeBackDependencyValidationException(
                    notFoundChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(), It.IsAny<ExternalAcceptDeclineChargeBackRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<AcceptDeclineChargeBack> retrieveChargeBackTask =
               this.chargeBackService.PostAcceptDeclineChargeBacksAsync(inputChargeBackId, someRandomCreateChargeBackRequest);

            ChargeBackDependencyValidationException
                actualChargeBackDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeBackDependencyValidationException>(
                        retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeBackDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(), It.IsAny<ExternalAcceptDeclineChargeBackRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostAcceptDeclineChargeBackRequestIfBadRequestOccurredAsync()
        {
            // given
            string randomAction = GetRandomString();
            string randomComment = GetRandomString();
            string inputAmount = randomAction;
            string inputBillerName = randomComment;
            string randomId = GetRandomString();
            string inputChargeBackId = randomId;



            var someRandomCreateChargeBackRequest = new AcceptDeclineChargeBack
            {
                Request = new AcceptDeclineChargeBackRequest
                {
                    Comment = inputAmount,
                    Action = inputBillerName
                },



            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidChargeBackException =
                new InvalidChargeBackException(
                    httpResponseBadRequestException);

            var expectedChargeBackDependencyValidationException =
                new ChargeBackDependencyValidationException(
                    invalidChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(), It.IsAny<ExternalAcceptDeclineChargeBackRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<AcceptDeclineChargeBack> retrieveChargeBackTask =
               this.chargeBackService.PostAcceptDeclineChargeBacksAsync(inputChargeBackId, someRandomCreateChargeBackRequest);

            ChargeBackDependencyValidationException
                actualChargeBackDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeBackDependencyValidationException>(
                        retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeBackDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(), It.IsAny<ExternalAcceptDeclineChargeBackRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostAcceptDeclineChargeBackRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            string randomAction = GetRandomString();
            string randomComment = GetRandomString();
            string inputAmount = randomAction;
            string inputBillerName = randomComment;
            string randomId = GetRandomString();
            string inputChargeBackId = randomId;



            var someRandomCreateChargeBackRequest = new AcceptDeclineChargeBack
            {
                Request = new AcceptDeclineChargeBackRequest
                {
                    Comment = inputAmount,
                    Action = inputBillerName
                },



            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallChargeBackException =
                new ExcessiveCallChargeBackException(
                    httpResponseTooManyRequestsException);

            var expectedChargeBackDependencyValidationException =
                new ChargeBackDependencyValidationException(
                    excessiveCallChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(), It.IsAny<ExternalAcceptDeclineChargeBackRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<AcceptDeclineChargeBack> retrieveChargeBackTask =
               this.chargeBackService.PostAcceptDeclineChargeBacksAsync(inputChargeBackId, someRandomCreateChargeBackRequest);

            ChargeBackDependencyValidationException actualChargeBackDependencyValidationException =
                await Assert.ThrowsAsync<ChargeBackDependencyValidationException>(
                    retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeBackDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(), It.IsAny<ExternalAcceptDeclineChargeBackRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostAcceptDeclineChargeBackRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            string randomAction = GetRandomString();
            string randomComment = GetRandomString();
            string inputAmount = randomAction;
            string inputBillerName = randomComment;
            string randomId = GetRandomString();
            string inputChargeBackId = randomId;



            var someRandomCreateChargeBackRequest = new AcceptDeclineChargeBack
            {
                Request = new AcceptDeclineChargeBackRequest
                {
                    Comment = inputAmount,
                    Action = inputBillerName
                },



            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerChargeBackException =
                new FailedServerChargeBackException(
                    httpResponseException);

            var expectedChargeBackDependencyException =
                new ChargeBackDependencyException(
                    failedServerChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(), It.IsAny<ExternalAcceptDeclineChargeBackRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<AcceptDeclineChargeBack> retrieveChargeBackTask =
               this.chargeBackService.PostAcceptDeclineChargeBacksAsync(inputChargeBackId, someRandomCreateChargeBackRequest);

            ChargeBackDependencyException actualChargeBackDependencyException =
                await Assert.ThrowsAsync<ChargeBackDependencyException>(
                    retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyException.Should().BeEquivalentTo(
                expectedChargeBackDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(), It.IsAny<ExternalAcceptDeclineChargeBackRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostAcceptDeclineChargeBackRequestIfServiceErrorOccurredAsync()
        {
            // given
            string randomAction = GetRandomString();
            string randomComment = GetRandomString();
            string inputAmount = randomAction;
            string inputBillerName = randomComment;
            string randomId = GetRandomString();
            string inputChargeBackId = randomId;



            var someRandomCreateChargeBackRequest = new AcceptDeclineChargeBack
            {
                Request = new AcceptDeclineChargeBackRequest
                {
                    Comment = inputAmount,
                    Action = inputBillerName
                },



            };
            var serviceException = new Exception();

            var failedChargeBackServiceException =
                new FailedChargeBackServiceException(serviceException);

            var expectedChargeBackServiceException =
                new ChargeBackServiceException(failedChargeBackServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(), It.IsAny<ExternalAcceptDeclineChargeBackRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<AcceptDeclineChargeBack> retrieveChargeBackTask =
               this.chargeBackService.PostAcceptDeclineChargeBacksAsync(inputChargeBackId, someRandomCreateChargeBackRequest);

            ChargeBackServiceException actualChargeBackServiceException =
                await Assert.ThrowsAsync<ChargeBackServiceException>(
                    retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackServiceException.Should().BeEquivalentTo(
                expectedChargeBackServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(), It.IsAny<ExternalAcceptDeclineChargeBackRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}