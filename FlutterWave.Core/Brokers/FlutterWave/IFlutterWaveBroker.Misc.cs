using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalBalance;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {
        ValueTask<ExternalBalanceByCurrencyResponse> GetBalanceByCurrencyAsync(string currency);

        ValueTask<ExternalAllBalanceCurrenciesResponse> GetBalanceCurrenciesAsync();

        ValueTask<ExternalStatementResponse> GetStatementAsync();

        ValueTask<ExternalBankAccountVerificationResponse> PostBankAccountVerificationAsync(
            ExternalBankAccountVerificationRequest externalBankAccountVerificationRequest);

        ValueTask<ExternalBvnConsentResponse> PostBvnConsentAsync(
            ExternalBvnConsentRequest externalBvnConsentRequest);

        ValueTask<ExternalCardBinVerificationResponse> GetCardBinVerificationAsync(
           string bin);


    }
}
