using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {

        ValueTask<ExternalSettlementsResponse> GetAllSettlementsAsync();
        ValueTask<ExternalSettlementResponse> GetSettlementByIdAsync(string settlementId);

    }


}
