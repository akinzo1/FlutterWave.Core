



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
        public async Task ShouldPostBvnConsentWithBvnConsentRequestAsync()
        {
            // given 
            string randomBvn = GetRandomString();
            string randomFirstName = GetRandomString();
            string inputBvn = randomBvn;
            string inputFirstName = randomFirstName;
            string randomLastName = GetRandomString();
            string randomRedirectUrl = GetRandomString();
            string inputLastName = randomLastName;
            string inputRedirectUrl = randomRedirectUrl;


            dynamic createRandomBvnConsentProperties =
                  CreateRandomBvnConsentProperties();


            var randomExternalBvnConsentRequest = new ExternalBvnConsentRequest
            {
                Bvn = inputBvn,
                Firstname = inputFirstName,
                Lastname = inputLastName,
                RedirectUrl = inputRedirectUrl,


            };


            var randomExternalBvnConsentResponse = new ExternalBvnConsentResponse
            {

                Data = new ExternalBvnConsentResponse.ExternalBvnConsentData
                {
                    Reference = createRandomBvnConsentProperties.Data.Reference,
                    Url = createRandomBvnConsentProperties.Data.Url
                },
                Message = createRandomBvnConsentProperties.Message,
                Status = createRandomBvnConsentProperties.Status,


            };



            var randomBvnConsentRequest = new BvnConsentRequest
            {

                Bvn = inputBvn,
                FirstName = inputFirstName,
                LastName = inputLastName,
                RedirectUrl = inputRedirectUrl,
            };

            var randomBvnConsentResponse = new BvnConsentResponse
            {

                Data = new BvnConsentResponse.BvnConsentData
                {
                    Reference = createRandomBvnConsentProperties.Data.Reference,
                    Url = createRandomBvnConsentProperties.Data.Url
                },
                Message = createRandomBvnConsentProperties.Message,
                Status = createRandomBvnConsentProperties.Status,


            };

            var randomBvnConsent = new BvnConsent
            {
                Request = randomBvnConsentRequest,
            };

            BvnConsent inputBvnConsent = randomBvnConsent;
            BvnConsent expectedBvnConsent = inputBvnConsent.DeepClone();
            expectedBvnConsent.Response = randomBvnConsentResponse;

            ExternalBvnConsentRequest mappedExternalBvnConsentRequest =
               randomExternalBvnConsentRequest;

            ExternalBvnConsentResponse returnedExternalBvnConsentResponse =
                randomExternalBvnConsentResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
             broker.PostBvnConsentAsync(It.Is(
                 SameExternalBvnConsentRequestRequestAs(mappedExternalBvnConsentRequest))))
                .ReturnsAsync(returnedExternalBvnConsentResponse);

            // when
            BvnConsent actualBvnConsents =
                await this.miscellaneousService.PostBvnConsentAsync(inputBvnConsent);

            // then
            actualBvnConsents.Should().BeEquivalentTo(expectedBvnConsent);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostBvnConsentAsync(It.Is(
                   SameExternalBvnConsentRequestRequestAs(mappedExternalBvnConsentRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}