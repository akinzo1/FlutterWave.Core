



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Settlements;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace FlutterWave.Core.Tests.Acceptance.Clients.SettlementsClient
{
    public partial class SettlementsClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IFlutterWaveClient flutterWaveClient;

        public SettlementsClientTests()
        {
            this.apiKey = GetRandomString();
            this.wireMockServer = WireMockServer.Start();

            var apiConfigurations = new ApiConfigurations
            {
                ApiUrl = this.wireMockServer.Url,
                ApiKey = this.apiKey,

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }

        private static DateTime GetRandomDate() =>
             new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();


        private AllSettlements ConvertToSettlementsResponse(ExternalSettlementsResponse externalSettlementsResponse)
        {
            return new AllSettlements
            {
                Response = new SettlementsResponse
                {
                    Message = externalSettlementsResponse.Message,
                    Status = externalSettlementsResponse.Status,
                    Meta = new SettlementsResponse.SettlementsMeta
                    {
                        PageInfo = new SettlementsResponse.PageInfo
                        {
                            CurrentPage = externalSettlementsResponse.Meta.PageInfo.CurrentPage,
                            PageSize = externalSettlementsResponse.Meta.PageInfo.PageSize,
                            Total = externalSettlementsResponse.Meta.PageInfo.Total,
                            TotalPages = externalSettlementsResponse.Meta.PageInfo.TotalPages,

                        }
                    },

                    Data = externalSettlementsResponse.Data.Select(data =>
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
                            DueDate = data.DueDate,
                            FlagMessage = data.FlagMessage,
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
                            Refund = data.Refund,
                            ProcessorRef = data.ProcessorRef,
                            RefundMeta = data.RefundMeta,
                            SettlementAccount = data.SettlementAccount,
                            SourceBankcode = data.SourceBankcode,
                            StampdutyCharge = data.StampdutyCharge,
                            Status = data.Status,
                            TransactionCount = data.TransactionCount,
                            TransactionDate = data.TransactionDate,



                        };

                    }).ToList(),



                }
            };
        }
        private static Settlement ConvertToSettlementResponse(ExternalSettlementResponse externalSettlementResponse)
        {

            return new Settlement
            {

                Response = new SettlementResponse
                {


                    Message = externalSettlementResponse.Message,
                    Status = externalSettlementResponse.Status,
                    Data = new SettlementResponse.Datum
                    {
                        AccountId = externalSettlementResponse.Data.AccountId,
                        AppFee = externalSettlementResponse.Data.AppFee,
                        BankCode = externalSettlementResponse.Data.BankCode,
                        Channel = externalSettlementResponse.Data.Channel,
                        Chargeback = externalSettlementResponse.Data.Chargeback,
                        ChargebackMeta = externalSettlementResponse.Data.ChargebackMeta,
                        CreatedAt = externalSettlementResponse.Data.CreatedAt,
                        Currency = externalSettlementResponse.Data.Currency,
                        Destination = externalSettlementResponse.Data.Destination,
                        DisburseMessage = externalSettlementResponse.Data.DisburseMessage,
                        DisburseRef = externalSettlementResponse.Data.DisburseRef,
                        DueDate = externalSettlementResponse.Data.DueDate,
                        FlagMessage = externalSettlementResponse.Data.FlagMessage,
                        FxData = externalSettlementResponse.Data.FxData,
                        GrossAmount = externalSettlementResponse.Data.GrossAmount,
                        Id = externalSettlementResponse.Data.Id,
                        IsLocal = externalSettlementResponse.Data.IsLocal,
                        MerchantEmail = externalSettlementResponse.Data.MerchantEmail,
                        MerchantFee = externalSettlementResponse.Data.MerchantFee,
                        MerchantName = externalSettlementResponse.Data.MerchantName,
                        Meta = externalSettlementResponse.Data.Meta,
                        NetAmount = externalSettlementResponse.Data.NetAmount,
                        ProcessedDate = externalSettlementResponse.Data.ProcessedDate,
                        Refund = externalSettlementResponse.Data.Refund,
                        ProcessorRef = externalSettlementResponse.Data.ProcessorRef,
                        RefundMeta = externalSettlementResponse.Data.RefundMeta,
                        SettlementAccount = externalSettlementResponse.Data.SettlementAccount,
                        SourceBankcode = externalSettlementResponse.Data.SourceBankcode,
                        StampdutyCharge = externalSettlementResponse.Data.StampdutyCharge,
                        Status = externalSettlementResponse.Data.Status,
                        TransactionCount = externalSettlementResponse.Data.TransactionCount,
                        TransactionDate = externalSettlementResponse.Data.TransactionDate,
                        Transactions = externalSettlementResponse.Data.Transactions.Select(transactions =>
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

                }

            };
        }
        private static ExternalSettlementsResponse CreateExternalSettlementsResponseResult() =>
                CreateExternalSettlementsResponseFiller().Create();
        private static ExternalSettlementResponse CreateExternalSettlementResponseResult() =>
           CreateExternalSettlementResponseFiller().Create();
        private static Filler<ExternalSettlementResponse> CreateExternalSettlementResponseFiller()
        {
            var filler = new Filler<ExternalSettlementResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalSettlementsResponse> CreateExternalSettlementsResponseFiller()
        {
            var filler = new Filler<ExternalSettlementsResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt()
               .OnType<List<object>>().IgnoreIt()
               .OnType<DateTime>().Use(GetRandomDate());


            return filler;
        }


        public void Dispose() => this.wireMockServer.Stop();
    }
}
