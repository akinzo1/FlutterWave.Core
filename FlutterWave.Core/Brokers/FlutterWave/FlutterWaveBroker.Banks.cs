using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBanks;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {
        public async ValueTask<ExternalBankResponse> GetAllBanksByCountryAsync(string country) =>
            await GetAsync<ExternalBankResponse>(relativeUrl: $"v3/banks/{country}");

        public async ValueTask<ExternalBankBranchesResponse> GetAllBankBranchesByIdAsync(int bankCode) =>
            await GetAsync<ExternalBankBranchesResponse>(relativeUrl: $"v3/banks/{bankCode}/branches");

    }
}
