using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldPostZambiaMobileMoneyWithZambiaMobileMoneyRequestAsync()
        {
            // given 



            dynamic createRandomZambiaMobileMoneyRequestProperties =
              CreateRandomZambiaMobileMoneyRequestProperties();

            dynamic createRandomZambiaMobileMoneyResponseProperties =
                CreateRandomZambiaMobileMoneyResponseProperties();


            var randomExternalZambiaMobileMoneyRequest = new ExternalZambiaMobileMoneyRequest
            {
                Amount = createRandomZambiaMobileMoneyRequestProperties.Amount,
                Currency = createRandomZambiaMobileMoneyRequestProperties.Currency,
                Email = createRandomZambiaMobileMoneyRequestProperties.Email,
                TxRef = createRandomZambiaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomZambiaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomZambiaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomZambiaMobileMoneyRequestProperties.Network,
                OrderId = createRandomZambiaMobileMoneyRequestProperties.OrderId,
                Meta = new ExternalZambiaMobileMoneyRequest.ExternalZambiaMobileMoneyMeta
                {
                    FlightID = createRandomZambiaMobileMoneyRequestProperties.Meta.FlightID
                },
                Fullname = createRandomZambiaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomZambiaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomExternalZambiaMobileMoneyResponse = new ExternalZambiaMobileMoneyResponse
            {
                Message = createRandomZambiaMobileMoneyResponseProperties.Message,
                Status = createRandomZambiaMobileMoneyResponseProperties.Status,
                Meta = new ExternalZambiaMobileMoneyResponse.ExternalZambiaMobileMoneyMeta
                {
                    Authorization = new ExternalZambiaMobileMoneyResponse.Authorization
                    {
                        Mode = createRandomZambiaMobileMoneyResponseProperties.Meta.Authorization.Mode,
                        Redirect = createRandomZambiaMobileMoneyResponseProperties.Meta.Authorization.Redirect
                    }
                },


            };

            var randomZambiaMobileMoneyRequest = new ZambiaMobileMoneyRequest
            {
                Amount = createRandomZambiaMobileMoneyRequestProperties.Amount,
                Currency = createRandomZambiaMobileMoneyRequestProperties.Currency,
                Email = createRandomZambiaMobileMoneyRequestProperties.Email,
                TxRef = createRandomZambiaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomZambiaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomZambiaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomZambiaMobileMoneyRequestProperties.Network,
                OrderId = createRandomZambiaMobileMoneyRequestProperties.OrderId,
                Meta = new ZambiaMobileMoneyRequest.ZambiaMobileMoneyMeta
                {
                    FlightID = createRandomZambiaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomZambiaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomZambiaMobileMoneyRequestProperties.PhoneNumber

            };

            var randomZambiaMobileMoneyResponse = new ZambiaMobileMoneyResponse
            {
                Message = createRandomZambiaMobileMoneyResponseProperties.Message,
                Status = createRandomZambiaMobileMoneyResponseProperties.Status,
                Meta = new ZambiaMobileMoneyResponse.ZambiaMobileMoneyMeta
                {
                    Authorization = new ZambiaMobileMoneyResponse.Authorization
                    {
                        Mode = createRandomZambiaMobileMoneyResponseProperties.Meta.Authorization.Mode,
                        Redirect = createRandomZambiaMobileMoneyResponseProperties.Meta.Authorization.Redirect
                    }
                },
            };

            var randomZambiaMobileMoney = new ZambiaMobileMoney
            {
                Request = randomZambiaMobileMoneyRequest,
            };

            ZambiaMobileMoney inputZambiaMobileMoney = randomZambiaMobileMoney;
            ZambiaMobileMoney expectedZambiaMobileMoney = inputZambiaMobileMoney.DeepClone();
            expectedZambiaMobileMoney.Response = randomZambiaMobileMoneyResponse;

            ExternalZambiaMobileMoneyRequest mappedExternalZambiaMobileMoneyRequest =
               randomExternalZambiaMobileMoneyRequest;

            ExternalZambiaMobileMoneyResponse returnedExternalZambiaMobileMoneyResponse =
                randomExternalZambiaMobileMoneyResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeZambiaMobileMoneyAsync(It.Is(
                      SameExternalZambiaMobileMoneyRequestAs(mappedExternalZambiaMobileMoneyRequest))))
                     .ReturnsAsync(returnedExternalZambiaMobileMoneyResponse);

            // when
            ZambiaMobileMoney actualCreateZambiaMobileMoney =
               await this.chargeService.PostChargeZambiaMobileMoneyRequestAsync(inputZambiaMobileMoney);

            // then
            actualCreateZambiaMobileMoney.Should().BeEquivalentTo(expectedZambiaMobileMoney);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeZambiaMobileMoneyAsync(It.Is(
                   SameExternalZambiaMobileMoneyRequestAs(mappedExternalZambiaMobileMoneyRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}