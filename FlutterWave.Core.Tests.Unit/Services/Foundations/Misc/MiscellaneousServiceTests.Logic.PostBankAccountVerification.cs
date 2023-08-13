



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Miscellaneous
{
    public partial class MiscellaneousServiceTests
    {
        [Fact]
        public async Task ShouldPostBankAccountVerificationWithBankAccountVerificationRequestAsync()
        {
            // given 
            string randomAccountNumber = GetRandomString();
            string randomAccountBank = GetRandomString();
            string inputAccountNumber = randomAccountNumber;
            string inputAccountBank = randomAccountBank;


            dynamic createRandomBankAccountVerificationProperties =
                  CreateRandomBankAccountVerificationProperties();


            var randomExternalBankAccountVerificationRequest = new ExternalBankAccountVerificationRequest
            {
                AccountBank = inputAccountBank,
                AccountNumber = inputAccountNumber,

            };

            var randomExternalBankAccountVerificationResponse = new ExternalBankAccountVerificationResponse
            {

                Message = createRandomBankAccountVerificationProperties.Message,
                Status = createRandomBankAccountVerificationProperties.Status,
                Data = new ExternalBankAccountVerificationResponse.ExternalBankAccountVerificationData
                {
                    AccountNumber = createRandomBankAccountVerificationProperties.Data.AccountNumber,
                    AccountName = createRandomBankAccountVerificationProperties.Data.AccountName,
                }

            };



            var randomBankAccountVerificationRequest = new BankAccountVerificationRequest
            {
                AccountBank = inputAccountBank,
                AccountNumber = inputAccountNumber,

            };

            var randomBankAccountVerificationResponse = new BankAccountVerificationResponse
            {

                Message = createRandomBankAccountVerificationProperties.Message,
                Status = createRandomBankAccountVerificationProperties.Status,
                Data = new BankAccountVerificationResponse.BankAccountVerificationData
                {
                    AccountNumber = createRandomBankAccountVerificationProperties.Data.AccountNumber,
                    AccountName = createRandomBankAccountVerificationProperties.Data.AccountName,
                }

            };

            var randomBankAccountVerification = new BankAccountVerification
            {
                Request = randomBankAccountVerificationRequest,
            };

            BankAccountVerification inputBankAccountVerification = randomBankAccountVerification;
            BankAccountVerification expectedBankAccountVerification = inputBankAccountVerification.DeepClone();
            expectedBankAccountVerification.Response = randomBankAccountVerificationResponse;

            ExternalBankAccountVerificationRequest mappedExternalBankAccountVerificationRequest =
               randomExternalBankAccountVerificationRequest;

            ExternalBankAccountVerificationResponse returnedExternalBankAccountVerificationResponse =
                randomExternalBankAccountVerificationResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
             broker.PostBankAccountVerificationAsync(It.Is(
                 SameExternalBankAccountVerificationRequestAs(mappedExternalBankAccountVerificationRequest))))
                .ReturnsAsync(returnedExternalBankAccountVerificationResponse);

            // when
            BankAccountVerification actualBankAccountVerifications =
                await this.miscellaneousService.PostBankAccountVerificationAsync(inputBankAccountVerification);

            // then
            actualBankAccountVerifications.Should().BeEquivalentTo(expectedBankAccountVerification);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostBankAccountVerificationAsync(It.Is(
                   SameExternalBankAccountVerificationRequestAs(mappedExternalBankAccountVerificationRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}