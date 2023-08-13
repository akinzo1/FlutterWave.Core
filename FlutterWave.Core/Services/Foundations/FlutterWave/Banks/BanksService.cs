using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBanks;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;
using System.Linq;
using System.Threading.Tasks;
using static FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks.BankBranchesResponse;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.BanksService
{
    internal partial class BanksService : IBanksService
    {
        private readonly IFlutterWaveBroker flutterWaveBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public BanksService(
            IFlutterWaveBroker flutterWaveBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.flutterWaveBroker = flutterWaveBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<Bank> GetAllBanksByCountryAsync(string country) =>
        TryCatch(async () =>
        {
            ValidateBankCountryCode(country);
            ExternalBankResponse externalBankResponse = await flutterWaveBroker.GetAllBanksByCountryAsync(country);
            return ConvertToBanksResponse(externalBankResponse);
        });

        public ValueTask<BankBranches> GetAllBankBranchesByBankCodeAsync(int bankCode) =>
        TryCatch(async () =>
        {
            ValidateBankBranchesBankCode(bankCode);
            ExternalBankBranchesResponse externalBankBranchesResponse = await flutterWaveBroker.GetAllBankBranchesByIdAsync(bankCode);

            return ConvertToBankBranchesResponse(externalBankBranchesResponse);

        });



        private static Bank ConvertToBanksResponse(ExternalBankResponse externalBanksResponse)
        {
            return new Bank
            {

                Response = new BankResponse
                {
                    Message = externalBanksResponse.Message,
                    Status = externalBanksResponse.Status,
                    Data = externalBanksResponse.Data.Select(banks =>
                    {
                        return new BankResponse.BanksData
                        {
                            Code = banks.Code,
                            Id = banks.Id,
                            Name = banks.Name,
                        };
                    }).ToList()
                }

            };

        }

        private static BankBranches ConvertToBankBranchesResponse(ExternalBankBranchesResponse externalBankBranchesResponse)
        {

            return new BankBranches
            {
                Response = new BankBranchesResponse
                {
                    Message = externalBankBranchesResponse.Message,
                    Status = externalBankBranchesResponse.Status,
                    Data = externalBankBranchesResponse.Data.Select(branches =>
                    {
                        return new BankBranchesData
                        {
                            Id = branches.Id,
                            BankId = branches.BankId,
                            Bic = branches.Bic,
                            BranchCode = branches.BranchCode,
                            BranchName = branches.BranchName,
                            SwiftCode = branches.SwiftCode,
                        };
                    }).ToList()

                }

            };
        }

    }
}
