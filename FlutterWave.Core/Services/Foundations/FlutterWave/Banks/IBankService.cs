using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.BanksService
{
    internal interface IBanksService
    {
        ValueTask<Bank> GetAllBanksByCountryAsync(string country);

        ValueTask<BankBranches> GetAllBankBranchesByBankCodeAsync(int bankCode);
    }
}
