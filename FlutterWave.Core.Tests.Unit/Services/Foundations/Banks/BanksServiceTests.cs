using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification;
using FlutterWave.Core.Services.Foundations.FlutterWave.BanksService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Data;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Banks
{
    public partial class BanksServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IBanksService banksService;

        public BanksServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            this.banksService = new BanksService(
                flutterWaveBroker: this.flutterWaveBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);
        }




        private Expression<Func<ExternalBankAccountVerificationRequest, bool>> SameExternalBankBranchesRequestAs(
            ExternalBankAccountVerificationRequest expectedExternalBankAccountVerificationRequest)
        {
            return actualExternalBankAccountVerificationRequest =>
                this.compareLogic.Compare(
                    expectedExternalBankAccountVerificationRequest,
                    actualExternalBankAccountVerificationRequest)
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


        private static List<dynamic> GetRandomBankBranchList()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Id = GetRandomNumber(),
                BankId = GetRandomNumber(),
                Bic = GetRandomString(),
                BranchCode = GetRandomString(),
                BranchName = GetRandomString(),
                SwiftCode = GetRandomString(),

            }).ToList<dynamic>();

        }

        private static List<dynamic> GetRandomBankList()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
               item => new
               {
                   Id = GetRandomNumber(),
                   Code = GetRandomString(),
                   Name = GetRandomString(),

               }).ToList<dynamic>();
        }
        private static dynamic CreateRandomBankProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomBankList()
            };
        }

        private static dynamic CreateRandomBankBranchesProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomBankBranchList()
            };
        }


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
