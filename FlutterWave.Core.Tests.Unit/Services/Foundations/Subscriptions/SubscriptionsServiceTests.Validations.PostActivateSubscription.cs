



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscription;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Subscriptions
{
    public partial class SubscriptionsServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnPostActivateSubscriptionWithSubscriptionIdDataIsInvalidAsync(
            string invalidSubscriptionId)
        {
            // given
            var invalidSubscriptionException =
                new InvalidSubscriptionsException();

            invalidSubscriptionException.AddData(
                key: nameof(Subscription),
                values: "Value is required");

            var expectedSubscriptionValidationException =
                new SubscriptionsValidationException(invalidSubscriptionException);

            // when
            ValueTask<Subscription> retrieveSubscriptionTask =
                this.subscriptionsService.PostActivateSubscriptionAsync(invalidSubscriptionId);

            SubscriptionsValidationException actualSubscriptionValidationException =
                await Assert.ThrowsAsync<SubscriptionsValidationException>(
                    retrieveSubscriptionTask.AsTask);

            // then
            actualSubscriptionValidationException.Should()
                .BeEquivalentTo(expectedSubscriptionValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostActivateSubscriptionAsync(
                    It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}