



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PayoutSubaccount
{
    public partial class PayoutSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldRetrievePayoutSubaccountAsync()
        {
            // given 
            dynamic createRandomFetchPayoutSubaccountResponseProperties =
                 CreateRandomFetchPayoutSubaccountResponseProperties();

            var randomSubaccountId = GetRandomString();

            var randomExternalFetchPayoutSubaccountResponse = new ExternalFetchPayoutSubaccountResponse
            {
                Message = createRandomFetchPayoutSubaccountResponseProperties.Message,
                Status = createRandomFetchPayoutSubaccountResponseProperties.Status,
                Data = new ExternalFetchPayoutSubaccountResponse.ExternalFetchPayoutSubaccountData
                {
                    Mobilenumber = createRandomFetchPayoutSubaccountResponseProperties.Data.Mobilenumber,
                    Email = createRandomFetchPayoutSubaccountResponseProperties.Data.Email,
                    CreatedAt = createRandomFetchPayoutSubaccountResponseProperties.Data.CreatedAt,
                    AccountName = createRandomFetchPayoutSubaccountResponseProperties.Data.AccountName,
                    AccountReference = createRandomFetchPayoutSubaccountResponseProperties.Data.AccountReference,
                    BankCode = createRandomFetchPayoutSubaccountResponseProperties.Data.BankCode,
                    BankName = createRandomFetchPayoutSubaccountResponseProperties.Data.BankName,
                    BarterId = createRandomFetchPayoutSubaccountResponseProperties.Data.BarterId,
                    Country = createRandomFetchPayoutSubaccountResponseProperties.Data.Country,
                    Id = createRandomFetchPayoutSubaccountResponseProperties.Data.Id,
                    Nuban = createRandomFetchPayoutSubaccountResponseProperties.Data.Nuban,
                    Status = createRandomFetchPayoutSubaccountResponseProperties.Data.Status,
                    TransferLimits = new ExternalFetchPayoutSubaccountResponse.TransferLimits
                    {
                        SingleLimit = createRandomFetchPayoutSubaccountResponseProperties.Data.TransferLimits.SingleLimit,
                        TotalDailyLimit = createRandomFetchPayoutSubaccountResponseProperties.Data.TransferLimits.TotalDailyLimit
                    }
                },




            };

            var randomExpectedFetchPayoutSubaccountResponse = new FetchPayoutSubaccountResponse
            {
                Message = createRandomFetchPayoutSubaccountResponseProperties.Message,
                Status = createRandomFetchPayoutSubaccountResponseProperties.Status,
                Data = new FetchPayoutSubaccountResponse.FetchPayoutSubaccountData
                {
                    Mobilenumber = createRandomFetchPayoutSubaccountResponseProperties.Data.Mobilenumber,
                    Email = createRandomFetchPayoutSubaccountResponseProperties.Data.Email,
                    CreatedAt = createRandomFetchPayoutSubaccountResponseProperties.Data.CreatedAt,
                    AccountName = createRandomFetchPayoutSubaccountResponseProperties.Data.AccountName,
                    AccountReference = createRandomFetchPayoutSubaccountResponseProperties.Data.AccountReference,
                    BankCode = createRandomFetchPayoutSubaccountResponseProperties.Data.BankCode,
                    BankName = createRandomFetchPayoutSubaccountResponseProperties.Data.BankName,
                    BarterId = createRandomFetchPayoutSubaccountResponseProperties.Data.BarterId,
                    Country = createRandomFetchPayoutSubaccountResponseProperties.Data.Country,
                    Id = createRandomFetchPayoutSubaccountResponseProperties.Data.Id,
                    Nuban = createRandomFetchPayoutSubaccountResponseProperties.Data.Nuban,
                    Status = createRandomFetchPayoutSubaccountResponseProperties.Data.Status,
                    TransferLimits = new FetchPayoutSubaccountResponse.TransferLimits
                    {
                        SingleLimit = createRandomFetchPayoutSubaccountResponseProperties.Data.TransferLimits.SingleLimit,
                        TotalDailyLimit = createRandomFetchPayoutSubaccountResponseProperties.Data.TransferLimits.TotalDailyLimit
                    }
                },

            };


            var expectedInputRetrievePayoutSubaccount = new FetchPayoutSubaccount
            {
                Response = randomExpectedFetchPayoutSubaccountResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetPayoutSubaccountAsync(randomSubaccountId))
                    .ReturnsAsync(randomExternalFetchPayoutSubaccountResponse);

            // when
            FetchPayoutSubaccount actualRetrievePayoutSubaccount =
                await this.payoutSubaccountService.GetPayoutSubaccountRequestAsync(randomSubaccountId);

            // then
            actualRetrievePayoutSubaccount.Should().BeEquivalentTo(expectedInputRetrievePayoutSubaccount);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPayoutSubaccountAsync(randomSubaccountId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}