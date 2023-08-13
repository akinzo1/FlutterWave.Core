



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using FlutterWave.Core.Services.Foundations.FlutterWave.TokenizedChargeService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Data;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.TokenizedCharge
{
    public partial class TokenizedChargeServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly ITokenizedChargeService tokenizedChargeService;

        public TokenizedChargeServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            this.tokenizedChargeService = new TokenizedChargeService(
                flutterWaveBroker: this.flutterWaveBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);
        }





        private Expression<Func<ExternalCreateBulkTokenizedChargeRequest, bool>> SameExternalCreateBulkTokenizedChargeRequestAs(
            ExternalCreateBulkTokenizedChargeRequest expectedExternalCreateBulkTokenizedChargeRequest)
        {
            return actualExternalCreateBulkTokenizedChargeRequest =>
                this.compareLogic.Compare(
                    expectedExternalCreateBulkTokenizedChargeRequest,
                    actualExternalCreateBulkTokenizedChargeRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalCreateTokenizedChargeRequest, bool>> SameExternalCreateTokenizedChargeRequestAs(
          ExternalCreateTokenizedChargeRequest expectedExternalCreateTokenizedChargeRequest)
        {
            return actualExternalCreateTokenizedChargeRequest =>
                this.compareLogic.Compare(
                    expectedExternalCreateTokenizedChargeRequest,
                    actualExternalCreateTokenizedChargeRequest)
                        .AreEqual;
        }


        private Expression<Func<ExternalUpdateCardTokenRequest, bool>> SameExternalUpdateCardTokenRequestAs(
         ExternalUpdateCardTokenRequest expectedExternalUpdateCardTokenRequest)
        {
            return actualExternalUpdateCardTokenRequest =>
                this.compareLogic.Compare(
                    expectedExternalUpdateCardTokenRequest,
                    actualExternalUpdateCardTokenRequest)
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

        private static UpdateCardToken CreateRandomUpdateCardToken() =>
           CreateUpdateCardTokenFiller().Create();

        private static CreateBulkTokenizedCharge CreateRandomCreateBulkTokenizedCharge() =>
        CreateCreateBulkTokenizedChargeFiller().Create();

        private static CreateTokenizedCharge CreateRandomCreateTokenizedCharge() =>
            CreateCreateTokenizedChargeFiller().Create();

        #region UpdateCardTokenRequestProperties

        private static dynamic CreateRandomUpdateCardTokenRequestProperties()
        {
            return new
            {
                Email = GetRandomString(),
                FullName = GetRandomString(),
                PhoneNumber = GetRandomString(),

            };
        }


        #endregion

        #region UpdateCardTokenResponseProperties

        private static dynamic CreateRandomUpdateCardTokenResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomCreateRandomUpdateCardTokenResponseData(),

            };
        }

        private static dynamic GetRandomCreateRandomUpdateCardTokenResponseData()
        {
            return new
            {
                CustomerEmail = GetRandomString(),
                CustomerFullName = GetRandomString(),
                CustomerPhoneNumber = GetRandomString(),
                CreatedAt = GetRandomDate(),


            };
        }

        #endregion  

        #region CreateTokenizedChargeRequestProperties

        private static dynamic CreateRandomCreateTokenizedChargeRequestProperties()
        {
            return new
            {
                Token = GetRandomString(),
                Currency = GetRandomString(),
                Country = GetRandomString(),
                Amount = GetRandomNumber(),
                Email = GetRandomString(),
                FirstName = GetRandomString(),
                LastName = GetRandomString(),
                Ip = GetRandomString(),
                Narration = GetRandomString(),
                TxRef = GetRandomString(),



            };
        }


        #endregion  


        #region CreateBulkTokenizedChargeResponseProperties

        private static dynamic CreateRandomCreateBulkTokenizedChargeResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomCreateBulkTokenizedChargeResponseData(),


            };
        }




        private static dynamic GetRandomCreateBulkTokenizedChargeResponseData()
        {

            return new
            {

                Id = GetRandomNumber(),
                CreatedAt = GetRandomDate(),
                Approver = GetRandomString(),


            };

        }


        #endregion

        #region CreateBulkTokenizedChargeRequestProperties

        private static dynamic CreateRandomCreateBulkTokenizedChargeRequestProperties()
        {
            return new
            {
                Title = GetRandomString(),
                BulkData = GetRandomCreateBulkTokenizedChargeRequestData(),
                RetryStrategy = GetRandomCreateBulkTokenizedChargeRequestRetryStrategy()

            };
        }


        private static List<dynamic> GetRandomCreateBulkTokenizedChargeRequestData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Currency = GetRandomString(),
                Token = GetRandomString(),
                Country = GetRandomString(),
                Amount = GetRandomNumber(),
                Email = GetRandomString(),
                FirstName = GetRandomString(),
                LastName = GetRandomString(),
                Ip = GetRandomString(),
                TxRef = GetRandomString(),





            }).ToList<dynamic>();

        }

        private static dynamic GetRandomCreateBulkTokenizedChargeRequestRetryStrategy()
        {

            return new
            {

                RetryInterval = GetRandomNumber(),
                RetryAmountVariable = GetRandomNumber(),
                RetryAttemptVariable = GetRandomNumber(),

            };

        }


        #endregion

        #region CreateTokenizedChargeResponseProperties

        private static dynamic CreateRandomCreateTokenizedChargeResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomCreateTokenizedChargeResponseData(),

            };
        }


        private static dynamic GetRandomCreateTokenizedChargeResponseData()
        {

            return new
            {

                Id = GetRandomNumber(),
                TxRef = GetRandomString(),
                FlwRef = GetRandomString(),
                RedirectUrl = GetRandomString(),
                DeviceFingerprint = GetRandomString(),
                Amount = GetRandomNumber(),
                ChargedAmount = GetRandomNumber(),
                AppFee = GetRandomNumber(),
                MerchantFee = GetRandomNumber(),
                ProcessorResponse = GetRandomString(),
                AuthModel = GetRandomString(),
                Currency = GetRandomString(),
                Ip = GetRandomString(),
                Narration = GetRandomString(),
                Status = GetRandomString(),
                PaymentType = GetRandomString(),
                CreatedAt = GetRandomDate(),
                AccountId = GetRandomNumber(),
                Customer = GetRandomCreateTokenizedChargeResponseCustomer(),
                Card = GetRandomCreateTokenizedChargeResponseCard(),






            };

        }

        private static dynamic GetRandomCreateTokenizedChargeResponseCustomer()
        {

            return new
            {

                Id = GetRandomNumber(),
                PhoneNumber = new object(),
                Name = GetRandomString(),
                Email = GetRandomString(),
                CreatedAt = GetRandomDate(),


            };

        }

        private static dynamic GetRandomCreateTokenizedChargeResponseCard()
        {

            return new
            {

                First6digits = GetRandomString(),
                Last4digits = GetRandomString(),
                Issuer = GetRandomString(),
                Country = GetRandomString(),
                Type = GetRandomString(),
                Expiry = GetRandomString(),
                Token = GetRandomString(),

            };

        }


        #endregion

        #region FetchBulkTokenizedChargeResponseProperties

        private static dynamic CreateRandomFetchBulkTokenizedChargeResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomFetchBulkTokenizedChargeResponseData(),


            };
        }


        private static List<dynamic> GetRandomFetchBulkTokenizedChargeResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                TxRef = GetRandomString(),
                Id = GetRandomString(),
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
                AccountId = GetRandomString(),
                AmountSettled = GetRandomNumber(),
                Card = GetRandomFetchBulkTokenizedChargeResponseCard(),
                Customer = GetRandomFetchBulkTokenizedChargeResponseCustomer(),


            }).ToList<dynamic>();

        }

        private static dynamic GetRandomFetchBulkTokenizedChargeResponseCustomer()
        {

            return new
            {

                Id = GetRandomString(),
                Email = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Name = GetRandomString(),
                CreatedAt = GetRandomDate(),


            };

        }

        private static dynamic GetRandomFetchBulkTokenizedChargeResponseCard()
        {

            return new
            {
                Expiry = GetRandomString(),
                Type = GetRandomString(),
                Country = GetRandomString(),
                Issuer = GetRandomString(),
                First6digits = GetRandomString(),
                Last4digits = GetRandomString(),


            };

        }

        #endregion

        #region FetchBulkTokenizedStatusResponseProperties

        private static dynamic CreateRandomFetchBulkTokenizedStatusResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomFetchBulkTokenizedStatusResponseData(),


            };
        }




        private static dynamic GetRandomFetchBulkTokenizedStatusResponseData()
        {

            return new
            {

                Id = GetRandomNumber(),
                Title = GetRandomString(),
                Approver = GetRandomString(),
                ProcessedCharges = GetRandomNumber(),
                PendingCharges = GetRandomNumber(),
                TotalCharges = GetRandomNumber(),



            };

        }



        #endregion

        #region UpdateCardTokenChargeResponseProperties

        private static dynamic CreateRandomUpdateCardTokenChargeResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomUpdateCardTokenChargeResponseData(),


            };
        }




        private static dynamic GetRandomUpdateCardTokenChargeResponseData()
        {

            return new
            {

                CustomerEmail = GetRandomString(),
                CustomerFullName = GetRandomString(),
                CustomerPhoneNumber = GetRandomString(),
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

        private static Filler<UpdateCardToken> CreateUpdateCardTokenFiller()
        {
            var filler = new Filler<UpdateCardToken>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<CreateBulkTokenizedCharge> CreateCreateBulkTokenizedChargeFiller()
        {
            var filler = new Filler<CreateBulkTokenizedCharge>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<CreateTokenizedCharge> CreateCreateTokenizedChargeFiller()
        {
            var filler = new Filler<CreateTokenizedCharge>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

    }
}
