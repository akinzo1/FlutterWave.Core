



using FlutterWave.Core.Services.Foundations.FlutterWave.SubscriptionService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Data;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Subscriptions
{
    public partial class SubscriptionsServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly ISubscriptionService subscriptionsService;

        public SubscriptionsServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            this.subscriptionsService = new SubscriptionService(
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

        #region AllSubscriptionsProperties

        private static dynamic CreateRandomAllSubscriptionsProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomSubscriptionList(),
                Meta = GetRandomAllSubscriptionsPageInfo()
            };
        }

        private static List<dynamic> GetRandomSubscriptionList()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Id = GetRandomNumber(),
                Amount = GetRandomNumber(),
                Customer = GetRandomCustomerSubscription(),
                Plan = GetRandomNumber(),
                Status = GetRandomString(),
                CreatedAt = GetRandomDate(),


            }).ToList<dynamic>();

        }

        private static dynamic GetRandomCustomerSubscription()
        {
            return new
            {
                Id = GetRandomNumber(),
                CustomerEmail = GetRandomString(),

            };
        }

        private static dynamic GetRandomAllSubscriptionsPageInfo()
        {
            return new
            {
                Total = GetRandomNumber(),
                CurrentPage = GetRandomNumber(),
                TotalPages = GetRandomNumber(),
                PageSize = GetRandomNumber(),

            };
        }

        #endregion


        #region ActivateSubscriptionsProperties

        private static dynamic CreateRandomActivateSubscriptionsProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomActivateSubscriptionData(),

            };
        }

        private static dynamic GetRandomActivateSubscriptionData()
        {

            return new
            {

                Id = GetRandomNumber(),
                Amount = GetRandomNumber(),
                Customer = GetRandomCustomerSubscription(),
                Plan = GetRandomNumber(),
                Status = GetRandomString(),
                CreatedAt = GetRandomDate(),


            };

        }
        #endregion


        #region DeactivateSubscriptionsProperties

        private static dynamic CreateRandomDeactivateSubscriptionsProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomDeactivateSubscriptionData(),

            };
        }

        private static dynamic GetRandomDeactivateSubscriptionData()
        {

            return new
            {

                Id = GetRandomNumber(),
                Amount = GetRandomNumber(),
                Customer = GetRandomCustomerSubscription(),
                Plan = GetRandomNumber(),
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




    }
}
