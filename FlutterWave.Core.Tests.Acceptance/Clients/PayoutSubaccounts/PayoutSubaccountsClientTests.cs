



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace FlutterWave.Core.Tests.Acceptance.Clients.PayoutSubaccountsClient
{
    public partial class PayoutSubaccountsClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IFlutterWaveClient flutterWaveClient;

        public PayoutSubaccountsClientTests()
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

        private static DateTime GetRandomDate() =>
             new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
        new IntRange(min: 2, max: 10).GetValue();

        private FetchPayoutSubaccount ConvertToPayoutSubaccountResponse(ExternalFetchPayoutSubaccountResponse externalFetchPayoutSubaccountResponse)
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
        private FetchStaticVirtualAccounts ConvertToPayoutSubaccountResponse(ExternalFetchStaticVirtualAccountsResponse externalFetchStaticVirtualAccountsResponse)
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
        private FetchSubaccountAvailableBalance ConvertToPayoutSubaccountResponse(ExternalFetchSubaccountAvailableBalanceResponse externalFetchSubaccountAvailableBalanceResponse)
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
        private ListPayoutSubaccounts ConvertToPayoutSubaccountResponse(ExternalListPayoutSubaccountsResponse externalListPayoutSubaccountsResponse)
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
        private FetchPayoutSubaccountTransactions ConvertToPayoutSubaccountResponse(ExternalFetchPayoutSubaccountTransactionsResponse externalFetchPayoutSubaccountTransactionsResponse)
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






        private static ExternalUpdatePayoutSubaccountResponse CreateRandomExternalUpdatePayoutSubaccountResponseResult() =>
         CreateExternalUpdatePayoutSubaccountResponseFiller().Create();
        private static ExternalCreatePayoutSubaccountResponse CreateRandomExternalCreatePayoutSubaccountResponseResult() =>
         CreateExternalCreatePayoutSubaccountResponseFiller().Create();
        private static ExternalFetchPayoutSubaccountTransactionsResponse CreateRandomExternalFetchPayoutSubaccountTransactionsResponseResult() =>
         CreateExternalFetchPayoutSubaccountTransactionsResponseFiller().Create();
        private static ExternalListPayoutSubaccountsResponse CreateRandomExternalListPayoutSubaccountsResponseResult() =>
         CreateExternalListPayoutSubaccountsResponseFiller().Create();
        private static ExternalFetchSubaccountAvailableBalanceResponse CreateRandomExternalFetchSubaccountAvailableBalanceResponseResult() =>
          CreateExternalFetchSubaccountAvailableBalanceResponseFiller().Create();
        private static ExternalFetchStaticVirtualAccountsResponse CreateRandomExternalFetchStaticVirtualAccountsResponseResult() =>
            CreateExternalFetchStaticVirtualAccountsResponseFiller().Create();
        private static ExternalFetchPayoutSubaccountResponse CreateRandomExternalFetchPayoutSubaccountResponseResult() =>
         CreateExternalFetchPayoutSubaccountResponseFiller().Create();



        private static UpdatePayoutSubaccount CreateRandomUpdatePayoutSubaccountResult() =>
                 CreateUpdatePayoutSubaccountFiller().Create();
        private static CreatePayoutSubaccount CreateRandomCreatePayoutSubaccountResult() =>
         CreateCreatePayoutSubaccountFiller().Create();




        private static Filler<ExternalUpdatePayoutSubaccountResponse> CreateExternalUpdatePayoutSubaccountResponseFiller()
        {
            var filler = new Filler<ExternalUpdatePayoutSubaccountResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalCreatePayoutSubaccountResponse> CreateExternalCreatePayoutSubaccountResponseFiller()
        {
            var filler = new Filler<ExternalCreatePayoutSubaccountResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalFetchPayoutSubaccountTransactionsResponse> CreateExternalFetchPayoutSubaccountTransactionsResponseFiller()
        {
            var filler = new Filler<ExternalFetchPayoutSubaccountTransactionsResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalListPayoutSubaccountsResponse> CreateExternalListPayoutSubaccountsResponseFiller()
        {
            var filler = new Filler<ExternalListPayoutSubaccountsResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalFetchSubaccountAvailableBalanceResponse> CreateExternalFetchSubaccountAvailableBalanceResponseFiller()
        {
            var filler = new Filler<ExternalFetchSubaccountAvailableBalanceResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalFetchStaticVirtualAccountsResponse> CreateExternalFetchStaticVirtualAccountsResponseFiller()
        {
            var filler = new Filler<ExternalFetchStaticVirtualAccountsResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalFetchPayoutSubaccountResponse> CreateExternalFetchPayoutSubaccountResponseFiller()
        {
            var filler = new Filler<ExternalFetchPayoutSubaccountResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }




        private static Filler<UpdatePayoutSubaccount> CreateUpdatePayoutSubaccountFiller()
        {
            var filler = new Filler<UpdatePayoutSubaccount>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<CreatePayoutSubaccount> CreateCreatePayoutSubaccountFiller()
        {
            var filler = new Filler<CreatePayoutSubaccount>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        public void Dispose() => this.wireMockServer.Stop();
    }
}
