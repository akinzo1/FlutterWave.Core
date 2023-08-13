using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using System.Linq;
using System.Threading.Tasks;


namespace FlutterWave.Core.Services.Foundations.FlutterWave.VirtualAccountsService
{
    internal partial class VirtualAccountsService : IVirtualAccountsService
    {
        private readonly IFlutterWaveBroker flutterWaveBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public VirtualAccountsService(
            IFlutterWaveBroker flutterWaveBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.flutterWaveBroker = flutterWaveBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<DeleteVirtualAccounts> DeleteVirtualAccountsRequestAsync(DeleteVirtualAccounts virtualAccounts, string orderReference) =>
        TryCatch(async () =>
        {
            ValidateDeleteVirtualAccountId(orderReference);
            ValidateDeleteVirtualAccount(virtualAccounts);
            ExternalDeleteVirtualAccountRequest externalDeleteVirtualAccountRequest = ConvertToDeleteVirtualAccountRequest(virtualAccounts);
            ExternalDeleteVirtualAccountResponse externalDeleteVirtualAccountResponse = await flutterWaveBroker.DeleteVirtualAccountsRequestAsync(
                externalDeleteVirtualAccountRequest, orderReference);
            return ConvertToVirtualAccountsResponse(virtualAccounts, externalDeleteVirtualAccountResponse);
        });
        public ValueTask<BulkVirtualAccountDetails> GetVirtualAccountDetailsRequestAsync(string batchId) =>
        TryCatch(async () =>
        {
            ValidateBulkVirtualAccountDetails(batchId);
            ExternalBulkVirtualAccountDetailsResponse externalBulkCreateVirtualAccountsResponse = await flutterWaveBroker.GetBulkVirtualAccountDetailsRequestAsync(batchId);
            return ConvertToVirtualAccountsResponse(externalBulkCreateVirtualAccountsResponse);
        });
        public ValueTask<FetchVirtualAccounts> GetVirtualAccountNumberRequestAsync(string orderReference) =>
        TryCatch(async () =>
        {
            ValidateFetchVirtualAccountId(orderReference);
            ExternalVirtualAccountNumberResponse externalVirtualAccountNumberResponse = await flutterWaveBroker.GetVirtualAccountNumberRequestAsync(orderReference);
            return ConvertToVirtualAccountsResponse(externalVirtualAccountNumberResponse);
        });
        public ValueTask<BulkCreateVirtualAccounts> PostBulkCreateVirtualAccountsRequestAsync(BulkCreateVirtualAccounts virtualAccounts) =>
        TryCatch(async () =>
        {
            ValidateBulkCreateVirtualAccount(virtualAccounts);
            ExternalCreateBulkVirtualAccountsRequest externalCreateBulkVirtualAccountsRequest =
            ConvertToCreateBulkVirtualAccountRequest(virtualAccounts);
            ExternalBulkCreateVirtualAccountsResponse externalBulkCreateVirtualAccountsResponse =
            await flutterWaveBroker.PostBulkCreateVirtualAccountsRequestAsync(
                externalCreateBulkVirtualAccountsRequest);
            return ConvertToVirtualAccountsResponse(virtualAccounts, externalBulkCreateVirtualAccountsResponse);
        });
        public ValueTask<CreateVirtualAccounts> PostCreateVirtualAccountRequestAsync(CreateVirtualAccounts virtualAccounts) =>
        TryCatch(async () =>
        {
            ValidateCreateVirtualAccount(virtualAccounts);
            ExternalCreateVirtualAccountRequest externalCreateVirtualAccountRequest = ConvertToCreateVirtualAccountRequest(virtualAccounts);
            ExternalCreateVirtualAccountResponse externalCreateVirtualAccountResponse = await flutterWaveBroker.PostCreateVirtualAccountRequestAsync(
                externalCreateVirtualAccountRequest);
            return ConvertToVirtualAccountsResponse(virtualAccounts, externalCreateVirtualAccountResponse);
        });
        public ValueTask<UpdateBvnVirtualAccounts> UpdateVirtualAccountsBvnRequestAsync(
            UpdateBvnVirtualAccounts virtualAccounts, string orderReference) =>
        TryCatch(async () =>
        {
            ValidateUpdateVirtualAccountId(orderReference);
            ValidateUpdateVirtualAccount(virtualAccounts);
            ExternalUpdateVirtualAccountBvnRequest externalUpdateVirtualAccountBvnRequest = ConvertToUpdateVirtualAccountBvnRequest(virtualAccounts);
            ExternalUpdateVirtualAccountBvnResponse externalUpdateVirtualAccountBvnResponse =
            await flutterWaveBroker.UpdateVirtualAccountsBvnRequestAsync(
                externalUpdateVirtualAccountBvnRequest, orderReference);
            return ConvertToVirtualAccountsResponse(virtualAccounts, externalUpdateVirtualAccountBvnResponse);
            ;
        });

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



    }
}
