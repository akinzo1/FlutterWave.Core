using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {
        ValueTask<ExternalCreateVirtualCardResponse> PostCreateVirtualCardAsync(
         ExternalCreateVirtualCardRequest externalCreateVirtualCardRequest);
        ValueTask<ExternalFetchVirtualCardsResponse> GetVirtualCardsAsync();

        ValueTask<ExternalFetchVirtualCardResponse> GetVirtualCardAsync(
           string virtualCardId);

        ValueTask<ExternalVirtualCardWithdrawalResponse> PostVirtualCardWithdrawalAsync(
            string virtualCardId, ExternalVirtualCardWithdrawalRequest externalVirtualCardWithdrawalRequest);
        ValueTask<ExternalFundVirtualCardResponse> PostFundVirtualCardAsync(
            string virtualCardId, ExternalFundVirtualCardRequest externalFundVirtualCardRequest);

        ValueTask<ExternalBlockUnblockVirtualCardResponse> PostBlockUnblockVirtualCardAsync(
            string virtualCardId, string statusAction);

        ValueTask<ExternalTerminateVirtualCardResponse> PostTerminateVirtualCardAsync(
            string virtualCardId);

        ValueTask<ExternalVirtualCardTransactionsResponse> GetVirtualCardTransactionsAsync(
         string virtualCardId);
    }
}
