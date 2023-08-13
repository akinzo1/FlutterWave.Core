using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {


        public async ValueTask<ExternalCreateVirtualAccountResponse> PostCreateVirtualAccountRequestAsync(
          ExternalCreateVirtualAccountRequest externalCreateVirtualAccountRequest)
        {
            return await PostAsync<ExternalCreateVirtualAccountRequest, ExternalCreateVirtualAccountResponse>(
                relativeUrl: "v3/virtual-account-numbers",
                content: externalCreateVirtualAccountRequest);
        }

        public async ValueTask<ExternalBulkCreateVirtualAccountsResponse> PostBulkCreateVirtualAccountsRequestAsync(
        ExternalCreateBulkVirtualAccountsRequest externalCreateBulkVirtualAccountsRequest)
        {
            return await PostAsync<ExternalCreateBulkVirtualAccountsRequest, ExternalBulkCreateVirtualAccountsResponse>(
                relativeUrl: "v3/bulk-virtual-account-numbers",
                content: externalCreateBulkVirtualAccountsRequest);
        }


        public async ValueTask<ExternalVirtualAccountNumberResponse> GetVirtualAccountNumberRequestAsync(
        string orderReference)
        {
            return await GetAsync<ExternalVirtualAccountNumberResponse>(
                relativeUrl: $"v3/virtual-account-numbers/{orderReference}"
               );

        }
        public async ValueTask<ExternalBulkVirtualAccountDetailsResponse> GetBulkVirtualAccountDetailsRequestAsync(
        string batchId)
        {
            return await GetAsync<ExternalBulkVirtualAccountDetailsResponse>(
                relativeUrl: $"v3/bulk-virtual-account-numbers/{batchId}"
               );
        }

        public async ValueTask<ExternalDeleteVirtualAccountResponse> DeleteVirtualAccountsRequestAsync(
        ExternalDeleteVirtualAccountRequest externalDeleteVirtualAccountRequest, string orderReference)
        {

            return await PostAsync<ExternalDeleteVirtualAccountRequest, ExternalDeleteVirtualAccountResponse>(
                relativeUrl: $"v3/virtual-account-numbers/{orderReference}",
                content: externalDeleteVirtualAccountRequest);
        }
        public async ValueTask<ExternalUpdateVirtualAccountBvnResponse> UpdateVirtualAccountsBvnRequestAsync(
        ExternalUpdateVirtualAccountBvnRequest externalUpdateVirtualAccountBvnRequest, string orderReference)
        {

            return await PutAsync<ExternalUpdateVirtualAccountBvnRequest, ExternalUpdateVirtualAccountBvnResponse>(
                relativeUrl: $"v3/virtual-account-numbers/{orderReference}",
                content: externalUpdateVirtualAccountBvnRequest);
        }

    }
}
