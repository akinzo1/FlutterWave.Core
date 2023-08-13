using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCollectionSubaccounts;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {
        ValueTask<ExternalCreateCollectionSubaccountResponse> PostCreateCollectionSubaccountAsync(
           ExternalCreateCollectionSubaccountRequest externalCreateCollectionSubaccountRequest);

        ValueTask<ExternalFetchSubaccountsResponse> GetSubaccountsAsync();

        ValueTask<ExternalFetchSubaccountResponse> GetSubaccountAsync(int subaccountId);

        ValueTask<ExternalUpdateSubaccountResponse> PostUpdateCollectionSubaccountAsync(
                 int subaccountId, ExternalUpdateSubaccountRequest externalCreateCollectionSubaccountRequest);
        ValueTask<ExternalDeleteSubaccountResponse> DeleteCollectionSubaccountAsync(
               int subaccountId);

    }
}
