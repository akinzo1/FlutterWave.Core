



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.PaymentPlan;
using FlutterWave.Core.Services.Foundations.FlutterWave.PaymentPlanService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PaymentPlans
{
    public partial class PaymentPlanServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IPaymentPlanService paymentPlanService;

        public PaymentPlanServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            this.paymentPlanService = new PaymentPlanService(
                flutterWaveBroker: this.flutterWaveBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);
        }




        private Expression<Func<ExternalCreatePaymentPlanRequest, bool>> SameExternalCreatePaymentPlanRequestAs(
            ExternalCreatePaymentPlanRequest expectedExternalCreatePaymentPlanRequest)
        {
            return actualExternalCreatePaymentPlanRequest =>
                this.compareLogic.Compare(
                    expectedExternalCreatePaymentPlanRequest,
                    actualExternalCreatePaymentPlanRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalUpdatePaymentPlanRequest, bool>> SameExternalUpdatePaymentPlanRequestAs(
          ExternalUpdatePaymentPlanRequest expectedExternalUpdatePaymentPlanRequest)
        {
            return actualExternalExternalUpdatePaymentPlanRequest =>
                this.compareLogic.Compare(
                    expectedExternalUpdatePaymentPlanRequest,
                    actualExternalExternalUpdatePaymentPlanRequest)
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

        #region CreatePaymentPlanProperties

        private static dynamic CreateRandomPaymentPlanProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = CreateRandomPaymentPlanData()
            };
        }

        private static dynamic CreateRandomPaymentPlanData()
        {
            return new
            {

                Id = GetRandomNumber(),
                Name = GetRandomString(),
                Amount = GetRandomNumber(),
                Interval = GetRandomString(),
                Duration = GetRandomNumber(),
                Status = GetRandomString(),
                Currency = GetRandomString(),
                PlanToken = GetRandomString(),
                CreatedAt = GetRandomDate(),

            };
        }

        #endregion


        #region CreatePaymentPlansProperties

        private static dynamic CreateRandomPaymentPlansProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Meta = GetRandomPaymentPlanPageInfo(),
                Data = GetRandomPaymentPlansDataList()
            };
        }

        private static dynamic GetRandomPaymentPlanPageInfo()
        {
            return new
            {
                Total = GetRandomNumber(),
                CurrentPage = GetRandomNumber(),
                TotalPages = GetRandomNumber(),

            };
        }

        private static List<dynamic> GetRandomPaymentPlansDataList()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
             item => new
             {
                 Id = GetRandomNumber(),
                 Name = GetRandomString(),
                 Amount = GetRandomNumber(),
                 Interval = GetRandomString(),
                 Duration = GetRandomNumber(),
                 Status = GetRandomString(),
                 Currency = GetRandomString(),
                 PlanToken = GetRandomString(),
                 CreatedAt = GetRandomDate(),

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
