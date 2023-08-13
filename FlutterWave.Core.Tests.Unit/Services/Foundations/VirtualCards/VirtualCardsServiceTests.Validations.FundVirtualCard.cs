



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnFundVirtualCardsIfRequestIsNullAsync()
        {
            // given


            FundVirtualCard? nullVirtualCards = null;
            var nullVirtualCardsException = new NullVirtualCardsException();

            var exceptedVirtualCardsValidationException =
                new VirtualCardsValidationException(nullVirtualCardsException);

            // when
            ValueTask<FundVirtualCard> PaymentsTask =
                this.virtualCardsService.PostFundVirtualCardRequestAsync(It.IsAny<string>(), nullVirtualCards);

            VirtualCardsValidationException actualVirtualCardsValidationException =
                await Assert.ThrowsAsync<VirtualCardsValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualVirtualCardsValidationException.Should()
                .BeEquivalentTo(exceptedVirtualCardsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostFundVirtualCardAsync(It.IsAny<string>(),
                    It.IsAny<ExternalFundVirtualCardRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnFundVirtualCardIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new FundVirtualCard();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidVirtualCardsException();

            invalidPaymentsException.AddData(
                key: nameof(FundVirtualCardRequest),
                values: "Value is required");

            var expectedVirtualCardsValidationException =
                new VirtualCardsValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<FundVirtualCard> FundVirtualCardTask =
                this.virtualCardsService.PostFundVirtualCardRequestAsync(It.IsAny<string>(), invalidPayments);

            VirtualCardsValidationException actualVirtualCardsValidationException =
                await Assert.ThrowsAsync<VirtualCardsValidationException>(
                    FundVirtualCardTask.AsTask);

            // then
            actualVirtualCardsValidationException.Should()
                .BeEquivalentTo(expectedVirtualCardsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostFundVirtualCardAsync(It.IsAny<string>(),
                    It.IsAny<ExternalFundVirtualCardRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null)]
        [InlineData(0, "")]
        [InlineData(0, "  ")]
        public async Task ShouldThrowValidationExceptionOnPostFundVirtualCardIfFundVirtualCardIsInvalidAsync(
            int invalidAmount, string invalidDebitCurrency)
        {
            // given
            var FundVirtualCard = new FundVirtualCard
            {
                Request = new FundVirtualCardRequest
                {
                    Amount = invalidAmount,
                    DebitCurrency = invalidDebitCurrency,


                }
            };

            var invalidPaymentsException = new InvalidVirtualCardsException();

            invalidPaymentsException.AddData(
              key: nameof(FundVirtualCard),
              values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(FundVirtualCardRequest.Amount),
              values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(FundVirtualCardRequest.DebitCurrency),
              values: "Value is required");


            var expectedVirtualCardsValidationException =
                new VirtualCardsValidationException(invalidPaymentsException);

            // when
            ValueTask<FundVirtualCard> FundVirtualCardTask =
                this.virtualCardsService.PostFundVirtualCardRequestAsync(It.IsAny<string>(), FundVirtualCard);

            VirtualCardsValidationException actualVirtualCardsValidationException =
                await Assert.ThrowsAsync<VirtualCardsValidationException>(FundVirtualCardTask.AsTask);

            // then
            actualVirtualCardsValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostFundVirtualCardIfPostFundVirtualCardIsEmptyAsync()
        {
            // given
            var FundVirtualCard = new FundVirtualCard
            {
                Request = new FundVirtualCardRequest
                {

                    DebitCurrency = string.Empty,

                }
            };

            var invalidPaymentsException = new InvalidVirtualCardsException();

            invalidPaymentsException.AddData(
          key: nameof(FundVirtualCard),
          values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(FundVirtualCardRequest.Amount),
              values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(FundVirtualCardRequest.DebitCurrency),
              values: "Value is required");


            var expectedVirtualCardsValidationException =
                new VirtualCardsValidationException(invalidPaymentsException);

            // when
            ValueTask<FundVirtualCard> FundVirtualCardTask =
                this.virtualCardsService.PostFundVirtualCardRequestAsync(It.IsAny<string>(), FundVirtualCard);

            VirtualCardsValidationException actualVirtualCardsValidationException =
                await Assert.ThrowsAsync<VirtualCardsValidationException>(
                    FundVirtualCardTask.AsTask);

            // then
            actualVirtualCardsValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}