using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalChargeBack;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.ChargeBacks
{
    public partial class ChargeBackServiceTests
    {
        [Fact]
        public async Task ShouldPostBillPaymentWithBillPaymentRequestAsync()
        {
            // given 
            string randomAction = GetRandomString();
            string randomComment = GetRandomString();
            string inputAction = randomAction;
            string inputComment = randomComment;
            string randomId = GetRandomString();
            string inputChargeBackId = randomId;


            dynamic createRandomAcceptDeclineChargeBacksProperties =
                  CreateRandomAcceptDeclineChargeBacksProperties();


            var randomExternalAcceptDeclineChargeBackRequest = new ExternalAcceptDeclineChargeBackRequest
            {
                Action = inputAction,
                Comment = inputComment,

            };

            var randomExternalAcceptDeclineChargeBackResponse = new ExternalAcceptDeclineChargeBackResponse
            {

                Message = createRandomAcceptDeclineChargeBacksProperties.Message,
                Status = createRandomAcceptDeclineChargeBacksProperties.Status,

            };



            var randomAcceptDeclineChargeBackRequest = new AcceptDeclineChargeBackRequest
            {
                Action = inputAction,
                Comment = inputComment,

            };

            var randomAcceptDeclineChargeBackResponse = new AcceptDeclineChargeBackResponse
            {

                Message = createRandomAcceptDeclineChargeBacksProperties.Message,
                Status = createRandomAcceptDeclineChargeBacksProperties.Status,

            };

            var randomAcceptDeclineChargeBack = new AcceptDeclineChargeBack
            {
                Request = randomAcceptDeclineChargeBackRequest,
            };

            AcceptDeclineChargeBack inputAcceptDeclineChargeBack = randomAcceptDeclineChargeBack;
            AcceptDeclineChargeBack expectedAcceptDeclineChargeBack = inputAcceptDeclineChargeBack.DeepClone();
            expectedAcceptDeclineChargeBack.Response = randomAcceptDeclineChargeBackResponse;

            ExternalAcceptDeclineChargeBackRequest mappedExternalAcceptDeclineChargeBackRequest =
               randomExternalAcceptDeclineChargeBackRequest;

            ExternalAcceptDeclineChargeBackResponse returnedExternalAcceptDeclineChargeBackResponse =
                randomExternalAcceptDeclineChargeBackResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
             broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(), It.Is(
                 SameExternalAcceptDeclineChargeBackRequestAs(mappedExternalAcceptDeclineChargeBackRequest))))
                .ReturnsAsync(returnedExternalAcceptDeclineChargeBackResponse);

            // when
            AcceptDeclineChargeBack actualCreateBillPayments =
                await this.chargeBackService.PostAcceptDeclineChargeBacksAsync(inputChargeBackId, inputAcceptDeclineChargeBack);

            // then
            actualCreateBillPayments.Should().BeEquivalentTo(expectedAcceptDeclineChargeBack);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(), It.Is(
                   SameExternalAcceptDeclineChargeBackRequestAs(mappedExternalAcceptDeclineChargeBackRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}