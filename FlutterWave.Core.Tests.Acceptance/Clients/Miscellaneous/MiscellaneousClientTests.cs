



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalBalance;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace FlutterWave.Core.Tests.Acceptance.Clients.MiscellaneousClient
{
    public partial class MiscellaneousClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IFlutterWaveClient flutterWaveClient;

        public MiscellaneousClientTests()
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

        private static ExternalBankAccountVerificationRequest ConvertToBankAccountVerificationRequest(
           BankAccountVerification bankAccountVerification)
        {

            return new ExternalBankAccountVerificationRequest
            {
                AccountBank = bankAccountVerification.Request.AccountBank,
                AccountNumber = bankAccountVerification.Request.AccountNumber,
            };


        }
        private static ExternalBvnConsentRequest ConvertToBvnConsentRequest(
           BvnConsent bvnConsent)
        {

            return new ExternalBvnConsentRequest
            {
                Bvn = bvnConsent.Request.Bvn,
                Firstname = bvnConsent.Request.FirstName,
                Lastname = bvnConsent.Request.LastName,
                RedirectUrl = bvnConsent.Request.RedirectUrl,
            };


        }

        private static BalanceByCurrency ConvertToMiscellaneousResponse(ExternalBalanceByCurrencyResponse externalBalanceByCurrencyResponse)
        {

            return new BalanceByCurrency
            {
                Response = new BalanceByCurrencyResponse
                {
                    Data = new BalanceByCurrencyResponse.BalanceCurrencyData
                    {
                        AvailableBalance = externalBalanceByCurrencyResponse.Data.AvailableBalance,
                        Currency = externalBalanceByCurrencyResponse.Data.Currency,
                        LedgerBalance = externalBalanceByCurrencyResponse.Data.LedgerBalance,
                    },
                    Message = externalBalanceByCurrencyResponse.Message,
                    Status = externalBalanceByCurrencyResponse.Status,

                }
            };


        }
        private static BalanceByCurrencies ConvertToMiscellaneousResponse(ExternalAllBalanceCurrenciesResponse externalAllBalanceCurrenciesResponse)
        {

            return new BalanceByCurrencies
            {
                Response = new AllBalanceCurrenciesResponse
                {
                    Data = externalAllBalanceCurrenciesResponse.Data.Select(balance =>
                    {
                        return new AllBalanceCurrenciesResponse.Datum
                        {
                            AvailableBalance = balance.AvailableBalance,
                            Currency = balance.Currency,
                            LedgerBalance = balance.LedgerBalance,
                        };

                    }).ToList(),
                    Message = externalAllBalanceCurrenciesResponse?.Message,
                    Status = externalAllBalanceCurrenciesResponse?.Status,
                }
            };


        }
        private static Statement ConvertToMiscellaneousResponse(ExternalStatementResponse externalStatement)
        {

            return new Statement
            {
                Response = new StatementResponse
                {
                    Data = new StatementResponse.StatementResult
                    {
                        PageInfo = new StatementResponse.StatementsPageInfo
                        {
                            CurrentPage = externalStatement.Data.PageInfo.CurrentPage,
                            Total = externalStatement.Data.PageInfo.Total,
                            TotalPages = externalStatement.Data.PageInfo.TotalPages
                        },
                        Transactions = externalStatement.Data.Transactions.Select(transactions =>
                        {
                            return new StatementResponse.TansactionStatement
                            {
                                Amount = transactions.Amount,
                                BalanceAfter = transactions.BalanceAfter,
                                BalanceBefore = transactions.BalanceBefore,
                                Currency = transactions.Currency,
                                Date = transactions.Date,
                                RateUsed = transactions.RateUsed,
                                Reference = transactions.Reference,
                                Remarks = transactions.Remarks,
                                SentAmount = transactions.SentAmount,
                                SentCurrency = transactions.SentCurrency,
                                StatementType = transactions.StatementType,
                                Type = transactions.Type,
                            };
                        }).ToList(),
                    },
                    Message = externalStatement.Message,
                    Status = externalStatement.Status,
                }
            };


        }
        private static BinVerification ConvertToMiscellaneousResponse(ExternalCardBinVerificationResponse externalCardBinVerificationResponse)
        {

            return new BinVerification
            {
                Response = new CardBinVerificationResponse
                {
                    Status = externalCardBinVerificationResponse.Status,
                    Message = externalCardBinVerificationResponse.Message,
                    Data = new CardBinVerificationResponse.CardBinVerificationData
                    {
                        Bin = externalCardBinVerificationResponse.Data.Bin,
                        CardType = externalCardBinVerificationResponse.Data.CardType,
                        IssuerInfo = externalCardBinVerificationResponse.Data.IssuerInfo,
                        IssuingCountry = externalCardBinVerificationResponse.Data.IssuingCountry,
                    }
                }
            };


        }
        private static BankAccountVerification ConvertToMiscellaneousResponse(BankAccountVerification bankAccountVerification, ExternalBankAccountVerificationResponse externalBankAccountVerificationResponse)
        {
            bankAccountVerification.Response = new BankAccountVerificationResponse
            {

                Data = new BankAccountVerificationResponse.BankAccountVerificationData
                {
                    AccountName = externalBankAccountVerificationResponse.Data.AccountName,
                    AccountNumber = externalBankAccountVerificationResponse.Data.AccountNumber,

                },

                Status = externalBankAccountVerificationResponse.Status,
                Message = externalBankAccountVerificationResponse.Message

            };
            return bankAccountVerification;


        }
        private static BvnConsent ConvertToMiscellaneousResponse(BvnConsent bvnConsent, ExternalBvnConsentResponse externalBvnConsentResponse)
        {
            bvnConsent.Response = new BvnConsentResponse
            {
                Data = new BvnConsentResponse.BvnConsentData
                {
                    Reference = externalBvnConsentResponse.Data.Reference,
                    Url = externalBvnConsentResponse.Data.Url,
                },
                Message = externalBvnConsentResponse.Message,
                Status = externalBvnConsentResponse.Status,
            };
            return bvnConsent;


        }


        private static ExternalBvnConsentResponse CreateExternalBvnConsentResponseResult() =>
                CreateExternalBvnConsentResponseFiller().Create();

        private static ExternalBankAccountVerificationResponse CreateExternalBankAccountVerificationResponseResult() =>
           CreateExternalBankAccountVerificationResponseFiller().Create();

        private static ExternalCardBinVerificationResponse CreateExternalCardBinVerificationResponseResult() =>
           CreateExternalCardBinVerificationResponseFiller().Create();

        private static ExternalStatementResponse CreateExternalStatementResponseResult() =>
          CreateExternalStatementResponseFiller().Create();

        private static ExternalAllBalanceCurrenciesResponse CreateExternalAllBalanceCurrenciesResponseResult() =>
            CreateExternalAllBalanceCurrenciesResponseFiller().Create();

        private static ExternalBalanceByCurrencyResponse CreateExternalBalanceByCurrencyResponseResult() =>
            CreateExternalBalanceByCurrencyResponseFiller().Create();

        private static BankAccountVerification CreateRandomBankAccountVerification() =>
          CreateBankAccountVerificationFiller().Create();

        private static BvnConsent CreateRandomBvnConsent() =>
          CreateBvnConsentFiller().Create();


        private static Filler<ExternalBankAccountVerificationResponse> CreateExternalBankAccountVerificationResponseFiller()
        {
            var filler = new Filler<ExternalBankAccountVerificationResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }

        private static Filler<ExternalAllBalanceCurrenciesResponse> CreateExternalAllBalanceCurrenciesResponseFiller()
        {
            var filler = new Filler<ExternalAllBalanceCurrenciesResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalBvnConsentResponse> CreateExternalBvnConsentResponseFiller()
        {
            var filler = new Filler<ExternalBvnConsentResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalBalanceByCurrencyResponse> CreateExternalBalanceByCurrencyResponseFiller()
        {
            var filler = new Filler<ExternalBalanceByCurrencyResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalCardBinVerificationResponse> CreateExternalCardBinVerificationResponseFiller()
        {
            var filler = new Filler<ExternalCardBinVerificationResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalStatementResponse> CreateExternalStatementResponseFiller()
        {
            var filler = new Filler<ExternalStatementResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<BvnConsent> CreateBvnConsentFiller()
        {
            var filler = new Filler<BvnConsent>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<BankAccountVerification> CreateBankAccountVerificationFiller()
        {
            var filler = new Filler<BankAccountVerification>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        public void Dispose() => this.wireMockServer.Stop();
    }
}
