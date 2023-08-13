using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostCardChargeRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomCardChargeRequestProperties =
             CreateRandomCardChargeRequestProperties();


            var randomCardChargeRequest = new CardChargeRequest
            {
                Amount = createRandomCardChargeRequestProperties.Amount,
                Currency = createRandomCardChargeRequestProperties.Currency,
                Email = createRandomCardChargeRequestProperties.Email,
                CardNumber = createRandomCardChargeRequestProperties.CardNumber,
                ClientIp = createRandomCardChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCardChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCardChargeRequestProperties.PaymentPlan,
                Authorization = new CardChargeRequest.AuthorizationData
                {
                    Address = createRandomCardChargeRequestProperties.Authorization.Address,
                    City = createRandomCardChargeRequestProperties.Authorization.City,
                    Country = createRandomCardChargeRequestProperties.Authorization.Country,
                    Mode = createRandomCardChargeRequestProperties.Authorization.Mode,
                    Pin = createRandomCardChargeRequestProperties.Authorization.Pin,
                    State = createRandomCardChargeRequestProperties.Authorization.State,
                    ZipCode = createRandomCardChargeRequestProperties.Authorization.ZipCode,
                },
                Cvv = createRandomCardChargeRequestProperties.Cvv,
                ExpiryMonth = createRandomCardChargeRequestProperties.ExpiryMonth,
                ExpiryYear = createRandomCardChargeRequestProperties.ExpiryYear,
                FullName = createRandomCardChargeRequestProperties.FullName,
                Meta = new CardChargeRequest.CardMeta
                {
                    SideNote = createRandomCardChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCardChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCardChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCardChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCardChargeRequestProperties.TxRef




            };


            var randomCardCharge = new CardCharge
            {
                Request = randomCardChargeRequest
            };

            var randomEncryptionKey = GetRandomLengthyString();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationChargeException =
                new InvalidConfigurationChargeException(
                    httpResponseUrlNotFoundException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(
                    invalidConfigurationChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeCardAsync(It.IsAny<ExternalEncryptedChargeRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CardCharge> retrieveChargeTask =
               this.chargeService.PostChargeCardRequestAsync(randomCardCharge, randomEncryptionKey);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeCardAsync(It.IsAny<ExternalEncryptedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostCardChargeRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomCardChargeRequestProperties =
             CreateRandomCardChargeRequestProperties();




            var randomCardChargeRequest = new CardChargeRequest
            {
                Amount = createRandomCardChargeRequestProperties.Amount,
                Currency = createRandomCardChargeRequestProperties.Currency,
                Email = createRandomCardChargeRequestProperties.Email,
                CardNumber = createRandomCardChargeRequestProperties.CardNumber,
                ClientIp = createRandomCardChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCardChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCardChargeRequestProperties.PaymentPlan,
                Authorization = new CardChargeRequest.AuthorizationData
                {
                    Address = createRandomCardChargeRequestProperties.Authorization.Address,
                    City = createRandomCardChargeRequestProperties.Authorization.City,
                    Country = createRandomCardChargeRequestProperties.Authorization.Country,
                    Mode = createRandomCardChargeRequestProperties.Authorization.Mode,
                    Pin = createRandomCardChargeRequestProperties.Authorization.Pin,
                    State = createRandomCardChargeRequestProperties.Authorization.State,
                    ZipCode = createRandomCardChargeRequestProperties.Authorization.ZipCode,
                },
                Cvv = createRandomCardChargeRequestProperties.Cvv,
                ExpiryMonth = createRandomCardChargeRequestProperties.ExpiryMonth,
                ExpiryYear = createRandomCardChargeRequestProperties.ExpiryYear,
                FullName = createRandomCardChargeRequestProperties.FullName,
                Meta = new CardChargeRequest.CardMeta
                {
                    SideNote = createRandomCardChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCardChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCardChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCardChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCardChargeRequestProperties.TxRef




            };

            var randomCardCharge = new CardCharge
            {
                Request = randomCardChargeRequest
            };

            var randomEncryptionKey = GetRandomLengthyString();
            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeCardAsync(It.IsAny<ExternalEncryptedChargeRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CardCharge> retrieveChargeTask =
               this.chargeService.PostChargeCardRequestAsync(randomCardCharge, randomEncryptionKey);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeCardAsync(It.IsAny<ExternalEncryptedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCardChargeRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomCardChargeRequestProperties =
              CreateRandomCardChargeRequestProperties();




            var randomCardChargeRequest = new CardChargeRequest
            {
                Amount = createRandomCardChargeRequestProperties.Amount,
                Currency = createRandomCardChargeRequestProperties.Currency,
                Email = createRandomCardChargeRequestProperties.Email,
                CardNumber = createRandomCardChargeRequestProperties.CardNumber,
                ClientIp = createRandomCardChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCardChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCardChargeRequestProperties.PaymentPlan,
                Authorization = new CardChargeRequest.AuthorizationData
                {
                    Address = createRandomCardChargeRequestProperties.Authorization.Address,
                    City = createRandomCardChargeRequestProperties.Authorization.City,
                    Country = createRandomCardChargeRequestProperties.Authorization.Country,
                    Mode = createRandomCardChargeRequestProperties.Authorization.Mode,
                    Pin = createRandomCardChargeRequestProperties.Authorization.Pin,
                    State = createRandomCardChargeRequestProperties.Authorization.State,
                    ZipCode = createRandomCardChargeRequestProperties.Authorization.ZipCode,
                },
                Cvv = createRandomCardChargeRequestProperties.Cvv,
                ExpiryMonth = createRandomCardChargeRequestProperties.ExpiryMonth,
                ExpiryYear = createRandomCardChargeRequestProperties.ExpiryYear,
                FullName = createRandomCardChargeRequestProperties.FullName,
                Meta = new CardChargeRequest.CardMeta
                {
                    SideNote = createRandomCardChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCardChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCardChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCardChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCardChargeRequestProperties.TxRef




            };

            var randomCardCharge = new CardCharge
            {
                Request = randomCardChargeRequest
            };

            var randomEncryptionKey = GetRandomLengthyString();
            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundChargeException =
                new NotFoundChargeException(
                    httpResponseNotFoundException);

            var expectedChargeDependencyValidationException =
                new ChargeDependencyValidationException(
                    notFoundChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeCardAsync(It.IsAny<ExternalEncryptedChargeRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CardCharge> retrieveChargeTask =
               this.chargeService.PostChargeCardRequestAsync(randomCardCharge, randomEncryptionKey);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeCardAsync(It.IsAny<ExternalEncryptedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCardChargeRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomCardChargeRequestProperties =
          CreateRandomCardChargeRequestProperties();

            dynamic createRandomCardChargeResponseProperties =
                CreateRandomCardChargeResponseProperties();


            var randomCardChargeRequest = new CardChargeRequest
            {
                Amount = createRandomCardChargeRequestProperties.Amount,
                Currency = createRandomCardChargeRequestProperties.Currency,
                Email = createRandomCardChargeRequestProperties.Email,
                CardNumber = createRandomCardChargeRequestProperties.CardNumber,
                ClientIp = createRandomCardChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCardChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCardChargeRequestProperties.PaymentPlan,
                Authorization = new CardChargeRequest.AuthorizationData
                {
                    Address = createRandomCardChargeRequestProperties.Authorization.Address,
                    City = createRandomCardChargeRequestProperties.Authorization.City,
                    Country = createRandomCardChargeRequestProperties.Authorization.Country,
                    Mode = createRandomCardChargeRequestProperties.Authorization.Mode,
                    Pin = createRandomCardChargeRequestProperties.Authorization.Pin,
                    State = createRandomCardChargeRequestProperties.Authorization.State,
                    ZipCode = createRandomCardChargeRequestProperties.Authorization.ZipCode,
                },
                Cvv = createRandomCardChargeRequestProperties.Cvv,
                ExpiryMonth = createRandomCardChargeRequestProperties.ExpiryMonth,
                ExpiryYear = createRandomCardChargeRequestProperties.ExpiryYear,
                FullName = createRandomCardChargeRequestProperties.FullName,
                Meta = new CardChargeRequest.CardMeta
                {
                    SideNote = createRandomCardChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCardChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCardChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCardChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCardChargeRequestProperties.TxRef




            };

            var randomCardCharge = new CardCharge
            {
                Request = randomCardChargeRequest
            };

            var randomEncryptionKey = GetRandomLengthyString(); var httpResponseBadRequestException =
                   new HttpResponseBadRequestException();

            var invalidChargeException =
                new InvalidChargeException(
                    httpResponseBadRequestException);

            var expectedChargeDependencyValidationException =
                new ChargeDependencyValidationException(
                    invalidChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeCardAsync(It.IsAny<ExternalEncryptedChargeRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CardCharge> retrieveChargeTask =
               this.chargeService.PostChargeCardRequestAsync(randomCardCharge, randomEncryptionKey);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeCardAsync(It.IsAny<ExternalEncryptedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCardChargeRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomCardChargeRequestProperties =
          CreateRandomCardChargeRequestProperties();

            dynamic createRandomCardChargeResponseProperties =
                CreateRandomCardChargeResponseProperties();


            var randomCardChargeRequest = new CardChargeRequest
            {
                Amount = createRandomCardChargeRequestProperties.Amount,
                Currency = createRandomCardChargeRequestProperties.Currency,
                Email = createRandomCardChargeRequestProperties.Email,
                CardNumber = createRandomCardChargeRequestProperties.CardNumber,
                ClientIp = createRandomCardChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCardChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCardChargeRequestProperties.PaymentPlan,
                Authorization = new CardChargeRequest.AuthorizationData
                {
                    Address = createRandomCardChargeRequestProperties.Authorization.Address,
                    City = createRandomCardChargeRequestProperties.Authorization.City,
                    Country = createRandomCardChargeRequestProperties.Authorization.Country,
                    Mode = createRandomCardChargeRequestProperties.Authorization.Mode,
                    Pin = createRandomCardChargeRequestProperties.Authorization.Pin,
                    State = createRandomCardChargeRequestProperties.Authorization.State,
                    ZipCode = createRandomCardChargeRequestProperties.Authorization.ZipCode,
                },
                Cvv = createRandomCardChargeRequestProperties.Cvv,
                ExpiryMonth = createRandomCardChargeRequestProperties.ExpiryMonth,
                ExpiryYear = createRandomCardChargeRequestProperties.ExpiryYear,
                FullName = createRandomCardChargeRequestProperties.FullName,
                Meta = new CardChargeRequest.CardMeta
                {
                    SideNote = createRandomCardChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCardChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCardChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCardChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCardChargeRequestProperties.TxRef




            };

            var randomCardCharge = new CardCharge
            {
                Request = randomCardChargeRequest
            };

            var randomEncryptionKey = GetRandomLengthyString(); var httpResponseTooManyRequestsException =
                   new HttpResponseTooManyRequestsException();

            var excessiveCallChargeException =
                new ExcessiveCallChargeException(
                    httpResponseTooManyRequestsException);

            var expectedChargeDependencyValidationException =
                new ChargeDependencyValidationException(
                    excessiveCallChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeCardAsync(It.IsAny<ExternalEncryptedChargeRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CardCharge> retrieveChargeTask =
               this.chargeService.PostChargeCardRequestAsync(randomCardCharge, randomEncryptionKey);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeCardAsync(It.IsAny<ExternalEncryptedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostCardChargeRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomCardChargeRequestProperties =
          CreateRandomCardChargeRequestProperties();

            dynamic createRandomCardChargeResponseProperties =
                CreateRandomCardChargeResponseProperties();


            var randomCardChargeRequest = new CardChargeRequest
            {
                Amount = createRandomCardChargeRequestProperties.Amount,
                Currency = createRandomCardChargeRequestProperties.Currency,
                Email = createRandomCardChargeRequestProperties.Email,
                CardNumber = createRandomCardChargeRequestProperties.CardNumber,
                ClientIp = createRandomCardChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCardChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCardChargeRequestProperties.PaymentPlan,
                Authorization = new CardChargeRequest.AuthorizationData
                {
                    Address = createRandomCardChargeRequestProperties.Authorization.Address,
                    City = createRandomCardChargeRequestProperties.Authorization.City,
                    Country = createRandomCardChargeRequestProperties.Authorization.Country,
                    Mode = createRandomCardChargeRequestProperties.Authorization.Mode,
                    Pin = createRandomCardChargeRequestProperties.Authorization.Pin,
                    State = createRandomCardChargeRequestProperties.Authorization.State,
                    ZipCode = createRandomCardChargeRequestProperties.Authorization.ZipCode,
                },
                Cvv = createRandomCardChargeRequestProperties.Cvv,
                ExpiryMonth = createRandomCardChargeRequestProperties.ExpiryMonth,
                ExpiryYear = createRandomCardChargeRequestProperties.ExpiryYear,
                FullName = createRandomCardChargeRequestProperties.FullName,
                Meta = new CardChargeRequest.CardMeta
                {
                    SideNote = createRandomCardChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCardChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCardChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCardChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCardChargeRequestProperties.TxRef




            };

            var randomCardCharge = new CardCharge
            {
                Request = randomCardChargeRequest
            };

            var randomEncryptionKey = GetRandomLengthyString(); var httpResponseException =
                   new HttpResponseException();

            var failedServerChargeException =
                new FailedServerChargeException(
                    httpResponseException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(
                    failedServerChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeCardAsync(It.IsAny<ExternalEncryptedChargeRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CardCharge> retrieveChargeTask =
               this.chargeService.PostChargeCardRequestAsync(randomCardCharge, randomEncryptionKey);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeCardAsync(It.IsAny<ExternalEncryptedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostCardChargeRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomCardChargeRequestProperties =
            CreateRandomCardChargeRequestProperties();


            var randomCardChargeRequest = new CardChargeRequest
            {
                Amount = createRandomCardChargeRequestProperties.Amount,
                Currency = createRandomCardChargeRequestProperties.Currency,
                Email = createRandomCardChargeRequestProperties.Email,
                CardNumber = createRandomCardChargeRequestProperties.CardNumber,
                ClientIp = createRandomCardChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCardChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCardChargeRequestProperties.PaymentPlan,
                Authorization = new CardChargeRequest.AuthorizationData
                {
                    Address = createRandomCardChargeRequestProperties.Authorization.Address,
                    City = createRandomCardChargeRequestProperties.Authorization.City,
                    Country = createRandomCardChargeRequestProperties.Authorization.Country,
                    Mode = createRandomCardChargeRequestProperties.Authorization.Mode,
                    Pin = createRandomCardChargeRequestProperties.Authorization.Pin,
                    State = createRandomCardChargeRequestProperties.Authorization.State,
                    ZipCode = createRandomCardChargeRequestProperties.Authorization.ZipCode,
                },
                Cvv = createRandomCardChargeRequestProperties.Cvv,
                ExpiryMonth = createRandomCardChargeRequestProperties.ExpiryMonth,
                ExpiryYear = createRandomCardChargeRequestProperties.ExpiryYear,
                FullName = createRandomCardChargeRequestProperties.FullName,
                Meta = new CardChargeRequest.CardMeta
                {
                    SideNote = createRandomCardChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCardChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCardChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCardChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCardChargeRequestProperties.TxRef




            };

            var randomCardCharge = new CardCharge
            {
                Request = randomCardChargeRequest
            };

            var randomEncryptionKey = GetRandomLengthyString(); var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeCardAsync(It.IsAny<ExternalEncryptedChargeRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CardCharge> retrieveChargeTask =
               this.chargeService.PostChargeCardRequestAsync(randomCardCharge, randomEncryptionKey);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeCardAsync(It.IsAny<ExternalEncryptedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}