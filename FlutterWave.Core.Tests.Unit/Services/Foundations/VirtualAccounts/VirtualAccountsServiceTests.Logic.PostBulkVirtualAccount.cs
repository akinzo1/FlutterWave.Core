



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
        public async Task ShouldPostBulkCreateVirtualAccountWithBulkCreateVirtualAccountsRequestAsync()
        {
            // given
            string inputEmail = GetRandomString();
            int inputAccounts = GetRandomNumber();
            string inputTxRef = GetRandomString();
            bool inputIsPermanent = GetRandomBoolean();



            dynamic createRandomBulkVirtualAccountsProperties =
                   CreateRandomBulkVirtualAccountsProperties();


            var randomExternalCreateBulkVirtualAccountsRequest = new ExternalCreateBulkVirtualAccountsRequest
            {

                Accounts = inputAccounts,
                Email = inputEmail,
                IsPermanent = inputIsPermanent,
                TxRef = inputTxRef

            };



            var randomExternalBulkCreateVirtualAccountsResponse = new ExternalBulkCreateVirtualAccountsResponse
            {

                Message = createRandomBulkVirtualAccountsProperties.Message,
                Status = createRandomBulkVirtualAccountsProperties.Status,
                Data = new ExternalBulkCreateVirtualAccountsResponse.ExternalBulkCreateVirtualAccountsData
                {
                    BatchId = createRandomBulkVirtualAccountsProperties.Data.BatchId,
                    ResponseCode = createRandomBulkVirtualAccountsProperties.Data.ResponseCode,
                    ResponseMessage = createRandomBulkVirtualAccountsProperties.Data.ResponseMessage
                }

            };



            var randomBulkCreateVirtualAccountResponse = new BulkCreateVirtualAccountResponse
            {

                Message = createRandomBulkVirtualAccountsProperties.Message,
                Status = createRandomBulkVirtualAccountsProperties.Status,
                Data = new BulkCreateVirtualAccountResponse.BulkCreateVirtualAccountsData
                {
                    BatchId = createRandomBulkVirtualAccountsProperties.Data.BatchId,
                    ResponseCode = createRandomBulkVirtualAccountsProperties.Data.ResponseCode,
                    ResponseMessage = createRandomBulkVirtualAccountsProperties.Data.ResponseMessage
                }

            };



            var randomBulkCreateVirtualAccountsRequest = new BulkCreateVirtualAccountsRequest
            {
                Accounts = inputAccounts,
                Email = inputEmail,
                IsPermanent = inputIsPermanent,
                TxRef = inputTxRef


            };


            var randomBulkCreateVirtualAccounts = new BulkCreateVirtualAccounts
            {
                Request = randomBulkCreateVirtualAccountsRequest,
            };

            BulkCreateVirtualAccounts inputBulkCreateVirtualAccounts = randomBulkCreateVirtualAccounts;
            BulkCreateVirtualAccounts expectedBulkCreateVirtualAccounts = inputBulkCreateVirtualAccounts.DeepClone();
            expectedBulkCreateVirtualAccounts.Response = randomBulkCreateVirtualAccountResponse;

            ExternalCreateBulkVirtualAccountsRequest mappedExternalBulkCreateVirtualAccountsRequest =
               randomExternalCreateBulkVirtualAccountsRequest;

            ExternalBulkCreateVirtualAccountsResponse returnedExternalBulkCreateVirtualAccountsResponse =
                randomExternalBulkCreateVirtualAccountsResponse;


            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostBulkCreateVirtualAccountsRequestAsync(It.Is(
                 SameExternalCreateBulkVirtualAccountsRequestAs(mappedExternalBulkCreateVirtualAccountsRequest))))
                .ReturnsAsync(randomExternalBulkCreateVirtualAccountsResponse);


            // when
            BulkCreateVirtualAccounts actualBulkCreateVirtualAccounts =
                await this.virtualAccountsService.PostBulkCreateVirtualAccountsRequestAsync(inputBulkCreateVirtualAccounts);

            // then
            actualBulkCreateVirtualAccounts.Should().BeEquivalentTo(expectedBulkCreateVirtualAccounts);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostBulkCreateVirtualAccountsRequestAsync(It.Is(
                   SameExternalCreateBulkVirtualAccountsRequestAs(mappedExternalBulkCreateVirtualAccountsRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}