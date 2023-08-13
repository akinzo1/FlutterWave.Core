



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Preauthorization
{
    public partial class PreauthorizationServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostCreateChargeRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomCreateChargeRequestProperties =
              CreateRandomCreateChargeRequestProperties();


            var randomCreateChargeRequest = new CreateChargeRequest
            {

                Amount = createRandomCreateChargeRequestProperties.Amount,
                Currency = createRandomCreateChargeRequestProperties.Currency,
                Email = createRandomCreateChargeRequestProperties.Email,
                CardNumber = createRandomCreateChargeRequestProperties.CardNumber,
                ClientIp = createRandomCreateChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCreateChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCreateChargeRequestProperties.PaymentPlan,
                UseSecureAuth = createRandomCreateChargeRequestProperties.UseSecureAuth,
                Authorization = new CreateChargeRequest.AuthorizationData
                {
                    Address = createRandomCreateChargeRequestProperties.Authorization.Address,
                    City = createRandomCreateChargeRequestProperties.Authorization.City,
                    Country = createRandomCreateChargeRequestProperties.Authorization.Country,
                    Mode = createRandomCreateChargeRequestProperties.Authorization.Mode,
                    Pin = createRandomCreateChargeRequestProperties.Authorization.Pin,
                    State = createRandomCreateChargeRequestProperties.Authorization.State,
                    ZipCode = createRandomCreateChargeRequestProperties.Authorization.ZipCode,
                },
                Cvv = createRandomCreateChargeRequestProperties.Cvv,
                ExpiryMonth = createRandomCreateChargeRequestProperties.ExpiryMonth,
                ExpiryYear = createRandomCreateChargeRequestProperties.ExpiryYear,
                FullName = createRandomCreateChargeRequestProperties.FullName,
                Meta = new CreateChargeRequest.CreateChargeMeta
                {
                    SideNote = createRandomCreateChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCreateChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCreateChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCreateChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCreateChargeRequestProperties.TxRef

            };

            var randomCreateCharge = new CreateCharge
            {
                Request = randomCreateChargeRequest
            };

            var randomEncryptionKey = GetRandomLengthyString();


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationCreateChargeException =
                new InvalidConfigurationPreauthorizationException(
                    httpResponseUrlNotFoundException);

            var expectedPreauthorizationDependencyException =
                new PreauthorizationDependencyException(
                    invalidConfigurationCreateChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateChargeAsync(It.IsAny<ExternalEncryptedChargeRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreateCharge> retrieveCreateChargeTask =
               this.preauthorizationService.PostCreateChargeRequestAsync(randomCreateCharge, randomEncryptionKey);

            PreauthorizationDependencyException
                actualPreauthorizationDependencyException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyException>(
                        retrieveCreateChargeTask.AsTask);

            // then
            actualPreauthorizationDependencyException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateChargeAsync(It.IsAny<ExternalEncryptedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostPostCreateChargeRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomCreateChargeRequestProperties =
            CreateRandomCreateChargeRequestProperties();


            var randomCreateChargeRequest = new CreateChargeRequest
            {
                Amount = createRandomCreateChargeRequestProperties.Amount,
                Currency = createRandomCreateChargeRequestProperties.Currency,
                Email = createRandomCreateChargeRequestProperties.Email,
                CardNumber = createRandomCreateChargeRequestProperties.CardNumber,
                ClientIp = createRandomCreateChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCreateChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCreateChargeRequestProperties.PaymentPlan,
                UseSecureAuth = createRandomCreateChargeRequestProperties.UseSecureAuth,
                Authorization = new CreateChargeRequest.AuthorizationData
                {
                    Address = createRandomCreateChargeRequestProperties.Authorization.Address,
                    City = createRandomCreateChargeRequestProperties.Authorization.City,
                    Country = createRandomCreateChargeRequestProperties.Authorization.Country,
                    Mode = createRandomCreateChargeRequestProperties.Authorization.Mode,
                    Pin = createRandomCreateChargeRequestProperties.Authorization.Pin,
                    State = createRandomCreateChargeRequestProperties.Authorization.State,
                    ZipCode = createRandomCreateChargeRequestProperties.Authorization.ZipCode,
                },
                Cvv = createRandomCreateChargeRequestProperties.Cvv,
                ExpiryMonth = createRandomCreateChargeRequestProperties.ExpiryMonth,
                ExpiryYear = createRandomCreateChargeRequestProperties.ExpiryYear,
                FullName = createRandomCreateChargeRequestProperties.FullName,
                Meta = new CreateChargeRequest.CreateChargeMeta
                {
                    SideNote = createRandomCreateChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCreateChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCreateChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCreateChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCreateChargeRequestProperties.TxRef



            };

            var someRandomCreateCharge = new CreateCharge
            {
                Request = randomCreateChargeRequest
            };

            var randomEncryptionKey = GetRandomLengthyString();

            var unauthorizedCreateChargeException =
                new UnauthorizedPreauthorizationException(unauthorizedException);

            var expectedPreauthorizationDependencyException =
                new PreauthorizationDependencyException(unauthorizedCreateChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateChargeAsync(It.IsAny<ExternalEncryptedChargeRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreateCharge> retrieveCreateChargeTask =
               this.preauthorizationService.PostCreateChargeRequestAsync(someRandomCreateCharge, randomEncryptionKey);

            PreauthorizationDependencyException
                actualPreauthorizationDependencyException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyException>(
                        retrieveCreateChargeTask.AsTask);

            // then
            actualPreauthorizationDependencyException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateChargeAsync(It.IsAny<ExternalEncryptedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreateChargeRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomCreateChargeRequestProperties =
            CreateRandomCreateChargeRequestProperties();


            var randomCreateChargeRequest = new CreateChargeRequest
            {
                Amount = createRandomCreateChargeRequestProperties.Amount,
                Currency = createRandomCreateChargeRequestProperties.Currency,
                Email = createRandomCreateChargeRequestProperties.Email,
                CardNumber = createRandomCreateChargeRequestProperties.CardNumber,
                ClientIp = createRandomCreateChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCreateChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCreateChargeRequestProperties.PaymentPlan,
                UseSecureAuth = createRandomCreateChargeRequestProperties.UseSecureAuth,
                Authorization = new CreateChargeRequest.AuthorizationData
                {
                    Address = createRandomCreateChargeRequestProperties.Authorization.Address,
                    City = createRandomCreateChargeRequestProperties.Authorization.City,
                    Country = createRandomCreateChargeRequestProperties.Authorization.Country,
                    Mode = createRandomCreateChargeRequestProperties.Authorization.Mode,
                    Pin = createRandomCreateChargeRequestProperties.Authorization.Pin,
                    State = createRandomCreateChargeRequestProperties.Authorization.State,
                    ZipCode = createRandomCreateChargeRequestProperties.Authorization.ZipCode,
                },
                Cvv = createRandomCreateChargeRequestProperties.Cvv,
                ExpiryMonth = createRandomCreateChargeRequestProperties.ExpiryMonth,
                ExpiryYear = createRandomCreateChargeRequestProperties.ExpiryYear,
                FullName = createRandomCreateChargeRequestProperties.FullName,
                Meta = new CreateChargeRequest.CreateChargeMeta
                {
                    SideNote = createRandomCreateChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCreateChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCreateChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCreateChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCreateChargeRequestProperties.TxRef



            };

            var randomCreateCharge = new CreateCharge
            {
                Request = randomCreateChargeRequest
            };

            var randomEncryptionKey = GetRandomLengthyString();


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundCreateChargeException =
                new NotFoundPreauthorizationException(
                    httpResponseNotFoundException);

            var expectedPreauthorizationDependencyValidationException =
                new PreauthorizationDependencyValidationException(
                    notFoundCreateChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateChargeAsync(It.IsAny<ExternalEncryptedChargeRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreateCharge> retrieveCreateChargeTask =
               this.preauthorizationService.PostCreateChargeRequestAsync(randomCreateCharge, randomEncryptionKey);

            PreauthorizationDependencyValidationException
                actualPreauthorizationDependencyValidationException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyValidationException>(
                        retrieveCreateChargeTask.AsTask);

            // then
            actualPreauthorizationDependencyValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateChargeAsync(It.IsAny<ExternalEncryptedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreateChargeRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomCreateChargeRequestProperties =
            CreateRandomCreateChargeRequestProperties();


            var randomCreateChargeRequest = new CreateChargeRequest
            {

                Amount = createRandomCreateChargeRequestProperties.Amount,
                Currency = createRandomCreateChargeRequestProperties.Currency,
                Email = createRandomCreateChargeRequestProperties.Email,
                CardNumber = createRandomCreateChargeRequestProperties.CardNumber,
                ClientIp = createRandomCreateChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCreateChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCreateChargeRequestProperties.PaymentPlan,
                UseSecureAuth = createRandomCreateChargeRequestProperties.UseSecureAuth,
                Authorization = new CreateChargeRequest.AuthorizationData
                {
                    Address = createRandomCreateChargeRequestProperties.Authorization.Address,
                    City = createRandomCreateChargeRequestProperties.Authorization.City,
                    Country = createRandomCreateChargeRequestProperties.Authorization.Country,
                    Mode = createRandomCreateChargeRequestProperties.Authorization.Mode,
                    Pin = createRandomCreateChargeRequestProperties.Authorization.Pin,
                    State = createRandomCreateChargeRequestProperties.Authorization.State,
                    ZipCode = createRandomCreateChargeRequestProperties.Authorization.ZipCode,
                },
                Cvv = createRandomCreateChargeRequestProperties.Cvv,
                ExpiryMonth = createRandomCreateChargeRequestProperties.ExpiryMonth,
                ExpiryYear = createRandomCreateChargeRequestProperties.ExpiryYear,
                FullName = createRandomCreateChargeRequestProperties.FullName,
                Meta = new CreateChargeRequest.CreateChargeMeta
                {
                    SideNote = createRandomCreateChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCreateChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCreateChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCreateChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCreateChargeRequestProperties.TxRef



            };

            var randomCreateCharge = new CreateCharge
            {
                Request = randomCreateChargeRequest
            };

            var randomEncryptionKey = GetRandomLengthyString();


            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidCreateChargeException =
                new InvalidPreauthorizationException(
                    httpResponseBadRequestException);

            var expectedPreauthorizationDependencyValidationException =
                new PreauthorizationDependencyValidationException(
                    invalidCreateChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateChargeAsync(It.IsAny<ExternalEncryptedChargeRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreateCharge> retrieveCreateChargeTask =
               this.preauthorizationService.PostCreateChargeRequestAsync(randomCreateCharge, randomEncryptionKey);

            PreauthorizationDependencyValidationException
                actualPreauthorizationDependencyValidationException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyValidationException>(
                        retrieveCreateChargeTask.AsTask);

            // then
            actualPreauthorizationDependencyValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateChargeAsync(It.IsAny<ExternalEncryptedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreateChargeRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomCreateChargeRequestProperties =
            CreateRandomCreateChargeRequestProperties();


            var randomCreateChargeRequest = new CreateChargeRequest
            {
                Amount = createRandomCreateChargeRequestProperties.Amount,
                Currency = createRandomCreateChargeRequestProperties.Currency,
                Email = createRandomCreateChargeRequestProperties.Email,
                CardNumber = createRandomCreateChargeRequestProperties.CardNumber,
                ClientIp = createRandomCreateChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCreateChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCreateChargeRequestProperties.PaymentPlan,
                UseSecureAuth = createRandomCreateChargeRequestProperties.UseSecureAuth,
                Authorization = new CreateChargeRequest.AuthorizationData
                {
                    Address = createRandomCreateChargeRequestProperties.Authorization.Address,
                    City = createRandomCreateChargeRequestProperties.Authorization.City,
                    Country = createRandomCreateChargeRequestProperties.Authorization.Country,
                    Mode = createRandomCreateChargeRequestProperties.Authorization.Mode,
                    Pin = createRandomCreateChargeRequestProperties.Authorization.Pin,
                    State = createRandomCreateChargeRequestProperties.Authorization.State,
                    ZipCode = createRandomCreateChargeRequestProperties.Authorization.ZipCode,
                },
                Cvv = createRandomCreateChargeRequestProperties.Cvv,
                ExpiryMonth = createRandomCreateChargeRequestProperties.ExpiryMonth,
                ExpiryYear = createRandomCreateChargeRequestProperties.ExpiryYear,
                FullName = createRandomCreateChargeRequestProperties.FullName,
                Meta = new CreateChargeRequest.CreateChargeMeta
                {
                    SideNote = createRandomCreateChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCreateChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCreateChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCreateChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCreateChargeRequestProperties.TxRef



            };

            var randomCreateCharge = new CreateCharge
            {
                Request = randomCreateChargeRequest
            };

            var randomEncryptionKey = GetRandomLengthyString();


            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallCreateChargeException =
                new ExcessiveCallPreauthorizationException(
                    httpResponseTooManyRequestsException);

            var expectedPreauthorizationDependencyValidationException =
                new PreauthorizationDependencyValidationException(
                    excessiveCallCreateChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateChargeAsync(It.IsAny<ExternalEncryptedChargeRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreateCharge> retrieveCreateChargeTask =
               this.preauthorizationService.PostCreateChargeRequestAsync(randomCreateCharge, randomEncryptionKey);

            PreauthorizationDependencyValidationException actualPreauthorizationDependencyValidationException =
                await Assert.ThrowsAsync<PreauthorizationDependencyValidationException>(
                    retrieveCreateChargeTask.AsTask);

            // then
            actualPreauthorizationDependencyValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateChargeAsync(It.IsAny<ExternalEncryptedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostPostCreateChargeRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateChargeRequestProperties =
            CreateRandomCreateChargeRequestProperties();


            var randomCreateChargeRequest = new CreateChargeRequest
            {
                Amount = createRandomCreateChargeRequestProperties.Amount,
                Currency = createRandomCreateChargeRequestProperties.Currency,
                Email = createRandomCreateChargeRequestProperties.Email,
                CardNumber = createRandomCreateChargeRequestProperties.CardNumber,
                ClientIp = createRandomCreateChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCreateChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCreateChargeRequestProperties.PaymentPlan,
                UseSecureAuth = createRandomCreateChargeRequestProperties.UseSecureAuth,
                Authorization = new CreateChargeRequest.AuthorizationData
                {
                    Address = createRandomCreateChargeRequestProperties.Authorization.Address,
                    City = createRandomCreateChargeRequestProperties.Authorization.City,
                    Country = createRandomCreateChargeRequestProperties.Authorization.Country,
                    Mode = createRandomCreateChargeRequestProperties.Authorization.Mode,
                    Pin = createRandomCreateChargeRequestProperties.Authorization.Pin,
                    State = createRandomCreateChargeRequestProperties.Authorization.State,
                    ZipCode = createRandomCreateChargeRequestProperties.Authorization.ZipCode,
                },
                Cvv = createRandomCreateChargeRequestProperties.Cvv,
                ExpiryMonth = createRandomCreateChargeRequestProperties.ExpiryMonth,
                ExpiryYear = createRandomCreateChargeRequestProperties.ExpiryYear,
                FullName = createRandomCreateChargeRequestProperties.FullName,
                Meta = new CreateChargeRequest.CreateChargeMeta
                {
                    SideNote = createRandomCreateChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCreateChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCreateChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCreateChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCreateChargeRequestProperties.TxRef



            };

            var randomCreateCharge = new CreateCharge
            {
                Request = randomCreateChargeRequest
            };

            var randomEncryptionKey = GetRandomLengthyString();


            var httpResponseException =
                new HttpResponseException();

            var failedServerCreateChargeException =
                new FailedServerPreauthorizationException(
                    httpResponseException);

            var expectedPreauthorizationDependencyException =
                new PreauthorizationDependencyException(
                    failedServerCreateChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateChargeAsync(It.IsAny<ExternalEncryptedChargeRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreateCharge> retrieveCreateChargeTask =
               this.preauthorizationService.PostCreateChargeRequestAsync(randomCreateCharge, randomEncryptionKey);

            PreauthorizationDependencyException actualPreauthorizationDependencyException =
                await Assert.ThrowsAsync<PreauthorizationDependencyException>(
                    retrieveCreateChargeTask.AsTask);

            // then
            actualPreauthorizationDependencyException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateChargeAsync(It.IsAny<ExternalEncryptedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostPostCreateChargeRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateChargeRequestProperties =
           CreateRandomCreateChargeRequestProperties();


            var randomCreateChargeRequest = new CreateChargeRequest
            {
                Amount = createRandomCreateChargeRequestProperties.Amount,
                Currency = createRandomCreateChargeRequestProperties.Currency,
                Email = createRandomCreateChargeRequestProperties.Email,
                CardNumber = createRandomCreateChargeRequestProperties.CardNumber,
                ClientIp = createRandomCreateChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCreateChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCreateChargeRequestProperties.PaymentPlan,
                UseSecureAuth = createRandomCreateChargeRequestProperties.UseSecureAuth,
                Authorization = new CreateChargeRequest.AuthorizationData
                {
                    Address = createRandomCreateChargeRequestProperties.Authorization.Address,
                    City = createRandomCreateChargeRequestProperties.Authorization.City,
                    Country = createRandomCreateChargeRequestProperties.Authorization.Country,
                    Mode = createRandomCreateChargeRequestProperties.Authorization.Mode,
                    Pin = createRandomCreateChargeRequestProperties.Authorization.Pin,
                    State = createRandomCreateChargeRequestProperties.Authorization.State,
                    ZipCode = createRandomCreateChargeRequestProperties.Authorization.ZipCode,
                },
                Cvv = createRandomCreateChargeRequestProperties.Cvv,
                ExpiryMonth = createRandomCreateChargeRequestProperties.ExpiryMonth,
                ExpiryYear = createRandomCreateChargeRequestProperties.ExpiryYear,
                FullName = createRandomCreateChargeRequestProperties.FullName,
                Meta = new CreateChargeRequest.CreateChargeMeta
                {
                    SideNote = createRandomCreateChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCreateChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCreateChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCreateChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCreateChargeRequestProperties.TxRef



            };

            var randomCreateCharge = new CreateCharge
            {
                Request = randomCreateChargeRequest
            };

            var randomEncryptionKey = GetRandomLengthyString();

            var serviceException = new Exception();

            var failedCreateChargeServiceException =
                new FailedPreauthorizationServiceException(serviceException);

            var expectedCreateChargeServiceException =
                new PreauthorizationServiceException(failedCreateChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateChargeAsync(It.IsAny<ExternalEncryptedChargeRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreateCharge> retrieveCreateChargeTask =
               this.preauthorizationService.PostCreateChargeRequestAsync(randomCreateCharge, randomEncryptionKey);

            PreauthorizationServiceException actualCreateChargeServiceException =
                await Assert.ThrowsAsync<PreauthorizationServiceException>(
                    retrieveCreateChargeTask.AsTask);

            // then
            actualCreateChargeServiceException.Should().BeEquivalentTo(
                expectedCreateChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateChargeAsync(It.IsAny<ExternalEncryptedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}