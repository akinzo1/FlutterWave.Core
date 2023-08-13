using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.CollectionSubaccount
{
    public partial class CollectionSubaccountsServiceTests
    {
        [Theory]
        [InlineData(0)]
        public async Task ShouldThrowValidationExceptionOnDeleteubaccountWitSubaccountIdDataIsInvalidAsync(
            int invalidDeleteSubaccountId)
        {
            // given
            var invalidCollectionSubaccountsException =
                new InvalidCollectionSubaccountsException();

            invalidCollectionSubaccountsException.AddData(
                key: nameof(DeleteSubaccount),
                values: "Value is required");

            var expectedCollectionSubaccountsValidationException =
                new CollectionSubaccountsValidationException(invalidCollectionSubaccountsException);

            // when
            ValueTask<DeleteSubaccount> retrieveCollectionSubaccountsTask =
                this.collectionSubaccountsService.DeleteCollectionSubaccountRequestAsync(invalidDeleteSubaccountId);

            CollectionSubaccountsValidationException actualCollectionSubaccountsValidationException =
                await Assert.ThrowsAsync<CollectionSubaccountsValidationException>(
                    retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsValidationException.Should()
                .BeEquivalentTo(expectedCollectionSubaccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteCollectionSubaccountAsync(
                    It.IsAny<int>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}