



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveTransactionFeesAsync()
        {
            // given 
            int randomNumber = GetRandomNumber();
            string randomString = GetRandomString();
            string inputCurrency = randomString;
            int inputAmount = randomNumber;

            dynamic createRandomFeesProperties =
                CreateRandomFeesProperties();

            var externalFeesResponse = new ExternalFetchTransactionFeesResponse
            {

                Message = createRandomFeesProperties.Message,
                Data = new ExternalFetchTransactionFeesResponse.ExternalFetchTransactionFeesDataModel
                {
                    Currency = createRandomFeesProperties.Data.Currency,
                    Fee = createRandomFeesProperties.Data.Fee,
                    ChargeAmount = createRandomFeesProperties.Data.ChargeAmount,
                    FlutterwaveFee = createRandomFeesProperties.Data.FlutterwaveFee,
                    MerchantFee = createRandomFeesProperties.Data.MerchantFee,
                    StampDutyFee = createRandomFeesProperties.Data.StampDutyFee,
                },
                Status = createRandomFeesProperties.Status,
            };

            var expectedFeesResponse = new FetchTransactionFeesResponse
            {

                Message = createRandomFeesProperties.Message,
                Data = new FetchTransactionFeesResponse.FetchTransactionFeesDataModel
                {
                    Currency = createRandomFeesProperties.Data.Currency,
                    Fee = createRandomFeesProperties.Data.Fee,
                    ChargeAmount = createRandomFeesProperties.Data.ChargeAmount,
                    FlutterwaveFee = createRandomFeesProperties.Data.FlutterwaveFee,
                    MerchantFee = createRandomFeesProperties.Data.MerchantFee,
                    StampDutyFee = createRandomFeesProperties.Data.StampDutyFee,
                },
                Status = createRandomFeesProperties.Status,

            };

            var expectedTransactionFees = new TransactionFees
            {
                Response = expectedFeesResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetTransactionFeesAsync(inputAmount, inputCurrency))
                    .ReturnsAsync(externalFeesResponse);

            // when
            TransactionFees actualFees =
                await this.transactionsService.GetTransactionFeesAsync(inputAmount, inputCurrency);

            // then
            actualFees.Should().BeEquivalentTo(expectedTransactionFees);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionFeesAsync(inputAmount, inputCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}