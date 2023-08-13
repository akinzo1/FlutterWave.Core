using FlutterWave.Core.Services.Foundations.FlutterWave.SettlementsService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Data;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Settlements
{
    public partial class SettlementsServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly ISettlementsService settlementsService;

        public SettlementsServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            this.settlementsService = new SettlementsService(
                flutterWaveBroker: this.flutterWaveBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);
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

        #region AllSettlementsProperties

        private static dynamic CreateRandomAllSettlementsProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomAllSettlementsDataList(),
                Meta = CreateRandomAllSettlementsPageInfo()
            };
        }

        private static dynamic CreateRandomAllSettlementsPageInfo()
        {
            return new
            {
                Total = GetRandomNumber(),
                CurrentPage = GetRandomNumber(),
                TotalPages = GetRandomNumber(),
                PageSize = GetRandomNumber(),

            };
        }

        private static List<dynamic> GetRandomAllSettlementsDataList()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Id = GetRandomNumber(),
                AccountId = GetRandomNumber(),
                MerchantName = GetRandomString(),
                MerchantEmail = GetRandomString(),
                SettlementAccount = GetRandomString(),
                BankCode = GetRandomString(),
                TransactionDate = GetRandomDate(),
                DueDate = GetRandomDate(),
                ProcessedDate = new object(),
                Status = GetRandomString(),
                IsLocal = GetRandomBoolean(),
                Currency = GetRandomString(),
                GrossAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                Chargeback = GetRandomNumber(),
                Refund = GetRandomNumber(),
                StampdutyCharge = GetRandomNumber(),
                NetAmount = GetRandomNumber(),
                TransactionCount = GetRandomNumber(),
                ProcessorRef = new object(),
                DisburseRef = GetRandomString(),
                DisburseMessage = new object(),
                Channel = GetRandomString(),
                Destination = GetRandomString(),
                FxData = new object(),
                FlagMessage = new object(),
                Meta = new List<int>(),
                RefundMeta = new List<int>(),
                ChargebackMeta = new List<object>(),
                SourceBankcode = new object(),
                CreatedAt = GetRandomDate(),


            }).ToList<dynamic>();

        }



        #endregion


        #region FetchSettlementProperties

        private static dynamic CreateRandomFetchSettlementProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomSettlementDataList(),

            };
        }



        private static dynamic GetRandomSettlementDataList()
        {

            return new
            {
                Id = GetRandomNumber(),
                AccountId = GetRandomNumber(),
                MerchantName = GetRandomString(),
                MerchantEmail = GetRandomString(),
                SettlementAccount = GetRandomString(),
                BankCode = GetRandomString(),
                TransactionDate = GetRandomDate(),
                DueDate = GetRandomDate(),
                ProcessedDate = new object(),
                Status = GetRandomString(),
                IsLocal = GetRandomBoolean(),
                Currency = GetRandomString(),
                GrossAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                Chargeback = GetRandomNumber(),
                Refund = GetRandomNumber(),
                StampdutyCharge = GetRandomNumber(),
                NetAmount = GetRandomNumber(),
                TransactionCount = GetRandomNumber(),
                ProcessorRef = new object(),
                DisburseRef = GetRandomString(),
                DisburseMessage = new object(),
                Channel = GetRandomString(),
                Destination = GetRandomString(),
                FxData = new object(),
                FlagMessage = new object(),
                Meta = new List<int>(),
                RefundMeta = new List<int>(),
                ChargebackMeta = new List<object>(),
                SourceBankcode = new object(),
                CreatedAt = GetRandomDate(),
                Transactions = GetRandomSettlementTransactionList()

            };


        }

        private static List<dynamic> GetRandomSettlementTransactionList()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {
                CustomerEmail = GetRandomString(),
                FlwRef = GetRandomString(),
                TxRef = GetRandomString(),
                Id = GetRandomNumber(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                StampdutyCharge = GetRandomNumber(),
                SettlementAmount = GetRandomNumber(),
                Status = GetRandomString(),
                PaymentEntity = GetRandomString(),
                TransactionDate = GetRandomString(),
                Currency = GetRandomString(),
                CardLocale = GetRandomString(),
                Rrn = GetRandomString(),
                SubaccountSettlement = GetRandomNumber(),


            }).ToList<dynamic>();
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
