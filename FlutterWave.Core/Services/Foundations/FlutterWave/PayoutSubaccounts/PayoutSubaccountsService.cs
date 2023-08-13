using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using System.Linq;
using System.Threading.Tasks;


namespace FlutterWave.Core.Services.Foundations.FlutterWave.PayoutSubaccountsService
{
    internal partial class PayoutSubaccountsService : IPayoutSubaccountsService
    {
        private readonly IFlutterWaveBroker flutterWaveBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public PayoutSubaccountsService(
            IFlutterWaveBroker flutterWaveBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.flutterWaveBroker = flutterWaveBroker;
            this.dateTimeBroker = dateTimeBroker;
        }


        public ValueTask<CreatePayoutSubaccount> PostCreatePayoutSubaccountRequestAsync(CreatePayoutSubaccount createPayoutSubaccount) =>
        TryCatch(async () =>
        {
            ValidateCreatePayoutSubaccount(createPayoutSubaccount);
            ExternalCreatePayoutSubaccountRequest externalCreatePayoutSubaccountRequest = ConvertToPayoutSubaccountRequest(createPayoutSubaccount);
            ExternalCreatePayoutSubaccountResponse externalCreatePayoutSubaccountResponse = await flutterWaveBroker.PostCreatePayoutSubaccountAsync(
               externalCreatePayoutSubaccountRequest);
            return ConvertToPayoutSubaccountResponse(createPayoutSubaccount, externalCreatePayoutSubaccountResponse);
        });

        public ValueTask<ListPayoutSubaccounts> GetListPayoutSubaccountsRequestAsync() =>
        TryCatch(async () =>
        {

            ExternalListPayoutSubaccountsResponse externalListPayoutSubaccountsResponse =
            await flutterWaveBroker.GetListPayoutSubaccountsAsync();
            return ConvertToPayoutSubAccountResponse(externalListPayoutSubaccountsResponse);
        });

        public ValueTask<FetchPayoutSubaccount> GetPayoutSubaccountRequestAsync(string accountReference) =>
        TryCatch(async () =>
        {
            ValidateFetchPayoutSubaccountString(accountReference);
            ExternalFetchPayoutSubaccountResponse externalFetchPayoutSubaccountResponse = await flutterWaveBroker.GetPayoutSubaccountAsync(
               accountReference);
            return ConvertToPayoutSubAccountResponse(externalFetchPayoutSubaccountResponse);
        });

        public ValueTask<UpdatePayoutSubaccount> PostUpdatePayoutSubaccountRequestAsync(string accountReference, UpdatePayoutSubaccount updatePayoutSubaccount) =>
        TryCatch(async () =>
        {
            ValidateUpdatePayoutSubaccount(accountReference, updatePayoutSubaccount);
            //ValidateUpdatePayoutSubaccountString(accountReference);
            ExternalUpdatePayoutSubaccountRequest externalUpdatePayoutSubaccountRequest = ConvertToPayoutSubaccountRequest(updatePayoutSubaccount);
            ExternalUpdatePayoutSubaccountResponse externalUpdatePayoutSubaccountResponse = await flutterWaveBroker.PostUpdatePayoutSubaccountAsync(
              accountReference, externalUpdatePayoutSubaccountRequest);
            return ConvertToPayoutSubaccountResponse(updatePayoutSubaccount, externalUpdatePayoutSubaccountResponse);
        });

        public ValueTask<FetchPayoutSubaccountTransactions> GetPayoutSubaccountTransactionsRequestAsync(string accountReference, string from, string to, string currency) =>
        TryCatch(async () =>
        {
            ValidatePayoutSubaccountTransactionsString(accountReference);
            ValidatePayoutSubaccountTransactionsString(currency);
            ValidatePayoutSubaccountTransactionsString(from);
            ValidatePayoutSubaccountTransactionsString(to);
            ExternalFetchPayoutSubaccountTransactionsResponse externalFetchPayoutSubaccountTransactionsResponse =
            await flutterWaveBroker.GetPayoutSubaccountTransactionsAsync(
               accountReference, from, to, currency);
            return ConvertToPayoutSubAccountResponse(externalFetchPayoutSubaccountTransactionsResponse);
        });
        public ValueTask<FetchSubaccountAvailableBalance> GetPayoutSubaccountsAvailableBalanceRequestAsync(string accountReference, string currency) =>
        TryCatch(async () =>
        {
            ValidateFetchSubaccountAvailableBalanceString(accountReference);
            ValidateFetchSubaccountAvailableBalanceString(accountReference);
            ExternalFetchSubaccountAvailableBalanceResponse externalFetchSubaccountAvailableBalanceResponse =
            await flutterWaveBroker.GetPayoutSubaccountsAvailableBalanceAsync(
               accountReference, currency);
            return ConvertToPayoutSubAccountResponse(externalFetchSubaccountAvailableBalanceResponse);
        });

        public ValueTask<FetchStaticVirtualAccounts> GetStaticVirtualAccountRequestAsync(string accountReference, string currency) =>
        TryCatch(async () =>
        {
            ValidateFetchStaticVirtualAccountsString(accountReference);
            ValidateFetchStaticVirtualAccountsString(currency);
            ExternalFetchStaticVirtualAccountsResponse externalFetchStaticVirtualAccountsResponse = await flutterWaveBroker.GetStaticVirtualAccountAsync(
               accountReference, currency);
            return ConvertToPayoutSubAccountResponse(externalFetchStaticVirtualAccountsResponse);
        });




        private FetchPayoutSubaccount ConvertToPayoutSubAccountResponse(ExternalFetchPayoutSubaccountResponse externalFetchPayoutSubaccountResponse)
        {
            return new FetchPayoutSubaccount
            {
                Response = new FetchPayoutSubaccountResponse
                {
                    Message = externalFetchPayoutSubaccountResponse.Message,
                    Data = new FetchPayoutSubaccountResponse.FetchPayoutSubaccountData
                    {

                        AccountName = externalFetchPayoutSubaccountResponse.Data.AccountName,
                        Mobilenumber = externalFetchPayoutSubaccountResponse.Data.Mobilenumber,
                        Country = externalFetchPayoutSubaccountResponse.Data.Country,
                        Email = externalFetchPayoutSubaccountResponse.Data.Email,
                        AccountReference = externalFetchPayoutSubaccountResponse.Data.AccountReference,
                        BankCode = externalFetchPayoutSubaccountResponse.Data.BankCode,
                        BankName = externalFetchPayoutSubaccountResponse.Data.BankName,
                        BarterId = externalFetchPayoutSubaccountResponse.Data.BarterId,
                        CreatedAt = externalFetchPayoutSubaccountResponse.Data.CreatedAt,
                        Id = externalFetchPayoutSubaccountResponse.Data.Id,
                        Nuban = externalFetchPayoutSubaccountResponse.Data.Nuban,
                        Status = externalFetchPayoutSubaccountResponse.Data.Status,
                        TransferLimits = new FetchPayoutSubaccountResponse.TransferLimits
                        {
                            SingleLimit = externalFetchPayoutSubaccountResponse.Data.TransferLimits.SingleLimit,
                            TotalDailyLimit = externalFetchPayoutSubaccountResponse.Data.TransferLimits.TotalDailyLimit
                        }

                    },
                    Status = externalFetchPayoutSubaccountResponse.Status,


                }

            };
        }
        private FetchStaticVirtualAccounts ConvertToPayoutSubAccountResponse(ExternalFetchStaticVirtualAccountsResponse externalFetchStaticVirtualAccountsResponse)
        {
            return new FetchStaticVirtualAccounts
            {
                Response = new FetchStaticVirtualAccountsResponse
                {
                    Message = externalFetchStaticVirtualAccountsResponse.Message,
                    Data = new FetchStaticVirtualAccountsResponse.FetchStaticVirtualAccountsData
                    {
                        BankCode = externalFetchStaticVirtualAccountsResponse.Data.BankCode,
                        BankName = externalFetchStaticVirtualAccountsResponse.Data.BankName,
                        Currency = externalFetchStaticVirtualAccountsResponse.Data.Currency,
                        IsDefault = externalFetchStaticVirtualAccountsResponse.Data.IsDefault,
                        StaticAccount = externalFetchStaticVirtualAccountsResponse.Data.StaticAccount,
                        Type = externalFetchStaticVirtualAccountsResponse.Data.Type
                    },
                    Status = externalFetchStaticVirtualAccountsResponse.Status,


                }

            };
        }
        private FetchSubaccountAvailableBalance ConvertToPayoutSubAccountResponse(ExternalFetchSubaccountAvailableBalanceResponse externalFetchSubaccountAvailableBalanceResponse)
        {
            return new FetchSubaccountAvailableBalance
            {
                Response = new FetchSubaccountAvailableBalanceResponse
                {
                    Message = externalFetchSubaccountAvailableBalanceResponse.Message,
                    Data = new FetchSubaccountAvailableBalanceResponse.FetchSubaccountAvailableBalanceData
                    {
                        Currency = externalFetchSubaccountAvailableBalanceResponse.Data.Currency,
                        AvailableBalance = externalFetchSubaccountAvailableBalanceResponse.Data.AvailableBalance,
                        LedgerBalance = externalFetchSubaccountAvailableBalanceResponse.Data.LedgerBalance
                    },

                    Status = externalFetchSubaccountAvailableBalanceResponse.Status,


                }

            };
        }
        private ListPayoutSubaccounts ConvertToPayoutSubAccountResponse(ExternalListPayoutSubaccountsResponse externalListPayoutSubaccountsResponse)
        {
            return new ListPayoutSubaccounts
            {
                Response = new ListPayoutSubaccountsResponse
                {
                    Message = externalListPayoutSubaccountsResponse.Message,
                    Data = externalListPayoutSubaccountsResponse.Data.Select(data =>
                    {
                        return new ListPayoutSubaccountsResponse.Datum
                        {
                            AccountName = data.AccountName,
                            Mobilenumber = data.Mobilenumber,
                            Country = data.Country,
                            Email = data.Email,
                            AccountReference = data.AccountReference,
                            BankCode = data.BankCode,
                            BankName = data.BankName,
                            BarterId = data.BarterId,
                            CreatedAt = data.CreatedAt,
                            Id = data.Id,
                            Nuban = data.Nuban,
                            Status = data.Status

                        };

                    }).ToList(),
                    Status = externalListPayoutSubaccountsResponse.Status,


                }

            };
        }
        private FetchPayoutSubaccountTransactions ConvertToPayoutSubAccountResponse(ExternalFetchPayoutSubaccountTransactionsResponse externalFetchPayoutSubaccountTransactionsResponse)
        {
            return new FetchPayoutSubaccountTransactions
            {
                Response = new FetchPayoutSubaccountTransactionsResponse
                {

                    Data = externalFetchPayoutSubaccountTransactionsResponse.Data,
                    Message = externalFetchPayoutSubaccountTransactionsResponse.Message,
                    Status = externalFetchPayoutSubaccountTransactionsResponse.Status
                }

            };
        }

        private ExternalCreatePayoutSubaccountRequest ConvertToPayoutSubaccountRequest(CreatePayoutSubaccount createPayoutSubaccount)
        {
            return new ExternalCreatePayoutSubaccountRequest
            {
                Email = createPayoutSubaccount.Request.Email,
                Country = createPayoutSubaccount.Request.Country,
                MobileNumber = createPayoutSubaccount.Request.MobileNumber,
                AccountName = createPayoutSubaccount.Request.AccountName



            };
        }
        private CreatePayoutSubaccount ConvertToPayoutSubaccountResponse(CreatePayoutSubaccount createPayoutSubAccount, ExternalCreatePayoutSubaccountResponse externalCreatePayoutSubaccountResponse)
        {

            createPayoutSubAccount.Response = new CreatePayoutSubaccountResponse
            {
                Message = externalCreatePayoutSubaccountResponse.Message,
                Data = new CreatePayoutSubaccountResponse.CreatePayoutSubaccountData
                {

                    AccountName = externalCreatePayoutSubaccountResponse.Data.AccountName,
                    MobileNumber = externalCreatePayoutSubaccountResponse.Data.Mobilenumber,
                    Country = externalCreatePayoutSubaccountResponse.Data.Country,
                    Email = externalCreatePayoutSubaccountResponse.Data.Email,
                    AccountReference = externalCreatePayoutSubaccountResponse.Data.AccountReference,
                    BankCode = externalCreatePayoutSubaccountResponse.Data.BankCode,
                    BankName = externalCreatePayoutSubaccountResponse.Data.BankName,
                    BarterId = externalCreatePayoutSubaccountResponse.Data.BarterId,
                    CreatedAt = externalCreatePayoutSubaccountResponse.Data.CreatedAt,
                    Id = externalCreatePayoutSubaccountResponse.Data.Id,
                    Nuban = externalCreatePayoutSubaccountResponse.Data.Nuban,
                    Status = externalCreatePayoutSubaccountResponse.Data.Status

                },

                Status = externalCreatePayoutSubaccountResponse.Status,


            };
            return createPayoutSubAccount;

        }

        private ExternalUpdatePayoutSubaccountRequest ConvertToPayoutSubaccountRequest(UpdatePayoutSubaccount updatePayoutSubaccount)
        {
            return new ExternalUpdatePayoutSubaccountRequest
            {
                AccountName = updatePayoutSubaccount.Request.AccountName,
                Country = updatePayoutSubaccount.Request.Country,
                Email = updatePayoutSubaccount.Request.Email,
                Mobilenumber = updatePayoutSubaccount.Request.MobileNumber



            };
        }
        private UpdatePayoutSubaccount ConvertToPayoutSubaccountResponse(UpdatePayoutSubaccount updatePayoutSubaccount, ExternalUpdatePayoutSubaccountResponse externalUpdatePayoutSubaccountResponse)
        {

            updatePayoutSubaccount.Response = new UpdatePayoutSubaccountResponse
            {
                Message = externalUpdatePayoutSubaccountResponse.Message,
                Data = new UpdatePayoutSubaccountResponse.UpdatePayoutSubaccountData
                {
                    AccountName = externalUpdatePayoutSubaccountResponse.Data.AccountName,
                    Mobilenumber = externalUpdatePayoutSubaccountResponse.Data.Mobilenumber,
                    Country = externalUpdatePayoutSubaccountResponse.Data.Country,
                    Email = externalUpdatePayoutSubaccountResponse.Data.Email,
                    AccountReference = externalUpdatePayoutSubaccountResponse.Data.AccountReference,
                    BankCode = externalUpdatePayoutSubaccountResponse.Data.BankCode,
                    BankName = externalUpdatePayoutSubaccountResponse.Data.BankName,
                    BarterId = externalUpdatePayoutSubaccountResponse.Data.BarterId,
                    CreatedAt = externalUpdatePayoutSubaccountResponse.Data.CreatedAt,
                    Id = externalUpdatePayoutSubaccountResponse.Data.Id,
                    Nuban = externalUpdatePayoutSubaccountResponse.Data.Nuban,
                    Status = externalUpdatePayoutSubaccountResponse.Data.Status,

                },
                Status = externalUpdatePayoutSubaccountResponse.Status,


            };
            return updatePayoutSubaccount;

        }



    }



}
