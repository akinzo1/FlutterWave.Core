using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.Banks
{
    public interface IBanksClient
    {
        /// <exception cref="ChatCompletionClientValidationException" />
        /// <exception cref="ChatCompletionClientDependencyException" />
        /// <exception cref="ChatCompletionClientServiceException" />
        ValueTask<BankBranches> RetrieveAllBankBranchesByBankCodeAsync(int bankCode);

        ValueTask<Bank> RetrieveAllBanksByCountryAsync(string country);
    }
}
