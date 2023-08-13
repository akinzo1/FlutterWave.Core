



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualAccounts
{
    public partial class VirtualAccountsServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnBulkCreateVirtualAccountsIfBulkCreateVirtualAccountsRequestIsNullAsync()
        {
            // given



            BulkCreateVirtualAccounts? nullBulkCreateVirtualAccounts = null;
            var nullBulkCreateVirtualAccountsException = new NullVirtualAccountsException();

            var exceptedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(nullBulkCreateVirtualAccountsException);

            // when
            ValueTask<BulkCreateVirtualAccounts> VirtualAccountsTask =
                this.virtualAccountsService.PostBulkCreateVirtualAccountsRequestAsync(nullBulkCreateVirtualAccounts);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(
                    VirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should()
                .BeEquivalentTo(exceptedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBulkCreateVirtualAccountsRequestAsync(
                    It.IsAny<ExternalCreateBulkVirtualAccountsRequest>()),
                    Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnBulkCreateVirtualAccountsIfRequestIsNullAsync()
        {
            // given


            var invalidVirtualAccounts = new BulkCreateVirtualAccounts();
            invalidVirtualAccounts.Request = null;

            var invalidVirtualAccountsException =
                new InvalidVirtualAccountsException();

            invalidVirtualAccountsException.AddData(
                key: nameof(BulkCreateVirtualAccountsRequest),
                values: "Value is required");


            var expectedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(
                    invalidVirtualAccountsException);

            // when
            ValueTask<BulkCreateVirtualAccounts> BulkCreateVirtualAccountsTask =
                this.virtualAccountsService.PostBulkCreateVirtualAccountsRequestAsync(invalidVirtualAccounts);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(
                    BulkCreateVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should()
                .BeEquivalentTo(expectedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBulkCreateVirtualAccountsRequestAsync(
                    It.IsAny<ExternalCreateBulkVirtualAccountsRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, false, null)]
        [InlineData(0, "", false, "")]
        [InlineData(0, " ", false, " ")]
        public async Task ShouldThrowValidationExceptionOnPostBulkCreateVirtualAccountsIfBulkCreateVirtualAccountsRequestIsInvalidAsync(
            int invalidAccounts, string invalidEmail, bool invalidIsPermanent, string invalidTxRef

            )
        {
            // given


            var validateVirtualAccounts = new BulkCreateVirtualAccounts
            {
                Request = new BulkCreateVirtualAccountsRequest
                {
                    Accounts = invalidAccounts,
                    Email = invalidEmail,
                    IsPermanent = invalidIsPermanent,
                    TxRef = invalidTxRef

                }
            };

            var invalidVirtualAccountsException = new InvalidVirtualAccountsException();

            invalidVirtualAccountsException.AddData(
                   key: nameof(BulkCreateVirtualAccountsRequest.Accounts),
                   values: "Value is required");

            invalidVirtualAccountsException.AddData(
                   key: nameof(BulkCreateVirtualAccountsRequest.Email),
                   values: "Value is required");

            invalidVirtualAccountsException.AddData(
                   key: nameof(BulkCreateVirtualAccountsRequest.TxRef),
                   values: "Value is required");


            var expectedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(invalidVirtualAccountsException);

            // when
            ValueTask<BulkCreateVirtualAccounts> BulkCreateVirtualAccountsTask =
                this.virtualAccountsService.PostBulkCreateVirtualAccountsRequestAsync(validateVirtualAccounts);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(BulkCreateVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostBulkCreateVirtualAccountsIfBulkCreateVirtualAccountsRequestIsEmptyAsync()
        {
            // given


            var validateVirtualAccounts = new BulkCreateVirtualAccounts
            {
                Request = new BulkCreateVirtualAccountsRequest
                {

                    Email = string.Empty,
                    TxRef = string.Empty
                }
            };

            var invalidVirtualAccountsException = new InvalidVirtualAccountsException();


            invalidVirtualAccountsException.AddData(
                     key: nameof(BulkCreateVirtualAccountsRequest.TxRef),
                     values: "Value is required");

            invalidVirtualAccountsException.AddData(
                      key: nameof(BulkCreateVirtualAccountsRequest.Email),
                      values: "Value is required");


            invalidVirtualAccountsException.AddData(
                      key: nameof(BulkCreateVirtualAccountsRequest.Accounts),
                      values: "Value is required");


            var expectedVirtualAccountsValidationException =
                new VirtualAccountsValidationException(invalidVirtualAccountsException);

            // when
            ValueTask<BulkCreateVirtualAccounts> BulkCreateVirtualAccountsTask =
                this.virtualAccountsService.PostBulkCreateVirtualAccountsRequestAsync(validateVirtualAccounts);

            VirtualAccountsValidationException actualVirtualAccountsValidationException =
                await Assert.ThrowsAsync<VirtualAccountsValidationException>(
                    BulkCreateVirtualAccountsTask.AsTask);

            // then
            actualVirtualAccountsValidationException.Should().BeEquivalentTo(
                expectedVirtualAccountsValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}