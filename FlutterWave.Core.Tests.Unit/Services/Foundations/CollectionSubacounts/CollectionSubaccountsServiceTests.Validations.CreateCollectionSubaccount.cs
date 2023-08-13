using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCollectionSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.CollectionSubaccount
{
    public partial class CollectionSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateCollectionSubaccountIfCollectionSubaccountsRequestIsNullAsync()
        {
            // given
            CreateCollectionSubaccount? nullCollectionSubaccounts = null;
            var nullCollectionSubaccountsException = new NullCollectionSubaccountsException();

            var exceptedCollectionSubaccountsValidationException =
                new CollectionSubaccountsValidationException(nullCollectionSubaccountsException);

            // when
            ValueTask<CreateCollectionSubaccount> PaymentsTask =
                this.collectionSubaccountsService.PostCreateCollectionSubaccountRequestAsync(nullCollectionSubaccounts);

            CollectionSubaccountsValidationException actualCollectionSubaccountsValidationException =
                await Assert.ThrowsAsync<CollectionSubaccountsValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualCollectionSubaccountsValidationException.Should()
                .BeEquivalentTo(exceptedCollectionSubaccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateCollectionSubaccountAsync(
                    It.IsAny<ExternalCreateCollectionSubaccountRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateCollectionSubaccountIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new CreateCollectionSubaccount();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidCollectionSubaccountsException();

            invalidPaymentsException.AddData(
                key: nameof(CreateCollectionSubaccountRequest),
                values: "Value is required");

            var expectedCollectionSubaccountsValidationException =
                new CollectionSubaccountsValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<CreateCollectionSubaccount> CreateCollectionSubaccountTask =
                this.collectionSubaccountsService.PostCreateCollectionSubaccountRequestAsync(invalidPayments);

            CollectionSubaccountsValidationException actualCollectionSubaccountsValidationException =
                await Assert.ThrowsAsync<CollectionSubaccountsValidationException>(
                    CreateCollectionSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsValidationException.Should()
                .BeEquivalentTo(expectedCollectionSubaccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateCollectionSubaccountAsync(
                    It.IsAny<ExternalCreateCollectionSubaccountRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null, null)]
        [InlineData(0, "", "", "", "")]
        [InlineData(0, "  ", "  ", "  ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostCreateCollectionSubaccountIfCreateCollectionSubaccountIsInvalidAsync(
            double invalidSplitValue, string invalidBusinessName, string invalidBusinessMobile,
            string invalidAccountBank, string invalidAccountNumber)
        {
            // given
            var CreateCollectionSubaccount = new CreateCollectionSubaccount
            {
                Request = new CreateCollectionSubaccountRequest
                {
                    SplitValue = invalidSplitValue,
                    BusinessName = invalidBusinessName,
                    BusinessMobile = invalidBusinessMobile,
                    AccountBank = invalidAccountBank,
                    AccountNumber = invalidAccountNumber



                }
            };

            var invalidPaymentsException = new InvalidCollectionSubaccountsException();

            invalidPaymentsException.AddData(
                key: nameof(CreateCollectionSubaccountRequest.SplitValue),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateCollectionSubaccountRequest.BusinessMobile),
                values: "Value is required");


            invalidPaymentsException.AddData(
             key: nameof(CreateCollectionSubaccountRequest.BusinessName),
             values: "Value is required");

            invalidPaymentsException.AddData(
           key: nameof(CreateCollectionSubaccountRequest.AccountNumber),
           values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(CreateCollectionSubaccountRequest.AccountBank),
              values: "Value is required");



            var expectedCollectionSubaccountsValidationException =
                new CollectionSubaccountsValidationException(invalidPaymentsException);

            // when
            ValueTask<CreateCollectionSubaccount> CreateCollectionSubaccountTask =
                this.collectionSubaccountsService.PostCreateCollectionSubaccountRequestAsync(CreateCollectionSubaccount);

            CollectionSubaccountsValidationException actualCollectionSubaccountsValidationException =
                await Assert.ThrowsAsync<CollectionSubaccountsValidationException>(CreateCollectionSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCreateCollectionSubaccountIfPostCreateCollectionSubaccountIsEmptyAsync()
        {
            // given
            var CreateCollectionSubaccount = new CreateCollectionSubaccount
            {
                Request = new CreateCollectionSubaccountRequest
                {

                    BusinessName = string.Empty,
                    BusinessMobile = string.Empty,
                    AccountBank = string.Empty,
                    AccountNumber = string.Empty,
                }
            };

            var invalidPaymentsException = new InvalidCollectionSubaccountsException();

            invalidPaymentsException.AddData(
             key: nameof(CreateCollectionSubaccountRequest.SplitValue),
             values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateCollectionSubaccountRequest.BusinessMobile),
                values: "Value is required");



            invalidPaymentsException.AddData(
             key: nameof(CreateCollectionSubaccountRequest.BusinessName),
             values: "Value is required");

            invalidPaymentsException.AddData(
           key: nameof(CreateCollectionSubaccountRequest.AccountNumber),
           values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(CreateCollectionSubaccountRequest.AccountBank),
              values: "Value is required");

            var expectedCollectionSubaccountsValidationException =
                new CollectionSubaccountsValidationException(invalidPaymentsException);

            // when
            ValueTask<CreateCollectionSubaccount> CreateCollectionSubaccountTask =
                this.collectionSubaccountsService.PostCreateCollectionSubaccountRequestAsync(CreateCollectionSubaccount);

            CollectionSubaccountsValidationException actualCollectionSubaccountsValidationException =
                await Assert.ThrowsAsync<CollectionSubaccountsValidationException>(
                    CreateCollectionSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}