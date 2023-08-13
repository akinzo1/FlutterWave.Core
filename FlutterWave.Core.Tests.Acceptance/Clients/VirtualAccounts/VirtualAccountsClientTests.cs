



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace FlutterWave.Core.Tests.Acceptance.Clients.VirtualAccountsClient
{
    public partial class VirtualAccountsClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IFlutterWaveClient flutterWaveClient;

        public VirtualAccountsClientTests()
        {
            this.apiKey = GetRandomString();
            this.wireMockServer = WireMockServer.Start();

            var apiConfigurations = new ApiConfigurations
            {
                ApiUrl = this.wireMockServer.Url,
                ApiKey = this.apiKey,

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }

        private static DateTimeOffset GetRandomDate() =>
             new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private ExternalDeleteVirtualAccountRequest ConvertToDeleteVirtualAccountRequest(DeleteVirtualAccounts virtualAccounts)
        {
            return new ExternalDeleteVirtualAccountRequest
            {

                Status = virtualAccounts.Request.Status

            };
        }

        private ExternalUpdateVirtualAccountBvnRequest ConvertToUpdateVirtualAccountBvnRequest(UpdateBvnVirtualAccounts virtualAccounts)
        {
            return new ExternalUpdateVirtualAccountBvnRequest
            {

                Bvn = virtualAccounts.Request.Bvn

            };
        }

        private ExternalCreateBulkVirtualAccountsRequest ConvertToCreateBulkVirtualAccountRequest(BulkCreateVirtualAccounts virtualAccounts)
        {
            return new ExternalCreateBulkVirtualAccountsRequest
            {

                Accounts = virtualAccounts.Request.Accounts,
                Email = virtualAccounts.Request.Email,
                IsPermanent = virtualAccounts.Request.IsPermanent,
                TxRef = virtualAccounts.Request.TxRef,

            };
        }

        private ExternalCreateVirtualAccountRequest ConvertToCreateVirtualAccountRequest(CreateVirtualAccounts virtualAccounts)
        {
            return new ExternalCreateVirtualAccountRequest
            {

                Bvn = virtualAccounts.Request.Bvn,
                Email = virtualAccounts.Request.Email,
                IsPermanent = virtualAccounts.Request.IsPermanent,
                TxRef = virtualAccounts.Request.TxRef,
                FirstName = virtualAccounts.Request.FirstName,
                LastName = virtualAccounts.Request.LastName,
                Narration = virtualAccounts.Request.Narration,
                PhoneNumber = virtualAccounts.Request.PhoneNumber

            };
        }

        private BulkVirtualAccountDetails ConvertToVirtualAccountsResponse(ExternalBulkVirtualAccountDetailsResponse externalBulkCreateVirtualAccountsResponse)
        {
            return new BulkVirtualAccountDetails
            {

                Response = new BulkVirtualAccountDetailsResponse
                {
                    Status = externalBulkCreateVirtualAccountsResponse.Status,
                    Message = externalBulkCreateVirtualAccountsResponse.Message,
                    Data = externalBulkCreateVirtualAccountsResponse.Data.Select(bulk =>
                    {
                        return new BulkVirtualAccountDetailsResponse.Datum
                        {
                            AccountNumber = bulk.AccountNumber,
                            Amount = bulk.Amount,
                            BankName = bulk.BankName,
                            CreatedAt = bulk.CreatedAt,
                            ExpiryDate = bulk.ExpiryDate,
                            FlwRef = bulk.FlwRef,
                            Frequency = bulk.Frequency,
                            Note = bulk.Note,
                            OrderRef = bulk.OrderRef,
                            ResponseCode = bulk.ResponseCode,
                            ResponseMessage = bulk.ResponseMessage,
                        };
                    }).ToList()
                }



            };
        }

        private BulkCreateVirtualAccounts ConvertToVirtualAccountsResponse(BulkCreateVirtualAccounts bulkCreateVirtualAccounts, ExternalBulkCreateVirtualAccountsResponse externalBulkCreateVirtualAccountsResponse)
        {
            bulkCreateVirtualAccounts.Response = new BulkCreateVirtualAccountResponse
            {
                Status = externalBulkCreateVirtualAccountsResponse.Status,
                Message = externalBulkCreateVirtualAccountsResponse.Message,
                Data = new BulkCreateVirtualAccountResponse.BulkCreateVirtualAccountsData
                {
                    BatchId = externalBulkCreateVirtualAccountsResponse.Data.BatchId,
                    ResponseCode = externalBulkCreateVirtualAccountsResponse.Data.ResponseCode,
                    ResponseMessage = externalBulkCreateVirtualAccountsResponse.Data.ResponseMessage
                },
            };
            return bulkCreateVirtualAccounts;
        }

        private CreateVirtualAccounts ConvertToVirtualAccountsResponse(CreateVirtualAccounts createVirtualAccounts, ExternalCreateVirtualAccountResponse externalCreateVirtualAccountResponse)
        {
            createVirtualAccounts.Response = new CreateVirtualAccountResponse
            {
                Data = new CreateVirtualAccountResponse.CreateVirtualAccountDataModel
                {
                    AccountNumber = externalCreateVirtualAccountResponse.Data.AccountNumber,
                    BankName = externalCreateVirtualAccountResponse.Data.BankName,
                    ResponseCode = externalCreateVirtualAccountResponse.Data.ResponseCode,
                    ResponseMessage = externalCreateVirtualAccountResponse.Data.ResponseMessage,
                    Amount = externalCreateVirtualAccountResponse.Data.Amount,
                    OrderRef = externalCreateVirtualAccountResponse.Data.OrderRef
                },
                Message = externalCreateVirtualAccountResponse.Message,
                Status = externalCreateVirtualAccountResponse.Status
            };
            return createVirtualAccounts;
        }

        private DeleteVirtualAccounts ConvertToVirtualAccountsResponse(DeleteVirtualAccounts deleteVirtualAccounts, ExternalDeleteVirtualAccountResponse externalDeleteVirtualAccountResponse)
        {
            deleteVirtualAccounts.Response = new DeleteVirtualAccountResponse
            {
                Status = externalDeleteVirtualAccountResponse.Status,
                Message = externalDeleteVirtualAccountResponse.Message,
                Data = new DeleteVirtualAccountResponse.DeleteVirtualAccountData
                {
                    Status = externalDeleteVirtualAccountResponse.Data.Status,
                    StatusDesc = externalDeleteVirtualAccountResponse.Data.StatusDesc
                }
            };

            return deleteVirtualAccounts;

        }

        private UpdateBvnVirtualAccounts ConvertToVirtualAccountsResponse(UpdateBvnVirtualAccounts updateBvnVirtualAccounts, ExternalUpdateVirtualAccountBvnResponse updateVirtualAccountBvnResponse)
        {
            updateBvnVirtualAccounts.Response = new UpdateVirtualAccountBvnResponse
            {
                Data = updateVirtualAccountBvnResponse.Data,
                Status = updateVirtualAccountBvnResponse.Status,
                Message = updateVirtualAccountBvnResponse.Message,
            };
            return updateBvnVirtualAccounts;

        }

        private FetchVirtualAccounts ConvertToVirtualAccountsResponse(ExternalVirtualAccountNumberResponse externalVirtualAccountNumberResponse)
        {
            return new FetchVirtualAccounts
            {

                Response = new FetchVirtualAccountNumberResponse
                {
                    Message = externalVirtualAccountNumberResponse.Message,
                    Status = externalVirtualAccountNumberResponse.Status,
                    Data = new FetchVirtualAccountNumberResponse.VirtualAccountNumberData
                    {
                        AccountNumber = externalVirtualAccountNumberResponse.Data.AccountNumber,
                        Amount = externalVirtualAccountNumberResponse.Data.Amount,
                        BankName = externalVirtualAccountNumberResponse.Data.BankName,
                        CreatedAt = externalVirtualAccountNumberResponse.Data.CreatedAt,
                        ExpiryDate = externalVirtualAccountNumberResponse.Data.ExpiryDate,
                        FlwRef = externalVirtualAccountNumberResponse.Data.FlwRef,
                        Frequency = externalVirtualAccountNumberResponse.Data.Frequency,
                        Note = externalVirtualAccountNumberResponse.Data.Note,
                        OrderRef = externalVirtualAccountNumberResponse.Data.OrderRef,
                        ResponseCode = externalVirtualAccountNumberResponse.Data.ResponseCode,
                        ResponseMessage = externalVirtualAccountNumberResponse.Data.ResponseMessage
                    }
                }



            };
        }


        private static ExternalUpdateVirtualAccountBvnResponse CreateExternalUpdateVirtualAccountBvnResponseResult() =>
                CreateExternalUpdateVirtualAccountBvnResponseFiller().Create();
        private static ExternalBulkCreateVirtualAccountsResponse CreateExternalBulkCreateVirtualAccountsResponseResult() =>
           CreateExternalBulkCreateVirtualAccountsResponseFiller().Create();
        private static ExternalBulkVirtualAccountDetailsResponse CreateExternalBulkVirtualAccountDetailsResponseResult() =>
           CreateExternalBulkVirtualAccountDetailsResponseFiller().Create();
        private static ExternalCreateVirtualAccountResponse CreateExternalCreateVirtualAccountResponseResult() =>
          CreateExternalCreateVirtualAccountResponseFiller().Create();
        private static ExternalVirtualAccountNumberResponse CreateExternalVirtualAccountNumberResponseResult() =>
           CreateExternalVirtualAccountNumberResponseFiller().Create();
        private static ExternalDeleteVirtualAccountResponse CreateExternalDeleteVirtualAccountResponseResult() =>
           CreateExternalDeleteVirtualAccountResponseFiller().Create();


        private static CreateVirtualAccounts CreateRandomCreateVirtualAccounts() =>
          CreateCreateVirtualAccountsFiller().Create();
        private static BulkCreateVirtualAccounts CreateRandomBulkCreateVirtualAccounts() =>
          CreateBulkCreateVirtualAccountsFiller().Create();

        private static DeleteVirtualAccounts CreateRandomDeleteVirtualAccounts() =>
         CreateDeleteVirtualAccountsFiller().Create();

        private static UpdateBvnVirtualAccounts CreateRandomUpdateBvnVirtualAccounts() =>
         CreateUpdateBvnVirtualAccountsFiller().Create();

        private static Filler<ExternalBulkCreateVirtualAccountsResponse> CreateExternalBulkCreateVirtualAccountsResponseFiller()
        {
            var filler = new Filler<ExternalBulkCreateVirtualAccountsResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalUpdateVirtualAccountBvnResponse> CreateExternalUpdateVirtualAccountBvnResponseFiller()
        {
            var filler = new Filler<ExternalUpdateVirtualAccountBvnResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalBulkVirtualAccountDetailsResponse> CreateExternalBulkVirtualAccountDetailsResponseFiller()
        {
            var filler = new Filler<ExternalBulkVirtualAccountDetailsResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalCreateVirtualAccountResponse> CreateExternalCreateVirtualAccountResponseFiller()
        {
            var filler = new Filler<ExternalCreateVirtualAccountResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }

        private static Filler<ExternalVirtualAccountNumberResponse> CreateExternalVirtualAccountNumberResponseFiller()
        {
            var filler = new Filler<ExternalVirtualAccountNumberResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }

        private static Filler<ExternalDeleteVirtualAccountResponse> CreateExternalDeleteVirtualAccountResponseFiller()
        {
            var filler = new Filler<ExternalDeleteVirtualAccountResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }

        private static Filler<BulkCreateVirtualAccounts> CreateBulkCreateVirtualAccountsFiller()
        {
            var filler = new Filler<BulkCreateVirtualAccounts>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<CreateVirtualAccounts> CreateCreateVirtualAccountsFiller()
        {
            var filler = new Filler<CreateVirtualAccounts>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<DeleteVirtualAccounts> CreateDeleteVirtualAccountsFiller()
        {
            var filler = new Filler<DeleteVirtualAccounts>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<UpdateBvnVirtualAccounts> CreateUpdateBvnVirtualAccountsFiller()
        {
            var filler = new Filler<UpdateBvnVirtualAccounts>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        public void Dispose() => this.wireMockServer.Stop();
    }
}
