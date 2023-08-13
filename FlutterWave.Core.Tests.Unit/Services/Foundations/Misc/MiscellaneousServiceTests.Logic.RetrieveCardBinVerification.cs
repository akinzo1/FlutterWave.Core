



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Miscellaneous
{
    public partial class MiscellaneousServiceTests
    {
        [Fact]
        public async Task ShouldVerifyCardBinWithBinAsync()
        {
            // given 
            string randomRandomBIn = GetRandomString();
            string inputBin = randomRandomBIn;

            dynamic createRandomCardBinVerificationProperties =
                     CreateRandomCardBinVerificationProperties();

            var randomExternalCardBinVerificationResponse = new ExternalCardBinVerificationResponse
            {
                Data = new ExternalCardBinVerificationResponse.ExternalCardBinVerificationData
                {
                    Bin = createRandomCardBinVerificationProperties.Data.Bin,
                    CardType = createRandomCardBinVerificationProperties.Data.CardType,
                    IssuerInfo = createRandomCardBinVerificationProperties.Data.IssuerInfo,
                    IssuingCountry = createRandomCardBinVerificationProperties.Data.IssuingCountry
                },
                Status = createRandomCardBinVerificationProperties.Status,
                Message = createRandomCardBinVerificationProperties.Message
            };

            var randomExpectedCardBinVerificationResponse = new CardBinVerificationResponse
            {
                Data = new CardBinVerificationResponse.CardBinVerificationData
                {
                    Bin = createRandomCardBinVerificationProperties.Data.Bin,
                    CardType = createRandomCardBinVerificationProperties.Data.CardType,
                    IssuerInfo = createRandomCardBinVerificationProperties.Data.IssuerInfo,
                    IssuingCountry = createRandomCardBinVerificationProperties.Data.IssuingCountry
                },
                Status = createRandomCardBinVerificationProperties.Status,
                Message = createRandomCardBinVerificationProperties.Message
            };

            var expectedBinVerification = new BinVerification
            {
                Response = randomExpectedCardBinVerificationResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetCardBinVerificationAsync(inputBin))
                    .ReturnsAsync(randomExternalCardBinVerificationResponse);

            // when
            BinVerification actualBillPaymentsStatus =
               await this.miscellaneousService.GetCardBinVerificationAsync(inputBin);

            // then
            actualBillPaymentsStatus.Should().BeEquivalentTo(expectedBinVerification);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetCardBinVerificationAsync(inputBin),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}