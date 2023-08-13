



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualAccounts
{
    public partial class VirtualAccountsServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveVirtualAccountsDetailsOfAccountAsync()
        {
            // given 
            string inputVirtualAccountsId = GetRandomString();


            dynamic createRandomBulkVirtualAccountDetailsProperties =
                     CreateRandomBulkVirtualAccountDetailsProperties();


            var randomExternalBulkVirtualAccountDetailsResponse = new ExternalBulkVirtualAccountDetailsResponse
            {

                Message = createRandomBulkVirtualAccountDetailsProperties.Message,
                Status = createRandomBulkVirtualAccountDetailsProperties.Status,
                Data = ((List<dynamic>)createRandomBulkVirtualAccountDetailsProperties.Data).Select(data =>
                {
                    return new ExternalBulkVirtualAccountDetailsResponse.Datum
                    {
                        AccountNumber = data.AccountNumber,
                        Amount = data.Amount,
                        BankName = data.BankName,
                        CreatedAt = data.CreatedAt,
                        ExpiryDate = data.ExpiryDate,
                        FlwRef = data.FlwRef,
                        Frequency = data.Frequency,
                        Note = data.Note,
                        OrderRef = data.OrderRef,
                        ResponseCode = data.ResponseCode,
                        ResponseMessage = data.ResponseMessage,

                    };

                }).ToList()

            };

            var randomBulkVirtualAccountDetailsResponse = new BulkVirtualAccountDetailsResponse
            {

                Message = createRandomBulkVirtualAccountDetailsProperties.Message,
                Status = createRandomBulkVirtualAccountDetailsProperties.Status,
                Data = ((List<dynamic>)createRandomBulkVirtualAccountDetailsProperties.Data).Select(data =>
                {
                    return new BulkVirtualAccountDetailsResponse.Datum
                    {
                        AccountNumber = data.AccountNumber,
                        Amount = data.Amount,
                        BankName = data.BankName,
                        CreatedAt = data.CreatedAt,
                        ExpiryDate = data.ExpiryDate,
                        FlwRef = data.FlwRef,
                        Frequency = data.Frequency,
                        Note = data.Note,
                        OrderRef = data.OrderRef,
                        ResponseCode = data.ResponseCode,
                        ResponseMessage = data.ResponseMessage,

                    };

                }).ToList()

            };

            var expectedVirtualAccounts = new BulkVirtualAccountDetails
            {
                Response = randomBulkVirtualAccountDetailsResponse
            };


            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBulkVirtualAccountDetailsRequestAsync(inputVirtualAccountsId))
                    .ReturnsAsync(randomExternalBulkVirtualAccountDetailsResponse);

            // when
            BulkVirtualAccountDetails actualVirtualAccounts =
               await this.virtualAccountsService.GetVirtualAccountDetailsRequestAsync(inputVirtualAccountsId);

            // then
            actualVirtualAccounts.Should().BeEquivalentTo(expectedVirtualAccounts);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkVirtualAccountDetailsRequestAsync(inputVirtualAccountsId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}