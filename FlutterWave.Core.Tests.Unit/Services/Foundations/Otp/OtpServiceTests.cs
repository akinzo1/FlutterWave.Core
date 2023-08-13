



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalOtp;
using FlutterWave.Core.Services.Foundations.FlutterWave.OtpService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Data;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Otp
{
    public partial class OtpServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IOtpService otpService;

        public OtpServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            this.otpService = new OtpService(
                flutterWaveBroker: this.flutterWaveBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);
        }




        private Expression<Func<ExternalCreateOtpRequest, bool>> SameExternalCreateOtpRequestRequestAs(
            ExternalCreateOtpRequest expectedExternalCreateOtpRequest)
        {
            return actualExternalCreateOtpRequest =>
                this.compareLogic.Compare(
                    expectedExternalCreateOtpRequest,
                    actualExternalCreateOtpRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalValidateOtpRequest, bool>> SameExternalValidateOtpRequestAs(
          ExternalValidateOtpRequest expectedExternalValidateOtpRequest)
        {
            return actualExternalValidateOtpRequest =>
                this.compareLogic.Compare(
                    expectedExternalValidateOtpRequest,
                    actualExternalValidateOtpRequest)
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

        #region CreateOtpProperties

        private static dynamic CreateRandomOtpProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomCreateOtpDataList()
            };
        }


        private static List<dynamic> GetRandomCreateOtpDataList()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Medium = GetRandomString(),
                Reference = GetRandomString(),
                Otp = GetRandomString(),
                Expiry = GetRandomDate(),


            }).ToList<dynamic>();

        }

        #endregion

        #region ValidateOtpProperties

        private static dynamic CreateRandomValidateOtpProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = new object()
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
