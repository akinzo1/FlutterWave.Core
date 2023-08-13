using FlutterWave.Core.Models.Clients.CollectionSubaccounts.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.CollectionSubaccounts
{
    public interface ICollectionSubaccountsClient
    {
        /// <exception cref="CollectionSubaccountsClientDependencyException" />
        /// <exception cref="CollectionSubaccountsClientDependencyException" />
        /// <exception cref="CollectionSubaccountsClientServiceException" />
        ValueTask<CreateCollectionSubaccount> CreateCollectionSubaccountAsync(
             CreateCollectionSubaccount createCollectionSubaccount);

        ValueTask<FetchSubaccounts> RetrieveSubaccountsAsync();

        ValueTask<FetchSubaccount> RetrieveSubaccountAsync(int subaccountId);

        ValueTask<UpdateSubaccount> UpdateCollectionSubaccountAsync(
                 int subaccountId, UpdateSubaccount updateSubaccount);
        ValueTask<DeleteSubaccount> DeleteCollectionSubaccountAsync(
               int subaccountId);
    }
}
