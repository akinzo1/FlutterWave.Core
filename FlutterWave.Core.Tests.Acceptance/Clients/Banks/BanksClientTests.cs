



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBanks;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace FlutterWave.Core.Tests.Acceptance.Clients.Banks
{
    public partial class BanksClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IFlutterWaveClient flutterWaveClient;

        public BanksClientTests()
        {
            this.apiKey = CreateRandomString();
            this.wireMockServer = WireMockServer.Start();

            var apiConfigurations = new ApiConfigurations
            {
                ApiUrl = this.wireMockServer.Url,
                ApiKey = this.apiKey,

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }

        private static DateTimeOffset GetRandomDate() =>
             new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string CreateRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
          new IntRange(min: 2, max: 10).GetValue();


        private static BankBranches ConvertToBankBranchesResponse(ExternalBankBranchesResponse externalBankBranchesResponse)
        {
            return new BankBranches
            {
                Response = new BankBranchesResponse
                {
                    Message = externalBankBranchesResponse.Message,
                    Data = externalBankBranchesResponse.Data.Select(data =>
                    {
                        return new BankBranchesResponse.BankBranchesData
                        {
                            BankId = data.BankId,
                            Bic = data.Bic,
                            BranchCode = data.BranchCode,
                            BranchName = data.BranchName,
                            Id = data.Id,
                            SwiftCode = data.SwiftCode,
                        };
                    }).ToList(),
                    Status = externalBankBranchesResponse.Status,
                }

            };
        }

        private static Bank ConvertToBankResponse(ExternalBankResponse externalBankResponse)
        {
            return new Bank
            {
                Response = new BankResponse
                {
                    Message = externalBankResponse.Message,
                    Data = externalBankResponse.Data.Select(data =>
                    {
                        return new BankResponse.BanksData
                        {
                            Id = data.Id,
                            Code = data.Code,
                            Name = data.Name,
                        };
                    }).ToList(),
                    Status = externalBankResponse.Status,
                }

            };
        }


        private static ExternalBankResponse CreateRandomExternalBanksResult() =>
          CreateExternalBankFiller().Create();

        private static ExternalBankBranchesResponse CreateRandomExternalBankBranchesResult() =>
        CreateExternalBankBranchesFiller().Create();

        private static Filler<ExternalBankResponse> CreateExternalBankFiller()
        {
            var filler = new Filler<ExternalBankResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }

        private static Filler<ExternalBankBranchesResponse> CreateExternalBankBranchesFiller()
        {
            var filler = new Filler<ExternalBankBranchesResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }

        private static Filler<Bank> CreateCompletionFiller()
        {
            var filler = new Filler<Bank>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        public void Dispose() => this.wireMockServer.Stop();
    }
}
