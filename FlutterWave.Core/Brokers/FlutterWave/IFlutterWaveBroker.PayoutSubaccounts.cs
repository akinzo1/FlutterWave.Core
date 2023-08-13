using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {
        ValueTask<ExternalCreatePayoutSubaccountResponse> PostCreatePayoutSubaccountAsync(
             ExternalCreatePayoutSubaccountRequest externalCreatePayoutSubaccountRequest);

        ValueTask<ExternalListPayoutSubaccountsResponse> GetListPayoutSubaccountsAsync();

        ValueTask<ExternalFetchPayoutSubaccountResponse> GetPayoutSubaccountAsync(string accountReference);

        ValueTask<ExternalUpdatePayoutSubaccountResponse> PostUpdatePayoutSubaccountAsync(
              string accountReference, ExternalUpdatePayoutSubaccountRequest externalCreatePayoutSubaccountRequest);

        ValueTask<ExternalFetchPayoutSubaccountTransactionsResponse> GetPayoutSubaccountTransactionsAsync(string accountReference, string from, string to, string currency);

        ValueTask<ExternalFetchSubaccountAvailableBalanceResponse> GetPayoutSubaccountsAvailableBalanceAsync(string accountReference, string currency);

        ValueTask<ExternalFetchStaticVirtualAccountsResponse> GetStaticVirtualAccountAsync(string accountReference, string currency);


    }
}
