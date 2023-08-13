using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using FlutterWave.Core.Services.Foundations.FlutterWave.BillPaymentService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Data;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.BillPayment
{
    public partial class BillPaymentsServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IBillPaymentService billPaymentsService;

        public BillPaymentsServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            this.billPaymentsService = new BillPaymentService(
                flutterWaveBroker: this.flutterWaveBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);
        }




        private Expression<Func<ExternalCreateBillPaymentRequest, bool>> SameExternalCreateBillPaymentRequestAs(
            ExternalCreateBillPaymentRequest expectedExternalCreateBillPaymentRequest)
        {
            return actualExternalCreateBillPaymentRequest =>
                this.compareLogic.Compare(
                    expectedExternalCreateBillPaymentRequest,
                    actualExternalCreateBillPaymentRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalBulkBillPaymentsRequest, bool>> SameExternalBulkBillPaymentsRequestAs(
                ExternalBulkBillPaymentsRequest expectedExternalBulkBillPaymentsRequest)
        {
            return actualExternalBulkBillPaymentsRequest =>
                this.compareLogic.Compare(
                    expectedExternalBulkBillPaymentsRequest,
                    actualExternalBulkBillPaymentsRequest)
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

        private static BillPayments CreateRandomBillPayments() =>
         CreateBillPaymentsFiller().Create();

        #region BulkBillPaymentsRequestProperties

        private static dynamic CreateRandomBulkBillPaymentsRequestProperties()
        {
            return new
            {
                BulkReference = GetRandomString(),
                CallbackUrl = GetRandomString(),
                BulkData = GetRandomBulkBillPaymentsList(),
            };
        }

        private static List<dynamic> GetRandomBulkBillPaymentsList()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {


                Country = GetRandomString(),
                Customer = GetRandomString(),
                Amount = GetRandomNumber(),
                Recurrence = GetRandomString(),
                Type = GetRandomString(),
                Reference = GetRandomString(),


            }).ToList<dynamic>();

        }

        #endregion  

        #region BillCategoriesProperties

        private static dynamic CreateRandomBillCategoriesProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomBillCategoriesList()
            };
        }


        private static List<dynamic> GetRandomBillCategoriesList()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Id = GetRandomNumber(),
                BillerCode = GetRandomString(),
                Name = GetRandomString(),
                DefaultCommission = GetRandomNumber(),
                DateAdded = GetRandomDate(),
                Country = GetRandomString(),
                IsAirtime = GetRandomBoolean(),
                BillerName = GetRandomString(),
                ItemCode = GetRandomString(),
                ShortName = GetRandomString(),
                Fee = GetRandomNumber(),
                CommissionOnFee = GetRandomBoolean(),
                LabelName = GetRandomString(),
                Amount = GetRandomNumber(),

            }).ToList<dynamic>();

        }
        #endregion

        #region ValidateBillServiceProperties

        private static dynamic CreateRandomValidateBillServicesProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = CreateRandomValidateBillServiceData()
            };
        }

        private static dynamic CreateRandomValidateBillServiceData()
        {

            return new
            {
                ResponseCode = GetRandomString(),
                Address = new object(),
                ResponseMessage = GetRandomString(),
                Name = GetRandomString(),
                BillerCode = GetRandomString(),
                Customer = GetRandomString(),
                ProductCode = GetRandomString(),
                Email = new object(),
                Fee = GetRandomNumber(),
                Maximum = GetRandomNumber(),
                Minimum = GetRandomNumber(),
            };

        }

        #endregion

        #region  CreateBillPaymentProperties

        private static dynamic CreateRandomBillPaymentsProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = CreateRandomBillPaymentData()
            };
        }

        private static dynamic CreateRandomBillPaymentData()
        {

            return new
            {
                PhoneNumber = GetRandomString(),
                Amount = GetRandomNumber(),
                Network = GetRandomString(),
                FlwRef = GetRandomString(),
                TxRef = GetRandomString(),
                Reference = new object(),

            };

        }

        #endregion

        #region  BulkBillPaymentProperties

        private static dynamic CreateRandomBulkBillPaymentsProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = CreateRandomBulkBillPaymentData()
            };
        }

        private static dynamic CreateRandomBulkBillPaymentData()
        {

            return new
            {
                BatchReference = GetRandomString(),

            };

        }

        #endregion

        #region BillStatusProperties

        private static dynamic CreateRandomBillStatusPaymentsProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = CreateRandomBillStatusPaymentData()
            };
        }

        private static dynamic CreateRandomBillStatusPaymentData()
        {

            return new
            {
                TxRef = GetRandomString(),
                Amount = GetRandomNumber(),
                Fee = GetRandomNumber(),
                Currency = new object(),
                Extra = new object(),
                FlwRef = new object(),
                Token = new object(),


            };

        }


        #endregion

        #region BillPaymentsProperties
        private static dynamic CreateRandomGetBillPaymentsProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = CreateRandomGetBillPaymentsData()
            };
        }

        private static dynamic CreateRandomGetBillPaymentsData()
        {
            return new
            {
                Summary = CreateRandomGetBillPaymentsSummaryData(),
                Total = GetRandomNumber(),
                TotalPages = GetRandomNumber(),
                Reference = new object(),

            };
        }

        private static List<dynamic> CreateRandomGetBillPaymentsSummaryData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {
                Currency = GetRandomString(),
                SumBills = GetRandomNumber(),
                SumCommission = GetRandomNumber(),
                SumDstv = GetRandomNumber(),
                SumAirtime = GetRandomNumber(),
                CountDstv = GetRandomNumber(),
                CountAirtime = GetRandomNumber(),

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

        private static Filler<BillPayments> CreateBillPaymentsFiller()
        {
            var filler = new Filler<BillPayments>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }


    }
}
