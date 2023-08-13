using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Settlements;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.SettlementClient
{
    public interface ISettlementClient
    {
        /// <exception cref="ChatCompletionClientValidationException" />
        /// <exception cref="ChatCompletionClientDependencyException" />
        /// <exception cref="ChatCompletionClientServiceException" />
        ValueTask<AllSettlements> RetrieveAllSettlementsAsync();
        ValueTask<Settlement> FetchSettlementByIdAsync(string settlementId);
    }
}
