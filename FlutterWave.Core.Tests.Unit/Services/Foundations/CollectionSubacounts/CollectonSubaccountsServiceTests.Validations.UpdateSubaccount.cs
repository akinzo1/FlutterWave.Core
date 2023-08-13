using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCollectionSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.CollectionSubaccount
{
    public partial class CollectionSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdateSubaccountIfUpdateSubaccountIsNullAsync()
        {
            // given
            UpdateSubaccount? nullCollectionSubaccounts = null;
            var nullCollectionSubaccountsException = new NullCollectionSubaccountsException();

            var exceptedCollectionSubaccountsValidationException =
                new CollectionSubaccountsValidationException(nullCollectionSubaccountsException);

            // when
            ValueTask<UpdateSubaccount> PaymentsTask =
                this.collectionSubaccountsService.PostUpdateCollectionSubaccountRequestAsync(It.IsAny<int>(), nullCollectionSubaccounts);

            CollectionSubaccountsValidationException actualCollectionSubaccountsValidationException =
                await Assert.ThrowsAsync<CollectionSubaccountsValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualCollectionSubaccountsValidationException.Should()
                .BeEquivalentTo(exceptedCollectionSubaccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(),
                    It.IsAny<ExternalUpdateSubaccountRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdateSubaccountIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new UpdateSubaccount();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidCollectionSubaccountsException();

            invalidPaymentsException.AddData(
                key: nameof(UpdateSubaccountRequest),
                values: "Value is required");

            var expectedCollectionSubaccountsValidationException =
                new CollectionSubaccountsValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<UpdateSubaccount> UpdateSubaccountTask =
                this.collectionSubaccountsService.PostUpdateCollectionSubaccountRequestAsync(It.IsAny<int>(), invalidPayments);

            CollectionSubaccountsValidationException actualCollectionSubaccountsValidationException =
                await Assert.ThrowsAsync<CollectionSubaccountsValidationException>(
                    UpdateSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsValidationException.Should()
                .BeEquivalentTo(expectedCollectionSubaccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(),
                    It.IsAny<ExternalUpdateSubaccountRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnPostUpdateSubaccountIfUpdateSubaccountIsInvalidAsync(
            string invalidSplitType)
        {
            // given
            var UpdateSubaccount = new UpdateSubaccount
            {
                Request = new UpdateSubaccountRequest
                {
                    SplitType = invalidSplitType




                }
            };

            var subaccountId = GetRandomNumber();

            var invalidPaymentsException = new InvalidCollectionSubaccountsException();

            invalidPaymentsException.AddData(
                key: nameof(UpdateSubaccountRequest.SplitValue),
                values: "Value is required");







            var expectedCollectionSubaccountsValidationException =
                new CollectionSubaccountsValidationException(invalidPaymentsException);

            // when
            ValueTask<UpdateSubaccount> UpdateSubaccountTask =
                this.collectionSubaccountsService.PostUpdateCollectionSubaccountRequestAsync(subaccountId, UpdateSubaccount);

            CollectionSubaccountsValidationException actualCollectionSubaccountsValidationException =
                await Assert.ThrowsAsync<CollectionSubaccountsValidationException>(UpdateSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }


    }
}