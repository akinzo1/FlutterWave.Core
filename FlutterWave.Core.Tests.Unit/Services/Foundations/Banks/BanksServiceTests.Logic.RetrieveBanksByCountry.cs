using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBanks;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;
using Moq;
using static FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBanks.ExternalBankResponse;
using static FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks.BankResponse;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Banks
{
    public partial class BanksServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveBanksByCountryAsync()
        {
            // given 
            string randomString = GetRandomString();
            string randomCountry = randomString;
            string inputCountry = randomCountry;

            dynamic banksRandomProperties =
                CreateRandomBankProperties();

            var externalBanksResponse = new ExternalBankResponse
            {

                Message = banksRandomProperties.Message,
                Data = ((List<dynamic>)banksRandomProperties.Data).Select(items =>
                    new ExternalBankData
                    {
                        Name = items.Name,
                        Code = items.Code,
                        Id = items.Id,

                    }
                 ).ToList(),
                Status = banksRandomProperties.Status,

            };

            var expectedBankResponse = new BankResponse
            {
                Message = banksRandomProperties.Message,
                Data = ((List<dynamic>)banksRandomProperties.Data).Select(items =>
                     new BanksData
                     {
                         Name = items.Name,
                         Code = items.Code,
                         Id = items.Id,

                     }
                 ).ToList(),
                Status = banksRandomProperties.Status,
            };

            var expectedBank = new Bank
            {
                Response = expectedBankResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllBanksByCountryAsync(inputCountry))
                    .ReturnsAsync(externalBanksResponse);

            // when
            Bank actualBanks =
                await this.banksService.GetAllBanksByCountryAsync(inputCountry);

            // then
            actualBanks.Should().BeEquivalentTo(expectedBank);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllBanksByCountryAsync(inputCountry),
                    Times.Once);


            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}