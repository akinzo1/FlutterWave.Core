using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCollectionSubaccounts;
using FlutterWave.Core.Services.Foundations.FlutterWave.CollectionSubaccountsService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Data;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.CollectionSubaccount
{
    public partial class CollectionSubaccountsServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly ICollectionSubaccountsService collectionSubaccountsService;

        public CollectionSubaccountsServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            this.collectionSubaccountsService = new CollectionSubaccountsService(
                flutterWaveBroker: this.flutterWaveBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);
        }




        private Expression<Func<ExternalCreateCollectionSubaccountRequest, bool>> SameExternalCreateCollectionSubaccountRequestAs(
            ExternalCreateCollectionSubaccountRequest expectedExternalCreateCollectionSubaccountRequest)
        {
            return actualExternalCreateCollectionSubaccountRequest =>
                this.compareLogic.Compare(
                    expectedExternalCreateCollectionSubaccountRequest,
                    actualExternalCreateCollectionSubaccountRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalUpdateSubaccountRequest, bool>> SameExternalUpdateSubaccountRequestAs(
          ExternalUpdateSubaccountRequest expectedExternalUpdateSubaccountRequest)
        {
            return actualExternalUpdateSubaccountRequest =>
                this.compareLogic.Compare(
                    expectedExternalUpdateSubaccountRequest,
                    actualExternalUpdateSubaccountRequest)
                        .AreEqual;
        }

        private static DateTime GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
           new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static string[] CreateRandomStringArray() =>
            new Filler<string[]>().Create();

        private static List<string> CreateRandomStringList() =>
          new Filler<List<string>>().Create();

        private static bool GetRandomBoolean() =>
            Randomizer<bool>.Create();

        private static Dictionary<string, int> CreateRandomDictionary() =>
            new Filler<Dictionary<string, int>>().Create();



        #region CreateCollectionSubaccountRequestProperties

        private static dynamic CreateRandomCreateCollectionSubaccountRequestProperties()
        {
            return new
            {
                AccountBank = GetRandomString(),
                AccountNumber = GetRandomString(),
                BusinessName = GetRandomString(),
                BusinessEmail = GetRandomString(),
                BusinessContact = GetRandomString(),
                BusinessContactMobile = GetRandomString(),
                BusinessMobile = GetRandomString(),
                Country = GetRandomString(),
                Meta = GetRandomCreateCollectionSubaccountList(),
                SplitType = GetRandomString(),
                SplitValue = GetRandomNumber(),

            };
        }

        private static List<dynamic> GetRandomCreateCollectionSubaccountList()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                MetaName = GetRandomString(),
                MetaValue = GetRandomString(),



            }).ToList<dynamic>();

        }

        #endregion  

        #region UpdateSubaccountRequestProperties

        private static dynamic CreateRandomUpdateSubaccountRequestProperties()
        {
            return new
            {
                BusinessName = GetRandomString(),
                BusinessEmail = GetRandomString(),
                AccountBank = GetRandomString(),
                AccountNumber = GetRandomString(),
                SplitType = GetRandomString(),
                SplitValue = GetRandomNumber(),



            };
        }






        #endregion

        #region UpdateSubaccountResponseProperties

        private static dynamic CreateRandomUpdateSubaccountResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomUpdateSubaccountResponseData(),

            };
        }


        private static dynamic GetRandomUpdateSubaccountResponseData()
        {

            return new
            {

                Id = GetRandomNumber(),
                AccountNumber = GetRandomString(),
                AccountBank = GetRandomString(),
                BusinessName = GetRandomString(),
                FullName = GetRandomString(),
                CreatedAt = GetRandomDate(),
                Meta = GetRandomUpdateSubaccountResponseMeta(),
                AccountId = GetRandomNumber(),
                SplitRatio = GetRandomNumber(),
                SplitType = GetRandomString(),
                SplitValue = GetRandomNumber(),
                SubaccountId = GetRandomString(),
                BankName = GetRandomString(),
                Country = GetRandomString(),





            };

        }



        private static List<dynamic> GetRandomUpdateSubaccountResponseMeta()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                MetaName = GetRandomString(),
                MetaValue = GetRandomString(),



            }).ToList<dynamic>();

        }


        #endregion

        #region CreateCollectionSubaccountResponseProperties

        private static dynamic CreateRandomCreateCollectionSubaccountResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomCreateCollectionSubaccountResponseData()
            };
        }


        private static dynamic GetRandomCreateCollectionSubaccountResponseData()
        {

            return new
            {

                Id = GetRandomNumber(),
                AccountNumber = GetRandomString(),
                AccountBank = GetRandomString(),
                FullName = GetRandomString(),
                CreatedAt = GetRandomDate(),
                SplitType = GetRandomString(),
                SplitValue = GetRandomNumber(),
                SubaccountId = GetRandomString(),
                BankName = GetRandomString(),


            };

        }
        #endregion

        #region DeleteSubaccountResponseProperties

        private static dynamic CreateRandomDeleteSubaccountResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = new object()
            };
        }



        #endregion

        #region FetchSubaccountResponseProperties

        private static dynamic CreateRandomFetchSubaccountResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomFetchSubaccountResponseData()
            };
        }


        private static dynamic GetRandomFetchSubaccountResponseData()
        {

            return new
            {

                Id = GetRandomNumber(),
                AccountNumber = GetRandomString(),
                AccountBank = GetRandomString(),
                BusinessName = GetRandomString(),
                FullName = GetRandomString(),
                CreatedAt = GetRandomDate(),
                Meta = new object(),
                AccountId = GetRandomNumber(),
                SplitRatio = GetRandomNumber(),
                SplitType = GetRandomString(),
                SplitValue = GetRandomNumber(),
                SubaccountId = GetRandomString(),
                BankName = GetRandomString(),
                Country = GetRandomString(),



            };

        }
        #endregion

        #region FetchSubaccountsResponseProperties

        private static dynamic CreateRandomFetchSubaccountsResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomFetchSubaccountsResponseData(),
                Meta = GetRandomFetchSubaccountsResponseMeta(),
            };
        }


        private static List<dynamic> GetRandomFetchSubaccountsResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Id = GetRandomNumber(),
                AccountNumber = GetRandomString(),
                AccountBank = GetRandomString(),
                BusinessName = GetRandomString(),
                FullName = GetRandomString(),
                CreatedAt = GetRandomDate(),
                Meta = GetRandomFetchSubaccountsResponseMetum(),
                AccountId = GetRandomNumber(),
                SplitRatio = GetRandomNumber(),
                SplitType = GetRandomString(),
                SplitValue = GetRandomNumber(),
                SubaccountId = GetRandomString(),
                BankName = GetRandomString(),
                Country = GetRandomString(),




            }).ToList<dynamic>();

        }

        private static dynamic GetRandomFetchSubaccountsResponseMeta()
        {

            return new
            {

                MetaName = GetRandomString(),
                MetaValue = GetRandomString(),
                PageInfo = GetRandomFetchSubaccountsResponsePageInfo(),
                SwiftCode = GetRandomString()






            };

        }

        private static List<dynamic> GetRandomFetchSubaccountsResponseMetum()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                MetaName = GetRandomString(),
                MetaValue = GetRandomString(),



            }).ToList<dynamic>();

        }

        private static dynamic GetRandomFetchSubaccountsResponsePageInfo()
        {

            return new
            {

                Total = GetRandomNumber(),
                CurrentPage = GetRandomNumber(),
                TotalPages = GetRandomNumber(),


            };

        }



        #endregion




        public static TheoryData UnauthorizedExceptions()
        {
            return new TheoryData<HttpResponseException>
            {
                new HttpResponseUnauthorizedException(),
                new HttpResponseForbiddenException()
            };
        }



    }
}
