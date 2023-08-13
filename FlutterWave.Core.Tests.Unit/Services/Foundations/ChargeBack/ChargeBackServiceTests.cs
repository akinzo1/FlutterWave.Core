using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalChargeBack;
using FlutterWave.Core.Services.Foundations.FlutterWave.ChargeBackService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Data;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.ChargeBacks
{
    public partial class ChargeBackServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IChargeBackService chargeBackService;

        public ChargeBackServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            this.chargeBackService = new ChargeBackService(
                flutterWaveBroker: this.flutterWaveBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);
        }


        private Expression<Func<ExternalAcceptDeclineChargeBackRequest, bool>> SameExternalAcceptDeclineChargeBackRequestAs(
            ExternalAcceptDeclineChargeBackRequest expectedExternalAcceptDeclineChargeBackRequest)
        {
            return actualExternalAcceptDeclineChargeBackRequest =>
                this.compareLogic.Compare(
                    expectedExternalAcceptDeclineChargeBackRequest,
                    actualExternalAcceptDeclineChargeBackRequest)
                        .AreEqual;
        }

        private Expression<Func<string, bool>> SameExternalAcceptDeclineChargeBackIdRequestAs(
        string expectedExternalAcceptDeclineChargeBackIdRequest)
        {
            return actualExternalAcceptDeclineChargeBackIdRequest =>
                this.compareLogic.Compare(
                    expectedExternalAcceptDeclineChargeBackIdRequest,
                    actualExternalAcceptDeclineChargeBackIdRequest)
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



        #region AcceptDeclineChargeBackProperties

        private static dynamic CreateRandomAcceptDeclineChargeBacksProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = new object(),


            };
        }

        #endregion

        #region ChargeBackProperties

        private static dynamic CreateRandomAllChargeBackProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomAllChargeBacksDataList(),
                Meta = CreateRandomChargeBackPageInfoData()

            };
        }


        private static List<dynamic> GetRandomAllChargeBacksDataList()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Id = GetRandomNumber(),
                Amount = GetRandomNumber(),
                FlwRef = GetRandomString(),
                Status = GetRandomString(),
                Stage = GetRandomString(),
                Comment = GetRandomString(),
                Meta = CreateRandomChargeBackMetaHistoryData(),
                DueDate = GetRandomDate(),
                SettlementId = GetRandomString(),
                CreatedAt = GetRandomDate(),
                TransactionId = GetRandomNumber(),
                TxRef = GetRandomString(),

            }).ToList<dynamic>();
        }

        private static List<dynamic> CreateRandomChargeBackHistoryData()
        {
            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {
                Initiator = GetRandomString(),
                Date = GetRandomDate(),
                Description = GetRandomString(),
                Action = GetRandomString(),
                Stage = GetRandomString(),
                Source = GetRandomString(),
            }).ToList<dynamic>();
        }

        private static dynamic CreateRandomChargeBackPageInfoData()
        {
            return new
            {
                Total = GetRandomNumber(),
                CurrentPage = GetRandomNumber(),
                TotalPages = GetRandomNumber(),
                PageSize = GetRandomNumber(),
            };
        }

        private static dynamic CreateRandomChargeBackMetaHistoryData()
        {
            return new
            {
                PageInfo = CreateRandomChargeBackPageInfoData(),
                UploadedProof = new object(),
                History = CreateRandomChargeBackHistoryData()
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
