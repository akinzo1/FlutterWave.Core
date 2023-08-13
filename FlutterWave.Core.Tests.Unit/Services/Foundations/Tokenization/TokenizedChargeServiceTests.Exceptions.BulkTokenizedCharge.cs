



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.TokenizedCharge
{
    public partial class TokenizedChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostCreateBulkTokenizedChargeRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomCreateBulkTokenizedChargeRequestProperties =
              CreateRandomCreateBulkTokenizedChargeRequestProperties();


            var randomCreateBulkTokenizedChargeRequest = new CreateBulkTokenizedChargeRequest
            {
                BulkData = ((List<dynamic>)createRandomCreateBulkTokenizedChargeRequestProperties.BulkData).Select(data =>
                {
                    return new CreateBulkTokenizedChargeRequest.BulkDatum
                    {
                        Amount = data.Amount,
                        Country = data.Country,
                        Currency = data.Currency,
                        Email = data.Email,
                        FirstName = data.FirstName,
                        Ip = data.Ip,
                        LastName = data.LastName,
                        Token = data.Token,
                        TxRef = data.TxRef,
                    };
                }).ToList(),
                RetryStrategy = new CreateBulkTokenizedChargeRequest.RetryStrategyData
                {
                    RetryAmountVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAmountVariable,
                    RetryAttemptVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAttemptVariable,
                    RetryInterval = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryInterval
                },
                Title = createRandomCreateBulkTokenizedChargeRequestProperties.Title


            };

            var randomCreateBulkTokenizedCharge = new CreateBulkTokenizedCharge
            {
                Request = randomCreateBulkTokenizedChargeRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationCreateBulkTokenizedChargeException =
                new InvalidConfigurationTokenizedChargeException(
                    httpResponseUrlNotFoundException);

            var expectedTokenizedChargeDependencyException =
                new TokenizedChargeDependencyException(
                    invalidConfigurationCreateBulkTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateBulkTokenizedChargeAsync(It.IsAny<ExternalCreateBulkTokenizedChargeRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreateBulkTokenizedCharge> retrieveCreateBulkTokenizedChargeTask =
               this.tokenizedChargeService.PostCreateBulkTokenizedChargeRequestAsync(randomCreateBulkTokenizedCharge);

            TokenizedChargeDependencyException
                actualTokenizedChargeDependencyException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyException>(
                        retrieveCreateBulkTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTokenizedChargeAsync(It.IsAny<ExternalCreateBulkTokenizedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostPostCreateBulkTokenizedChargeRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomCreateBulkTokenizedChargeRequestProperties =
            CreateRandomCreateBulkTokenizedChargeRequestProperties();


            var randomCreateBulkTokenizedChargeRequest = new CreateBulkTokenizedChargeRequest
            {
                BulkData = ((List<dynamic>)createRandomCreateBulkTokenizedChargeRequestProperties.BulkData).Select(data =>
              {
                  return new CreateBulkTokenizedChargeRequest.BulkDatum
                  {
                      Amount = data.Amount,
                      Country = data.Country,
                      Currency = data.Currency,
                      Email = data.Email,
                      FirstName = data.FirstName,
                      Ip = data.Ip,
                      LastName = data.LastName,
                      Token = data.Token,
                      TxRef = data.TxRef,
                  };
              }).ToList(),
                RetryStrategy = new CreateBulkTokenizedChargeRequest.RetryStrategyData
                {
                    RetryAmountVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAmountVariable,
                    RetryAttemptVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAttemptVariable,
                    RetryInterval = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryInterval
                },
                Title = createRandomCreateBulkTokenizedChargeRequestProperties.Title


            };

            var someRandomCreateBulkTokenizedCharge = new CreateBulkTokenizedCharge
            {
                Request = randomCreateBulkTokenizedChargeRequest
            };

            var unauthorizedCreateBulkTokenizedChargeException =
                new UnauthorizedTokenizedChargeException(unauthorizedException);

            var expectedTokenizedChargeDependencyException =
                new TokenizedChargeDependencyException(unauthorizedCreateBulkTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateBulkTokenizedChargeAsync(It.IsAny<ExternalCreateBulkTokenizedChargeRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreateBulkTokenizedCharge> retrieveCreateBulkTokenizedChargeTask =
               this.tokenizedChargeService.PostCreateBulkTokenizedChargeRequestAsync(someRandomCreateBulkTokenizedCharge);

            TokenizedChargeDependencyException
                actualTokenizedChargeDependencyException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyException>(
                        retrieveCreateBulkTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTokenizedChargeAsync(It.IsAny<ExternalCreateBulkTokenizedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreateBulkTokenizedChargeRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomCreateBulkTokenizedChargeRequestProperties =
            CreateRandomCreateBulkTokenizedChargeRequestProperties();


            var randomCreateBulkTokenizedChargeRequest = new CreateBulkTokenizedChargeRequest
            {
                BulkData = ((List<dynamic>)createRandomCreateBulkTokenizedChargeRequestProperties.BulkData).Select(data =>
            {
                return new CreateBulkTokenizedChargeRequest.BulkDatum
                {
                    Amount = data.Amount,
                    Country = data.Country,
                    Currency = data.Currency,
                    Email = data.Email,
                    FirstName = data.FirstName,
                    Ip = data.Ip,
                    LastName = data.LastName,
                    Token = data.Token,
                    TxRef = data.TxRef,
                };
            }).ToList(),
                RetryStrategy = new CreateBulkTokenizedChargeRequest.RetryStrategyData
                {
                    RetryAmountVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAmountVariable,
                    RetryAttemptVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAttemptVariable,
                    RetryInterval = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryInterval
                },
                Title = createRandomCreateBulkTokenizedChargeRequestProperties.Title


            };

            var randomCreateBulkTokenizedCharge = new CreateBulkTokenizedCharge
            {
                Request = randomCreateBulkTokenizedChargeRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundCreateBulkTokenizedChargeException =
                new NotFoundTokenizedChargeException(
                    httpResponseNotFoundException);

            var expectedTokenizedChargeDependencyValidationException =
                new TokenizedChargeDependencyValidationException(
                    notFoundCreateBulkTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateBulkTokenizedChargeAsync(It.IsAny<ExternalCreateBulkTokenizedChargeRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreateBulkTokenizedCharge> retrieveCreateBulkTokenizedChargeTask =
               this.tokenizedChargeService.PostCreateBulkTokenizedChargeRequestAsync(randomCreateBulkTokenizedCharge);

            TokenizedChargeDependencyValidationException
                actualTokenizedChargeDependencyValidationException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyValidationException>(
                        retrieveCreateBulkTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTokenizedChargeAsync(It.IsAny<ExternalCreateBulkTokenizedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreateBulkTokenizedChargeRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomCreateBulkTokenizedChargeRequestProperties =
            CreateRandomCreateBulkTokenizedChargeRequestProperties();


            var randomCreateBulkTokenizedChargeRequest = new CreateBulkTokenizedChargeRequest
            {
                BulkData = ((List<dynamic>)createRandomCreateBulkTokenizedChargeRequestProperties.BulkData).Select(data =>
            {
                return new CreateBulkTokenizedChargeRequest.BulkDatum
                {
                    Amount = data.Amount,
                    Country = data.Country,
                    Currency = data.Currency,
                    Email = data.Email,
                    FirstName = data.FirstName,
                    Ip = data.Ip,
                    LastName = data.LastName,
                    Token = data.Token,
                    TxRef = data.TxRef,
                };
            }).ToList(),
                RetryStrategy = new CreateBulkTokenizedChargeRequest.RetryStrategyData
                {
                    RetryAmountVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAmountVariable,
                    RetryAttemptVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAttemptVariable,
                    RetryInterval = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryInterval
                },
                Title = createRandomCreateBulkTokenizedChargeRequestProperties.Title


            };

            var randomCreateBulkTokenizedCharge = new CreateBulkTokenizedCharge
            {
                Request = randomCreateBulkTokenizedChargeRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidCreateBulkTokenizedChargeException =
                new InvalidTokenizedChargeException(
                    httpResponseBadRequestException);

            var expectedTokenizedChargeDependencyValidationException =
                new TokenizedChargeDependencyValidationException(
                    invalidCreateBulkTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateBulkTokenizedChargeAsync(It.IsAny<ExternalCreateBulkTokenizedChargeRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreateBulkTokenizedCharge> retrieveCreateBulkTokenizedChargeTask =
               this.tokenizedChargeService.PostCreateBulkTokenizedChargeRequestAsync(randomCreateBulkTokenizedCharge);

            TokenizedChargeDependencyValidationException
                actualTokenizedChargeDependencyValidationException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyValidationException>(
                        retrieveCreateBulkTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTokenizedChargeAsync(It.IsAny<ExternalCreateBulkTokenizedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreateBulkTokenizedChargeRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomCreateBulkTokenizedChargeRequestProperties =
            CreateRandomCreateBulkTokenizedChargeRequestProperties();


            var randomCreateBulkTokenizedChargeRequest = new CreateBulkTokenizedChargeRequest
            {
                BulkData = ((List<dynamic>)createRandomCreateBulkTokenizedChargeRequestProperties.BulkData).Select(data =>
            {
                return new CreateBulkTokenizedChargeRequest.BulkDatum
                {
                    Amount = data.Amount,
                    Country = data.Country,
                    Currency = data.Currency,
                    Email = data.Email,
                    FirstName = data.FirstName,
                    Ip = data.Ip,
                    LastName = data.LastName,
                    Token = data.Token,
                    TxRef = data.TxRef,
                };
            }).ToList(),
                RetryStrategy = new CreateBulkTokenizedChargeRequest.RetryStrategyData
                {
                    RetryAmountVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAmountVariable,
                    RetryAttemptVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAttemptVariable,
                    RetryInterval = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryInterval
                },
                Title = createRandomCreateBulkTokenizedChargeRequestProperties.Title


            };

            var randomCreateBulkTokenizedCharge = new CreateBulkTokenizedCharge
            {
                Request = randomCreateBulkTokenizedChargeRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallCreateBulkTokenizedChargeException =
                new ExcessiveCallTokenizedChargeException(
                    httpResponseTooManyRequestsException);

            var expectedTokenizedChargeDependencyValidationException =
                new TokenizedChargeDependencyValidationException(
                    excessiveCallCreateBulkTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateBulkTokenizedChargeAsync(It.IsAny<ExternalCreateBulkTokenizedChargeRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreateBulkTokenizedCharge> retrieveCreateBulkTokenizedChargeTask =
               this.tokenizedChargeService.PostCreateBulkTokenizedChargeRequestAsync(randomCreateBulkTokenizedCharge);

            TokenizedChargeDependencyValidationException actualTokenizedChargeDependencyValidationException =
                await Assert.ThrowsAsync<TokenizedChargeDependencyValidationException>(
                    retrieveCreateBulkTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTokenizedChargeAsync(It.IsAny<ExternalCreateBulkTokenizedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostPostCreateBulkTokenizedChargeRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateBulkTokenizedChargeRequestProperties =
            CreateRandomCreateBulkTokenizedChargeRequestProperties();


            var randomCreateBulkTokenizedChargeRequest = new CreateBulkTokenizedChargeRequest
            {
                BulkData = ((List<dynamic>)createRandomCreateBulkTokenizedChargeRequestProperties.BulkData).Select(data =>
            {
                return new CreateBulkTokenizedChargeRequest.BulkDatum
                {
                    Amount = data.Amount,
                    Country = data.Country,
                    Currency = data.Currency,
                    Email = data.Email,
                    FirstName = data.FirstName,
                    Ip = data.Ip,
                    LastName = data.LastName,
                    Token = data.Token,
                    TxRef = data.TxRef,
                };
            }).ToList(),
                RetryStrategy = new CreateBulkTokenizedChargeRequest.RetryStrategyData
                {
                    RetryAmountVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAmountVariable,
                    RetryAttemptVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAttemptVariable,
                    RetryInterval = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryInterval
                },
                Title = createRandomCreateBulkTokenizedChargeRequestProperties.Title


            };

            var randomCreateBulkTokenizedCharge = new CreateBulkTokenizedCharge
            {
                Request = randomCreateBulkTokenizedChargeRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerCreateBulkTokenizedChargeException =
                new FailedServerTokenizedChargeException(
                    httpResponseException);

            var expectedTokenizedChargeDependencyException =
                new TokenizedChargeDependencyException(
                    failedServerCreateBulkTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateBulkTokenizedChargeAsync(It.IsAny<ExternalCreateBulkTokenizedChargeRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreateBulkTokenizedCharge> retrieveCreateBulkTokenizedChargeTask =
               this.tokenizedChargeService.PostCreateBulkTokenizedChargeRequestAsync(randomCreateBulkTokenizedCharge);

            TokenizedChargeDependencyException actualTokenizedChargeDependencyException =
                await Assert.ThrowsAsync<TokenizedChargeDependencyException>(
                    retrieveCreateBulkTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTokenizedChargeAsync(It.IsAny<ExternalCreateBulkTokenizedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostPostCreateBulkTokenizedChargeRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateBulkTokenizedChargeRequestProperties =
           CreateRandomCreateBulkTokenizedChargeRequestProperties();


            var randomCreateBulkTokenizedChargeRequest = new CreateBulkTokenizedChargeRequest
            {
                BulkData = ((List<dynamic>)createRandomCreateBulkTokenizedChargeRequestProperties.BulkData).Select(data =>
            {
                return new CreateBulkTokenizedChargeRequest.BulkDatum
                {
                    Amount = data.Amount,
                    Country = data.Country,
                    Currency = data.Currency,
                    Email = data.Email,
                    FirstName = data.FirstName,
                    Ip = data.Ip,
                    LastName = data.LastName,
                    Token = data.Token,
                    TxRef = data.TxRef,
                };
            }).ToList(),
                RetryStrategy = new CreateBulkTokenizedChargeRequest.RetryStrategyData
                {
                    RetryAmountVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAmountVariable,
                    RetryAttemptVariable = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryAttemptVariable,
                    RetryInterval = createRandomCreateBulkTokenizedChargeRequestProperties.RetryStrategy.RetryInterval
                },
                Title = createRandomCreateBulkTokenizedChargeRequestProperties.Title


            };

            var randomCreateBulkTokenizedCharge = new CreateBulkTokenizedCharge
            {
                Request = randomCreateBulkTokenizedChargeRequest
            };
            var serviceException = new Exception();

            var failedCreateBulkTokenizedChargeServiceException =
                new FailedTokenizedChargeServiceException(serviceException);

            var expectedCreateBulkTokenizedChargeServiceException =
                new TokenizedChargeServiceException(failedCreateBulkTokenizedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateBulkTokenizedChargeAsync(It.IsAny<ExternalCreateBulkTokenizedChargeRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreateBulkTokenizedCharge> retrieveCreateBulkTokenizedChargeTask =
               this.tokenizedChargeService.PostCreateBulkTokenizedChargeRequestAsync(randomCreateBulkTokenizedCharge);

            TokenizedChargeServiceException actualCreateBulkTokenizedChargeServiceException =
                await Assert.ThrowsAsync<TokenizedChargeServiceException>(
                    retrieveCreateBulkTokenizedChargeTask.AsTask);

            // then
            actualCreateBulkTokenizedChargeServiceException.Should().BeEquivalentTo(
                expectedCreateBulkTokenizedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTokenizedChargeAsync(It.IsAny<ExternalCreateBulkTokenizedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}