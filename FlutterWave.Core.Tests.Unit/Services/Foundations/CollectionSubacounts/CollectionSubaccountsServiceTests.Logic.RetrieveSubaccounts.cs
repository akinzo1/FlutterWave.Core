using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCollectionSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.CollectionSubaccount
{
    public partial class CollectionSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveSubaccountsAsync()
        {
            // given 
            dynamic createRandomFetchFetchSubaccountsResponseProperties =
                 CreateRandomFetchSubaccountsResponseProperties();


            var randomExternalFetchCollectionSubaccountsResponse = new ExternalFetchSubaccountsResponse
            {
                Message = createRandomFetchFetchSubaccountsResponseProperties.Message,
                Status = createRandomFetchFetchSubaccountsResponseProperties.Status,
                Data = ((List<dynamic>)createRandomFetchFetchSubaccountsResponseProperties.Data).Select(data =>
                {
                    return new ExternalFetchSubaccountsResponse.Datum
                    {
                        AccountBank = data.AccountBank,
                        SubaccountId = data.SubaccountId,
                        AccountId = data.AccountId,
                        AccountNumber = data.AccountNumber,
                        BankName = data.BankName,
                        BusinessName = data.BusinessName,
                        Country = data.Country,
                        CreatedAt = data.CreatedAt,
                        FullName = data.FullName,
                        Id = data.Id,
                        SplitRatio = data.SplitRatio,
                        SplitType = data.SplitType,
                        SplitValue = data.SplitValue,
                        Meta = ((List<dynamic>)data.Meta).Select(meta =>
                        {
                            return new ExternalFetchSubaccountsResponse.Metum
                            {
                                MetaName = meta.MetaName,
                                MetaValue = meta.MetaValue,
                            };

                        }).ToList(),

                    };

                }).ToList(),
                Meta = new ExternalFetchSubaccountsResponse.ExternalFetchSubaccountsMeta
                {
                    MetaName = createRandomFetchFetchSubaccountsResponseProperties.Meta.MetaName,
                    MetaValue = createRandomFetchFetchSubaccountsResponseProperties.Meta.MetaValue,
                    PageInfo = new ExternalFetchSubaccountsResponse.PageInfo
                    {
                        CurrentPage = createRandomFetchFetchSubaccountsResponseProperties.Meta.PageInfo.CurrentPage,
                        Total = createRandomFetchFetchSubaccountsResponseProperties.Meta.PageInfo.Total,
                        TotalPages = createRandomFetchFetchSubaccountsResponseProperties.Meta.PageInfo.TotalPages
                    },
                    SwiftCode = createRandomFetchFetchSubaccountsResponseProperties.Meta.SwiftCode
                }




            };

            var randomExpectedFetchSubaccountsResponse = new FetchSubaccountsResponse
            {
                Message = createRandomFetchFetchSubaccountsResponseProperties.Message,
                Status = createRandomFetchFetchSubaccountsResponseProperties.Status,
                Data = ((List<dynamic>)createRandomFetchFetchSubaccountsResponseProperties.Data).Select(data =>
                {
                    return new FetchSubaccountsResponse.Datum
                    {
                        AccountBank = data.AccountBank,
                        SubaccountId = data.SubaccountId,
                        AccountId = data.AccountId,
                        AccountNumber = data.AccountNumber,
                        BankName = data.BankName,
                        BusinessName = data.BusinessName,
                        Country = data.Country,
                        CreatedAt = data.CreatedAt,
                        FullName = data.FullName,
                        Id = data.Id,
                        SplitRatio = data.SplitRatio,
                        SplitType = data.SplitType,
                        SplitValue = data.SplitValue,
                        Meta = ((List<dynamic>)data.Meta).Select(meta =>
                        {
                            return new FetchSubaccountsResponse.Metum
                            {
                                MetaName = meta.MetaName,
                                MetaValue = meta.MetaValue,
                            };

                        }).ToList(),

                    };

                }).ToList(),
                Meta = new FetchSubaccountsResponse.FetchSubaccountsMeta
                {
                    MetaName = createRandomFetchFetchSubaccountsResponseProperties.Meta.MetaName,
                    MetaValue = createRandomFetchFetchSubaccountsResponseProperties.Meta.MetaValue,
                    PageInfo = new FetchSubaccountsResponse.PageInfo
                    {
                        CurrentPage = createRandomFetchFetchSubaccountsResponseProperties.Meta.PageInfo.CurrentPage,
                        Total = createRandomFetchFetchSubaccountsResponseProperties.Meta.PageInfo.Total,
                        TotalPages = createRandomFetchFetchSubaccountsResponseProperties.Meta.PageInfo.TotalPages
                    },
                    SwiftCode = createRandomFetchFetchSubaccountsResponseProperties.Meta.SwiftCode
                }

            };


            var expectedInputFetchSubaccounts = new FetchSubaccounts
            {
                Response = randomExpectedFetchSubaccountsResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetSubaccountsAsync())
                    .ReturnsAsync(randomExternalFetchCollectionSubaccountsResponse);

            // when
            FetchSubaccounts actualFetchSubaccounts =
                await this.collectionSubaccountsService.GetSubaccountsRequestAsync();

            // then
            actualFetchSubaccounts.Should().BeEquivalentTo(expectedInputFetchSubaccounts);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}