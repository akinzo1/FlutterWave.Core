using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {


        public async ValueTask<ExternalSettlementsResponse> GetAllSettlementsAsync() =>
            await GetAsync<ExternalSettlementsResponse>(relativeUrl: $"v3/settlements");

        public async ValueTask<ExternalSettlementResponse> GetSettlementByIdAsync(string settlementId) =>
            await GetAsync<ExternalSettlementResponse>(relativeUrl: $"v3/settlements/{settlementId}");



    }
}
