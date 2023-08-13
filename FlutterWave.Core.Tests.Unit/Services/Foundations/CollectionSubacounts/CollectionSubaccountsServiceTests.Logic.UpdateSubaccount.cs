using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCollectionSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.CollectionSubaccount
{
    public partial class CollectionSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldPostUpdateSubaccountWithUpdateSubaccountRequestAsync()
        {
            // given 



            dynamic createRandomUpdateSubaccountRequestProperties =
              CreateRandomUpdateSubaccountRequestProperties();

            dynamic createRandomUpdateSubaccountResponseProperties =
                CreateRandomUpdateSubaccountResponseProperties();


            var randomExternalUpdateSubaccountRequest = new ExternalUpdateSubaccountRequest
            {
                SplitValue = createRandomUpdateSubaccountRequestProperties.SplitValue,
                AccountBank = createRandomUpdateSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomUpdateSubaccountRequestProperties.AccountNumber,
                BusinessEmail = createRandomUpdateSubaccountRequestProperties.BusinessEmail,
                BusinessName = createRandomUpdateSubaccountRequestProperties.BusinessName,
                SplitType = createRandomUpdateSubaccountRequestProperties.SplitType,



            };

            var randomExternalUpdateSubaccountResponse = new ExternalUpdateSubaccountResponse
            {
                Data = new ExternalUpdateSubaccountResponse.ExternalUpdateSubaccountData
                {
                    CreatedAt = createRandomUpdateSubaccountResponseProperties.Data.CreatedAt,
                    AccountBank = createRandomUpdateSubaccountResponseProperties.Data.AccountBank,
                    SplitValue = createRandomUpdateSubaccountResponseProperties.Data.SplitValue,
                    AccountNumber = createRandomUpdateSubaccountResponseProperties.Data.AccountNumber,
                    BusinessName = createRandomUpdateSubaccountResponseProperties.Data.BusinessName,
                    SplitType = createRandomUpdateSubaccountResponseProperties.Data.SplitType,
                    AccountId = createRandomUpdateSubaccountResponseProperties.Data.AccountId,
                    BankName = createRandomUpdateSubaccountResponseProperties.Data.BankName,
                    Country = createRandomUpdateSubaccountResponseProperties.Data.Country,
                    FullName = createRandomUpdateSubaccountResponseProperties.Data.FullName,
                    Id = createRandomUpdateSubaccountResponseProperties.Data.Id,
                    SplitRatio = createRandomUpdateSubaccountResponseProperties.Data.SplitRatio,
                    Meta = ((List<dynamic>)createRandomUpdateSubaccountResponseProperties.Data.Meta).Select(meta =>
                    {
                        return new ExternalUpdateSubaccountResponse.Metum
                        {
                            MetaName = meta.MetaName,
                            MetaValue = meta.MetaValue,
                        };
                    }).ToList(),
                    SubaccountId = createRandomUpdateSubaccountResponseProperties.Data.SubaccountId,


                },
                Message = createRandomUpdateSubaccountResponseProperties.Message,
                Status = createRandomUpdateSubaccountResponseProperties.Status,

            };


            var randomUpdateSubaccountRequest = new UpdateSubaccountRequest
            {
                SplitValue = createRandomUpdateSubaccountRequestProperties.SplitValue,
                AccountBank = createRandomUpdateSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomUpdateSubaccountRequestProperties.AccountNumber,
                BusinessEmail = createRandomUpdateSubaccountRequestProperties.BusinessEmail,
                BusinessName = createRandomUpdateSubaccountRequestProperties.BusinessName,
                SplitType = createRandomUpdateSubaccountRequestProperties.SplitType

            };

            var randomUpdateSubaccountResponse = new UpdateSubaccountResponse
            {

                Data = new UpdateSubaccountResponse.UpdateSubaccountData
                {
                    CreatedAt = createRandomUpdateSubaccountResponseProperties.Data.CreatedAt,
                    AccountBank = createRandomUpdateSubaccountResponseProperties.Data.AccountBank,
                    SplitValue = createRandomUpdateSubaccountResponseProperties.Data.SplitValue,
                    AccountNumber = createRandomUpdateSubaccountResponseProperties.Data.AccountNumber,
                    BusinessName = createRandomUpdateSubaccountResponseProperties.Data.BusinessName,
                    SplitType = createRandomUpdateSubaccountResponseProperties.Data.SplitType,
                    AccountId = createRandomUpdateSubaccountResponseProperties.Data.AccountId,
                    BankName = createRandomUpdateSubaccountResponseProperties.Data.BankName,
                    Country = createRandomUpdateSubaccountResponseProperties.Data.Country,
                    FullName = createRandomUpdateSubaccountResponseProperties.Data.FullName,
                    Id = createRandomUpdateSubaccountResponseProperties.Data.Id,
                    SplitRatio = createRandomUpdateSubaccountResponseProperties.Data.SplitRatio,
                    Meta = ((List<dynamic>)createRandomUpdateSubaccountResponseProperties.Data.Meta).Select(meta =>
                    {
                        return new UpdateSubaccountResponse.Metum
                        {
                            MetaName = meta.MetaName,
                            MetaValue = meta.MetaValue,
                        };
                    }).ToList(),
                    SubaccountId = createRandomUpdateSubaccountResponseProperties.Data.SubaccountId,





                },
                Message = createRandomUpdateSubaccountResponseProperties.Message,
                Status = createRandomUpdateSubaccountResponseProperties.Status,
            };


            var randomUpdateSubaccount = new UpdateSubaccount
            {
                Request = randomUpdateSubaccountRequest,
            };

            var randomSubaccountId = GetRandomNumber();

            UpdateSubaccount inputUpdateSubaccount = randomUpdateSubaccount;
            UpdateSubaccount expectedUpdateSubaccount = inputUpdateSubaccount.DeepClone();
            expectedUpdateSubaccount.Response = randomUpdateSubaccountResponse;

            ExternalUpdateSubaccountRequest mappedExternalUpdateSubaccountRequest =
               randomExternalUpdateSubaccountRequest;

            ExternalUpdateSubaccountResponse returnedExternalUpdateSubaccountResponse =
                randomExternalUpdateSubaccountResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(), It.Is(
                      SameExternalUpdateSubaccountRequestAs(mappedExternalUpdateSubaccountRequest))))
                     .ReturnsAsync(returnedExternalUpdateSubaccountResponse);

            // when
            UpdateSubaccount actualCreateUpdateSubaccount =
               await this.collectionSubaccountsService.PostUpdateCollectionSubaccountRequestAsync(randomSubaccountId, inputUpdateSubaccount);

            // then
            actualCreateUpdateSubaccount.Should().BeEquivalentTo(expectedUpdateSubaccount);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(), It.Is(
                   SameExternalUpdateSubaccountRequestAs(mappedExternalUpdateSubaccountRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}