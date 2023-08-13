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
        public async Task ShouldPostCreateCollectionSubaccountWithCreateCollectionSubaccountRequestAsync()
        {
            // given 



            dynamic createRandomCreateCollectionSubaccountRequestProperties =
              CreateRandomCreateCollectionSubaccountRequestProperties();

            dynamic createRandomCreateCollectionSubaccountResponseProperties =
                CreateRandomCreateCollectionSubaccountResponseProperties();


            var randomExternalCreateCollectionSubaccountRequest = new ExternalCreateCollectionSubaccountRequest
            {
                AccountBank = createRandomCreateCollectionSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomCreateCollectionSubaccountRequestProperties.AccountNumber,
                BusinessContact = createRandomCreateCollectionSubaccountRequestProperties.BusinessContact,
                BusinessContactMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessContactMobile,
                BusinessEmail = createRandomCreateCollectionSubaccountRequestProperties.BusinessEmail,
                BusinessMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessMobile,
                BusinessName = createRandomCreateCollectionSubaccountRequestProperties.BusinessName,
                Country = createRandomCreateCollectionSubaccountRequestProperties.Country,
                SplitType = createRandomCreateCollectionSubaccountRequestProperties.SplitType,
                SplitValue = createRandomCreateCollectionSubaccountRequestProperties.SplitValue,
                Meta = ((List<dynamic>)createRandomCreateCollectionSubaccountRequestProperties.Meta).Select(meta =>
                {
                    return new ExternalCreateCollectionSubaccountRequest.Metum
                    {
                        MetaName = meta.MetaName,
                        MetaValue = meta.MetaValue,
                    };
                }).ToList(),



            };

            var randomExternalCreateCollectionSubaccountResponse = new ExternalCreateCollectionSubaccountResponse
            {
                Data = new ExternalCreateCollectionSubaccountResponse.ExternalCreateCollectionSubaccountData
                {
                    AccountBank = createRandomCreateCollectionSubaccountResponseProperties.Data.AccountBank,
                    AccountNumber = createRandomCreateCollectionSubaccountResponseProperties.Data.AccountNumber,
                    SplitType = createRandomCreateCollectionSubaccountResponseProperties.Data.SplitType,
                    SplitValue = createRandomCreateCollectionSubaccountResponseProperties.Data.SplitValue,
                    BankName = createRandomCreateCollectionSubaccountResponseProperties.Data.BankName,
                    CreatedAt = createRandomCreateCollectionSubaccountResponseProperties.Data.CreatedAt,
                    FullName = createRandomCreateCollectionSubaccountResponseProperties.Data.FullName,
                    Id = createRandomCreateCollectionSubaccountResponseProperties.Data.Id,
                    SubaccountId = createRandomCreateCollectionSubaccountResponseProperties.Data.SubaccountId



                },
                Message = createRandomCreateCollectionSubaccountResponseProperties.Message,
                Status = createRandomCreateCollectionSubaccountResponseProperties.Status,

            };


            var randomCreateCollectionSubaccountRequest = new CreateCollectionSubaccountRequest
            {
                AccountBank = createRandomCreateCollectionSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomCreateCollectionSubaccountRequestProperties.AccountNumber,
                BusinessContact = createRandomCreateCollectionSubaccountRequestProperties.BusinessContact,
                BusinessContactMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessContactMobile,
                BusinessEmail = createRandomCreateCollectionSubaccountRequestProperties.BusinessEmail,
                BusinessMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessMobile,
                BusinessName = createRandomCreateCollectionSubaccountRequestProperties.BusinessName,
                Country = createRandomCreateCollectionSubaccountRequestProperties.Country,
                SplitType = createRandomCreateCollectionSubaccountRequestProperties.SplitType,
                SplitValue = createRandomCreateCollectionSubaccountRequestProperties.SplitValue,
                Meta = ((List<dynamic>)createRandomCreateCollectionSubaccountRequestProperties.Meta).Select(meta =>
                {
                    return new CreateCollectionSubaccountRequest.Metum
                    {
                        MetaName = meta.MetaName,
                        MetaValue = meta.MetaValue,
                    };
                }).ToList(),

            };

            var randomCreateCollectionSubaccountResponse = new CreateCollectionSubaccountResponse
            {

                Data = new CreateCollectionSubaccountResponse.CreateCollectionSubaccountData
                {

                    AccountBank = createRandomCreateCollectionSubaccountResponseProperties.Data.AccountBank,
                    AccountNumber = createRandomCreateCollectionSubaccountResponseProperties.Data.AccountNumber,
                    SplitType = createRandomCreateCollectionSubaccountResponseProperties.Data.SplitType,
                    SplitValue = createRandomCreateCollectionSubaccountResponseProperties.Data.SplitValue,
                    BankName = createRandomCreateCollectionSubaccountResponseProperties.Data.BankName,
                    CreatedAt = createRandomCreateCollectionSubaccountResponseProperties.Data.CreatedAt,
                    FullName = createRandomCreateCollectionSubaccountResponseProperties.Data.FullName,
                    Id = createRandomCreateCollectionSubaccountResponseProperties.Data.Id,
                    SubaccountId = createRandomCreateCollectionSubaccountResponseProperties.Data.SubaccountId






                },
                Message = createRandomCreateCollectionSubaccountResponseProperties.Message,
                Status = createRandomCreateCollectionSubaccountResponseProperties.Status,

            };


            var randomCreateCollectionSubaccount = new CreateCollectionSubaccount
            {
                Request = randomCreateCollectionSubaccountRequest,
            };

            CreateCollectionSubaccount inputCreateCollectionSubaccount = randomCreateCollectionSubaccount;
            CreateCollectionSubaccount expectedCreateCollectionSubaccount = inputCreateCollectionSubaccount.DeepClone();
            expectedCreateCollectionSubaccount.Response = randomCreateCollectionSubaccountResponse;

            ExternalCreateCollectionSubaccountRequest mappedExternalCreateCollectionSubaccountRequest =
               randomExternalCreateCollectionSubaccountRequest;

            ExternalCreateCollectionSubaccountResponse returnedExternalCreateCollectionSubaccountResponse =
                randomExternalCreateCollectionSubaccountResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateCollectionSubaccountAsync(It.Is(
                      SameExternalCreateCollectionSubaccountRequestAs(mappedExternalCreateCollectionSubaccountRequest))))
                     .ReturnsAsync(returnedExternalCreateCollectionSubaccountResponse);

            // when
            CreateCollectionSubaccount actualCreateCreateCollectionSubaccount =
               await this.collectionSubaccountsService.PostCreateCollectionSubaccountRequestAsync(inputCreateCollectionSubaccount);

            // then
            actualCreateCreateCollectionSubaccount.Should().BeEquivalentTo(expectedCreateCollectionSubaccount);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostCreateCollectionSubaccountAsync(It.Is(
                   SameExternalCreateCollectionSubaccountRequestAs(mappedExternalCreateCollectionSubaccountRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}