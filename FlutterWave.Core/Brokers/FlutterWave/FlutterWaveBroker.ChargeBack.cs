using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalChargeBack;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {


        public async ValueTask<ExternalChargeBacksResponse> GetAllChargeBacksAsync()
        {
            return await GetAsync<ExternalChargeBacksResponse>(
                relativeUrl: "v3/chargebacks");
        }

        public async ValueTask<ExternalAcceptDeclineChargeBackResponse> CreateAcceptDeclineChargeBacksAsync(
           string chargeBackId, ExternalAcceptDeclineChargeBackRequest externalAcceptDeclineChargeBackRequest)
        {
            return await PutAsync<ExternalAcceptDeclineChargeBackRequest, ExternalAcceptDeclineChargeBackResponse>(
                relativeUrl: $"v3/chargebacks/{chargeBackId}",
                content: externalAcceptDeclineChargeBackRequest
                );
        }

        public async ValueTask<ExternalChargeBackResponse> GetChargeBackAsync(string flutterWaveReference)
        {
            return await GetAsync<ExternalChargeBackResponse>(
                relativeUrl: $"v3/chargebacks?flw_ref={flutterWaveReference}");
        }
    }
}
