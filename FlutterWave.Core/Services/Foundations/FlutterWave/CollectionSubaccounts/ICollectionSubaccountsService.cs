using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.CollectionSubaccountsService
{
    internal interface ICollectionSubaccountsService
    {
        ValueTask<CreateCollectionSubaccount> PostCreateCollectionSubaccountRequestAsync(
          CreateCollectionSubaccount createCollectionSubaccount);

        ValueTask<FetchSubaccounts> GetSubaccountsRequestAsync();

        ValueTask<FetchSubaccount> GetSubaccountRequestAsync(int subaccountId);

        ValueTask<UpdateSubaccount> PostUpdateCollectionSubaccountRequestAsync(
                 int subaccountId, UpdateSubaccount updateSubaccount);
        ValueTask<DeleteSubaccount> DeleteCollectionSubaccountRequestAsync(
               int subaccountId);
    }
}
