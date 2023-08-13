



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
        public async Task ShouldRetrieveAllBalanceByCurrenciesAsync()
        {
            // given 


            dynamic createRandomAllBalanceCurrenciesProperties =
                     CreateRandomAllBalanceCurrenciesProperties();

            var randomExternalAllBalanceCurrenciesResponse = new ExternalAllBalanceCurrenciesResponse
            {
                Data = ((List<dynamic>)createRandomAllBalanceCurrenciesProperties.Data).Select(data =>
                {
                    return new ExternalAllBalanceCurrenciesResponse.Datum
                    {
                        AvailableBalance = data.AvailableBalance,
                        Currency = data.Currency,
                        LedgerBalance = data.LedgerBalance,
                    };
                }).ToList(),
                Message = createRandomAllBalanceCurrenciesProperties.Message,
                Status = createRandomAllBalanceCurrenciesProperties.Status,
            };

            var randomExpectedAllBalanceCurrenciesResponse = new AllBalanceCurrenciesResponse
            {
                Data = ((List<dynamic>)createRandomAllBalanceCurrenciesProperties.Data).Select(data =>
                {
                    return new AllBalanceCurrenciesResponse.Datum
                    {
                        AvailableBalance = data.AvailableBalance,
                        Currency = data.Currency,
                        LedgerBalance = data.LedgerBalance,
                    };
                }).ToList(),
                Message = createRandomAllBalanceCurrenciesProperties.Message,
                Status = createRandomAllBalanceCurrenciesProperties.Status,
            };

            var expectedAllBalanceCurrencies = new BalanceByCurrencies
            {
                Response = randomExpectedAllBalanceCurrenciesResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBalanceCurrenciesAsync())
                    .ReturnsAsync(randomExternalAllBalanceCurrenciesResponse);

            // when
            BalanceByCurrencies actualBillPaymentsStatus =
               await this.miscellaneousService.GetBalanceCurrenciesAsync();

            // then
            actualBillPaymentsStatus.Should().BeEquivalentTo(expectedAllBalanceCurrencies);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceCurrenciesAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}