



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Settlements;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Settlements
{
    public partial class SettlementsServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveSettlementByIdAsync()
        {
            // given 
            string inputSettlementId = GetRandomString();
            dynamic createRandomSettlementsProperties =
                     CreateRandomFetchSettlementProperties();


            var randomExternalSettlementResponse = new ExternalSettlementResponse
            {

                Message = createRandomSettlementsProperties.Message,
                Status = createRandomSettlementsProperties.Status,
                Data = new ExternalSettlementResponse.Datum
                {

                    AccountId = createRandomSettlementsProperties.Data.AccountId,
                    AppFee = createRandomSettlementsProperties.Data.AppFee,
                    BankCode = createRandomSettlementsProperties.Data.BankCode,
                    Channel = createRandomSettlementsProperties.Data.Channel,
                    Chargeback = createRandomSettlementsProperties.Data.Chargeback,
                    ChargebackMeta = createRandomSettlementsProperties.Data.ChargebackMeta,
                    CreatedAt = createRandomSettlementsProperties.Data.CreatedAt,
                    Currency = createRandomSettlementsProperties.Data.Currency,
                    Destination = createRandomSettlementsProperties.Data.Destination,
                    DisburseMessage = createRandomSettlementsProperties.Data.DisburseMessage,
                    DisburseRef = createRandomSettlementsProperties.Data.DisburseRef,
                    FlagMessage = createRandomSettlementsProperties.Data.FlagMessage,
                    DueDate = createRandomSettlementsProperties.Data.DueDate,
                    FxData = createRandomSettlementsProperties.Data.FxData,
                    GrossAmount = createRandomSettlementsProperties.Data.GrossAmount,
                    Id = createRandomSettlementsProperties.Data.Id,
                    IsLocal = createRandomSettlementsProperties.Data.IsLocal,
                    MerchantEmail = createRandomSettlementsProperties.Data.MerchantEmail,
                    MerchantFee = createRandomSettlementsProperties.Data.MerchantFee,
                    MerchantName = createRandomSettlementsProperties.Data.MerchantName,
                    Meta = createRandomSettlementsProperties.Data.Meta,
                    NetAmount = createRandomSettlementsProperties.Data.NetAmount,
                    ProcessedDate = createRandomSettlementsProperties.Data.ProcessedDate,
                    ProcessorRef = createRandomSettlementsProperties.Data.ProcessorRef,
                    Refund = createRandomSettlementsProperties.Data.Refund,
                    RefundMeta = createRandomSettlementsProperties.Data.RefundMeta,
                    SettlementAccount = createRandomSettlementsProperties.Data.SettlementAccount,
                    SourceBankcode = createRandomSettlementsProperties.Data.SourceBankcode,
                    StampdutyCharge = createRandomSettlementsProperties.Data.StampdutyCharge,
                    Status = createRandomSettlementsProperties.Data.Status,
                    TransactionCount = createRandomSettlementsProperties.Data.TransactionCount,
                    TransactionDate = createRandomSettlementsProperties.Data.TransactionDate,
                    Transactions = ((List<dynamic>)createRandomSettlementsProperties.Data.Transactions).Select(transactions =>
                    {
                        return new ExternalSettlementResponse.Transaction
                        {
                            AppFee = transactions.AppFee,
                            CardLocale = transactions.CardLocale,
                            ChargedAmount = transactions.ChargedAmount,
                            Currency = transactions.Currency,
                            CustomerEmail = transactions.CustomerEmail,
                            FlwRef = transactions.FlwRef,
                            Id = transactions.Id,
                            MerchantFee = transactions.MerchantFee,
                            PaymentEntity = transactions.PaymentEntity,
                            Rrn = transactions.Rrn,
                            SettlementAmount = transactions.SettlementAmount,
                            StampdutyCharge = transactions.StampdutyCharge,
                            Status = transactions.Status,
                            SubaccountSettlement = transactions.SubaccountSettlement,
                            TransactionDate = transactions.TransactionDate,
                            TxRef = transactions.TxRef,
                        };
                    }).ToList()
                }


            };

            var randomSettlementsResponse = new SettlementResponse
            {

                Message = createRandomSettlementsProperties.Message,
                Status = createRandomSettlementsProperties.Status,
                Data = new SettlementResponse.Datum
                {
                    AccountId = createRandomSettlementsProperties.Data.AccountId,
                    AppFee = createRandomSettlementsProperties.Data.AppFee,
                    BankCode = createRandomSettlementsProperties.Data.BankCode,
                    Channel = createRandomSettlementsProperties.Data.Channel,
                    Chargeback = createRandomSettlementsProperties.Data.Chargeback,
                    ChargebackMeta = createRandomSettlementsProperties.Data.ChargebackMeta,
                    CreatedAt = createRandomSettlementsProperties.Data.CreatedAt,
                    Currency = createRandomSettlementsProperties.Data.Currency,
                    Destination = createRandomSettlementsProperties.Data.Destination,
                    DisburseMessage = createRandomSettlementsProperties.Data.DisburseMessage,
                    DisburseRef = createRandomSettlementsProperties.Data.DisburseRef,
                    FlagMessage = createRandomSettlementsProperties.Data.FlagMessage,
                    DueDate = createRandomSettlementsProperties.Data.DueDate,
                    FxData = createRandomSettlementsProperties.Data.FxData,
                    GrossAmount = createRandomSettlementsProperties.Data.GrossAmount,
                    Id = createRandomSettlementsProperties.Data.Id,
                    IsLocal = createRandomSettlementsProperties.Data.IsLocal,
                    MerchantEmail = createRandomSettlementsProperties.Data.MerchantEmail,
                    MerchantFee = createRandomSettlementsProperties.Data.MerchantFee,
                    MerchantName = createRandomSettlementsProperties.Data.MerchantName,
                    Meta = createRandomSettlementsProperties.Data.Meta,
                    NetAmount = createRandomSettlementsProperties.Data.NetAmount,
                    ProcessedDate = createRandomSettlementsProperties.Data.ProcessedDate,
                    ProcessorRef = createRandomSettlementsProperties.Data.ProcessorRef,
                    Refund = createRandomSettlementsProperties.Data.Refund,
                    RefundMeta = createRandomSettlementsProperties.Data.RefundMeta,
                    SettlementAccount = createRandomSettlementsProperties.Data.SettlementAccount,
                    SourceBankcode = createRandomSettlementsProperties.Data.SourceBankcode,
                    StampdutyCharge = createRandomSettlementsProperties.Data.StampdutyCharge,
                    Status = createRandomSettlementsProperties.Data.Status,
                    TransactionCount = createRandomSettlementsProperties.Data.TransactionCount,
                    TransactionDate = createRandomSettlementsProperties.Data.TransactionDate,
                    Transactions = ((List<dynamic>)createRandomSettlementsProperties.Data.Transactions).Select(transactions =>
                    {
                        return new SettlementResponse.Transaction
                        {
                            AppFee = transactions.AppFee,
                            CardLocale = transactions.CardLocale,
                            ChargedAmount = transactions.ChargedAmount,
                            Currency = transactions.Currency,
                            CustomerEmail = transactions.CustomerEmail,
                            FlwRef = transactions.FlwRef,
                            Id = transactions.Id,
                            MerchantFee = transactions.MerchantFee,
                            PaymentEntity = transactions.PaymentEntity,
                            Rrn = transactions.Rrn,
                            SettlementAmount = transactions.SettlementAmount,
                            StampdutyCharge = transactions.StampdutyCharge,
                            Status = transactions.Status,
                            SubaccountSettlement = transactions.SubaccountSettlement,
                            TransactionDate = transactions.TransactionDate,
                            TxRef = transactions.TxRef,
                        };
                    }).ToList()
                }

            };

            var expectedSettlements = new Settlement
            {
                Response = randomSettlementsResponse
            };


            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetSettlementByIdAsync(inputSettlementId))
                    .ReturnsAsync(randomExternalSettlementResponse);

            // when
            Settlement actualSettlements =
               await this.settlementsService.GetSettlementsByIdAsync(inputSettlementId);

            // then
            actualSettlements.Should().BeEquivalentTo(expectedSettlements);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSettlementByIdAsync(inputSettlementId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}