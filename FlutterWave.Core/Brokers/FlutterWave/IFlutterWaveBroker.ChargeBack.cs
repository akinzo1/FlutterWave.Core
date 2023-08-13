using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalChargeBack;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {
        ValueTask<ExternalChargeBacksResponse> GetAllChargeBacksAsync();

        ValueTask<ExternalAcceptDeclineChargeBackResponse> CreateAcceptDeclineChargeBacksAsync(
            string chargeBackId, ExternalAcceptDeclineChargeBackRequest externalAcceptDeclineChargeBackRequest);

        ValueTask<ExternalChargeBackResponse> GetChargeBackAsync(string flutterWaveReference);

    }
}
