



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using FlutterWave.Core.Services.Foundations.FlutterWave.TransactionsService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly ITransactionsService transactionsService;

        public TransactionServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            transactionsService = new TransactionsService(
                flutterWaveBroker: flutterWaveBrokerMock.Object,
                dateTimeBroker: dateTimeBrokerMock.Object);
        }

        public static TheoryData UnauthorizedExceptions()
        {
            return new TheoryData<HttpResponseException>
            {
                new HttpResponseUnauthorizedException(),
                new HttpResponseForbiddenException()
            };
        }

        private Expression<Func<ExternalMultipleTransactionRequest, bool>> SameExternalMultipleTransactionRequestAs(
            ExternalMultipleTransactionRequest externalMultipleTransactionRequest)
        {
            return actualExternalMultipleTransactionRequest =>
                compareLogic.Compare(
                    externalMultipleTransactionRequest,
                    actualExternalMultipleTransactionRequest)
                        .AreEqual;
        }

        private static dynamic CreateRandomTransactionFeesRequestProperties()
        {
            return new
            {
                Amount = GetRandomNumber(),
                Currency = GetRandomNumber()
            };
        }

        private static DateTime GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static string[] CreateRandomStringArray() =>
          new Filler<string[]>().Create();
        private static object CreateRandomObject() =>
            new Filler<object>().Create();

        private static bool GetRandomBoolean() =>
            Randomizer<bool>.Create();

        private static Dictionary<string, int> CreateRandomDictionary() =>
            new Filler<Dictionary<string, int>>().Create();


        private static MultipleTransaction CreateRandomMultipleTransaction() =>
            CreateMultipleTransactionFiller().Create();

        #region TransactionFeesProperties

        private static dynamic CreateRandomFees()
        {
            return new
            {

                ChargeAmount = GetRandomNumber(),
                Fee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                FlutterwaveFee = GetRandomNumber(),
                StampDutyFee = GetRandomNumber(),
                Currency = GetRandomString(),

            };
        }

        private static dynamic CreateRandomFeesProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = CreateRandomFees(),

            };
        }



        #endregion

        #region MultipleTransactionProperties



        private static dynamic CreateRandomMultipleTransactionProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = CreateRandomMultipleTransactionsDataList(),
                Meta = CreateRandomMultipleTransactionsPageInfo(),

            };
        }

        private static dynamic CreateRandomMultipleTransactionsAccount()
        {
            return new
            {
                Nuban = GetRandomString(),
                Bank = GetRandomString(),

            };
        }

        private static dynamic CreateRandomMultipleTransactionsPageInfo()
        {
            return new
            {

                Total = GetRandomNumber(),
                CurrentPage = GetRandomNumber(),
                TotalPages = GetRandomNumber(),

            };
        }

        private static List<dynamic> CreateRandomMultipleTransactionsDataList()
        {
            return Enumerable.Range(0, GetRandomNumber()).Select(
             item => new
             {
                 Id = GetRandomString(),
                 TxRef = GetRandomString(),
                 FlwRef = GetRandomString(),
                 DeviceFingerprint = GetRandomString(),
                 Amount = GetRandomNumber(),
                 Currency = GetRandomString(),
                 ChargedAmount = GetRandomNumber(),
                 AppFee = GetRandomNumber(),
                 MerchantFee = GetRandomNumber(),
                 ProcessorResponse = GetRandomString(),
                 AuthModel = GetRandomString(),
                 Ip = GetRandomString(),
                 Narration = GetRandomString(),
                 Status = GetRandomString(),
                 PaymentType = GetRandomString(),
                 CreatedAt = GetRandomDate(),
                 AmountSettled = GetRandomNumber(),
                 Account = CreateRandomMultipleTransactionsAccount(),
                 CustomerName = GetRandomString(),
                 CustomerEmail = GetRandomString(),
                 AccountId = GetRandomString(),

             }).ToList<dynamic>();
        }

        #endregion

        #region MulitpleRefundProperties
        private static dynamic CreateRandomMultipleRefundsProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = CreateRandomMultipleRefundsList(),
                Meta = CreateRandomMultiplePageInfoRefunds()

            };
        }

        private static dynamic CreateRandomMultiplePageInfoRefunds()
        {
            return new
            {
                PageInfo = GetRandomString(),
                Total = GetRandomNumber(),
                CurrentPage = GetRandomNumber(),
                TotalPages = GetRandomNumber(),
                PageSize = GetRandomNumber(),
            };
        }

        private static List<dynamic> CreateRandomMultipleRefundsList()
        {
            return Enumerable.Range(0, GetRandomNumber()).Select(
             item => new
             {

                 Id = GetRandomNumber(),
                 AmountRefunded = GetRandomNumber(),
                 Status = GetRandomString(),
                 FlwRef = GetRandomString(),
                 Comment = GetRandomString(),
                 SettlementId = GetRandomString(),
                 Meta = GetRandomString(),
                 CreatedAt = GetRandomDate(),
                 AccountId = GetRandomNumber(),
                 TransactionId = GetRandomNumber(),

             }).ToList<dynamic>();
        }
        #endregion

        #region RefundDetailsProperties

        private static dynamic CreateRandomRefundDetailsProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomRefundDetailsData(),

            };
        }


        private static dynamic GetRandomRefundDetailsData()
        {
            return new
            {
                Id = GetRandomNumber(),
                AmountRefunded = GetRandomNumber(),
                Status = GetRandomString(),
                FlwRef = GetRandomString(),
                Comment = new object(),
                SettlementId = GetRandomString(),
                Meta = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                TransactionId = GetRandomNumber(),

            };
        }



        #endregion

        #region CreateRefundProperties
        private static dynamic CreateRandomCreateRefund()
        {
            return new
            {
                Id = GetRandomNumber(),
                AccountId = GetRandomNumber(),
                TxId = GetRandomNumber(),
                FlwRef = GetRandomString(),
                WalletId = GetRandomNumber(),
                AmountRefunded = GetRandomNumber(),
                Destination = GetRandomString(),
                Meta = GetRandomString(),
                Status = GetRandomString(),
                CreatedAt = GetRandomDate(),
            };
        }

        private static dynamic CreateRandomCreateRefundProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = CreateRandomCreateRefund(),
                Source = GetRandomString()

            };
        }
        #endregion

        #region VerifyTransactions

        private static dynamic CreateRandomCard()
        {
            return new
            {
                First6digits = GetRandomString(),
                Last4digits = GetRandomString(),
                Issuer = GetRandomString(),
                Country = GetRandomString(),
                Type = GetRandomString(),
                Token = GetRandomString(),
                Expiry = GetRandomString(),
            };
        }

        private static dynamic CreateRandomCustomer()
        {
            return new
            {
                Id = GetRandomNumber(),
                Name = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),

            };
        }
        private static dynamic CreateRandomVerifyTransactionData()
        {
            return new
            {
                Id = GetRandomNumber(),
                TxRef = GetRandomString(),
                FlwRef = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Amount = GetRandomNumber(),
                Currency = GetRandomString(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                ProcessorResponse = GetRandomString(),
                AuthModel = GetRandomString(),
                Ip = GetRandomString(),
                Narration = GetRandomString(),
                Status = GetRandomString(),
                PaymentType = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                Card = CreateRandomCard(),
                Meta = new object(),
                AmountSettled = GetRandomNumber(),
                Customer = CreateRandomCustomer(),
            };
        }

        private static dynamic CreateRandomVerifyTransactionProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = CreateRandomVerifyTransactionData(),


            };
        }

        #endregion

        #region TransactionTimeLine

        private static dynamic CreateRandomTransactionTimelineProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = CreateRandomTransactionTimelineData(),


            };
        }

        private static List<dynamic> CreateRandomTransactionTimelineData()
        {
            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Note = GetRandomString(),
                Actor = GetRandomString(),
                Object = GetRandomString(),
                Action = GetRandomString(),
                Context = GetRandomString(),
                CreatedAt = GetRandomDate(),

            }).ToList<dynamic>();
        }

        #endregion

        private static Filler<MultipleTransaction> CreateMultipleTransactionFiller()
        {
            var filler = new Filler<MultipleTransaction>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }


    }
}
