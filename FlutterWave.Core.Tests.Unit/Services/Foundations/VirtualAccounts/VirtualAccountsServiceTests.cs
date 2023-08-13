using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using FlutterWave.Core.Services.Foundations.FlutterWave.VirtualAccountsService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualAccounts
{
    public partial class VirtualAccountsServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IVirtualAccountsService virtualAccountsService;

        public VirtualAccountsServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            virtualAccountsService = new VirtualAccountsService(
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

        private Expression<Func<ExternalCreateVirtualAccountRequest, bool>> SameExternalCreateVirtualAccountRRequestAs(
            ExternalCreateVirtualAccountRequest externalCreateVirtualAccountRRequest)
        {
            return actualExternalCreateVirtualAccountRRequest =>
                compareLogic.Compare(
                    externalCreateVirtualAccountRRequest,
                    actualExternalCreateVirtualAccountRRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalCreateBulkVirtualAccountsRequest, bool>> SameExternalCreateBulkVirtualAccountsRequestAs(
          ExternalCreateBulkVirtualAccountsRequest externalCreateBulkVirtualAccountsRequest)
        {
            return actualExternalCreateBulkVirtualAccountsRequest =>
                compareLogic.Compare(
                    externalCreateBulkVirtualAccountsRequest,
                    actualExternalCreateBulkVirtualAccountsRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalDeleteVirtualAccountRequest, bool>> SameExternalDeleteVirtualAccountRequestAs(
          ExternalDeleteVirtualAccountRequest externalDeleteVirtualAccountRequest)
        {
            return actualExternalDeleteVirtualAccountRequest =>
                compareLogic.Compare(
                    externalDeleteVirtualAccountRequest,
                    actualExternalDeleteVirtualAccountRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalUpdateVirtualAccountBvnRequest, bool>> SameExternalUpdateVirtualAccountBvnRequestAs(
          ExternalUpdateVirtualAccountBvnRequest externalUpdateVirtualAccountBvnRequest)
        {
            return actualExternalUpdateVirtualAccountBvnRequest =>
                compareLogic.Compare(
                    externalUpdateVirtualAccountBvnRequest,
                    actualExternalUpdateVirtualAccountBvnRequest)
                        .AreEqual;
        }

        private static dynamic CreateRandomTransfersFeesRequestProperties()
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


        private static DeleteVirtualAccounts CreateRandomDeleteVirtualAccount() =>
             CreateDeleteVirtualAccountFiller().Create();

        private static UpdateBvnVirtualAccounts CreateRandomUpdateBvnVirtualAccount() =>
          CreateUpdateBvnVirtualAccountFiller().Create();

        private static CreateVirtualAccounts CreateRandomPostVirtualAccount() =>
             CreatePostVirtualAccountFiller().Create();

        private static BulkCreateVirtualAccounts CreateRandomBulkVirtualAccount() =>
           CreateBulkVirtualAccountFiller().Create();

        #region  BulkVirtualAccountDetailsProperties


        private static dynamic CreateRandomBulkVirtualAccountDetailsProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetBulkVirtualAccountDetailsDataList(),



            };
        }



        private static List<dynamic> GetBulkVirtualAccountDetailsDataList()
        {
            return Enumerable.Range(0, GetRandomNumber()).Select(
             item => new
             {
                 ResponseCode = GetRandomString(),
                 ResponseMessage = GetRandomString(),
                 FlwRef = GetRandomString(),
                 OrderRef = GetRandomString(),
                 AccountNumber = GetRandomString(),
                 Frequency = GetRandomString(),
                 BankName = GetRandomString(),
                 CreatedAt = GetRandomString(),
                 ExpiryDate = GetRandomString(),
                 Note = GetRandomString(),
                 Amount = new object(),




             }).ToList<dynamic>();
        }

        #endregion

        #region CreateVirtualAccountProperty 

        private static dynamic CreateRandomVirtualAccountProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetCreateVirtualAccountData(),



            };
        }



        private static dynamic GetCreateVirtualAccountData()
        {
            return new
            {
                ResponseCode = GetRandomString(),
                ResponseMessage = GetRandomString(),
                OrderRef = GetRandomString(),
                AccountNumber = GetRandomString(),
                BankName = GetRandomString(),
                Amount = new object(),



            };
        }

        #endregion

        #region BulkCreateVirtualAccountsProperties

        private static dynamic CreateRandomBulkVirtualAccountsProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetBulkCreateVirtualAccountsDataList(),



            };
        }



        private static dynamic GetBulkCreateVirtualAccountsDataList()
        {
            return new
            {
                BatchId = GetRandomString(),
                ResponseCode = GetRandomString(),
                ResponseMessage = GetRandomString(),



            };
        }

        #endregion

        #region  VirtualAccountNumberProperties 

        private static dynamic CreateRandomVirtualAccountNumberProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomVirtualAccountNumberData(),



            };
        }

        private static dynamic GetRandomVirtualAccountNumberData()
        {
            return new
            {
                ResponseCode = GetRandomString(),
                ResponseMessage = GetRandomString(),
                FlwRef = GetRandomString(),
                OrderRef = GetRandomString(),
                AccountNumber = GetRandomString(),
                Frequency = GetRandomString(),
                BankName = GetRandomString(),
                CreatedAt = GetRandomString(),
                ExpiryDate = GetRandomString(),
                Note = GetRandomString(),
                Amount = GetRandomNumber(),


            };
        }



        #endregion

        #region  DeleteVirtualAccountNumberProperties 

        private static dynamic CreateRandomDeleteVirtualAccountProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetDeleteVirtualAccountNumberData(),



            };
        }

        private static dynamic GetDeleteVirtualAccountNumberData()
        {
            return new
            {
                Status = GetRandomString(),
                StatusDesc = GetRandomString(),


            };
        }


        #endregion

        #region  UpdateVirtualAccountNumberProperties 

        private static dynamic CreateRandomUpdateVirtualAccountNumberProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = new object(),



            };
        }




        #endregion


        private static Filler<DeleteVirtualAccounts> CreateDeleteVirtualAccountFiller()
        {
            var filler = new Filler<DeleteVirtualAccounts>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<UpdateBvnVirtualAccounts> CreateUpdateBvnVirtualAccountFiller()
        {
            var filler = new Filler<UpdateBvnVirtualAccounts>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<BulkCreateVirtualAccounts> CreateBulkVirtualAccountFiller()
        {
            var filler = new Filler<BulkCreateVirtualAccounts>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<CreateVirtualAccounts> CreatePostVirtualAccountFiller()
        {
            var filler = new Filler<CreateVirtualAccounts>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

    }
}
