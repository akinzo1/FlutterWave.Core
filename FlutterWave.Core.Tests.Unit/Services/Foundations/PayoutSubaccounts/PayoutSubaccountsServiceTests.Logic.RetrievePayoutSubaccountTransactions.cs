



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PayoutSubaccount
{
    public partial class PayoutSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldRetrievePayoutSubaccountAvailableBalanceAsync()
        {
            // given 
            dynamic createRandomFetchSubaccountAvailableBalanceResponseProperties =
                 CreateRandomFetchSubaccountAvailableBalanceResponseProperties();

            var accountReference = GetRandomString();
            var currency = GetRandomString();

            var randomExternalFetchPayoutSubaccountAvailableBalanceResponse = new ExternalFetchSubaccountAvailableBalanceResponse
            {
                Message = createRandomFetchSubaccountAvailableBalanceResponseProperties.Message,
                Status = createRandomFetchSubaccountAvailableBalanceResponseProperties.Status,
                Data = new ExternalFetchSubaccountAvailableBalanceResponse.ExternalFetchSubaccountAvailableBalanceData
                {
                    AvailableBalance = createRandomFetchSubaccountAvailableBalanceResponseProperties.Data.AvailableBalance,
                    Currency = createRandomFetchSubaccountAvailableBalanceResponseProperties.Data.Currency,
                    LedgerBalance = createRandomFetchSubaccountAvailableBalanceResponseProperties.Data.LedgerBalance

                },




            };

            var randomExpectedPayoutSubaccountAvailableBalanceResponse = new FetchSubaccountAvailableBalanceResponse
            {
                Message = createRandomFetchSubaccountAvailableBalanceResponseProperties.Message,
                Status = createRandomFetchSubaccountAvailableBalanceResponseProperties.Status,
                Data = new FetchSubaccountAvailableBalanceResponse.FetchSubaccountAvailableBalanceData
                {
                    AvailableBalance = createRandomFetchSubaccountAvailableBalanceResponseProperties.Data.AvailableBalance,
                    Currency = createRandomFetchSubaccountAvailableBalanceResponseProperties.Data.Currency,
                    LedgerBalance = createRandomFetchSubaccountAvailableBalanceResponseProperties.Data.LedgerBalance

                },

            };


            var expectedInputSubaccountAAvailableBalance = new FetchSubaccountAvailableBalance
            {
                Response = randomExpectedPayoutSubaccountAvailableBalanceResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetPayoutSubaccountsAvailableBalanceAsync(accountReference, currency))
                    .ReturnsAsync(randomExternalFetchPayoutSubaccountAvailableBalanceResponse);

            // when
            FetchSubaccountAvailableBalance actualSubaccountAvailableBalance =
                await this.payoutSubaccountService.GetPayoutSubaccountsAvailableBalanceRequestAsync(accountReference, currency);

            // then
            actualSubaccountAvailableBalance.Should().BeEquivalentTo(expectedInputSubaccountAAvailableBalance);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPayoutSubaccountsAvailableBalanceAsync(accountReference, currency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}