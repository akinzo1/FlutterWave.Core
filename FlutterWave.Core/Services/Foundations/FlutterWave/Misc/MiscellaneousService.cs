using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalBalance;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.MiscService
{
    internal partial class MiscellaneousService : IMiscellaneousService
    {
        private readonly IFlutterWaveBroker flutterWaveBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public MiscellaneousService(
            IFlutterWaveBroker flutterWaveBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.flutterWaveBroker = flutterWaveBroker;
            this.dateTimeBroker = dateTimeBroker;
        }
        public ValueTask<BalanceByCurrency> GetBalanceByCurrencyAsync(string currency) =>
        TryCatch(async () =>
        {
            ValidateBalanceCurrency(currency);
            ExternalBalanceByCurrencyResponse externalBalanceByCurrencyResponse =
            await flutterWaveBroker.GetBalanceByCurrencyAsync(currency);
            return ConvertToMiscellaneousResponse(externalBalanceByCurrencyResponse);
        });

        public ValueTask<BalanceByCurrencies> GetBalanceCurrenciesAsync() =>
        TryCatch(async () =>
        {
            ExternalAllBalanceCurrenciesResponse externalAllBalanceCurrenciesResponse =
            await flutterWaveBroker.GetBalanceCurrenciesAsync();
            return ConvertToMiscellaneousResponse(externalAllBalanceCurrenciesResponse);
        });
        public ValueTask<Statement> GetStatementAsync() =>
        TryCatch(async () =>
        {

            ExternalStatementResponse externalStatementResponse =
            await flutterWaveBroker.GetStatementAsync();
            return ConvertToMiscellaneousResponse(externalStatementResponse);
        });
        public ValueTask<BankAccountVerification> PostBankAccountVerificationAsync(
            BankAccountVerification bankAccountVerification) =>
        TryCatch(async () =>
        {
            ValidateBankAccountVerification(bankAccountVerification);
            ExternalBankAccountVerificationRequest externalBankAccountVerificationRequest =
              ConvertToBankAccountVerificationRequest(bankAccountVerification);

            ExternalBankAccountVerificationResponse externalBankAccountVerificationResponse =
            await flutterWaveBroker.PostBankAccountVerificationAsync(externalBankAccountVerificationRequest);
            return ConvertToMiscellaneousResponse(bankAccountVerification, externalBankAccountVerificationResponse);
        });
        public ValueTask<BvnConsent> PostBvnConsentAsync(BvnConsent bvnConsent) =>
        TryCatch(async () =>
        {
            ValidateBvnConsent(bvnConsent);
            ExternalBvnConsentRequest externalBvnConsentRequest =
            ConvertToBvnConsentRequest(bvnConsent);
            ExternalBvnConsentResponse externalBvnConsentResponse =
            await flutterWaveBroker.PostBvnConsentAsync(externalBvnConsentRequest);
            return ConvertToMiscellaneousResponse(bvnConsent, externalBvnConsentResponse);
        });
        public ValueTask<BinVerification> GetCardBinVerificationAsync(string bin) =>
        TryCatch(async () =>
        {
            ValidateCardBin(bin);
            ExternalCardBinVerificationResponse externalCardBinVerificationResponse =
            await flutterWaveBroker.GetCardBinVerificationAsync(bin);
            return ConvertToMiscellaneousResponse(externalCardBinVerificationResponse);
        });
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


    }
}
