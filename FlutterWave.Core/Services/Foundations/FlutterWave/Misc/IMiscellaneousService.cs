using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.MiscService
{
    internal interface IMiscellaneousService
    {
        ValueTask<BalanceByCurrency> GetBalanceByCurrencyAsync(string currency);

        ValueTask<BalanceByCurrencies> GetBalanceCurrenciesAsync();

        ValueTask<Statement> GetStatementAsync();

        ValueTask<BankAccountVerification> PostBankAccountVerificationAsync(
            BankAccountVerification bankAccountVerification);

        ValueTask<BvnConsent> PostBvnConsentAsync(
            BvnConsent bvnConsent);

        ValueTask<BinVerification> GetCardBinVerificationAsync(
           string bin);
    }
}
