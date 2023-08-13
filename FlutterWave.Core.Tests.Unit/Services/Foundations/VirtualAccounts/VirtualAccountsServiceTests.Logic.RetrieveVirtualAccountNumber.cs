



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualAccounts
{
    public partial class VirtualAccountsServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveVirtualAccountNumberOfAccountAsync()
        {
            // given 
            string inputVirtualAccountsId = GetRandomString();


            dynamic createRandomVirtualAccountNumberProperties =
                     CreateRandomVirtualAccountNumberProperties();


            var randomExternalVirtualAccountNumberResponse = new ExternalVirtualAccountNumberResponse
            {

                Message = createRandomVirtualAccountNumberProperties.Message,
                Status = createRandomVirtualAccountNumberProperties.Status,
                Data = new ExternalVirtualAccountNumberResponse.VirtualAccountNumberData
                {
                    AccountNumber = createRandomVirtualAccountNumberProperties.Data.AccountNumber,
                    Amount = createRandomVirtualAccountNumberProperties.Data.Amount,
                    BankName = createRandomVirtualAccountNumberProperties.Data.BankName,
                    CreatedAt = createRandomVirtualAccountNumberProperties.Data.CreatedAt,
                    ExpiryDate = createRandomVirtualAccountNumberProperties.Data.ExpiryDate,
                    FlwRef = createRandomVirtualAccountNumberProperties.Data.FlwRef,
                    Frequency = createRandomVirtualAccountNumberProperties.Data.Frequency,
                    Note = createRandomVirtualAccountNumberProperties.Data.Note,
                    OrderRef = createRandomVirtualAccountNumberProperties.Data.OrderRef,
                    ResponseCode = createRandomVirtualAccountNumberProperties.Data.ResponseCode,
                    ResponseMessage = createRandomVirtualAccountNumberProperties.Data.ResponseMessage
                }

            };


            var randomVirtualAccountNumberResponse = new FetchVirtualAccountNumberResponse
            {

                Message = createRandomVirtualAccountNumberProperties.Message,
                Status = createRandomVirtualAccountNumberProperties.Status,
                Data = new FetchVirtualAccountNumberResponse.VirtualAccountNumberData
                {
                    AccountNumber = createRandomVirtualAccountNumberProperties.Data.AccountNumber,
                    Amount = createRandomVirtualAccountNumberProperties.Data.Amount,
                    BankName = createRandomVirtualAccountNumberProperties.Data.BankName,
                    CreatedAt = createRandomVirtualAccountNumberProperties.Data.CreatedAt,
                    ExpiryDate = createRandomVirtualAccountNumberProperties.Data.ExpiryDate,
                    FlwRef = createRandomVirtualAccountNumberProperties.Data.FlwRef,
                    Frequency = createRandomVirtualAccountNumberProperties.Data.Frequency,
                    Note = createRandomVirtualAccountNumberProperties.Data.Note,
                    OrderRef = createRandomVirtualAccountNumberProperties.Data.OrderRef,
                    ResponseCode = createRandomVirtualAccountNumberProperties.Data.ResponseCode,
                    ResponseMessage = createRandomVirtualAccountNumberProperties.Data.ResponseMessage
                }

            };

            var expectedVirtualAccounts = new FetchVirtualAccounts
            {
                Response = randomVirtualAccountNumberResponse
            };


            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetVirtualAccountNumberRequestAsync(inputVirtualAccountsId))
                    .ReturnsAsync(randomExternalVirtualAccountNumberResponse);

            // when
            FetchVirtualAccounts actualVirtualAccounts =
               await this.virtualAccountsService.GetVirtualAccountNumberRequestAsync(inputVirtualAccountsId);

            // then
            actualVirtualAccounts.Should().BeEquivalentTo(expectedVirtualAccounts);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualAccountNumberRequestAsync(inputVirtualAccountsId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}