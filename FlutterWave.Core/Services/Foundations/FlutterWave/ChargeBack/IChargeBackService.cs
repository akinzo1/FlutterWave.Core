using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.ChargeBackService
{
    internal interface IChargeBackService
    {
        ValueTask<AllChargeBacks> GetAllChargeBacksAsync();

        ValueTask<AcceptDeclineChargeBack> PostAcceptDeclineChargeBacksAsync(
             string chargeBackId, AcceptDeclineChargeBack chargeBack);

        ValueTask<ChargeBack> GetChargeBackAsync(string flutterWaveReference);
    }
}
