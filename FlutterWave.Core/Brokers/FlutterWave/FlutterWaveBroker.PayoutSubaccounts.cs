using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {
        public async ValueTask<ExternalCreatePayoutSubaccountResponse> PostCreatePayoutSubaccountAsync(
          ExternalCreatePayoutSubaccountRequest externalCreatePayoutSubaccountRequest)
        {
            return await PostAsync<ExternalCreatePayoutSubaccountRequest, ExternalCreatePayoutSubaccountResponse>(
                           relativeUrl: $"v3/payout-subaccounts",
                           content: externalCreatePayoutSubaccountRequest);
        }

        public async ValueTask<ExternalListPayoutSubaccountsResponse> GetListPayoutSubaccountsAsync()
        {
            return await GetAsync<ExternalListPayoutSubaccountsResponse>(
                           relativeUrl: $"v3/payout-subaccounts"
                           );
        }

        public async ValueTask<ExternalFetchPayoutSubaccountResponse> GetPayoutSubaccountAsync(string accountReference)
        {
            return await GetAsync<ExternalFetchPayoutSubaccountResponse>(
                           relativeUrl: $"v3/payout-subaccounts/{accountReference}"
                           );
        }

        public async ValueTask<ExternalUpdatePayoutSubaccountResponse> PostUpdatePayoutSubaccountAsync(
          string accountReference, ExternalUpdatePayoutSubaccountRequest externalCreatePayoutSubaccountRequest)
        {
            return await PutAsync<ExternalUpdatePayoutSubaccountRequest, ExternalUpdatePayoutSubaccountResponse>(
                           relativeUrl: $"v3/payout-subaccounts/{accountReference}",
                           content: externalCreatePayoutSubaccountRequest);
        }

        public async ValueTask<ExternalFetchPayoutSubaccountTransactionsResponse> GetPayoutSubaccountTransactionsAsync(string accountReference, string from, string to, string currency)
        {
            return await GetAsync<ExternalFetchPayoutSubaccountTransactionsResponse>(
                           relativeUrl: $"v3/payout-subaccounts/{accountReference}/transactions?from={from}&to={to}&currency={currency}"
                           );
        }

        public async ValueTask<ExternalFetchSubaccountAvailableBalanceResponse> GetPayoutSubaccountsAvailableBalanceAsync(string accountReference, string currency)
        {
            return await GetAsync<ExternalFetchSubaccountAvailableBalanceResponse>(
                           relativeUrl: $"v3/payout-subaccounts/{accountReference}/balances?currency={currency}"
                           );
        }

        public async ValueTask<ExternalFetchStaticVirtualAccountsResponse> GetStaticVirtualAccountAsync(string accountReference, string currency)
        {
            return await GetAsync<ExternalFetchStaticVirtualAccountsResponse>(
                           relativeUrl: $"v3/payout-subaccounts/{accountReference}/static-account?currency={currency}"
                           );
        }

    }
}
