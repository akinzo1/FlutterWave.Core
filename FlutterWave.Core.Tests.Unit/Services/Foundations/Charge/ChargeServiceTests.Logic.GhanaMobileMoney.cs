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
        public async Task ShouldPostGhanaMobileMoneyWithGhanaMobileMoneyRequestAsync()
        {
            // given 



            dynamic createRandomGhanaMobileMoneyRequestProperties =
              CreateRandomGhanaMobileMoneyRequestProperties();

            dynamic createRandomGhanaMobileMoneyResponseProperties =
                CreateRandomGhanaMobileMoneyResponseProperties();


            var randomExternalGhanaMobileMoneyRequest = new ExternalGhanaMobileMoneyRequest
            {
                Amount = createRandomGhanaMobileMoneyRequestProperties.Amount,
                Currency = createRandomGhanaMobileMoneyRequestProperties.Currency,
                Email = createRandomGhanaMobileMoneyRequestProperties.Email,
                TxRef = createRandomGhanaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomGhanaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomGhanaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomGhanaMobileMoneyRequestProperties.Network,
                Voucher = createRandomGhanaMobileMoneyRequestProperties.Voucher,
                Meta = new ExternalGhanaMobileMoneyRequest.ExternalGhanaMobileMoneyMeta
                {
                    FlightID = createRandomGhanaMobileMoneyRequestProperties.Meta.FlightID
                },
                Fullname = createRandomGhanaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomGhanaMobileMoneyRequestProperties.PhoneNumber

            };

            var randomExternalGhanaMobileMoneyResponse = new ExternalGhanaMobileMoneyResponse
            {

                Meta = new ExternalGhanaMobileMoneyResponse.ExternalGhanaMobileMoneyMeta
                {
                    Authorization = new ExternalGhanaMobileMoneyResponse.Authorization
                    {
                        Mode = createRandomGhanaMobileMoneyResponseProperties.Meta.Authorization.Mode,
                        Redirect = createRandomGhanaMobileMoneyResponseProperties.Meta.Authorization.Redirect
                    }
                },

                Message = createRandomGhanaMobileMoneyResponseProperties.Message,
                Status = createRandomGhanaMobileMoneyResponseProperties.Status,

            };


            var randomGhanaMobileMoneyRequest = new GhanaMobileMoneyRequest
            {
                Amount = createRandomGhanaMobileMoneyRequestProperties.Amount,
                Currency = createRandomGhanaMobileMoneyRequestProperties.Currency,
                Email = createRandomGhanaMobileMoneyRequestProperties.Email,
                TxRef = createRandomGhanaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomGhanaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomGhanaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomGhanaMobileMoneyRequestProperties.Network,
                Voucher = createRandomGhanaMobileMoneyRequestProperties.Voucher,
                Meta = new GhanaMobileMoneyRequest.GhanaMobileMoneyMeta
                {
                    FlightID = createRandomGhanaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomGhanaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomGhanaMobileMoneyRequestProperties.PhoneNumber

            };

            var randomGhanaMobileMoneyResponse = new GhanaMobileMoneyResponse
            {
                Meta = new GhanaMobileMoneyResponse.GhanaMobileMoneyMeta
                {
                    Authorization = new GhanaMobileMoneyResponse.Authorization
                    {
                        Mode = createRandomGhanaMobileMoneyResponseProperties.Meta.Authorization.Mode,
                        Redirect = createRandomGhanaMobileMoneyResponseProperties.Meta.Authorization.Redirect
                    }
                },

                Message = createRandomGhanaMobileMoneyResponseProperties.Message,
                Status = createRandomGhanaMobileMoneyResponseProperties.Status,


            };


            var randomGhanaMobileMoney = new GhanaMobileMoney
            {
                Request = randomGhanaMobileMoneyRequest,
            };

            GhanaMobileMoney inputGhanaMobileMoney = randomGhanaMobileMoney;
            GhanaMobileMoney expectedGhanaMobileMoney = inputGhanaMobileMoney.DeepClone();
            expectedGhanaMobileMoney.Response = randomGhanaMobileMoneyResponse;

            ExternalGhanaMobileMoneyRequest mappedExternalGhanaMobileMoneyRequest =
               randomExternalGhanaMobileMoneyRequest;

            ExternalGhanaMobileMoneyResponse returnedExternalGhanaMobileMoneyResponse =
                randomExternalGhanaMobileMoneyResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeGhanaMobileMoneyAsync(It.Is(
                      SameExternalGhanaMobileMoneyRequestAs(mappedExternalGhanaMobileMoneyRequest))))
                     .ReturnsAsync(returnedExternalGhanaMobileMoneyResponse);

            // when
            GhanaMobileMoney actualCreateGhanaMobileMoney =
               await this.chargeService.PostChargeGhanaMobileMoneyRequestAsync(inputGhanaMobileMoney);

            // then
            actualCreateGhanaMobileMoney.Should().BeEquivalentTo(expectedGhanaMobileMoney);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeGhanaMobileMoneyAsync(It.Is(
                   SameExternalGhanaMobileMoneyRequestAs(mappedExternalGhanaMobileMoneyRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}