



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Preauthorization
{
    public partial class PreauthorizationServiceTests
    {
        [Fact]
        public async Task ShouldPostCreateChargeWithCreateChargeRequestAsync()
        {
            // given 



            dynamic createRandomCreateChargeRequestProperties =
              CreateRandomCreateChargeRequestProperties();

            dynamic createRandomCreateChargeResponseProperties =
                CreateRandomCreateChargeResponseProperties();


            var randomExternalCreateChargeRequest = new ExternalCreateChargeRequest
            {
                Amount = createRandomCreateChargeRequestProperties.Amount,
                Currency = createRandomCreateChargeRequestProperties.Currency,
                Email = createRandomCreateChargeRequestProperties.Email,
                CardNumber = createRandomCreateChargeRequestProperties.CardNumber,
                ClientIp = createRandomCreateChargeRequestProperties.ClientIp,
                DeviceFingerprint = createRandomCreateChargeRequestProperties.DeviceFingerprint,
                PaymentPlan = createRandomCreateChargeRequestProperties.PaymentPlan,
                UseSecureAuth = createRandomCreateChargeRequestProperties.UseSecureAuth,
                Authorization = new ExternalCreateChargeRequest.ExternalAuthorizationData
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
                Meta = new ExternalCreateChargeRequest.ExternalMeta
                {
                    SideNote = createRandomCreateChargeRequestProperties.Meta.SideNote,
                    FlightId = createRandomCreateChargeRequestProperties.Meta.FlightId
                },
                Preauthorize = createRandomCreateChargeRequestProperties.Preauthorize,
                RedirectUrl = createRandomCreateChargeRequestProperties.RedirectUrl,
                TxRef = createRandomCreateChargeRequestProperties.TxRef


            };

            var randomExternalCreateChargeResponse = new ExternalCreateChargeResponse
            {

                Data = createRandomCreateChargeResponseProperties.Data,
                Message = createRandomCreateChargeResponseProperties.Message,
                Status = createRandomCreateChargeResponseProperties.Status,

            };


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

            var randomCreateChargeResponse = new CreateChargeResponse
            {

                Data = createRandomCreateChargeResponseProperties.Data,
                Message = createRandomCreateChargeResponseProperties.Message,
                Status = createRandomCreateChargeResponseProperties.Status,

            };


            var randomCreateCharge = new CreateCharge
            {
                Request = randomCreateChargeRequest,
            };


            var randomEncryptionKey = GetRandomLengthyString();

            CreateCharge inputCreateCharge = randomCreateCharge;
            CreateCharge expectedCreateCharge = inputCreateCharge.DeepClone();
            expectedCreateCharge.Response = randomCreateChargeResponse;

            ExternalCreateChargeRequest mappedExternalCreateChargeRequest =
               randomExternalCreateChargeRequest;

            ExternalCreateChargeResponse returnedExternalCreateChargeResponse =
                randomExternalCreateChargeResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateChargeAsync(It.IsAny<ExternalEncryptedChargeRequest>()))
                     .ReturnsAsync(returnedExternalCreateChargeResponse);

            // when
            CreateCharge actualCreateCreateCharge =
               await this.preauthorizationService.PostCreateChargeRequestAsync(inputCreateCharge, randomEncryptionKey);

            // then
            actualCreateCreateCharge.Should().BeEquivalentTo(expectedCreateCharge);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostCreateChargeAsync(It.IsAny<ExternalEncryptedChargeRequest>()),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}