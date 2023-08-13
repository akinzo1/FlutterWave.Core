



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalOtp;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Otp
{
    public partial class OtpServiceTests
    {
        [Fact]
        public async Task ShouldPostValidateOtpWithValidateOtpRequestAsync()
        {
            // given
            string inputOtp = GetRandomString();
            string inputOtpReference = GetRandomString();


            dynamic createRandomOtpProperties =
                   CreateRandomValidateOtpProperties();


            var randomExternalValidateOtpRequest = new ExternalValidateOtpRequest
            {

                Otp = inputOtp

            };


            var randomExternalValidateOtpResponse = new ExternalValidateOtpResponse
            {

                Message = createRandomOtpProperties.Message,
                Status = createRandomOtpProperties.Status,
                Data = createRandomOtpProperties.Data

            };



            var randomValidateOtpRequest = new ValidateOtpRequest
            {
                Otp = inputOtp

            };

            var randomValidateOtpResponse = new ValidateOtpResponse
            {

                Message = createRandomOtpProperties.Message,
                Status = createRandomOtpProperties.Status,
                Data = createRandomOtpProperties.Data

            };

            var randomValidateOtp = new ValidateOtp
            {
                Request = randomValidateOtpRequest,
            };

            ValidateOtp inputValidateOtp = randomValidateOtp;
            ValidateOtp expectedValidateOtp = inputValidateOtp.DeepClone();
            expectedValidateOtp.Response = randomValidateOtpResponse;

            ExternalValidateOtpRequest mappedExternalValidateOtpRequest =
               randomExternalValidateOtpRequest;

            ExternalValidateOtpResponse returnedExternalValidateOtpResponse =
                randomExternalValidateOtpResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
             broker.PostValidateOtpAsync(inputOtpReference, It.Is(
                 SameExternalValidateOtpRequestAs(mappedExternalValidateOtpRequest))))
                .ReturnsAsync(returnedExternalValidateOtpResponse);

            // when
            ValidateOtp actualValidateOtp =
                await this.otpService.PostValidateOtpAsync(inputOtpReference, inputValidateOtp);

            // then
            actualValidateOtp.Should().BeEquivalentTo(expectedValidateOtp);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostValidateOtpAsync(inputOtpReference, It.Is(
                   SameExternalValidateOtpRequestAs(mappedExternalValidateOtpRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}