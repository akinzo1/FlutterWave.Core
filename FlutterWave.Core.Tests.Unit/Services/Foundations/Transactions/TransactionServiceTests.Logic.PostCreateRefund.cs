



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Fact]
        public async Task ShouldCreateRefundRequestWithTransactionIdAsync()
        {
            // given 
            int randomNumber = GetRandomNumber();
            int randomTransactionId = randomNumber;
            int inputTransactionId = randomTransactionId;

            dynamic createRefundRandomProperties =
                CreateRandomCreateRefundProperties();

            var externalCreateRefundResponse = new ExternalCreateRefundResponse
            {

                Message = createRefundRandomProperties.Message,
                Data = new ExternalCreateRefundResponse.ExternalCreateRefundDataModel
                {
                    AccountId = createRefundRandomProperties.Data.AccountId,
                    AmountRefunded = createRefundRandomProperties.Data.AmountRefunded,
                    CreatedAt = createRefundRandomProperties.Data.CreatedAt,
                    Destination = createRefundRandomProperties.Data.Destination,
                    FlwRef = createRefundRandomProperties.Data.FlwRef,
                    Id = createRefundRandomProperties.Data.Id,
                    Meta = new ExternalCreateRefundResponse.Meta
                    {
                        Source = createRefundRandomProperties.Source
                    },
                    Status = createRefundRandomProperties.Data.Status,
                    TxId = createRefundRandomProperties.Data.TxId,
                    WalletId = createRefundRandomProperties.Data.WalletId
                },
                Status = createRefundRandomProperties.Status,
            };

            var expectedCreateRefundResponse = new CreateRefundResponse
            {

                Message = createRefundRandomProperties.Message,
                Data = new CreateRefundResponse.CreateRefundDataModel
                {
                    AccountId = createRefundRandomProperties.Data.AccountId,
                    AmountRefunded = createRefundRandomProperties.Data.AmountRefunded,
                    CreatedAt = createRefundRandomProperties.Data.CreatedAt,
                    Destination = createRefundRandomProperties.Data.Destination,
                    FlwRef = createRefundRandomProperties.Data.FlwRef,
                    Id = createRefundRandomProperties.Data.Id,
                    Meta = new CreateRefundResponse.Meta
                    {
                        Source = createRefundRandomProperties.Source
                    },
                    Status = createRefundRandomProperties.Data.Status,
                    TxId = createRefundRandomProperties.Data.TxId,
                    WalletId = createRefundRandomProperties.Data.WalletId
                },
                Status = createRefundRandomProperties.Status,

            };

            var expectedRefunds = new CreateRefund
            {
                Response = expectedCreateRefundResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateRefundRequestAsync(inputTransactionId))
                    .ReturnsAsync(externalCreateRefundResponse);

            // when
            CreateRefund actualRefunds =
                await this.transactionsService.PostCreateRefundRequestAsync(inputTransactionId);

            // then
            actualRefunds.Should().BeEquivalentTo(expectedRefunds);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundRequestAsync(inputTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}