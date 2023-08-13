



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PayoutSubaccount
{
    public partial class PayoutSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveStaticVirtualAccountsAsync()
        {
            // given 
            dynamic createRandomFetchStaticVirtualAccountsResponseProperties =
                 CreateRandomFetchStaticVirtualAccountsResponseProperties();

            var accountReference = GetRandomString();
            var currency = GetRandomString();

            var randomExternalFetchStaticVirtualAccountsResponse = new ExternalFetchStaticVirtualAccountsResponse
            {
                Message = createRandomFetchStaticVirtualAccountsResponseProperties.Message,
                Status = createRandomFetchStaticVirtualAccountsResponseProperties.Status,
                Data = new ExternalFetchStaticVirtualAccountsResponse.ExternalFetchStaticVirtualAccountsData
                {
                    BankCode = createRandomFetchStaticVirtualAccountsResponseProperties.Data.BankCode,
                    BankName = createRandomFetchStaticVirtualAccountsResponseProperties.Data.BankName,
                    Currency = createRandomFetchStaticVirtualAccountsResponseProperties.Data.Currency,
                    IsDefault = createRandomFetchStaticVirtualAccountsResponseProperties.Data.IsDefault,
                    StaticAccount = createRandomFetchStaticVirtualAccountsResponseProperties.Data.StaticAccount,
                    Type = createRandomFetchStaticVirtualAccountsResponseProperties.Data.Type
                },




            };

            var randomExpectedFetchStaticVirtualAccountsResponse = new FetchStaticVirtualAccountsResponse
            {
                Message = createRandomFetchStaticVirtualAccountsResponseProperties.Message,
                Status = createRandomFetchStaticVirtualAccountsResponseProperties.Status,
                Data = new FetchStaticVirtualAccountsResponse.FetchStaticVirtualAccountsData
                {
                    BankCode = createRandomFetchStaticVirtualAccountsResponseProperties.Data.BankCode,
                    BankName = createRandomFetchStaticVirtualAccountsResponseProperties.Data.BankName,
                    Currency = createRandomFetchStaticVirtualAccountsResponseProperties.Data.Currency,
                    IsDefault = createRandomFetchStaticVirtualAccountsResponseProperties.Data.IsDefault,
                    StaticAccount = createRandomFetchStaticVirtualAccountsResponseProperties.Data.StaticAccount,
                    Type = createRandomFetchStaticVirtualAccountsResponseProperties.Data.Type
                },

            };


            var expectedInputRetrieveStaticVirtualAccountTransactions = new FetchStaticVirtualAccounts
            {
                Response = randomExpectedFetchStaticVirtualAccountsResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetStaticVirtualAccountAsync(accountReference, currency))
                    .ReturnsAsync(randomExternalFetchStaticVirtualAccountsResponse);

            // when
            FetchStaticVirtualAccounts actualRetrieveStaticVirtualAccountTransactions =
                await this.payoutSubaccountService.GetStaticVirtualAccountRequestAsync(accountReference, currency);

            // then
            actualRetrieveStaticVirtualAccountTransactions.Should().BeEquivalentTo(expectedInputRetrieveStaticVirtualAccountTransactions);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetStaticVirtualAccountAsync(accountReference, currency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}