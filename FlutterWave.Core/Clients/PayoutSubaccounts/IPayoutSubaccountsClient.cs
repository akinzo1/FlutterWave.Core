using FlutterWave.Core.Models.Clients.PayoutSubaccounts.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.PayoutSubaccounts
{
    public interface IPayoutSubaccountsClient
    {
        /// <exception cref="PayoutSubaccountsClientDependencyException" />
        /// <exception cref="PayoutSubaccountsClientDependencyException" />
        /// <exception cref="PayoutSubaccountsClientServiceException" />
        ValueTask<CreatePayoutSubaccount> CreatePayoutSubaccountAsync(
            CreatePayoutSubaccount createPayoutSubaccount);

        ValueTask<ListPayoutSubaccounts> RetrieveListPayoutSubaccountsAsync();

        ValueTask<FetchPayoutSubaccount> RetrievePayoutSubaccountAsync(string accountReference);

        ValueTask<UpdatePayoutSubaccount> UpdatePayoutSubaccountAsync(
              string accountReference, UpdatePayoutSubaccount createPayoutSubaccount);

        ValueTask<FetchPayoutSubaccountTransactions> RetrievePayoutSubaccountTransactionsAsync(string accountReference, string from, string to, string currency);

        ValueTask<FetchSubaccountAvailableBalance> RetrievePayoutSubaccountsAvailableBalanceAsync(string accountReference, string currency);

        ValueTask<FetchStaticVirtualAccounts> RetrieveStaticVirtualAccountAsync(string accountReference, string currency);

    }
}
