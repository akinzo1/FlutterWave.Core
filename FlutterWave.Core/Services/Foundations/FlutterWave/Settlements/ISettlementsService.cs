using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Settlements;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.SettlementsService
{
    internal interface ISettlementsService
    {
        ValueTask<AllSettlements> GetAllSettlementsAsync();
        ValueTask<Settlement> GetSettlementsByIdAsync(string settlementId);
    }
}
