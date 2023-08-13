using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCollectionSubaccounts;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {


        public async ValueTask<ExternalCreateCollectionSubaccountResponse> PostCreateCollectionSubaccountAsync(
           ExternalCreateCollectionSubaccountRequest externalCreateCollectionSubaccountRequest)
        {
            return await PostAsync<ExternalCreateCollectionSubaccountRequest, ExternalCreateCollectionSubaccountResponse>(
                           relativeUrl: $"v3/subaccounts",
                           content: externalCreateCollectionSubaccountRequest);
        }
        public async ValueTask<ExternalFetchSubaccountsResponse> GetSubaccountsAsync()
        {
            return await GetAsync<ExternalFetchSubaccountsResponse>(
                           relativeUrl: $"v3/subaccounts"
                           );
        }

        public async ValueTask<ExternalFetchSubaccountResponse> GetSubaccountAsync(int subaccountId)
        {
            return await GetAsync<ExternalFetchSubaccountResponse>(
                           relativeUrl: $"v3/subaccounts/{subaccountId}"
                           );
        }

        public async ValueTask<ExternalUpdateSubaccountResponse> PostUpdateCollectionSubaccountAsync(
         int subaccountId, ExternalUpdateSubaccountRequest externalCreateCollectionSubaccountRequest)
        {
            return await PutAsync<ExternalUpdateSubaccountRequest, ExternalUpdateSubaccountResponse>(
                           relativeUrl: $"v3/subaccounts/{subaccountId}",
                           content: externalCreateCollectionSubaccountRequest);
        }

        public async ValueTask<ExternalDeleteSubaccountResponse> DeleteCollectionSubaccountAsync(
       int subaccountId)
        {
            return await DeleteAsync<ExternalDeleteSubaccountResponse>(
                           relativeUrl: $"v3/subaccounts/{subaccountId}"
                           );
        }

    }
}
