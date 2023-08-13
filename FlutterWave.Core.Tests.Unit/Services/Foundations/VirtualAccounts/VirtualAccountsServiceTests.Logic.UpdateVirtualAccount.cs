



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualAccounts
{
    public partial class VirtualAccountsServiceTests
    {
        [Fact]
        public async Task ShouldPostBvnVirtualAccountsWithUpdateBvnVirtualAccountsRequestAsync()
        {
            // given
            string inputBvn = GetRandomString();
            string inputOrderReference = GetRandomString();




            dynamic createRandomUpdateVirtualAccountNumberProperties =
                   CreateRandomUpdateVirtualAccountNumberProperties();


            var randomExternalUpdateVirtualAccountBvnRequest = new ExternalUpdateVirtualAccountBvnRequest
            {

                Bvn = inputBvn

            };



            var randomExternalUpdateVirtualAccountBvnResponse = new ExternalUpdateVirtualAccountBvnResponse
            {

                Message = createRandomUpdateVirtualAccountNumberProperties.Message,
                Status = createRandomUpdateVirtualAccountNumberProperties.Status,
                Data = createRandomUpdateVirtualAccountNumberProperties.Data

            };



            var randomUpdateVirtualAccountBvnRequest = new UpdateVirtualAccountBvnRequest
            {

                Bvn = inputBvn

            };



            var randomUpdateVirtualAccountBvnResponse = new UpdateVirtualAccountBvnResponse
            {

                Message = createRandomUpdateVirtualAccountNumberProperties.Message,
                Status = createRandomUpdateVirtualAccountNumberProperties.Status,
                Data = createRandomUpdateVirtualAccountNumberProperties.Data

            };


            var randomUpdateBvnVirtualAccounts = new UpdateBvnVirtualAccounts
            {
                Request = randomUpdateVirtualAccountBvnRequest,
            };

            UpdateBvnVirtualAccounts inputUpdateBvnVirtualAccounts = randomUpdateBvnVirtualAccounts;
            UpdateBvnVirtualAccounts expectedUpdateBvnVirtualAccounts = inputUpdateBvnVirtualAccounts.DeepClone();
            expectedUpdateBvnVirtualAccounts.Response = randomUpdateVirtualAccountBvnResponse;

            ExternalUpdateVirtualAccountBvnRequest mappedExternalUpdateBvnVirtualAccountsRequest =
               randomExternalUpdateVirtualAccountBvnRequest;

            ExternalUpdateVirtualAccountBvnResponse returnedExternalUpdateBvnVirtualAccountsResponse =
                randomExternalUpdateVirtualAccountBvnResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
             broker.UpdateVirtualAccountsBvnRequestAsync(It.Is(
                 SameExternalUpdateVirtualAccountBvnRequestAs(mappedExternalUpdateBvnVirtualAccountsRequest)), inputOrderReference))
                .ReturnsAsync(returnedExternalUpdateBvnVirtualAccountsResponse);

            // when
            UpdateBvnVirtualAccounts actualUpdateBvnVirtualAccounts =
                await this.virtualAccountsService.UpdateVirtualAccountsBvnRequestAsync(inputUpdateBvnVirtualAccounts, inputOrderReference);

            // then
            actualUpdateBvnVirtualAccounts.Should().BeEquivalentTo(expectedUpdateBvnVirtualAccounts);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.UpdateVirtualAccountsBvnRequestAsync(It.Is(
                   SameExternalUpdateVirtualAccountBvnRequestAs(mappedExternalUpdateBvnVirtualAccountsRequest)), inputOrderReference),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}