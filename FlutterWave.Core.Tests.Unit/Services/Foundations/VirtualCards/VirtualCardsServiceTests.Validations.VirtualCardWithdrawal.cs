



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Theory]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData(" ", 0)]
        public async Task ShouldThrowValidationExceptionOnVirtualCardWithdrawalWithVirtualCardIdDataIsInvalidAsync(
            string invalidVirtualCardId, int invalidAmount)
        {
            // given



            var randomVirtualCardWithdrawalRequest = new VirtualCardWithdrawal
            {
                Request = new VirtualCardWithdrawalRequest
                {
                    Amount = invalidAmount,
                }

            };

            var invalidVirtualCardsException =
                new InvalidVirtualCardsException();

            invalidVirtualCardsException.AddData(
                key: nameof(VirtualCardWithdrawal),
                values: "Value is required");

            invalidVirtualCardsException.AddData(
            key: nameof(VirtualCardWithdrawalRequest.Amount),
            values: "Value is required");

            var expectedVirtualCardsValidationException =
                new VirtualCardsValidationException(invalidVirtualCardsException);

            // when
            ValueTask<VirtualCardWithdrawal> retrieveVirtualCardsTask =
                this.virtualCardsService.PostVirtualCardWithdrawalRequestAsync(invalidVirtualCardId, randomVirtualCardWithdrawalRequest);

            VirtualCardsValidationException actualVirtualCardsValidationException =
                await Assert.ThrowsAsync<VirtualCardsValidationException>(
                    retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsValidationException.Should()
                .BeEquivalentTo(expectedVirtualCardsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVirtualCardWithdrawalAsync(
                    It.IsAny<string>(), It.IsAny<ExternalVirtualCardWithdrawalRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnVirtualCardWithdrawalIfVirtualCardWithdrawalIsNullAsync()
        {
            // given


            VirtualCardWithdrawal? nullAcceptDecline = null;
            var nullAcceptDeclineException = new NullVirtualCardsException();

            var exceptedVirtualCardsValidationException =
                new VirtualCardsValidationException(nullAcceptDeclineException);

            // when
            ValueTask<VirtualCardWithdrawal> VirtualCardsTask =
                this.virtualCardsService.PostVirtualCardWithdrawalRequestAsync(It.IsAny<string>(), nullAcceptDecline);

            VirtualCardsValidationException actualVirtualCardsValidationException =
                await Assert.ThrowsAsync<VirtualCardsValidationException>(
                    VirtualCardsTask.AsTask);

            // then
            actualVirtualCardsValidationException.Should()
                .BeEquivalentTo(exceptedVirtualCardsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(),
                    It.IsAny<ExternalVirtualCardWithdrawalRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnAcceptDeclineIfRequestIsNullAsync()
        {
            // given
            var invalidVirtualCards = new VirtualCardWithdrawal();
            invalidVirtualCards.Request = null;

            var invalidVirtualCardsException =
                new InvalidVirtualCardsException();

            invalidVirtualCardsException.AddData(
                key: nameof(VirtualCardWithdrawalRequest),
                values: "Value is required");



            var expectedVirtualCardsValidationException =
                new VirtualCardsValidationException(
                    invalidVirtualCardsException);

            // when
            ValueTask<VirtualCardWithdrawal> VirtualCardWithdrawalTask =
                this.virtualCardsService.PostVirtualCardWithdrawalRequestAsync(It.IsAny<string>(), invalidVirtualCards);

            VirtualCardsValidationException actualVirtualCardsValidationException =
                await Assert.ThrowsAsync<VirtualCardsValidationException>(
                    VirtualCardWithdrawalTask.AsTask);

            // then
            actualVirtualCardsValidationException.Should()
                .BeEquivalentTo(expectedVirtualCardsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(),
                    It.IsAny<ExternalVirtualCardWithdrawalRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }


        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostVirtualCardsIfRequestIsEmptyAsync()
        {
            // given
            var VirtualCardWithdrawal = new VirtualCardWithdrawal
            {
                Request = new VirtualCardWithdrawalRequest
                {
                    Amount = 0,



                }
            };
            string inputVirtualCardsId = string.Empty;
            var invalidVirtualCardsException = new InvalidVirtualCardsException();

            invalidVirtualCardsException.AddData(
            key: nameof(VirtualCardWithdrawal),
            values: "Value is required");

            invalidVirtualCardsException.AddData(
               key: nameof(VirtualCardWithdrawalRequest.Amount),
               values: "Value is required");



            var expectedVirtualCardsValidationException =
                new VirtualCardsValidationException(invalidVirtualCardsException);

            // when
            ValueTask<VirtualCardWithdrawal> VirtualCardWithdrawalTask =
                this.virtualCardsService.PostVirtualCardWithdrawalRequestAsync(inputVirtualCardsId, VirtualCardWithdrawal);

            VirtualCardsValidationException actualVirtualCardsValidationException =
                await Assert.ThrowsAsync<VirtualCardsValidationException>(
                    VirtualCardWithdrawalTask.AsTask);

            // then
            actualVirtualCardsValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}