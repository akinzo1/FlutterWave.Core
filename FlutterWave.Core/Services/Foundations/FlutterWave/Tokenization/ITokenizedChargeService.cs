using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.TokenizedChargeService
{
    internal interface ITokenizedChargeService
    {
        ValueTask<CreateTokenizedCharge> PostCreateTokenizedChargeRequestAsync(
         CreateTokenizedCharge CreateTokenizedCharge);

        ValueTask<CreateBulkTokenizedCharge> PostCreateBulkTokenizedChargeRequestAsync(
            CreateBulkTokenizedCharge CreateBulkTokenizedCharge);

        ValueTask<FetchBulkTokenizedCharge> GetBulkTokenizedChargesRequestAsync(int bulkId);

        ValueTask<BulkTokenizedStatus> GetBulkTokenizedStatusRequestAsync(int bulkId);

        ValueTask<UpdateCardToken> PostUpdateCardTokenRequestAsync(
                 string token, UpdateCardToken CreateBulkTokenizedCharge);
    }
}
