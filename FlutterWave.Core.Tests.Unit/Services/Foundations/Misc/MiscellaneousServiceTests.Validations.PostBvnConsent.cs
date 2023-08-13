



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
        public async Task ShouldThrowValidationExceptionOnBvnConsentIfBvnConsentRequestIsNullAsync()
        {
            // given
            BvnConsent? nullBvnConsent = null;
            var nullBvnConsentException = new NullMiscellaneousException();

            var exceptedMiscellaneousValidationException =
                new MiscellaneousValidationException(nullBvnConsentException);

            // when
            ValueTask<BvnConsent> MiscellaneousTask =
                this.miscellaneousService.PostBvnConsentAsync(nullBvnConsent);

            MiscellaneousValidationException actualMiscellaneousValidationException =
                await Assert.ThrowsAsync<MiscellaneousValidationException>(
                    MiscellaneousTask.AsTask);

            // then
            actualMiscellaneousValidationException.Should()
                .BeEquivalentTo(exceptedMiscellaneousValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBvnConsentAsync(
                    It.IsAny<ExternalBvnConsentRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnBvnConsentIfRequestIsNullAsync()
        {
            // given
            var invalidMiscellaneous = new BvnConsent();
            invalidMiscellaneous.Request = null;

            var invalidMiscellaneousException =
                new InvalidMiscellaneousException();

            invalidMiscellaneousException.AddData(
                key: nameof(BvnConsentRequest),
                values: "Value is required");


            var expectedMiscellaneousValidationException =
                new MiscellaneousValidationException(
                    invalidMiscellaneousException);

            // when
            ValueTask<BvnConsent> BvnConsentTask =
                this.miscellaneousService.PostBvnConsentAsync(invalidMiscellaneous);

            MiscellaneousValidationException actualMiscellaneousValidationException =
                await Assert.ThrowsAsync<MiscellaneousValidationException>(
                    BvnConsentTask.AsTask);

            // then
            actualMiscellaneousValidationException.Should()
                .BeEquivalentTo(expectedMiscellaneousValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBvnConsentAsync(
                    It.IsAny<ExternalBvnConsentRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, null, null)]
        [InlineData("", "", "", "")]
        [InlineData("  ", "  ", " ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostBvnConsentIfBvnConsentRequestIsInvalidAsync(
            string invalidBvn, string invalidFirstName, string invalidLastName, string invalidRedirectUrl)
        {
            // given
            var BvnConsent = new BvnConsent
            {
                Request = new BvnConsentRequest
                {
                    Bvn = invalidBvn,
                    FirstName = invalidFirstName,
                    LastName = invalidLastName,
                    RedirectUrl = invalidRedirectUrl


                }
            };

            var invalidMiscellaneousException = new InvalidMiscellaneousException();

            invalidMiscellaneousException.AddData(
                   key: nameof(BvnConsentRequest.LastName),
                   values: "Value is required");

            invalidMiscellaneousException.AddData(
               key: nameof(BvnConsentRequest.FirstName),
               values: "Value is required");

            invalidMiscellaneousException.AddData(
               key: nameof(BvnConsentRequest.Bvn),
               values: "Value is required");

            invalidMiscellaneousException.AddData(
              key: nameof(BvnConsentRequest.RedirectUrl),
              values: "Value is required");

            var expectedMiscellaneousValidationException =
                new MiscellaneousValidationException(invalidMiscellaneousException);

            // when
            ValueTask<BvnConsent> BvnConsentTask =
                this.miscellaneousService.PostBvnConsentAsync(BvnConsent);

            MiscellaneousValidationException actualMiscellaneousValidationException =
                await Assert.ThrowsAsync<MiscellaneousValidationException>(BvnConsentTask.AsTask);

            // then
            actualMiscellaneousValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostBvnConsentIfBvnConsentRequestIsEmptyAsync()
        {
            // given
            var BvnConsent = new BvnConsent
            {
                Request = new BvnConsentRequest
                {
                    Bvn = string.Empty,
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    RedirectUrl = string.Empty


                }
            };

            var invalidMiscellaneousException = new InvalidMiscellaneousException();


            invalidMiscellaneousException.AddData(
                   key: nameof(BvnConsentRequest.LastName),
                   values: "Value is required");

            invalidMiscellaneousException.AddData(
               key: nameof(BvnConsentRequest.FirstName),
               values: "Value is required");

            invalidMiscellaneousException.AddData(
               key: nameof(BvnConsentRequest.Bvn),
               values: "Value is required");

            invalidMiscellaneousException.AddData(
              key: nameof(BvnConsentRequest.RedirectUrl),
              values: "Value is required");

            var expectedMiscellaneousValidationException =
                new MiscellaneousValidationException(invalidMiscellaneousException);

            // when
            ValueTask<BvnConsent> BvnConsentTask =
                this.miscellaneousService.PostBvnConsentAsync(BvnConsent);

            MiscellaneousValidationException actualMiscellaneousValidationException =
                await Assert.ThrowsAsync<MiscellaneousValidationException>(
                    BvnConsentTask.AsTask);

            // then
            actualMiscellaneousValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}