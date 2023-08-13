using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {

        ValueTask<ExternalCreateTokenizedChargeResponse> PostCreateTokenizedChargeAsync(
            ExternalCreateTokenizedChargeRequest externalCreateTokenizedChargeRequest);

        ValueTask<ExternalCreateBulkTokenizedChargeResponse> PostCreateBulkTokenizedChargeAsync(
            ExternalCreateBulkTokenizedChargeRequest externalCreateBulkTokenizedChargeRequest);

        ValueTask<ExternalFetchBulkTokenizedChargeResponse> GetBulkTokenizedChargesAsync(int bulkId);

        ValueTask<ExternalBulkTokenizedStatusResponse> GetBulkTokenizedStatusAsync(int bulkId);

        ValueTask<ExternalUpdateCardTokenResponse> PostUpdateCardTokenAsync(
                 string token, ExternalUpdateCardTokenRequest externalCreateBulkTokenizedChargeRequest);

    }
}

