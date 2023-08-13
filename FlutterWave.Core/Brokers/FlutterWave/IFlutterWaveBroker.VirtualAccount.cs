using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {
        ValueTask<ExternalCreateVirtualAccountResponse> PostCreateVirtualAccountRequestAsync(
        ExternalCreateVirtualAccountRequest externalCreateVirtualAccountRequest);


        ValueTask<ExternalBulkCreateVirtualAccountsResponse> PostBulkCreateVirtualAccountsRequestAsync(
        ExternalCreateBulkVirtualAccountsRequest externalCreateBulkVirtualAccountsRequest);


        ValueTask<ExternalVirtualAccountNumberResponse> GetVirtualAccountNumberRequestAsync(
        string orderReference);

        ValueTask<ExternalBulkVirtualAccountDetailsResponse> GetBulkVirtualAccountDetailsRequestAsync(
        string batchId);


        ValueTask<ExternalDeleteVirtualAccountResponse> DeleteVirtualAccountsRequestAsync(
        ExternalDeleteVirtualAccountRequest externalDeleteVirtualAccountRequest, string orderReference);

        ValueTask<ExternalUpdateVirtualAccountBvnResponse> UpdateVirtualAccountsBvnRequestAsync(
        ExternalUpdateVirtualAccountBvnRequest externalUpdateVirtualAccountBvnRequest, string orderReference);

    }
}
