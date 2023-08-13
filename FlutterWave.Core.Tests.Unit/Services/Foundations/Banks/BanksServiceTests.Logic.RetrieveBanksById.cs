using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBanks;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;
using Moq;
using static FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBanks.ExternalBankBranchesResponse;
using static FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks.BankBranchesResponse;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Banks
{
    public partial class BanksServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveBankBranchesByIdAsync()
        {
            // given 
            int randomNumber = GetRandomNumber();
            int randomBankCode = randomNumber;
            int inputBankCode = randomBankCode;

            dynamic bankBranchesRandomProperties =
                CreateRandomBankBranchesProperties();

            var externalBanksBranchesResponse = new ExternalBankBranchesResponse
            {

                Message = bankBranchesRandomProperties.Message,
                Data = ((List<dynamic>)bankBranchesRandomProperties.Data).Select(items =>
                    new ExternalBankBranchesData
                    {
                        BankId = items.BankId,
                        Bic = items.Bic,
                        BranchCode = items.BranchCode,
                        BranchName = items.BranchName,
                        Id = items.Id,
                        SwiftCode = items.SwiftCode

                    }
                 ).ToList(),
                Status = bankBranchesRandomProperties.Status,
            };

            var expectedBankBranchesResponse = new BankBranchesResponse
            {

                Message = bankBranchesRandomProperties.Message,
                Data = ((List<dynamic>)bankBranchesRandomProperties.Data).Select(items =>
                    new BankBranchesData
                    {
                        BankId = items.BankId,
                        Bic = items.Bic,
                        BranchCode = items.BranchCode,
                        BranchName = items.BranchName,
                        Id = items.Id,
                        SwiftCode = items.SwiftCode

                    }
                 ).ToList(),
                Status = bankBranchesRandomProperties.Status,

            };
            var expectedBankBranches = new BankBranches
            {
                Response = expectedBankBranchesResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllBankBranchesByIdAsync(inputBankCode))
                    .ReturnsAsync(externalBanksBranchesResponse);

            // when
            BankBranches actualBankBranches =
                await this.banksService.GetAllBankBranchesByBankCodeAsync(inputBankCode);

            // then
            actualBankBranches.Should().BeEquivalentTo(expectedBankBranches);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBankBranchesByIdAsync(inputBankCode),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}