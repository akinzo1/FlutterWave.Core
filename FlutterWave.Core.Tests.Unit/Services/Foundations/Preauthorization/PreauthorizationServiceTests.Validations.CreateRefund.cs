



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Preauthorization
{
    public partial class PreauthorizationServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreatePreauthorizationRefundIfCreatePreauthorizationRefundIsNullAsync()
        {
            // given
            CreatePreauthorizationRefund? nullPreauthorization = null;
            var nullPreauthorizationException = new NullPreauthorizationException();

            var exceptedPreauthorizationValidationException =
                new PreauthorizationValidationException(nullPreauthorizationException);

            // when
            ValueTask<CreatePreauthorizationRefund> PaymentsTask =
                this.preauthorizationService.PostCreateRefundRequestAsync(It.IsAny<string>(), nullPreauthorization);

            PreauthorizationValidationException actualPreauthorizationValidationException =
                await Assert.ThrowsAsync<PreauthorizationValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualPreauthorizationValidationException.Should()
                .BeEquivalentTo(exceptedPreauthorizationValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundAsync(It.IsAny<string>(),
                    It.IsAny<ExternalCreatePreauthorizationRefundRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreatePreauthorizationRefundIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new CreatePreauthorizationRefund();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidPreauthorizationException();

            invalidPaymentsException.AddData(
                key: nameof(CreatePreauthorizationRefundRequest),
                values: "Value is required");

            var expectedPreauthorizationValidationException =
                new PreauthorizationValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<CreatePreauthorizationRefund> CreatePreauthorizationRefundTask =
                this.preauthorizationService.PostCreateRefundRequestAsync(It.IsAny<string>(), invalidPayments);

            PreauthorizationValidationException actualPreauthorizationValidationException =
                await Assert.ThrowsAsync<PreauthorizationValidationException>(
                    CreatePreauthorizationRefundTask.AsTask);

            // then
            actualPreauthorizationValidationException.Should()
                .BeEquivalentTo(expectedPreauthorizationValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundAsync(It.IsAny<string>(),
                    It.IsAny<ExternalCreatePreauthorizationRefundRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null)]
        [InlineData(0, "")]
        [InlineData(0, " ")]
        public async Task ShouldThrowValidationExceptionOnPostCreatePreauthorizationRefundIfCreatePreauthorizationRefundIsInvalidAsync(
            int invalidAmount, string invalidFlwRef)
        {
            // given
            var updatePayoutSubaccount = new CreatePreauthorizationRefund
            {
                Request = new CreatePreauthorizationRefundRequest
                {
                    Amount = invalidAmount

                }
            };



            var invalidPaymentsException = new InvalidPreauthorizationException();

            invalidPaymentsException.AddData(
                     key: nameof(CreatePreauthorizationRefundRequest),
                     values: "Value is required");

            invalidPaymentsException.AddData(
                    key: nameof(CreatePreauthorizationRefundRequest.Amount),
                    values: "Value is required");




            var expectedPreauthorizationValidationException =
                new PreauthorizationValidationException(invalidPaymentsException);

            // when
            ValueTask<CreatePreauthorizationRefund> CreatePreauthorizationRefundTask =
                this.preauthorizationService.PostCreateRefundRequestAsync(invalidFlwRef, updatePayoutSubaccount);

            PreauthorizationValidationException actualPreauthorizationValidationException =
                await Assert.ThrowsAsync<PreauthorizationValidationException>(CreatePreauthorizationRefundTask.AsTask);

            // then
            actualPreauthorizationValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }


    }
}