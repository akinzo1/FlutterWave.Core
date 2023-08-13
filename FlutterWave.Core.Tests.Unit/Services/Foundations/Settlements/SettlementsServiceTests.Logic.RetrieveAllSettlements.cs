



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Settlements;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Settlements
{
    public partial class SettlementsServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveSettlementsOfAccountAsync()
        {
            // given 

            dynamic createRandomSettlementsProperties =
                     CreateRandomAllSettlementsProperties();


            var randomExternalSettlementsResponse = new ExternalSettlementsResponse
            {

                Message = createRandomSettlementsProperties.Message,
                Status = createRandomSettlementsProperties.Status,
                Meta = new ExternalSettlementsResponse.ExternalSettlementsMeta
                {
                    PageInfo = new ExternalSettlementsResponse.PageInfo
                    {
                        CurrentPage = createRandomSettlementsProperties.Meta.CurrentPage,
                        PageSize = createRandomSettlementsProperties.Meta.PageSize,
                        Total = createRandomSettlementsProperties.Meta.Total,
                        TotalPages = createRandomSettlementsProperties.Meta.TotalPages
                    }
                },
                Data = ((List<dynamic>)createRandomSettlementsProperties.Data).Select(data =>
                {
                    return new ExternalSettlementsResponse.Datum
                    {
                        AccountId = data.AccountId,
                        AppFee = data.AppFee,
                        BankCode = data.BankCode,
                        Channel = data.Channel,
                        Chargeback = data.Chargeback,
                        ChargebackMeta = data.ChargebackMeta,
                        CreatedAt = data.CreatedAt,
                        Currency = data.Currency,
                        Destination = data.Destination,
                        DisburseMessage = data.DisburseMessage,
                        DisburseRef = data.DisburseRef,
                        FlagMessage = data.FlagMessage,
                        DueDate = data.DueDate,
                        FxData = data.FxData,
                        GrossAmount = data.GrossAmount,
                        Id = data.Id,
                        IsLocal = data.IsLocal,
                        MerchantEmail = data.MerchantEmail,
                        MerchantFee = data.MerchantFee,
                        MerchantName = data.MerchantName,
                        Meta = data.Meta,
                        NetAmount = data.NetAmount,
                        ProcessedDate = data.ProcessedDate,
                        ProcessorRef = data.ProcessorRef,
                        Refund = data.Refund,
                        RefundMeta = data.RefundMeta,
                        SettlementAccount = data.SettlementAccount,
                        SourceBankcode = data.SourceBankcode,
                        StampdutyCharge = data.StampdutyCharge,
                        Status = data.Status,
                        TransactionCount = data.TransactionCount,
                        TransactionDate = data.TransactionDate,
                    };
                }).ToList(),

            };

            var randomSettlementsResponse = new SettlementsResponse
            {

                Message = createRandomSettlementsProperties.Message,
                Status = createRandomSettlementsProperties.Status,
                Meta = new SettlementsResponse.SettlementsMeta
                {
                    PageInfo = new SettlementsResponse.PageInfo
                    {
                        CurrentPage = createRandomSettlementsProperties.Meta.CurrentPage,
                        PageSize = createRandomSettlementsProperties.Meta.PageSize,
                        Total = createRandomSettlementsProperties.Meta.Total,
                        TotalPages = createRandomSettlementsProperties.Meta.TotalPages
                    }
                },
                Data = ((List<dynamic>)createRandomSettlementsProperties.Data).Select(data =>
                {
                    return new SettlementsResponse.Datum
                    {
                        AccountId = data.AccountId,
                        AppFee = data.AppFee,
                        BankCode = data.BankCode,
                        Channel = data.Channel,
                        Chargeback = data.Chargeback,
                        ChargebackMeta = data.ChargebackMeta,
                        CreatedAt = data.CreatedAt,
                        Currency = data.Currency,
                        Destination = data.Destination,
                        DisburseMessage = data.DisburseMessage,
                        DisburseRef = data.DisburseRef,
                        FlagMessage = data.FlagMessage,
                        DueDate = data.DueDate,
                        FxData = data.FxData,
                        GrossAmount = data.GrossAmount,
                        Id = data.Id,
                        IsLocal = data.IsLocal,
                        MerchantEmail = data.MerchantEmail,
                        MerchantFee = data.MerchantFee,
                        MerchantName = data.MerchantName,
                        Meta = data.Meta,
                        NetAmount = data.NetAmount,
                        ProcessedDate = data.ProcessedDate,
                        ProcessorRef = data.ProcessorRef,
                        Refund = data.Refund,
                        RefundMeta = data.RefundMeta,
                        SettlementAccount = data.SettlementAccount,
                        SourceBankcode = data.SourceBankcode,
                        StampdutyCharge = data.StampdutyCharge,
                        Status = data.Status,
                        TransactionCount = data.TransactionCount,
                        TransactionDate = data.TransactionDate,
                    };
                }).ToList(),

            };

            var expectedSettlements = new AllSettlements
            {
                Response = randomSettlementsResponse
            };


            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllSettlementsAsync())
                    .ReturnsAsync(randomExternalSettlementsResponse);

            // when
            AllSettlements actualSettlements =
               await this.settlementsService.GetAllSettlementsAsync();

            // then
            actualSettlements.Should().BeEquivalentTo(expectedSettlements);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllSettlementsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}