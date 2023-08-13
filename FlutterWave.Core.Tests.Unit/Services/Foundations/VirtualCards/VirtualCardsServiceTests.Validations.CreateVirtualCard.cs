



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateVirtualCardsIfRequestIsNullAsync()
        {
            // given
            CreateVirtualCard? nullVirtualCards = null;
            var nullVirtualCardsException = new NullVirtualCardsException();

            var exceptedVirtualCardsValidationException =
                new VirtualCardsValidationException(nullVirtualCardsException);

            // when
            ValueTask<CreateVirtualCard> PaymentsTask =
                this.virtualCardsService.PostCreateVirtualCardRequestAsync(nullVirtualCards);

            VirtualCardsValidationException actualVirtualCardsValidationException =
                await Assert.ThrowsAsync<VirtualCardsValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualVirtualCardsValidationException.Should()
                .BeEquivalentTo(exceptedVirtualCardsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualCardAsync(
                    It.IsAny<ExternalCreateVirtualCardRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateVirtualCardIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new CreateVirtualCard();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidVirtualCardsException();

            invalidPaymentsException.AddData(
                key: nameof(CreateVirtualCardRequest),
                values: "Value is required");

            var expectedVirtualCardsValidationException =
                new VirtualCardsValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<CreateVirtualCard> CreateVirtualCardTask =
                this.virtualCardsService.PostCreateVirtualCardRequestAsync(invalidPayments);

            VirtualCardsValidationException actualVirtualCardsValidationException =
                await Assert.ThrowsAsync<VirtualCardsValidationException>(
                    CreateVirtualCardTask.AsTask);

            // then
            actualVirtualCardsValidationException.Should()
                .BeEquivalentTo(expectedVirtualCardsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualCardAsync(
                    It.IsAny<ExternalCreateVirtualCardRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null, null, null, null, null, null)]
        [InlineData(0, "", "", "", "", "", "", "", "")]
        [InlineData(0, "  ", "  ", "  ", " ", " ", " ", " ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostCreateVirtualCardIfCreateVirtualCardIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidCurrency,
            string invalidFirstName, string invalidLastName, string invalidPhone, string invalidTitle, string invalidGender, string invalidDateOfBirth)
        {
            // given
            var CreateVirtualCard = new CreateVirtualCard
            {
                Request = new CreateVirtualCardRequest
                {
                    Amount = invalidAmount,
                    Email = invalidEmail,
                    Currency = invalidCurrency,
                    FirstName = invalidFirstName,
                    LastName = invalidLastName,
                    Phone = invalidPhone,
                    Title = invalidTitle,
                    Gender = invalidGender,
                    DateOfBirth = invalidDateOfBirth


                }
            };

            var invalidPaymentsException = new InvalidVirtualCardsException();

            invalidPaymentsException.AddData(
                key: nameof(CreateVirtualCardRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateVirtualCardRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(CreateVirtualCardRequest.LastName),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(CreateVirtualCardRequest.Amount),
             values: "Value is required");

            invalidPaymentsException.AddData(
           key: nameof(CreateVirtualCardRequest.FirstName),
           values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(CreateVirtualCardRequest.Title),
              values: "Value is required");

            invalidPaymentsException.AddData(
            key: nameof(CreateVirtualCardRequest.Gender),
            values: "Value is required");

            invalidPaymentsException.AddData(
            key: nameof(CreateVirtualCardRequest.DateOfBirth),
            values: "Value is required");

            invalidPaymentsException.AddData(
            key: nameof(CreateVirtualCardRequest.Phone),
            values: "Value is required");

            var expectedVirtualCardsValidationException =
                new VirtualCardsValidationException(invalidPaymentsException);

            // when
            ValueTask<CreateVirtualCard> CreateVirtualCardTask =
                this.virtualCardsService.PostCreateVirtualCardRequestAsync(CreateVirtualCard);

            VirtualCardsValidationException actualVirtualCardsValidationException =
                await Assert.ThrowsAsync<VirtualCardsValidationException>(CreateVirtualCardTask.AsTask);

            // then
            actualVirtualCardsValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCreateVirtualCardIfPostCreateVirtualCardIsEmptyAsync()
        {
            // given
            var CreateVirtualCard = new CreateVirtualCard
            {
                Request = new CreateVirtualCardRequest
                {
                    Email = string.Empty,
                    Currency = string.Empty,
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    Phone = string.Empty,
                    Title = string.Empty,
                    Gender = string.Empty,
                    DateOfBirth = string.Empty
                }
            };

            var invalidPaymentsException = new InvalidVirtualCardsException();

            invalidPaymentsException.AddData(
                key: nameof(CreateVirtualCardRequest.Currency),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateVirtualCardRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(CreateVirtualCardRequest.LastName),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(CreateVirtualCardRequest.Amount),
             values: "Value is required");

            invalidPaymentsException.AddData(
           key: nameof(CreateVirtualCardRequest.FirstName),
           values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(CreateVirtualCardRequest.Title),
              values: "Value is required");

            invalidPaymentsException.AddData(
            key: nameof(CreateVirtualCardRequest.Gender),
            values: "Value is required");

            invalidPaymentsException.AddData(
            key: nameof(CreateVirtualCardRequest.DateOfBirth),
            values: "Value is required");

            invalidPaymentsException.AddData(
            key: nameof(CreateVirtualCardRequest.Phone),
            values: "Value is required");

            var expectedVirtualCardsValidationException =
                new VirtualCardsValidationException(invalidPaymentsException);

            // when
            ValueTask<CreateVirtualCard> CreateVirtualCardTask =
                this.virtualCardsService.PostCreateVirtualCardRequestAsync(CreateVirtualCard);

            VirtualCardsValidationException actualVirtualCardsValidationException =
                await Assert.ThrowsAsync<VirtualCardsValidationException>(
                    CreateVirtualCardTask.AsTask);

            // then
            actualVirtualCardsValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}