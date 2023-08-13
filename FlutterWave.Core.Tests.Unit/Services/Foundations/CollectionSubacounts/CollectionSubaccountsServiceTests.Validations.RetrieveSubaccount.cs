using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.CollectionSubaccount
{
    public partial class CollectionSubaccountsServiceTests
    {
        [Theory]
        [InlineData(0)]
        public async Task ShouldThrowValidationExceptionOnRetrieveSubaccountWitSubaccountIdDataIsInvalidAsync(
            int invalidFetchSubaccountId)
        {
            // given
            var invalidCollectionSubaccountsException =
                new InvalidCollectionSubaccountsException();

            invalidCollectionSubaccountsException.AddData(
                key: nameof(FetchSubaccount),
                values: "Value is required");

            var expectedCollectionSubaccountsValidationException =
                new CollectionSubaccountsValidationException(invalidCollectionSubaccountsException);

            // when
            ValueTask<FetchSubaccount> retrieveCollectionSubaccountsTask =
                this.collectionSubaccountsService.GetSubaccountRequestAsync(invalidFetchSubaccountId);

            CollectionSubaccountsValidationException actualCollectionSubaccountsValidationException =
                await Assert.ThrowsAsync<CollectionSubaccountsValidationException>(
                    retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsValidationException.Should()
                .BeEquivalentTo(expectedCollectionSubaccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountAsync(
                    It.IsAny<int>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}