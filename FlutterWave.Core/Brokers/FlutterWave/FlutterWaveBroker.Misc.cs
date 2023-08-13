using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalBalance;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {


        public async ValueTask<ExternalBalanceByCurrencyResponse> GetBalanceByCurrencyAsync(
          string currency)
        {
            return await GetAsync<ExternalBalanceByCurrencyResponse>(
                          relativeUrl: $"v3/balances/{currency}");
        }

        public async ValueTask<ExternalAllBalanceCurrenciesResponse> GetBalanceCurrenciesAsync()
        {
            return await GetAsync<ExternalAllBalanceCurrenciesResponse>(
                relativeUrl: $"v3/balances"
                );
        }

        public async ValueTask<ExternalStatementResponse> GetStatementAsync()
        {
            return await GetAsync<ExternalStatementResponse>(
            relativeUrl: $"v3/wallet/statement/"
            );
        }

        public async ValueTask<ExternalBankAccountVerificationResponse> PostBankAccountVerificationAsync(
            ExternalBankAccountVerificationRequest externalBankAccountVerificationRequest)
        {
            return await PostAsync<ExternalBankAccountVerificationRequest, ExternalBankAccountVerificationResponse>(
            relativeUrl: $"v3/accounts/resolve",
            content: externalBankAccountVerificationRequest);


        }

        public async ValueTask<ExternalBvnConsentResponse> PostBvnConsentAsync(
            ExternalBvnConsentRequest externalBvnConsentRequest)
        {
            return await PostAsync<ExternalBvnConsentRequest, ExternalBvnConsentResponse>(
            relativeUrl: $"v3/bvn/verifications",
            content: externalBvnConsentRequest
           );
        }

        public async ValueTask<ExternalCardBinVerificationResponse> GetCardBinVerificationAsync(
           string bin)
        {
            return await GetAsync<ExternalCardBinVerificationResponse>(
                         relativeUrl: $"v3/card-bins/{bin}"
                         );
        }
    }
}

