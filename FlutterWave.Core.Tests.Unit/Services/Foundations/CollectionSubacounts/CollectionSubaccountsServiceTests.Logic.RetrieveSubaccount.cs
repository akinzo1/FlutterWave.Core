using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCollectionSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.CollectionSubaccount
{
    public partial class CollectionSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveSubaccountAsync()
        {
            // given 
            dynamic createRandomFetchFetchSubaccountResponseProperties =
                 CreateRandomFetchSubaccountResponseProperties();

            var randomBulkId = GetRandomNumber();

            var randomExternalFetchCollectionSubaccountsResponse = new ExternalFetchSubaccountResponse
            {
                Message = createRandomFetchFetchSubaccountResponseProperties.Message,
                Status = createRandomFetchFetchSubaccountResponseProperties.Status,
                Data = new ExternalFetchSubaccountResponse.ExternalFetchSubaccountData
                {
                    AccountBank = createRandomFetchFetchSubaccountResponseProperties.Data.AccountBank,
                    SubaccountId = createRandomFetchFetchSubaccountResponseProperties.Data.SubaccountId,
                    AccountId = createRandomFetchFetchSubaccountResponseProperties.Data.AccountId,
                    AccountNumber = createRandomFetchFetchSubaccountResponseProperties.Data.AccountNumber,
                    BankName = createRandomFetchFetchSubaccountResponseProperties.Data.BankName,
                    BusinessName = createRandomFetchFetchSubaccountResponseProperties.Data.BusinessName,
                    Country = createRandomFetchFetchSubaccountResponseProperties.Data.Country,
                    CreatedAt = createRandomFetchFetchSubaccountResponseProperties.Data.CreatedAt,
                    FullName = createRandomFetchFetchSubaccountResponseProperties.Data.FullName,
                    Id = createRandomFetchFetchSubaccountResponseProperties.Data.Id,
                    SplitRatio = createRandomFetchFetchSubaccountResponseProperties.Data.SplitRatio,
                    SplitType = createRandomFetchFetchSubaccountResponseProperties.Data.SplitType,
                    SplitValue = createRandomFetchFetchSubaccountResponseProperties.Data.SplitValue,
                    Meta = createRandomFetchFetchSubaccountResponseProperties.Data.Meta

                },




            };

            var randomExpectedFetchSubaccountResponse = new FetchSubaccountResponse
            {
                Message = createRandomFetchFetchSubaccountResponseProperties.Message,
                Status = createRandomFetchFetchSubaccountResponseProperties.Status,
                Data = new FetchSubaccountResponse.FetchSubaccountData
                {
                    AccountBank = createRandomFetchFetchSubaccountResponseProperties.Data.AccountBank,
                    SubaccountId = createRandomFetchFetchSubaccountResponseProperties.Data.SubaccountId,
                    AccountId = createRandomFetchFetchSubaccountResponseProperties.Data.AccountId,
                    AccountNumber = createRandomFetchFetchSubaccountResponseProperties.Data.AccountNumber,
                    BankName = createRandomFetchFetchSubaccountResponseProperties.Data.BankName,
                    BusinessName = createRandomFetchFetchSubaccountResponseProperties.Data.BusinessName,
                    Country = createRandomFetchFetchSubaccountResponseProperties.Data.Country,
                    CreatedAt = createRandomFetchFetchSubaccountResponseProperties.Data.CreatedAt,
                    FullName = createRandomFetchFetchSubaccountResponseProperties.Data.FullName,
                    Id = createRandomFetchFetchSubaccountResponseProperties.Data.Id,
                    SplitRatio = createRandomFetchFetchSubaccountResponseProperties.Data.SplitRatio,
                    SplitType = createRandomFetchFetchSubaccountResponseProperties.Data.SplitType,
                    SplitValue = createRandomFetchFetchSubaccountResponseProperties.Data.SplitValue,
                    Meta = createRandomFetchFetchSubaccountResponseProperties.Data.Meta

                },

            };


            var expectedInputFetchSubaccount = new FetchSubaccount
            {
                Response = randomExpectedFetchSubaccountResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetSubaccountAsync(randomBulkId))
                    .ReturnsAsync(randomExternalFetchCollectionSubaccountsResponse);

            // when
            FetchSubaccount actualFetchSubaccount =
                await this.collectionSubaccountsService.GetSubaccountRequestAsync(randomBulkId);

            // then
            actualFetchSubaccount.Should().BeEquivalentTo(expectedInputFetchSubaccount);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}