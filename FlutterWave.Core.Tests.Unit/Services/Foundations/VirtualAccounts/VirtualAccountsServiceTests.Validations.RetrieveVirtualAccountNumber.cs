



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualAccounts
{
    public partial class VirtualAccountsServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnRetrieveVirtualAccountsNumberIfInvalidOrderReferenceAsync(
            string invalidOrderReference)
        {
            // given
            var invalidVirtualAccountsException =
                new InvalidVirtualAccountsException();

            invalidVirtualAccountsException.AddData(
                key: nameof(FetchVirtualAccounts),
                values: "Value is required");

            var expectedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(invalidVirtualAccountsException);

            // when
            ValueTask<FetchVirtualAccounts> retrieveVirtualAccountsTask =
                this.virtualAccountsService.GetVirtualAccountNumberRequestAsync(invalidOrderReference);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(
                    retrieveVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should()
                .BeEquivalentTo(expectedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualAccountNumberRequestAsync(
                   It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }



    }
}