



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalBalance;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Miscellaneous
{
    public partial class MiscellaneousServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveBalanceByCurrencyWithCurrencyCodeReferenceAsync()
        {
            // given 
            string randomRandomReference = GetRandomString();
            string inputCurrency = randomRandomReference;

            dynamic createRandomBalanceByCurrencyProperties =
                CreateRandomBalanceByCurrencyProperties();

            var randomExternalBalanceByCurrencyResponse = new ExternalBalanceByCurrencyResponse
            {
                Data = new BalanceByCurrencyResponse.BalanceCurrencyData
                {
                    AvailableBalance = createRandomBalanceByCurrencyProperties.Data.AvailableBalance,
                    Currency = createRandomBalanceByCurrencyProperties.Data.Currency,
                    LedgerBalance = createRandomBalanceByCurrencyProperties.Data.LedgerBalance,
                },
                Status = createRandomBalanceByCurrencyProperties.Status,
                Message = createRandomBalanceByCurrencyProperties.Message,

            };

            var randomExpectedBalanceByCurrencyResponse = new BalanceByCurrencyResponse
            {
                Data = new BalanceByCurrencyResponse.BalanceCurrencyData
                {
                    AvailableBalance = createRandomBalanceByCurrencyProperties.Data.AvailableBalance,
                    Currency = createRandomBalanceByCurrencyProperties.Data.Currency,
                    LedgerBalance = createRandomBalanceByCurrencyProperties.Data.LedgerBalance,
                },
                Status = createRandomBalanceByCurrencyProperties.Status,
                Message = createRandomBalanceByCurrencyProperties.Message,

            };

            var expectedChargeBack = new BalanceByCurrency
            {
                Response = randomExpectedBalanceByCurrencyResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBalanceByCurrencyAsync(inputCurrency))
                    .ReturnsAsync(randomExternalBalanceByCurrencyResponse);

            // when
            BalanceByCurrency actualBillPaymentsStatus =
               await this.miscellaneousService.GetBalanceByCurrencyAsync(inputCurrency);

            // then
            actualBillPaymentsStatus.Should().BeEquivalentTo(expectedChargeBack);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceByCurrencyAsync(inputCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}