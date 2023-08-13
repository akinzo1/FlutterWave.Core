



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.ChargeClient
{
    public partial class ChargeClientTests
    {
        [Fact]
        public async Task ShouldPostBankTransferAsync()
        {

            // given
            BankTransfer randomBankTransfer = CreateRandomBankTransferResult();
            BankTransfer inputBankTransfer = randomBankTransfer;

            ExternalBankTransferRequest BankTransferRequest =
                ConvertToChargeRequest(inputBankTransfer);

            ExternalBankTransferResponse BankTransferResponse =
                            CreateRandomExternalBankTransferResponseResult();

            BankTransfer expectedBankTransfer = inputBankTransfer.DeepClone();
            expectedBankTransfer = ConvertToChargeResponse(expectedBankTransfer, BankTransferResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "bank_transfer")
                    .WithBody(JsonConvert.SerializeObject(
                        BankTransferRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(BankTransferResponse));

            // when
            BankTransfer actualResult =
                await this.flutterWaveClient.Charge.ChargeBankTransferAsync(inputBankTransfer);

            // then
            actualResult.Should().BeEquivalentTo(expectedBankTransfer);
        }
    }
}
