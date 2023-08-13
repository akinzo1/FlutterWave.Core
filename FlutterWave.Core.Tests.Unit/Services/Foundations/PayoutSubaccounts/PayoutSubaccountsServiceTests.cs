



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using FlutterWave.Core.Services.Foundations.FlutterWave.PayoutSubaccountsService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Data;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PayoutSubaccount
{
    public partial class PayoutSubaccountsServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IPayoutSubaccountsService payoutSubaccountService;

        public PayoutSubaccountsServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            this.payoutSubaccountService = new PayoutSubaccountsService(
                flutterWaveBroker: this.flutterWaveBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);
        }




        private Expression<Func<ExternalCreatePayoutSubaccountRequest, bool>> SameExternalCreatePayoutSubaccountRequestAs(
            ExternalCreatePayoutSubaccountRequest expectedExternalCreatePayoutSubaccountRequest)
        {
            return actualExternalCreatePayoutSubaccountRequest =>
                this.compareLogic.Compare(
                    expectedExternalCreatePayoutSubaccountRequest,
                    actualExternalCreatePayoutSubaccountRequest)
                        .AreEqual;
        }


        private Expression<Func<ExternalUpdatePayoutSubaccountRequest, bool>> SameExternalUpdatePayoutSubaccountRequestAs(
          ExternalUpdatePayoutSubaccountRequest expectedExternalUpdatePayoutSubaccountRequest)
        {
            return actualExternalUpdatePayoutSubaccountRequest =>
                this.compareLogic.Compare(
                    expectedExternalUpdatePayoutSubaccountRequest,
                    actualExternalUpdatePayoutSubaccountRequest)
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

        private static UpdatePayoutSubaccount CreateRandomUpdatePayoutSubaccount() =>
           CreateUpdatePayoutSubaccountFiller().Create();

        private static CreatePayoutSubaccount CreateRandomCreatePayoutSubaccount() =>
            CreateCreatePayoutSubaccountFiller().Create();

        #region CreatePayoutSubaccountRequestProperties

        private static dynamic CreateRandomCreatePayoutSubaccountRequestProperties()
        {
            return new
            {
                AccountName = GetRandomString(),
                Email = GetRandomString(),
                Mobilenumber = GetRandomString(),
                Country = GetRandomString(),


            };
        }



        #endregion

        #region UpdatePayoutSubaccountRequestProperties

        private static dynamic CreateRandomUpdatePayoutSubaccountRequestProperties()
        {
            return new
            {
                AccountName = GetRandomString(),
                Email = GetRandomString(),
                Mobilenumber = GetRandomString(),
                Country = GetRandomString(),

            };
        }


        #endregion  

        #region CreatePayoutSubaccountResponseProperties

        private static dynamic CreateRandomCreatePayoutSubaccountResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomCreatePayoutSubaccountResponseData()
            };
        }


        private static dynamic GetRandomCreatePayoutSubaccountResponseData()
        {

            return new
            {

                Id = GetRandomNumber(),
                AccountReference = GetRandomString(),
                AccountName = GetRandomString(),
                BarterId = GetRandomString(),
                Email = GetRandomString(),
                Mobilenumber = GetRandomString(),
                Country = GetRandomString(),
                Nuban = GetRandomString(),
                BankName = GetRandomString(),
                BankCode = GetRandomString(),
                Status = GetRandomString(),
                CreatedAt = GetRandomDate(),



            };

        }
        #endregion

        #region FetchPayoutSubaccountResponseProperties

        private static dynamic CreateRandomFetchPayoutSubaccountResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomFetchPayoutSubaccountResponseData()
            };
        }

        private static dynamic GetRandomFetchPayoutSubaccountResponseData()
        {
            return new
            {
                Id = GetRandomNumber(),
                AccountReference = GetRandomString(),
                AccountName = GetRandomString(),
                BarterId = GetRandomString(),
                Email = GetRandomString(),
                Mobilenumber = GetRandomString(),
                Country = GetRandomString(),
                Nuban = GetRandomString(),
                BankName = GetRandomString(),
                BankCode = GetRandomString(),
                Status = GetRandomString(),
                TransferLimits = GetRandomFetchPayoutSubaccountResponseTransferLimit(),
                CreatedAt = GetRandomDate(),

            };
        }

        private static dynamic GetRandomFetchPayoutSubaccountResponseTransferLimit()
        {
            return new
            {
                SingleLimit = GetRandomNumber(),
                TotalDailyLimit = GetRandomNumber(),
            };
        }


        #endregion

        #region FetchPayoutSubaccountTransactionsResponseProperties

        private static dynamic CreateRandomFetchPayoutSubaccountTransactionsResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomFetchPayoutSubaccountTransactionsResponseData()
            };
        }


        private static dynamic GetRandomFetchPayoutSubaccountTransactionsResponseData()
        {

            return new
            {




            };

        }
        #endregion

        #region FetchStaticVirtualAccountsResponseProperties

        private static dynamic CreateRandomFetchStaticVirtualAccountsResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomFetchStaticVirtualAccountsResponseData()
            };
        }


        private static dynamic GetRandomFetchStaticVirtualAccountsResponseData()
        {

            return new
            {

                StaticAccount = GetRandomString(),
                BankName = GetRandomString(),
                BankCode = GetRandomString(),
                Currency = GetRandomString(),
                IsDefault = new object(),
                Type = GetRandomString(),



            };

        }
        #endregion

        #region FetchSubaccountAvailableBalanceResponseProperties

        private static dynamic CreateRandomFetchSubaccountAvailableBalanceResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomFetchSubaccountAvailableBalanceResponseData()
            };
        }


        private static dynamic GetRandomFetchSubaccountAvailableBalanceResponseData()
        {

            return new
            {

                Currency = GetRandomString(),
                AvailableBalance = GetRandomNumber(),
                LedgerBalance = GetRandomNumber(),




            };

        }
        #endregion

        #region ListPayoutSubaccountsResponseProperties

        private static dynamic CreateRandomListPayoutSubaccountsResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomListPayoutSubaccountsResponseData(),
            };
        }


        private static List<dynamic> GetRandomListPayoutSubaccountsResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Id = GetRandomNumber(),
                AccountReference = GetRandomString(),
                AccountName = GetRandomString(),
                BarterId = GetRandomString(),
                Email = GetRandomString(),
                Mobilenumber = GetRandomString(),
                Country = GetRandomString(),
                Nuban = GetRandomString(),
                BankName = GetRandomString(),
                BankCode = GetRandomString(),
                Status = GetRandomString(),
                CreatedAt = GetRandomDate(),





            }).ToList<dynamic>();

        }


        #endregion

        #region UpdatePayoutSubaccountResponseProperties

        private static dynamic CreateRandomUpdatePayoutSubaccountResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomUpdatePayoutSubaccountResponseData(),

            };
        }


        private static dynamic GetRandomUpdatePayoutSubaccountResponseData()
        {

            return new
            {

                Id = GetRandomNumber(),
                AccountReference = GetRandomString(),
                AccountName = GetRandomString(),
                BarterId = GetRandomString(),
                Email = GetRandomString(),
                Mobilenumber = GetRandomString(),
                Country = GetRandomString(),
                Nuban = GetRandomString(),
                BankName = GetRandomString(),
                BankCode = GetRandomString(),
                Status = GetRandomString(),
                CreatedAt = GetRandomDate(),

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

        private static Filler<CreatePayoutSubaccount> CreateCreatePayoutSubaccountFiller()
        {
            var filler = new Filler<CreatePayoutSubaccount>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<UpdatePayoutSubaccount> CreateUpdatePayoutSubaccountFiller()
        {
            var filler = new Filler<UpdatePayoutSubaccount>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }



    }
}
