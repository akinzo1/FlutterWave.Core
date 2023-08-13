



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
        public async Task ShouldPostCreateVirtualAccountWithCreateVirtualAccountsRequestAsync()
        {
            // given
            string inputEmail = GetRandomString();
            string inputBvn = GetRandomString();
            string inputTxRef = GetRandomString();
            string inputFirstName = GetRandomString();
            string inputLastName = GetRandomString();
            string inputNarration = GetRandomString();
            string inputPhoneNumber = GetRandomString();
            bool inputIsPermanent = GetRandomBoolean();



            dynamic createRandomBulkVirtualAccountsProperties =
                   CreateRandomVirtualAccountProperties();


            var randomExternalCreateVirtualAccountsResponse = new ExternalCreateVirtualAccountResponse
            {

                Data = new ExternalCreateVirtualAccountResponse.ExternalCreateVirtualAccountDataModel
                {
                    AccountNumber = createRandomBulkVirtualAccountsProperties.Data.AccountNumber,
                    Amount = createRandomBulkVirtualAccountsProperties.Data.Amount,
                    BankName = createRandomBulkVirtualAccountsProperties.Data.BankName,
                    OrderRef = createRandomBulkVirtualAccountsProperties.Data.OrderRef,
                    ResponseCode = createRandomBulkVirtualAccountsProperties.Data.ResponseCode,
                    ResponseMessage = createRandomBulkVirtualAccountsProperties.Data.ResponseMessage
                },
                Message = createRandomBulkVirtualAccountsProperties.Message,
                Status = createRandomBulkVirtualAccountsProperties.Status,

            };



            var randomExternalCreateVirtualAccountsRequest = new ExternalCreateVirtualAccountRequest
            {

                Bvn = inputBvn,
                Email = inputEmail,
                FirstName = inputFirstName,
                IsPermanent = inputIsPermanent,
                LastName = inputLastName,
                Narration = inputNarration,
                PhoneNumber = inputPhoneNumber,
                TxRef = inputTxRef


            };



            var randomCreateVirtualAccountResponse = new CreateVirtualAccountResponse
            {
                Data = new CreateVirtualAccountResponse.CreateVirtualAccountDataModel
                {
                    AccountNumber = createRandomBulkVirtualAccountsProperties.Data.AccountNumber,
                    Amount = createRandomBulkVirtualAccountsProperties.Data.Amount,
                    BankName = createRandomBulkVirtualAccountsProperties.Data.BankName,
                    OrderRef = createRandomBulkVirtualAccountsProperties.Data.OrderRef,
                    ResponseCode = createRandomBulkVirtualAccountsProperties.Data.ResponseCode,
                    ResponseMessage = createRandomBulkVirtualAccountsProperties.Data.ResponseMessage
                },
                Message = createRandomBulkVirtualAccountsProperties.Message,
                Status = createRandomBulkVirtualAccountsProperties.Status,
            };



            var randomCreateVirtualAccountRequest = new CreateVirtualAccountRequest
            {
                Bvn = inputBvn,
                Email = inputEmail,
                FirstName = inputFirstName,
                IsPermanent = inputIsPermanent,
                LastName = inputLastName,
                Narration = inputNarration,
                PhoneNumber = inputPhoneNumber,
                TxRef = inputTxRef


            };


            var randomCreateVirtualAccounts = new CreateVirtualAccounts
            {
                Request = randomCreateVirtualAccountRequest,
            };

            CreateVirtualAccounts inputCreateVirtualAccounts = randomCreateVirtualAccounts;
            CreateVirtualAccounts expectedCreateVirtualAccounts = inputCreateVirtualAccounts.DeepClone();
            expectedCreateVirtualAccounts.Response = randomCreateVirtualAccountResponse;

            ExternalCreateVirtualAccountRequest mappedExternalCreateVirtualAccountsRequest =
               randomExternalCreateVirtualAccountsRequest;

            ExternalCreateVirtualAccountResponse returnedExternalCreateVirtualAccountsResponse =
                randomExternalCreateVirtualAccountsResponse;


            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateVirtualAccountRequestAsync(It.Is(
                 SameExternalCreateVirtualAccountRRequestAs(mappedExternalCreateVirtualAccountsRequest))))
                .ReturnsAsync(randomExternalCreateVirtualAccountsResponse);


            // when
            CreateVirtualAccounts actualCreateVirtualAccounts =
                await this.virtualAccountsService.PostCreateVirtualAccountRequestAsync(inputCreateVirtualAccounts);

            // then
            actualCreateVirtualAccounts.Should().BeEquivalentTo(expectedCreateVirtualAccounts);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostCreateVirtualAccountRequestAsync(It.Is(
                   SameExternalCreateVirtualAccountRRequestAs(mappedExternalCreateVirtualAccountsRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}