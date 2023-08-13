



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualAccounts
{
    public partial class VirtualAccountsServiceTests
    {
        [Fact]
        public async Task ShouldPostDeleteVirtualAccountsWithDeleteVirtualAccountsRequestAsync()
        {
            // given
            string inputStatus = GetRandomString();
            string inputOrderReference = GetRandomString();




            dynamic createRandomDeleteVirtualAccountNumberProperties =
                   CreateRandomDeleteVirtualAccountProperties();


            var randomExternalDeleteVirtualAccountRequest = new ExternalDeleteVirtualAccountRequest
            {

                Status = inputStatus

            };



            var randomExternalDeleteVirtualAccountResponse = new ExternalDeleteVirtualAccountResponse
            {

                Message = createRandomDeleteVirtualAccountNumberProperties.Message,
                Status = createRandomDeleteVirtualAccountNumberProperties.Status,
                Data = new ExternalDeleteVirtualAccountResponse.ExternalDeleteVirtualAccountData
                {
                    Status = createRandomDeleteVirtualAccountNumberProperties.Data.Status,
                    StatusDesc = createRandomDeleteVirtualAccountNumberProperties.Data.StatusDesc
                }

            };



            var randomDeleteVirtualAccountRequest = new DeleteVirtualAccountRequest
            {

                Status = inputStatus,

            };



            var randomDeleteVirtualAccountResponse = new DeleteVirtualAccountResponse
            {

                Message = createRandomDeleteVirtualAccountNumberProperties.Message,
                Status = createRandomDeleteVirtualAccountNumberProperties.Status,
                Data = new DeleteVirtualAccountResponse.DeleteVirtualAccountData
                {
                    Status = createRandomDeleteVirtualAccountNumberProperties.Data.Status,
                    StatusDesc = createRandomDeleteVirtualAccountNumberProperties.Data.StatusDesc
                }

            };


            var randomDeleteVirtualAccounts = new DeleteVirtualAccounts
            {
                Request = randomDeleteVirtualAccountRequest,
            };

            DeleteVirtualAccounts inputDeleteVirtualAccounts = randomDeleteVirtualAccounts;
            DeleteVirtualAccounts expectedDeleteVirtualAccounts = inputDeleteVirtualAccounts.DeepClone();
            expectedDeleteVirtualAccounts.Response = randomDeleteVirtualAccountResponse;

            ExternalDeleteVirtualAccountRequest mappedExternalDeleteVirtualAccountsRequest =
               randomExternalDeleteVirtualAccountRequest;

            ExternalDeleteVirtualAccountResponse returnedExternalDeleteVirtualAccountsResponse =
                randomExternalDeleteVirtualAccountResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
             broker.DeleteVirtualAccountsRequestAsync(It.Is(
                 SameExternalDeleteVirtualAccountRequestAs(mappedExternalDeleteVirtualAccountsRequest)), inputOrderReference))
                .ReturnsAsync(returnedExternalDeleteVirtualAccountsResponse);

            // when
            DeleteVirtualAccounts actualDeleteVirtualAccounts =
                await this.virtualAccountsService.DeleteVirtualAccountsRequestAsync(inputDeleteVirtualAccounts, inputOrderReference);

            // then
            actualDeleteVirtualAccounts.Should().BeEquivalentTo(expectedDeleteVirtualAccounts);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.DeleteVirtualAccountsRequestAsync(It.Is(
                   SameExternalDeleteVirtualAccountRequestAs(mappedExternalDeleteVirtualAccountsRequest)), inputOrderReference),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}