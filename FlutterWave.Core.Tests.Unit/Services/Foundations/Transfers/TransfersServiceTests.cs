



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using FlutterWave.Core.Services.Foundations.FlutterWave.TransfersService;
using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        private readonly Mock<IFlutterWaveBroker> flutterWaveBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly ITransfersService transfersService;

        public TransfersServiceTests()
        {
            flutterWaveBrokerMock = new Mock<IFlutterWaveBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            transfersService = new TransfersService(
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

        private Expression<Func<ExternalInitiateTransferRequest, bool>> SameExternalInitiateTransferRequestAs(
            ExternalInitiateTransferRequest externalInitiateTransfersRequest)
        {
            return actualExternalInitiateTransfersRequest =>
                compareLogic.Compare(
                    externalInitiateTransfersRequest,
                    actualExternalInitiateTransfersRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalCreateBulkTransferRequest, bool>> SameExternalCreateBulkTransferRequestAs(
          ExternalCreateBulkTransferRequest externalCreateBulkTransfersRequest)
        {
            return actualExternalCreateBulkTransfersRequest =>
                compareLogic.Compare(
                    externalCreateBulkTransfersRequest,
                    actualExternalCreateBulkTransfersRequest)
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


        private static ExternalCreateBulkTransferRequest CreateRandomBulkTransferRequest() =>
            CreateBulkTransferRequestFiller().Create();

        private static InitiateTransfers CreateRandomInitiateTransferRequest() =>
            CreateInitiateTransferRequestFiller().Create();

        private static BulkCreateTransfers CreateRandomBulkCreateTransferRequest() =>
           CreateBulkCreateTransferRequestFiller().Create();

        #region AllTransfers 

        private static dynamic CreateRandomAllTransferProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetAllTransferDataList(),
                Meta = GetRandomAllTransfersPageInfoData()


            };
        }

        private static dynamic GetRandomAllTransfersPageInfoData()
        {
            return new
            {
                Total = GetRandomNumber(),
                CurrentPage = GetRandomNumber(),
                TotalPages = GetRandomNumber(),
                PageSize = GetRandomNumber(),


            };
        }

        private static List<dynamic> GetAllTransferDataList()
        {
            return Enumerable.Range(0, GetRandomNumber()).Select(
             item => new
             {
                 Id = GetRandomNumber(),
                 AccountNumber = GetRandomString(),
                 BankCode = GetRandomString(),
                 FullName = GetRandomString(),
                 CreatedAt = GetRandomDate(),
                 Currency = GetRandomString(),
                 DebitCurrency = GetRandomString(),
                 Amount = GetRandomNumber(),
                 Fee = GetRandomNumber(),
                 Status = GetRandomString(),
                 Reference = GetRandomString(),
                 Meta = new object(),
                 Narration = GetRandomString(),
                 Approver = new object(),
                 CompleteMessage = GetRandomString(),
                 RequiresApproval = GetRandomNumber(),
                 IsApproved = GetRandomNumber(),
                 BankName = GetRandomString(),


             }).ToList<dynamic>();
        }

        #endregion

        #region TransferRatesProperties
        private static dynamic CreateRandomTransferRatesProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetTransferRatesData(),


            };
        }

        private static dynamic GetTransferRatesData()
        {
            return new
            {

                Rate = GetRandomNumber(),
                Source = GetTransferRatesSourceData(),
                Destination = GetTransferRatesDestinationData(),



            };
        }


        private static dynamic GetTransferRatesSourceData()
        {
            return new
            {

                Currency = GetRandomString(),
                Amount = GetRandomNumber(),


            };
        }

        private static dynamic GetTransferRatesDestinationData()
        {
            return new
            {


                Currency = GetRandomString(),
                Amount = GetRandomNumber(),



            };
        }

        #endregion

        #region TransferFeesProperties
        private static dynamic CreateRandomTransferFeesProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetTransferFeesDataList(),


            };
        }

        private static List<dynamic> GetTransferFeesDataList()
        {
            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                FeeType = GetRandomString(),
                Currency = GetRandomString(),
                Fee = GetRandomNumber(),



            }).ToList<dynamic>();
        }

        #endregion

        #region RetryTransferProperties

        private static dynamic CreateRandomRetryTransferProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRetryTransferData(),


            };
        }

        private static dynamic GetRetryTransferData()
        {
            return new
            {

                Id = GetRandomNumber(),
                AccountNumber = GetRandomString(),
                BankCode = GetRandomString(),
                FullName = GetRandomString(),
                CreatedAt = GetRandomDate(),
                Currency = GetRandomString(),
                DebitCurrency = GetRandomString(),
                Amount = GetRandomNumber(),
                Fee = GetRandomNumber(),
                Status = GetRandomString(),
                Reference = GetRandomString(),
                Meta = new object(),
                CompleteMessage = GetRandomString(),
                RequiresApproval = GetRandomNumber(),
                IsApproved = GetRandomNumber(),
                BankName = GetRandomString(),




            };
        }

        #endregion

        #region FetchTransfersProperties

        private static dynamic CreateRandomFetchTransferProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetFetchTransferDataList(),


            };
        }

        private static dynamic GetFetchTransferDataList()
        {
            return new
            {

                Id = GetRandomNumber(),
                AccountNumber = GetRandomString(),
                BankCode = GetRandomString(),
                FullName = GetRandomString(),
                CreatedAt = GetRandomDate(),
                Currency = GetRandomString(),
                DebitCurrency = GetRandomString(),
                Amount = GetRandomNumber(),
                Fee = GetRandomNumber(),
                Status = GetRandomString(),
                Reference = GetRandomString(),
                Meta = new object(),
                Narration = GetRandomString(),
                Approver = new object(),
                CompleteMessage = GetRandomString(),
                RequiresApproval = GetRandomNumber(),
                IsApproved = GetRandomNumber(),
                BankName = GetRandomString(),



            };
        }
        #endregion

        #region TransfersRetryProperties

        private static dynamic CreateRandomTransferRetryProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetTransferRetryDataList(),


            };
        }

        private static List<dynamic> GetTransferRetryDataList()
        {
            return Enumerable.Range(0, GetRandomNumber()).Select(
             item => new
             {

                 Id = GetRandomNumber(),
                 AccountNumber = GetRandomString(),
                 BankCode = GetRandomString(),
                 BankName = GetRandomString(),
                 FullName = GetRandomString(),
                 Currency = GetRandomString(),
                 DebitCurrency = GetRandomString(),
                 Amount = GetRandomNumber(),
                 Fee = GetRandomNumber(),
                 Status = GetRandomString(),
                 Reference = GetRandomString(),
                 Narration = new object(),
                 CompleteMessage = GetRandomString(),
                 Meta = new object(),
                 RequiresApproval = GetRandomNumber(),
                 IsApproved = GetRandomNumber(),
                 CreatedAt = GetRandomDate(),


             }).ToList<dynamic>();
        }
        #endregion

        #region InitiateTransfersProperties
        private static dynamic CreateRandomInitiateTransferProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomInitiateTransfersData(),


            };
        }

        private static dynamic GetRandomInitiateTransfersData()
        {
            return new
            {
                Id = GetRandomNumber(),
                AccountNumber = GetRandomString(),
                BankCode = GetRandomString(),
                FullName = GetRandomString(),
                CreatedAt = GetRandomDate(),
                Currency = GetRandomString(),
                DebitCurrency = GetRandomString(),
                Amount = GetRandomNumber(),
                Fee = GetRandomNumber(),
                Status = GetRandomString(),
                Reference = GetRandomString(),
                Meta = new object(),
                Narration = GetRandomString(),
                CompleteMessage = GetRandomString(),
                RequiresApproval = GetRandomNumber(),
                IsApproved = GetRandomNumber(),
                BankName = GetRandomString(),
            };
        }

        private static List<dynamic> GetInitiateTransferDataList()
        {
            return Enumerable.Range(0, GetRandomNumber()).Select(
             item => new
             {

                 Id = GetRandomNumber(),
                 CreatedAt = GetRandomDate(),
                 Approver = GetRandomString(),


             }).ToList<dynamic>();
        }
        #endregion

        #region BulkTransfersProperties
        private static dynamic CreateRandomBulkTransferProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetCreateBulkTransferDataList(),


            };
        }


        private static dynamic GetCreateBulkTransferDataList()
        {
            return new
            {

                Id = GetRandomNumber(),
                CreatedAt = GetRandomDate(),
                Approver = GetRandomString(),


            };
        }
        #endregion

        #region FetchBulkTransfersProperties
        private static dynamic CreateRandomFetchBulkTransferProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Meta = GetFetchBulkTransferMeta(),
                Data = GetFetchBulkTransferDataList(),


            };
        }

        private static dynamic GetFetchBulkTransferMeta()
        {
            return new
            {
                PageInfo = GetFetchBulkTransferPageInfo(),

            };
        }

        private static dynamic GetFetchBulkTransferPageInfo()
        {
            return new
            {
                Total = GetRandomNumber(),
                CurrentPage = GetRandomNumber(),
                TotalPages = GetRandomNumber(),


            };
        }


        private static List<dynamic> GetFetchBulkTransferDataList()
        {
            return Enumerable.Range(0, GetRandomNumber()).Select(
             item => new
             {
                 Id = GetRandomNumber(),
                 AccountNumber = GetRandomString(),
                 BankCode = GetRandomString(),
                 FullName = GetRandomString(),
                 CreatedAt = GetRandomDate(),
                 Currency = GetRandomString(),
                 DebitCurrency = GetRandomString(),
                 Amount = GetRandomNumber(),
                 Fee = GetRandomNumber(),
                 Status = GetRandomString(),
                 Reference = GetRandomString(),
                 Meta = new object(),
                 Narration = GetRandomString(),
                 Approver = new object(),
                 CompleteMessage = GetRandomString(),
                 RequiresApproval = GetRandomNumber(),
                 IsApproved = GetRandomNumber(),
                 BankName = GetRandomString(),


             }).ToList<dynamic>();
        }
        #endregion

        private static Filler<ExternalCreateBulkTransferRequest> CreateBulkTransferRequestFiller()
        {
            var filler = new Filler<ExternalCreateBulkTransferRequest>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<InitiateTransfers> CreateInitiateTransferRequestFiller()
        {
            var filler = new Filler<InitiateTransfers>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<BulkCreateTransfers> CreateBulkCreateTransferRequestFiller()
        {
            var filler = new Filler<BulkCreateTransfers>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

    }
}
