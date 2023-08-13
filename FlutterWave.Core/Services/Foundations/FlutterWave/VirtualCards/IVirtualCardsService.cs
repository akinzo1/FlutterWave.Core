using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.VirtualCardsService
{
    internal interface IVirtualCardsService
    {
        ValueTask<CreateVirtualCard> PostCreateVirtualCardRequestAsync(
        CreateVirtualCard externalCreateVirtualCard);
        ValueTask<FetchVirtualCards> GetVirtualCardsRequestAsync();

        ValueTask<FetchVirtualCard> GetVirtualCardRequestAsync(
           string virtualCardId);

        ValueTask<VirtualCardWithdrawal> PostVirtualCardWithdrawalRequestAsync(
            string virtualCardId, VirtualCardWithdrawal externalFundVirtualCard);
        ValueTask<FundVirtualCard> PostFundVirtualCardRequestAsync(
            string virtualCardId, FundVirtualCard externalFundVirtualCard);

        ValueTask<BlockUnblockVirtualCard> PostBlockUnblockVirtualCardRequestAsync(
            string virtualCardId, string statusAction);

        ValueTask<TerminateVirtualCard> PostTerminateVirtualCardRequestAsync(
            string virtualCardId);

        ValueTask<VirtualCardTransactions> GetVirtualCardTransactionsRequestAsync(
         string virtualCardId);
    }
}
