



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using FlutterWave.Core.Services.Foundations.FlutterWave.VirtualCardsService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Data;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IVirtualCardsService virtualCardsService;

        public VirtualCardsServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            this.virtualCardsService = new VirtualCardsService(
                flutterWaveBroker: this.flutterWaveBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);
        }





        private Expression<Func<ExternalCreateVirtualCardRequest, bool>> SameExternalCreateVirtualCardRequestAs(
            ExternalCreateVirtualCardRequest expectedExternalCreateVirtualCardRequest)
        {
            return actualExternalCreateVirtualCardRequest =>
                this.compareLogic.Compare(
                    expectedExternalCreateVirtualCardRequest,
                    actualExternalCreateVirtualCardRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalFundVirtualCardRequest, bool>> SameExternalFundVirtualCardRequestAs(
          ExternalFundVirtualCardRequest expectedExternalFundVirtualCardRequest)
        {
            return actualExternalFundVirtualCardRequest =>
                this.compareLogic.Compare(
                    expectedExternalFundVirtualCardRequest,
                    actualExternalFundVirtualCardRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalVirtualCardWithdrawalRequest, bool>> SameExternalVirtualCardWithdrawalRequestAs(
        ExternalVirtualCardWithdrawalRequest expectedExternalVirtualCardWithdrawalRequest)
        {
            return actualExternalVirtualCardWithdrawalRequest =>
                this.compareLogic.Compare(
                    expectedExternalVirtualCardWithdrawalRequest,
                    actualExternalVirtualCardWithdrawalRequest)
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

        private static VirtualCardWithdrawal CreateRandomVirtualCardWithdrawal() =>
           CreateVirtualCardWithdrawalFiller().Create();

        private static FundVirtualCard CreateRandomFundVirtualCard() =>
        CreateFundVirtualCardFiller().Create();

        private static CreateVirtualCard CreateRandomCreateVirtualCard() =>
            CreateCreateVirtualCardFiller().Create();

        #region CreateVirtualCardRequestProperties

        private static dynamic CreateRandomCreateVirtualCardRequestProperties()
        {
            return new
            {
                Currency = GetRandomString(),
                Amount = GetRandomNumber(),
                DebitCurrency = GetRandomString(),
                BillingName = GetRandomString(),
                BillingAddress = GetRandomString(),
                BillingCity = GetRandomString(),
                BillingState = GetRandomString(),
                BillingPostalCode = GetRandomString(),
                BillingCountry = GetRandomString(),
                FirstName = GetRandomString(),
                LastName = GetRandomString(),
                DateOfBirth = GetRandomString(),
                Email = GetRandomString(),
                Phone = GetRandomString(),
                Title = GetRandomString(),
                Gender = GetRandomString(),
                CallbackUrl = GetRandomString(),


            };
        }


        #endregion  

        #region FundVirtualCardRequestProperties

        private static dynamic CreateRandomFundVirtualCardRequestProperties()
        {
            return new
            {
                DebitCurrency = GetRandomString(),
                Amount = GetRandomNumber(),

            };
        }


        #endregion  

        #region VirtualCardWithdrawalRequestProperties

        private static dynamic CreateRandomVirtualCardWithdrawalRequestProperties()
        {
            return new
            {

                Amount = GetRandomNumber(),
            };
        }

        #endregion



        #region CreateRandomBlockUnblockVirtualCardResponseProperties

        private static dynamic CreateRandomBlockUnblockVirtualCardResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = new object(),


            };
        }

        #endregion

        #region CreateVirtualCardResponseProperties

        private static dynamic CreateRandomCreateVirtualCardResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomCreateVirtualCardResponseData(),


            };
        }


        private static dynamic GetRandomCreateVirtualCardResponseData()
        {

            return new
            {

                Id = GetRandomString(),
                AccountId = GetRandomNumber(),
                Amount = GetRandomString(),
                Currency = GetRandomString(),
                CardPan = GetRandomString(),
                MaskedPan = GetRandomString(),
                City = GetRandomString(),
                State = GetRandomString(),
                Address1 = GetRandomString(),
                Address2 = GetRandomString(),
                ZipCode = GetRandomString(),
                Cvv = GetRandomString(),
                Expiration = GetRandomString(),
                SendTo = new object(),
                BinCheckName = new object(),
                CardType = GetRandomString(),
                NameOnCard = GetRandomString(),
                CreatedAt = GetRandomDate(),
                IsActive = GetRandomBoolean(),
                CallbackUrl = GetRandomString(),






            };

        }




        #endregion

        #region FetchVirtualCardResponseProperties

        private static dynamic CreateRandomFetchVirtualCardResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomFetchVirtualCardResponseData(),

            };
        }


        private static dynamic GetRandomFetchVirtualCardResponseData()
        {

            return new
            {

                Id = GetRandomString(),
                AccountId = GetRandomNumber(),
                Amount = GetRandomString(),
                Currency = GetRandomString(),
                CardHash = GetRandomString(),
                CardPan = GetRandomString(),
                MaskedPan = GetRandomString(),
                City = GetRandomString(),
                State = GetRandomString(),
                Address1 = GetRandomString(),
                Address2 = new object(),
                ZipCode = GetRandomString(),
                Cvv = GetRandomString(),
                Expiration = GetRandomString(),
                SendTo = new object(),
                BinCheckName = new object(),
                CardType = GetRandomString(),
                NameOnCard = GetRandomString(),
                CreatedAt = GetRandomDate(),
                IsActive = GetRandomBoolean(),
                CallbackUrl = new object(),

            };

        }



        #endregion

        #region FetchVirtualCardsResponseProperties

        private static dynamic CreateRandomFetchVirtualCardsResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomFetchVirtualCardsResponseData(),


            };
        }


        private static List<dynamic> GetRandomFetchVirtualCardsResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {
                Id = GetRandomString(),
                AccountId = GetRandomNumber(),
                Amount = GetRandomString(),
                Currency = GetRandomString(),
                CardHash = GetRandomString(),
                CardPan = GetRandomString(),
                MaskedPan = GetRandomString(),
                City = GetRandomString(),
                State = GetRandomString(),
                Address1 = GetRandomString(),
                Address2 = new object(),
                ZipCode = GetRandomString(),
                Cvv = GetRandomString(),
                Expiration = GetRandomString(),
                SendTo = new object(),
                BinCheckName = new object(),
                CardType = GetRandomString(),
                NameOnCard = GetRandomString(),
                CreatedAt = GetRandomDate(),
                IsActive = GetRandomBoolean(),
                CallbackUrl = GetRandomString(),



            }).ToList<dynamic>();

        }


        #endregion

        #region FundVirtualCardResponseProperties

        private static dynamic CreateRandomFundVirtualCardResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = new object(),

            };
        }






        #endregion

        #region TerminateVirtualCardResponseProperties

        private static dynamic CreateRandomTerminateVirtualCardResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = new object(),

            };
        }






        #endregion

        #region VirtualCardTransactionsResponseProperties

        private static dynamic CreateRandomVirtualCardTransactionsResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = new object(),

            };
        }






        #endregion

        #region VirtualCardWithdrawalResponseProperties

        private static dynamic CreateRandomVirtualCardWithdrawalResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = new object(),

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

        private static Filler<VirtualCardWithdrawal> CreateVirtualCardWithdrawalFiller()
        {
            var filler = new Filler<VirtualCardWithdrawal>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<FundVirtualCard> CreateFundVirtualCardFiller()
        {
            var filler = new Filler<FundVirtualCard>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<CreateVirtualCard> CreateCreateVirtualCardFiller()
        {
            var filler = new Filler<CreateVirtualCard>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

    }
}
