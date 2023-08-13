using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.PayoutSubaccountsService
{
    internal interface IPayoutSubaccountsService
    {
        ValueTask<CreatePayoutSubaccount> PostCreatePayoutSubaccountRequestAsync(
        CreatePayoutSubaccount createPayoutSubaccount);

        ValueTask<ListPayoutSubaccounts> GetListPayoutSubaccountsRequestAsync();

        ValueTask<FetchPayoutSubaccount> GetPayoutSubaccountRequestAsync(string accountReference);

        ValueTask<UpdatePayoutSubaccount> PostUpdatePayoutSubaccountRequestAsync(
              string accountReference, UpdatePayoutSubaccount createPayoutSubaccount);

        ValueTask<FetchPayoutSubaccountTransactions> GetPayoutSubaccountTransactionsRequestAsync(string accountReference, string from, string to, string currency);

        ValueTask<FetchSubaccountAvailableBalance> GetPayoutSubaccountsAvailableBalanceRequestAsync(string accountReference, string currency);

        ValueTask<FetchStaticVirtualAccounts> GetStaticVirtualAccountRequestAsync(string accountReference, string currency);
    }
}
