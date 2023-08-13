using FlutterWave.Core.Models.Clients.VirtualCards.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.VirtualCards
{
    public interface IVirtualCardsClient
    {
        /// <exception cref="VirtualCardsClientDependencyException" />
        /// <exception cref="VirtualCardsClientDependencyException" />
        /// <exception cref="VirtualCardsClientServiceException" />
        ValueTask<CreateVirtualCard> CreateVirtualCardAsync(
        CreateVirtualCard createVirtualCard);
        ValueTask<FetchVirtualCards> RetrieveVirtualCardsAsync();

        ValueTask<FetchVirtualCard> RetrieveVirtualCardAsync(
           string virtualCardId);

        ValueTask<VirtualCardWithdrawal> VirtualCardWithdrawalAsync(
            string virtualCardId, VirtualCardWithdrawal fundVirtualCard);
        ValueTask<FundVirtualCard> PostFundVirtualCardAsync(
            string virtualCardId, FundVirtualCard fundVirtualCard);

        ValueTask<BlockUnblockVirtualCard> PostBlockUnblockVirtualCardAsync(
            string virtualCardId, string statusAction);

        ValueTask<TerminateVirtualCard> TerminateVirtualCardAsync(
            string virtualCardId);

        ValueTask<VirtualCardTransactions> GetVirtualCardTransactionsAsync(
         string virtualCardId);
    }
}
