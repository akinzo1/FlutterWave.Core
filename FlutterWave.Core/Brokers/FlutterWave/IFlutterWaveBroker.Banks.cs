using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBanks;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {
        ValueTask<ExternalBankResponse> GetAllBanksByCountryAsync(string country);

        ValueTask<ExternalBankBranchesResponse> GetAllBankBranchesByIdAsync(int bankCode);
    }
}
