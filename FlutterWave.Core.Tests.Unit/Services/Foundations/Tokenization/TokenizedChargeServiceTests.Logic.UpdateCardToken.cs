



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.TokenizedCharge
{
    public partial class TokenizedChargeServiceTests
    {
        [Fact]
        public async Task ShouldPostUpdateCardTokenWithUpdateCardTokenRequestAsync()
        {
            // given 



            dynamic createRandomUpdateCardTokenRequestProperties =
              CreateRandomUpdateCardTokenRequestProperties();

            dynamic createRandomUpdateCardTokenResponseProperties =
                CreateRandomUpdateCardTokenResponseProperties();


            var randomExternalUpdateCardTokenRequest = new ExternalUpdateCardTokenRequest
            {
                Email = createRandomUpdateCardTokenRequestProperties.Email,
                FullName = createRandomUpdateCardTokenRequestProperties.FullName,
                PhoneNumber = createRandomUpdateCardTokenRequestProperties.PhoneNumber,


            };

            var randomExternalUpdateCardTokenResponse = new ExternalUpdateCardTokenResponse
            {
                Data = new ExternalUpdateCardTokenResponse.ExternalUpdateCardTokenData
                {
                    CreatedAt = createRandomUpdateCardTokenResponseProperties.Data.CreatedAt,
                    CustomerEmail = createRandomUpdateCardTokenResponseProperties.Data.CustomerEmail,
                    CustomerFullName = createRandomUpdateCardTokenResponseProperties.Data.CustomerFullName,
                    CustomerPhoneNumber = createRandomUpdateCardTokenResponseProperties.Data.CustomerPhoneNumber



                },
                Message = createRandomUpdateCardTokenResponseProperties.Message,
                Status = createRandomUpdateCardTokenResponseProperties.Status,

            };


            var randomUpdateCardTokenRequest = new UpdateCardTokenRequest
            {
                Email = createRandomUpdateCardTokenRequestProperties.Email,
                FullName = createRandomUpdateCardTokenRequestProperties.FullName,
                PhoneNumber = createRandomUpdateCardTokenRequestProperties.PhoneNumber,

            };

            var randomUpdateCardTokenResponse = new UpdateCardTokenResponse
            {

                Data = new UpdateCardTokenResponse.UpdateCardTokenData
                {
                    CreatedAt = createRandomUpdateCardTokenResponseProperties.Data.CreatedAt,
                    CustomerEmail = createRandomUpdateCardTokenResponseProperties.Data.CustomerEmail,
                    CustomerFullName = createRandomUpdateCardTokenResponseProperties.Data.CustomerFullName,
                    CustomerPhoneNumber = createRandomUpdateCardTokenResponseProperties.Data.CustomerPhoneNumber


                },
                Message = createRandomUpdateCardTokenResponseProperties.Message,
                Status = createRandomUpdateCardTokenResponseProperties.Status,

            };


            var randomUpdateCardToken = new UpdateCardToken
            {
                Request = randomUpdateCardTokenRequest,
            };

            var randomToken = GetRandomString();

            UpdateCardToken inputUpdateCardToken = randomUpdateCardToken;
            UpdateCardToken expectedUpdateCardToken = inputUpdateCardToken.DeepClone();
            expectedUpdateCardToken.Response = randomUpdateCardTokenResponse;

            ExternalUpdateCardTokenRequest mappedExternalUpdateCardTokenRequest =
               randomExternalUpdateCardTokenRequest;

            ExternalUpdateCardTokenResponse returnedExternalUpdateCardTokenResponse =
                randomExternalUpdateCardTokenResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostUpdateCardTokenAsync(It.IsAny<string>(), It.Is(
                      SameExternalUpdateCardTokenRequestAs(mappedExternalUpdateCardTokenRequest))))
                     .ReturnsAsync(returnedExternalUpdateCardTokenResponse);

            // when
            UpdateCardToken actualCreateUpdateCardToken =
               await this.tokenizedChargeService.PostUpdateCardTokenRequestAsync(randomToken, inputUpdateCardToken);

            // then
            actualCreateUpdateCardToken.Should().BeEquivalentTo(expectedUpdateCardToken);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostUpdateCardTokenAsync(It.IsAny<string>(), It.Is(
                   SameExternalUpdateCardTokenRequestAs(mappedExternalUpdateCardTokenRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}