using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification;
using FlutterWave.Core.Services.Foundations.FlutterWave.MiscService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Data;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Miscellaneous
{
    public partial class MiscellaneousServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IMiscellaneousService miscellaneousService;

        public MiscellaneousServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            this.miscellaneousService = new MiscellaneousService(
                flutterWaveBroker: this.flutterWaveBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);
        }




        private Expression<Func<ExternalBankAccountVerificationRequest, bool>> SameExternalBankAccountVerificationRequestAs(
            ExternalBankAccountVerificationRequest expectedExternalBankAccountVerificationRequest)
        {
            return actualExternalBankAccountVerificationRequest =>
                this.compareLogic.Compare(
                    expectedExternalBankAccountVerificationRequest,
                    actualExternalBankAccountVerificationRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalBvnConsentRequest, bool>> SameExternalBvnConsentRequestRequestAs(
          ExternalBvnConsentRequest expectedExternalBvnConsentRequestRequest)
        {
            return actualExternalBvnConsentRequestRequest =>
                this.compareLogic.Compare(
                    expectedExternalBvnConsentRequestRequest,
                    actualExternalBvnConsentRequestRequest)
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

        #region BalanceBycurrencyProperties

        private static dynamic CreateRandomBalanceByCurrencyProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomBalanceByCurrencyData()
            };
        }
        private static dynamic GetRandomBalanceByCurrencyData()
        {


            return new
            {
                Currency = GetRandomString(),
                AvailableBalance = GetRandomNumber(),
                LedgerBalance = GetRandomNumber(),

            };
        }



        #endregion

        #region AllBalanceCurrenciesProperties

        private static dynamic CreateRandomAllBalanceCurrenciesProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomAllBalanceCurrenciesList()
            };
        }

        private static List<dynamic> GetRandomAllBalanceCurrenciesList()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Currency = GetRandomString(),
                AvailableBalance = GetRandomNumber(),
                LedgerBalance = GetRandomNumber(),

            }).ToList<dynamic>();

        }
        #endregion

        #region StatementofAccountProperties

        private static dynamic CreateRandomStatementOfAccountProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = CreateRandomStatementResultList()
            };
        }


        private static dynamic CreateRandomStatementResultList()
        {
            return new
            {
                PageInfo = CreateRandomStatementPageInfo(),
                Transactions = GetRandomStatementsTransactionsList(),

            };
        }

        private static dynamic CreateRandomStatementPageInfo()
        {
            return new
            {
                Total = GetRandomNumber(),
                CurrentPage = GetRandomNumber(),
                TotalPages = GetRandomNumber(),

            };
        }
        private static List<dynamic> GetRandomStatementsTransactionsList()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Type = GetRandomString(),
                Amount = GetRandomNumber(),
                Currency = GetRandomString(),
                BalanceBefore = GetRandomNumber(),
                BalanceAfter = GetRandomNumber(),
                Reference = GetRandomString(),
                Date = GetRandomDate(),
                Remarks = GetRandomString(),
                SentCurrency = GetRandomString(),
                RateUsed = GetRandomNumber(),
                SentAmount = GetRandomNumber(),
                StatementType = GetRandomString(),

            }).ToList<dynamic>();

        }

        #endregion

        #region  BankAccountVerificationProperties

        private static dynamic CreateRandomBankAccountVerificationProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomBankAccountVerificationData()
            };
        }


        private static dynamic GetRandomBankAccountVerificationData()
        {
            return new
            {
                AccountName = GetRandomString(),
                AccountNumber = GetRandomString(),

            };
        }
        #endregion

        #region BvnConsentProperties

        private static dynamic CreateRandomBvnConsentProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomBvnConsentData()
            };
        }

        private static dynamic GetRandomBvnConsentData()
        {
            return new
            {
                Url = GetRandomString(),
                Reference = GetRandomString(),

            };
        }

        #endregion

        #region CardBinVerificationProperties

        private static dynamic CreateRandomCardBinVerificationProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomCardBinVerificationData()
            };
        }

        private static dynamic GetRandomCardBinVerificationData()
        {
            return new
            {
                IssuingCountry = GetRandomString(),
                Bin = GetRandomString(),
                CardType = GetRandomString(),
                IssuerInfo = GetRandomString(),

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
