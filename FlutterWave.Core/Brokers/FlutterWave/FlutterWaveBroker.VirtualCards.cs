using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {
        public async ValueTask<ExternalCreateVirtualCardResponse> PostCreateVirtualCardAsync(
         ExternalCreateVirtualCardRequest externalCreateVirtualCardRequest)
        {
            return await PostAsync<ExternalCreateVirtualCardRequest, ExternalCreateVirtualCardResponse>(
                        relativeUrl: "v3/virtual-cards",
                        content: externalCreateVirtualCardRequest);
        }


        public async ValueTask<ExternalFetchVirtualCardsResponse> GetVirtualCardsAsync()
        {
            return await GetAsync<ExternalFetchVirtualCardsResponse>(
              relativeUrl: "v3/virtual-cards");
        }

        public async ValueTask<ExternalFetchVirtualCardResponse> GetVirtualCardAsync(
           string virtualCardId)
        {
            return await GetAsync<ExternalFetchVirtualCardResponse>(
              relativeUrl: $"v3/virtual-cards/{virtualCardId}");
        }

        public async ValueTask<ExternalVirtualCardWithdrawalResponse> PostVirtualCardWithdrawalAsync(
         string virtualCardId, ExternalVirtualCardWithdrawalRequest externalWithdrawalVirtualCardRequest)
        {
            return await PostAsync<ExternalVirtualCardWithdrawalRequest, ExternalVirtualCardWithdrawalResponse>(
                           relativeUrl: $"v3/virtual-cards/{virtualCardId}/withdraw",
                           content: externalWithdrawalVirtualCardRequest);
        }

        public async ValueTask<ExternalFundVirtualCardResponse> PostFundVirtualCardAsync(
            string virtualCardId, ExternalFundVirtualCardRequest externalFundVirtualCardRequest)
        {
            return await PostAsync<ExternalFundVirtualCardRequest, ExternalFundVirtualCardResponse>(
                           relativeUrl: $"v3/virtual-cards/{virtualCardId}/fund",
                           content: externalFundVirtualCardRequest);
        }

        public async ValueTask<ExternalBlockUnblockVirtualCardResponse> PostBlockUnblockVirtualCardAsync(
            string virtualCardId, string statusAction)
        {
            return await PutAsync<ExternalBlockUnblockVirtualCardResponse>(
                           relativeUrl: $"v3/virtual-cards/{virtualCardId}/status/{statusAction}",
                           content: null);
        }

        public async ValueTask<ExternalTerminateVirtualCardResponse> PostTerminateVirtualCardAsync(
            string virtualCardId)
        {
            return await PutAsync<ExternalTerminateVirtualCardResponse>(
                             relativeUrl: $"v3/virtual-cards/{virtualCardId}/terminate",
                             content: null);
        }

        public async ValueTask<ExternalVirtualCardTransactionsResponse> GetVirtualCardTransactionsAsync(
         string virtualCardId)
        {
            return await GetAsync<ExternalVirtualCardTransactionsResponse>(
                  relativeUrl: $"v3/virtual-cards/{virtualCardId}/transactions");
        }

    }
}
