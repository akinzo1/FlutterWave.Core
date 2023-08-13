



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PayoutSubaccount
{
    public partial class PayoutSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldRetrievePayoutSubaccountTransactionsAsync()
        {
            // given 
            dynamic createRandomFetchPayoutSubaccountTransactionsResponseProperties =
                 CreateRandomFetchPayoutSubaccountTransactionsResponseProperties();

            var accountReference = GetRandomString();
            var from = GetRandomString();
            var to = GetRandomString();
            var currency = GetRandomString();

            var randomExternalFetchPayoutSubaccountTransactionsResponse = new ExternalFetchPayoutSubaccountTransactionsResponse
            {
                Message = createRandomFetchPayoutSubaccountTransactionsResponseProperties.Message,
                Status = createRandomFetchPayoutSubaccountTransactionsResponseProperties.Status,
                Data = createRandomFetchPayoutSubaccountTransactionsResponseProperties.Data,




            };

            var randomExpectedFetchPayoutSubaccountTransactionsResponse = new FetchPayoutSubaccountTransactionsResponse
            {
                Message = createRandomFetchPayoutSubaccountTransactionsResponseProperties.Message,
                Status = createRandomFetchPayoutSubaccountTransactionsResponseProperties.Status,
                Data = createRandomFetchPayoutSubaccountTransactionsResponseProperties.Data,

            };


            var expectedInputRetrievePayoutSubaccountTransactionsTransactions = new FetchPayoutSubaccountTransactions
            {
                Response = randomExpectedFetchPayoutSubaccountTransactionsResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetPayoutSubaccountTransactionsAsync(accountReference, from, to, currency))
                    .ReturnsAsync(randomExternalFetchPayoutSubaccountTransactionsResponse);

            // when
            FetchPayoutSubaccountTransactions actualRetrievePayoutSubaccountTransactionsTransactions =
                await this.payoutSubaccountService.GetPayoutSubaccountTransactionsRequestAsync(accountReference, from, to, currency);

            // then
            actualRetrievePayoutSubaccountTransactionsTransactions.Should().BeEquivalentTo(expectedInputRetrievePayoutSubaccountTransactionsTransactions);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPayoutSubaccountTransactionsAsync(accountReference, from, to, currency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}