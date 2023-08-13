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
        public async Task ShouldPostUgandaMobileMoneyWithUgandaMobileMoneyRequestAsync()
        {
            // given 



            dynamic createRandomUgandaMobileMoneyRequestProperties =
              CreateRandomUgandaMobileMoneyRequestProperties();

            dynamic createRandomUgandaMobileMoneyResponseProperties =
                CreateRandomUgandaMobileMoneyResponseProperties();


            var randomExternalUgandaMobileMoneyRequest = new ExternalUgandaMobileMoneyRequest
            {
                Amount = createRandomUgandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomUgandaMobileMoneyRequestProperties.Currency,
                Email = createRandomUgandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomUgandaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomUgandaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomUgandaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomUgandaMobileMoneyRequestProperties.Network,
                Voucher = createRandomUgandaMobileMoneyRequestProperties.Voucher,
                Meta = new ExternalUgandaMobileMoneyRequest.ExternalUgandaMobileMoneyMeta
                {
                    FlightID = createRandomUgandaMobileMoneyRequestProperties.Meta.FlightID,

                },
                Fullname = createRandomUgandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomUgandaMobileMoneyRequestProperties.PhoneNumber

            };

            var randomExternalUgandaMobileMoneyResponse = new ExternalUgandaMobileMoneyResponse
            {

                Meta = new ExternalUgandaMobileMoneyResponse.ExternalUgandaMobileMoneyMeta
                {
                    Authorization = new ExternalUgandaMobileMoneyResponse.Authorization
                    {
                        Redirect = createRandomUgandaMobileMoneyResponseProperties.Meta.Authorization.Redirect,
                        Mode = createRandomUgandaMobileMoneyResponseProperties.Meta.Authorization.Mode
                    },

                },

                Message = createRandomUgandaMobileMoneyResponseProperties.Message,
                Status = createRandomUgandaMobileMoneyResponseProperties.Status,

            };


            var randomUgandaMobileMoneyRequest = new UgandaMobileMoneyRequest
            {
                Amount = createRandomUgandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomUgandaMobileMoneyRequestProperties.Currency,
                Email = createRandomUgandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomUgandaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomUgandaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomUgandaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomUgandaMobileMoneyRequestProperties.Network,
                Voucher = createRandomUgandaMobileMoneyRequestProperties.Voucher,
                Meta = new UgandaMobileMoneyRequest.UgandaMobileMoneyMeta
                {
                    FlightID = createRandomUgandaMobileMoneyRequestProperties.Meta.FlightID,

                },
                FullName = createRandomUgandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomUgandaMobileMoneyRequestProperties.PhoneNumber

            };

            var randomUgandaMobileMoneyResponse = new UgandaMobileMoneyResponse
            {
                Meta = new UgandaMobileMoneyResponse.UgandaMobileMoneyMeta
                {
                    Authorization = new UgandaMobileMoneyResponse.Authorization
                    {
                        Redirect = createRandomUgandaMobileMoneyResponseProperties.Meta.Authorization.Redirect,
                        Mode = createRandomUgandaMobileMoneyResponseProperties.Meta.Authorization.Mode
                    },

                },

                Message = createRandomUgandaMobileMoneyResponseProperties.Message,
                Status = createRandomUgandaMobileMoneyResponseProperties.Status,
            };


            var randomUgandaMobileMoney = new UgandaMobileMoney
            {
                Request = randomUgandaMobileMoneyRequest,
            };

            UgandaMobileMoney inputUgandaMobileMoney = randomUgandaMobileMoney;
            UgandaMobileMoney expectedUgandaMobileMoney = inputUgandaMobileMoney.DeepClone();
            expectedUgandaMobileMoney.Response = randomUgandaMobileMoneyResponse;

            ExternalUgandaMobileMoneyRequest mappedExternalUgandaMobileMoneyRequest =
               randomExternalUgandaMobileMoneyRequest;

            ExternalUgandaMobileMoneyResponse returnedExternalUgandaMobileMoneyResponse =
                randomExternalUgandaMobileMoneyResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeUgandaMobileMoneyAsync(It.Is(
                      SameExternalUgandaMobileMoneyRequestAs(mappedExternalUgandaMobileMoneyRequest))))
                     .ReturnsAsync(returnedExternalUgandaMobileMoneyResponse);

            // when
            UgandaMobileMoney actualCreateUgandaMobileMoney =
               await this.chargeService.PostChargeUgandaMobileMoneyRequestAsync(inputUgandaMobileMoney);

            // then
            actualCreateUgandaMobileMoney.Should().BeEquivalentTo(expectedUgandaMobileMoney);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeUgandaMobileMoneyAsync(It.Is(
                   SameExternalUgandaMobileMoneyRequestAs(mappedExternalUgandaMobileMoneyRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}