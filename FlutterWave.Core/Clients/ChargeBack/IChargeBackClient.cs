using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.ChargeBacks
{
    public interface IChargeBackClient
    {
        /// <exception cref="ChatCompletionClientValidationException" />
        /// <exception cref="ChatCompletionClientDependencyException" />
        /// <exception cref="ChatCompletionClientServiceException" />
        ValueTask<AllChargeBacks> RetrieveAllChargeBacksAsync();
        ValueTask<AcceptDeclineChargeBack> AcceptDeclineChargeBacksAsync(
          string chargeBackId, AcceptDeclineChargeBack chargeBack);
        ValueTask<ChargeBack> RetrieveChargeBackAsync(string flutterWaveReference);
    }
}
