using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.VirtualAccountsService
{
    internal interface IVirtualAccountsService
    {
        ValueTask<CreateVirtualAccounts> PostCreateVirtualAccountRequestAsync(
          CreateVirtualAccounts virtualAccounts);


        ValueTask<BulkCreateVirtualAccounts> PostBulkCreateVirtualAccountsRequestAsync(
        BulkCreateVirtualAccounts virtualAccounts);


        ValueTask<FetchVirtualAccounts> GetVirtualAccountNumberRequestAsync(
        string orderReference);

        ValueTask<BulkVirtualAccountDetails> GetVirtualAccountDetailsRequestAsync(
        string batchId);


        ValueTask<DeleteVirtualAccounts> DeleteVirtualAccountsRequestAsync(
        DeleteVirtualAccounts virtualAccounts, string orderReference);

        ValueTask<UpdateBvnVirtualAccounts> UpdateVirtualAccountsBvnRequestAsync(
        UpdateBvnVirtualAccounts virtualAccounts, string orderReference);
    }
}
