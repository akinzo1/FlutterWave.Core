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
        public async Task ShouldPostRwandaMobileMoneyWithRwandaMobileMoneyRequestAsync()
        {
            // given 



            dynamic createRandomRwandaMobileMoneyRequestProperties =
              CreateRandomRwandaMobileMoneyRequestProperties();

            dynamic createRandomRwandaMobileMoneyResponseProperties =
                CreateRandomRwandaMobileMoneyResponseProperties();


            var randomExternalRwandaMobileMoneyRequest = new ExternalRwandaMobileMoneyRequest
            {
                Amount = createRandomRwandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomRwandaMobileMoneyRequestProperties.Currency,
                Email = createRandomRwandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomRwandaMobileMoneyRequestProperties.TxRef,
                OrderId = createRandomRwandaMobileMoneyRequestProperties.OrderId,
                FullName = createRandomRwandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomRwandaMobileMoneyRequestProperties.PhoneNumber

            };

            var randomExternalRwandaMobileMoneyResponse = new ExternalRwandaMobileMoneyResponse
            {

                Meta = new ExternalRwandaMobileMoneyResponse.ExternalRwandaMobileMoneyMeta
                {
                    Authorization = new ExternalRwandaMobileMoneyResponse.Authorization
                    {
                        Redirect = createRandomRwandaMobileMoneyResponseProperties.Meta.Redirect,
                        Mode = createRandomRwandaMobileMoneyResponseProperties.Meta.Mode,


                    }
                },

                Message = createRandomRwandaMobileMoneyResponseProperties.Message,
                Status = createRandomRwandaMobileMoneyResponseProperties.Status,

            };


            var randomRwandaMobileMoneyRequest = new RwandaMobileMoneyRequest
            {
                Amount = createRandomRwandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomRwandaMobileMoneyRequestProperties.Currency,
                Email = createRandomRwandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomRwandaMobileMoneyRequestProperties.TxRef,
                OrderId = createRandomRwandaMobileMoneyRequestProperties.OrderId,
                FullName = createRandomRwandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomRwandaMobileMoneyRequestProperties.PhoneNumber

            };

            var randomRwandaMobileMoneyResponse = new RwandaMobileMoneyResponse
            {

                Meta = new RwandaMobileMoneyResponse.RwandaMobileMoneyMeta
                {
                    Authorization = new RwandaMobileMoneyResponse.Authorization
                    {
                        Redirect = createRandomRwandaMobileMoneyResponseProperties.Meta.Redirect,
                        Mode = createRandomRwandaMobileMoneyResponseProperties.Meta.Mode,


                    }
                },

                Message = createRandomRwandaMobileMoneyResponseProperties.Message,
                Status = createRandomRwandaMobileMoneyResponseProperties.Status,


            };


            var randomRwandaMobileMoney = new RwandaMobileMoney
            {
                Request = randomRwandaMobileMoneyRequest,
            };

            RwandaMobileMoney inputRwandaMobileMoney = randomRwandaMobileMoney;
            RwandaMobileMoney expectedRwandaMobileMoney = inputRwandaMobileMoney.DeepClone();
            expectedRwandaMobileMoney.Response = randomRwandaMobileMoneyResponse;

            ExternalRwandaMobileMoneyRequest mappedExternalRwandaMobileMoneyRequest =
               randomExternalRwandaMobileMoneyRequest;

            ExternalRwandaMobileMoneyResponse returnedExternalRwandaMobileMoneyResponse =
                randomExternalRwandaMobileMoneyResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeRwandaMobileMoneyAsync(It.Is(
                      SameExternalRwandaMobileMoneyRequestAs(mappedExternalRwandaMobileMoneyRequest))))
                     .ReturnsAsync(returnedExternalRwandaMobileMoneyResponse);

            // when
            RwandaMobileMoney actualCreateRwandaMobileMoney =
               await this.chargeService.PostChargeRwandaMobileMoneyRequestAsync(inputRwandaMobileMoney);

            // then
            actualCreateRwandaMobileMoney.Should().BeEquivalentTo(expectedRwandaMobileMoney);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostChargeRwandaMobileMoneyAsync(It.Is(
                   SameExternalRwandaMobileMoneyRequestAs(mappedExternalRwandaMobileMoneyRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}