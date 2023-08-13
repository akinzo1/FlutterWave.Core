using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {
        public async ValueTask<ExternalCreateTokenizedChargeResponse> PostCreateTokenizedChargeAsync(
            ExternalCreateTokenizedChargeRequest externalCreateTokenizedChargeRequest)
        {
            return await PostAsync<ExternalCreateTokenizedChargeRequest, ExternalCreateTokenizedChargeResponse>(
                relativeUrl: "v3/tokenized-charges",
                content: externalCreateTokenizedChargeRequest);
        }

        public async ValueTask<ExternalCreateBulkTokenizedChargeResponse> PostCreateBulkTokenizedChargeAsync(
           ExternalCreateBulkTokenizedChargeRequest externalCreateBulkTokenizedChargeRequest)
        {
            return await PostAsync<ExternalCreateBulkTokenizedChargeRequest, ExternalCreateBulkTokenizedChargeResponse>(
                relativeUrl: "v3/bulk-tokenized-charges",
                content: externalCreateBulkTokenizedChargeRequest);
        }

        public async ValueTask<ExternalFetchBulkTokenizedChargeResponse> GetBulkTokenizedChargesAsync(
        int bulkId)
        {
            return await GetAsync<ExternalFetchBulkTokenizedChargeResponse>(
                relativeUrl: $"v3/bulk-tokenized-charges/{bulkId}/transactions");
        }

        public async ValueTask<ExternalBulkTokenizedStatusResponse> GetBulkTokenizedStatusAsync(
        int bulkId)
        {
            return await GetAsync<ExternalBulkTokenizedStatusResponse>(
                relativeUrl: $"v3/bulk-tokenized-charges/{bulkId}");
        }

        public async ValueTask<ExternalUpdateCardTokenResponse> PostUpdateCardTokenAsync(
         string token, ExternalUpdateCardTokenRequest externalCreateBulkTokenizedChargeRequest)
        {
            return await PutAsync<ExternalUpdateCardTokenRequest, ExternalUpdateCardTokenResponse>(
                relativeUrl: $"v3/tokens/{token}",
                content: externalCreateBulkTokenizedChargeRequest);
        }
    }
}
