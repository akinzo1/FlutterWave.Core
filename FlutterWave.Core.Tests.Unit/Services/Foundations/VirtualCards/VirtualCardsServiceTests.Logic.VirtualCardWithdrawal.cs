



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Fact]
        public async Task ShouldPosVirtualCardWithdrawalWWithdrawalWitVirtualCardWithdrawalRWithdrawalRequestAsync()
        {
            // given 



            dynamic createRandomVirtualCardWithdrawalRequestProperties =
              CreateRandomVirtualCardWithdrawalRequestProperties();

            dynamic createRandomVirtualCardWithdrawalResponseProperties =
                CreateRandomVirtualCardWithdrawalResponseProperties();

            var virtualCardId = GetRandomString();

            var randomExternalVirtualCardWithdrawalRequest = new ExternalVirtualCardWithdrawalRequest
            {
                Amount = createRandomVirtualCardWithdrawalRequestProperties.Amount,



            };

            var randomExternalVirtualCardWithdrawalResponse = new ExternalVirtualCardWithdrawalResponse
            {
                Data = createRandomVirtualCardWithdrawalResponseProperties.Data,
                Message = createRandomVirtualCardWithdrawalResponseProperties.Message,
                Status = createRandomVirtualCardWithdrawalResponseProperties.Status,

            };


            var randomVirtualCardWithdrawalRequest = new VirtualCardWithdrawalRequest
            {
                Amount = createRandomVirtualCardWithdrawalRequestProperties.Amount,


            };

            var randomVirtualCardWithdrawalResponse = new VirtualCardWithdrawalResponse
            {
                Data = createRandomVirtualCardWithdrawalResponseProperties.Data,
                Message = createRandomVirtualCardWithdrawalResponseProperties.Message,
                Status = createRandomVirtualCardWithdrawalResponseProperties.Status,

            };


            var randomVirtualCardWithdrawal = new VirtualCardWithdrawal
            {
                Request = randomVirtualCardWithdrawalRequest,
            };

            VirtualCardWithdrawal inputVirtualCardWithdrawal = randomVirtualCardWithdrawal;
            VirtualCardWithdrawal expectedVirtualCardWithdrawal = inputVirtualCardWithdrawal.DeepClone();
            expectedVirtualCardWithdrawal.Response = randomVirtualCardWithdrawalResponse;

            ExternalVirtualCardWithdrawalRequest mappedExternalVirtualCardWithdrawalRequest =
               randomExternalVirtualCardWithdrawalRequest;

            ExternalVirtualCardWithdrawalResponse returnedExternalVirtualCardWithdrawalResponse =
                randomExternalVirtualCardWithdrawalResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(), It.Is(
                      SameExternalVirtualCardWithdrawalRequestAs(mappedExternalVirtualCardWithdrawalRequest))))
                     .ReturnsAsync(returnedExternalVirtualCardWithdrawalResponse);

            // when
            VirtualCardWithdrawal actualCreateVirtualCardWithdrawal =
               await this.virtualCardsService.PostVirtualCardWithdrawalRequestAsync(virtualCardId, inputVirtualCardWithdrawal);

            // then
            actualCreateVirtualCardWithdrawal.Should().BeEquivalentTo(expectedVirtualCardWithdrawal);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(), It.Is(
                   SameExternalVirtualCardWithdrawalRequestAs(mappedExternalVirtualCardWithdrawalRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}