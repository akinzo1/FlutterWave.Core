using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalChargeBack;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.ChargeBacks
{
    public partial class ChargeBackServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAcceptDeclineChargeBackIfChargeBacksIsNullAsync()
        {
            // given


            AcceptDeclineChargeBack? nullAcceptDecline = null;
            var nullAcceptDeclineException = new NullChargeBackException();

            var exceptedChargeBackValidationException =
                new ChargeBackValidationException(nullAcceptDeclineException);

            // when
            ValueTask<AcceptDeclineChargeBack> ChargeBackTask =
                this.chargeBackService.PostAcceptDeclineChargeBacksAsync(It.IsAny<string>(), nullAcceptDecline);

            ChargeBackValidationException actualChargeBackValidationException =
                await Assert.ThrowsAsync<ChargeBackValidationException>(
                    ChargeBackTask.AsTask);

            // then
            actualChargeBackValidationException.Should()
                .BeEquivalentTo(exceptedChargeBackValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(),
                    It.IsAny<ExternalAcceptDeclineChargeBackRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnAcceptDeclineIfRequestIsNullAsync()
        {
            // given
            var invalidChargeBack = new AcceptDeclineChargeBack();
            invalidChargeBack.Request = null;

            var invalidChargeBackException =
                new InvalidChargeBackException();

            invalidChargeBackException.AddData(
                key: nameof(AcceptDeclineChargeBackRequest),
                values: "Value is required");


            var expectedChargeBackValidationException =
                new ChargeBackValidationException(
                    invalidChargeBackException);

            // when
            ValueTask<AcceptDeclineChargeBack> AcceptDeclineChargeBackTask =
                this.chargeBackService.PostAcceptDeclineChargeBacksAsync(It.IsAny<string>(), invalidChargeBack);

            ChargeBackValidationException actualChargeBackValidationException =
                await Assert.ThrowsAsync<ChargeBackValidationException>(
                    AcceptDeclineChargeBackTask.AsTask);

            // then
            actualChargeBackValidationException.Should()
                .BeEquivalentTo(expectedChargeBackValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.CreateAcceptDeclineChargeBacksAsync(It.IsAny<string>(),
                    It.IsAny<ExternalAcceptDeclineChargeBackRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("", "", "")]
        [InlineData("  ", "  ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostChargeBackIfChargeBackIsInvalidAsync(
            string invalidAccount, string invalidComment, string invalidChargeBackId)
        {
            // given
            var AcceptDeclineChargeBack = new AcceptDeclineChargeBack
            {
                Request = new AcceptDeclineChargeBackRequest
                {
                    Action = invalidAccount,
                    Comment = invalidComment


                }
            };

            var invalidChargeBackException = new InvalidChargeBackException();

            invalidChargeBackException.AddData(
                key: nameof(AcceptDeclineChargeBackRequest),
                values: "Value is required");

            invalidChargeBackException.AddData(
                   key: nameof(AcceptDeclineChargeBackRequest.Action),
                   values: "Value is required");

            invalidChargeBackException.AddData(
               key: nameof(AcceptDeclineChargeBackRequest.Comment),
               values: "Value is required");

            var expectedChargeBackValidationException =
                new ChargeBackValidationException(invalidChargeBackException);

            // when
            ValueTask<AcceptDeclineChargeBack> AcceptDeclineChargeBackTask =
                this.chargeBackService.PostAcceptDeclineChargeBacksAsync(invalidChargeBackId, AcceptDeclineChargeBack);

            ChargeBackValidationException actualChargeBackValidationException =
                await Assert.ThrowsAsync<ChargeBackValidationException>(AcceptDeclineChargeBackTask.AsTask);

            // then
            actualChargeBackValidationException.Should().BeEquivalentTo(
                expectedChargeBackValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostChargeBackIfPostChargeBackIsEmptyAsync()
        {
            // given
            var AcceptDeclineChargeBack = new AcceptDeclineChargeBack
            {
                Request = new AcceptDeclineChargeBackRequest
                {
                    Action = string.Empty,
                    Comment = string.Empty


                }
            };
            string inputChargeBackId = string.Empty;
            var invalidChargeBackException = new InvalidChargeBackException();

            invalidChargeBackException.AddData(
            key: nameof(AcceptDeclineChargeBackRequest),
            values: "Value is required");

            invalidChargeBackException.AddData(
               key: nameof(AcceptDeclineChargeBackRequest.Action),
               values: "Value is required");

            invalidChargeBackException.AddData(
               key: nameof(AcceptDeclineChargeBackRequest.Comment),
               values: "Value is required");

            var expectedChargeBackValidationException =
                new ChargeBackValidationException(invalidChargeBackException);

            // when
            ValueTask<AcceptDeclineChargeBack> AcceptDeclineChargeBackTask =
                this.chargeBackService.PostAcceptDeclineChargeBacksAsync(inputChargeBackId, AcceptDeclineChargeBack);

            ChargeBackValidationException actualChargeBackValidationException =
                await Assert.ThrowsAsync<ChargeBackValidationException>(
                    AcceptDeclineChargeBackTask.AsTask);

            // then
            actualChargeBackValidationException.Should().BeEquivalentTo(
                expectedChargeBackValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}