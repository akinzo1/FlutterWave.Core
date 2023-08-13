



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace FlutterWave.Core.Tests.Acceptance.Clients.TransactionsClient
{
    public partial class TransactionsClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IFlutterWaveClient flutterWaveClient;

        public TransactionsClientTests()
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

        private static DateTimeOffset GetRandomDate() =>
             new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
         new IntRange(min: 2, max: 10).GetValue();


        private static CreateRefund ConvertToCreateRefundResponse(ExternalCreateRefundResponse externalCreateRefundResponse)
        {


            return new CreateRefund
            {
                Response = new CreateRefundResponse
                {
                    Data = new CreateRefundResponse.CreateRefundDataModel
                    {
                        AccountId = externalCreateRefundResponse.Data.AccountId,
                        AmountRefunded = externalCreateRefundResponse.Data.AmountRefunded,
                        CreatedAt = externalCreateRefundResponse.Data.CreatedAt,
                        Destination = externalCreateRefundResponse.Data.Destination,
                        FlwRef = externalCreateRefundResponse.Data.FlwRef,
                        Id = externalCreateRefundResponse.Data.Id,
                        Meta = new CreateRefundResponse.Meta
                        {
                            Source = externalCreateRefundResponse.Data.Meta.Source
                        },
                        Status = externalCreateRefundResponse.Data.Status,
                        TxId = externalCreateRefundResponse.Data.TxId,
                        WalletId = externalCreateRefundResponse.Data.WalletId,
                    },

                    Status = externalCreateRefundResponse.Status,
                    Message = externalCreateRefundResponse.Message
                }


            };


        }

        private static MultipleTransaction ConvertToMultipleTransactionsResponse(ExternalMultipleTransactionResponse externalMultipleTransactionRequest)
        {
            return new MultipleTransaction
            {

                Response = new FetchMultipleTransactionResponse
                {
                    Data = externalMultipleTransactionRequest.Data.Select(transactions =>
                    {

                        return new FetchMultipleTransactionResponse.Datum
                        {
                            AmountSettled = transactions.AmountSettled,
                            Amount = transactions.Amount,
                            AccountId = transactions.AccountId,
                            AppFee = transactions.AppFee,
                            AuthModel = transactions.AuthModel,
                            ChargedAmount = transactions.ChargedAmount,
                            CreatedAt = transactions.CreatedAt,
                            Currency = transactions.Currency,
                            CustomerEmail = transactions.CustomerEmail,
                            CustomerName = transactions.CustomerName,
                            DeviceFingerprint = transactions.DeviceFingerprint,
                            FlwRef = transactions.FlwRef,
                            MerchantFee = transactions.MerchantFee,
                            Id = transactions.Id,
                            Ip = transactions.Ip,
                            Narration = transactions.Narration,
                            PaymentType = transactions.PaymentType,
                            ProcessorResponse = transactions.ProcessorResponse,
                            Status = transactions.Status,
                            TxRef = transactions.TxRef,
                            Account = new FetchMultipleTransactionResponse.Account
                            {
                                Bank = transactions.Account.Bank,
                                Nuban = transactions.Account.Nuban
                            }
                        };
                    }).ToList(),
                    Status = externalMultipleTransactionRequest.Status,
                    Message = externalMultipleTransactionRequest.Message,
                    Meta = new FetchMultipleTransactionResponse.MultipleTransactionMetaModel
                    {
                        PageInfo = new FetchMultipleTransactionResponse.PageInfo
                        {
                            CurrentPage = externalMultipleTransactionRequest.Meta.PageInfo.CurrentPage,
                            Total = externalMultipleTransactionRequest.Meta.PageInfo.Total,
                            TotalPages = externalMultipleTransactionRequest.Meta.PageInfo.TotalPages
                        }
                    }
                }

            };


        }

        private static TransactionFees ConvertToTransactionFeesResponse(ExternalFetchTransactionFeesResponse externalFetchTransactionFeesResponse)
        {

            return new TransactionFees
            {
                Response = new FetchTransactionFeesResponse
                {


                    Data = new FetchTransactionFeesResponse.FetchTransactionFeesDataModel
                    {
                        ChargeAmount = externalFetchTransactionFeesResponse.Data.ChargeAmount,
                        Currency = externalFetchTransactionFeesResponse.Data.Currency,
                        Fee = externalFetchTransactionFeesResponse.Data.Fee,
                        FlutterwaveFee = externalFetchTransactionFeesResponse.Data.FlutterwaveFee,
                        MerchantFee = externalFetchTransactionFeesResponse.Data.MerchantFee,
                        StampDutyFee = externalFetchTransactionFeesResponse.Data.StampDutyFee
                    },
                    Status = externalFetchTransactionFeesResponse.Status,
                    Message = externalFetchTransactionFeesResponse.Message
                }
            };




        }

        private static RefundDetails ConvertToRefundDetailsResponse(ExternalFetchRefundDetailsResponse externalFetchRefundDetailsResponse)
        {



            return new RefundDetails
            {
                Response = new FetchRefundDetailsResponse
                {
                    Data = new FetchRefundDetailsResponse.FetchRefundDetailsData
                    {
                        Status = externalFetchRefundDetailsResponse.Data.Status,
                        AccountId = externalFetchRefundDetailsResponse.Data.AccountId,
                        AmountRefunded = externalFetchRefundDetailsResponse.Data.AmountRefunded,
                        Comment = externalFetchRefundDetailsResponse.Data.Comment,
                        CreatedAt = externalFetchRefundDetailsResponse.Data.CreatedAt,
                        FlwRef = externalFetchRefundDetailsResponse.Data.FlwRef,
                        Id = externalFetchRefundDetailsResponse.Data.Id,
                        Meta = externalFetchRefundDetailsResponse.Data.Meta,
                        SettlementId = externalFetchRefundDetailsResponse.Data.SettlementId,
                        TransactionId = externalFetchRefundDetailsResponse.Data.TransactionId,
                    },
                    Message = externalFetchRefundDetailsResponse.Message,
                    Status = externalFetchRefundDetailsResponse.Status
                }


            };


        }

        private static MultipleRefundTransaction ConvertToMultipleRefundsResponse(ExternalFetchMultipleTransactionsResponse externalFetchMultipleRefundTransactionResponse)
        {


            return new MultipleRefundTransaction
            {
                Response = new FetchMultipleRefundTransactionResponse
                {
                    Message = externalFetchMultipleRefundTransactionResponse.Message,
                    Meta = new FetchMultipleRefundTransactionResponse.FetchMultipleRefundTransactionMetaModel
                    {
                        PageInfo = new FetchMultipleRefundTransactionResponse.PageInfo
                        {
                            CurrentPage = externalFetchMultipleRefundTransactionResponse.Meta.PageInfo.CurrentPage,
                            PageSize = externalFetchMultipleRefundTransactionResponse.Meta.PageInfo.PageSize,
                            Total = externalFetchMultipleRefundTransactionResponse.Meta.PageInfo.Total,
                            TotalPages = externalFetchMultipleRefundTransactionResponse.Meta.PageInfo.TotalPages
                        }
                    },
                    Status = externalFetchMultipleRefundTransactionResponse.Status,
                    Data = externalFetchMultipleRefundTransactionResponse.Data.Select(refunds =>
                    {
                        return new FetchMultipleRefundTransactionResponse.Datum
                        {
                            AccountId = refunds.AccountId,
                            Comment = refunds.Comment,
                            Meta = refunds.Meta,
                            AmountRefunded = refunds.AmountRefunded,
                            CreatedAt = refunds.CreatedAt,
                            FlwRef = refunds.FlwRef,
                            Id = refunds.Id,
                            SettlementId = refunds.SettlementId,
                            Status = refunds.Status,
                            TransactionId = refunds.TransactionId
                        };
                    }).ToList()
                }


            };


        }

        private static TransactionTimeline ConvertToTransactionTimelineResponse(ExternalTransactionTimelineResponse externalTransactionTimelineResponse)
        {

            return new TransactionTimeline
            {
                Response = new TransactionTimelineResponse
                {
                    Data = externalTransactionTimelineResponse.Data.Select(timeline =>
                    {

                        return new TransactionTimelineResponse.Datum
                        {
                            Action = timeline.Action,
                            Note = timeline.Note,
                            Actor = timeline.Actor,
                            Context = timeline.Context,
                            CreatedAt = timeline.CreatedAt,
                            Object = timeline.Object,
                        };
                    }).ToList(),
                    Status = externalTransactionTimelineResponse.Status,
                    Message = externalTransactionTimelineResponse.Message

                }
            };



        }

        private static VerifyTransaction ConvertToVerifyTransactionResponse(ExternalVerifyTransactionResponse externalVerifyTransactionResponse)
        {



            return new VerifyTransaction
            {
                Response = new VerifyTransactionResponse
                {
                    Data = new VerifyTransactionResponse.VerifyTransactionDataModel
                    {
                        AccountId = externalVerifyTransactionResponse.Data.AccountId,
                        Amount = externalVerifyTransactionResponse.Data.Amount,
                        AmountSettled = externalVerifyTransactionResponse.Data.AmountSettled,
                        Status = externalVerifyTransactionResponse.Data.Status,
                        AppFee = externalVerifyTransactionResponse.Data.AppFee,
                        AuthModel = externalVerifyTransactionResponse.Data.AuthModel,
                        Card = new VerifyTransactionResponse.VerifyTransactionCardModel
                        {
                            Country = externalVerifyTransactionResponse.Data.Card.Country,
                            Expiry = externalVerifyTransactionResponse.Data.Card.Expiry,
                            First6digits = externalVerifyTransactionResponse.Data.Card.First6digits,
                            Issuer = externalVerifyTransactionResponse.Data.Card.Issuer,
                            Last4digits = externalVerifyTransactionResponse.Data.Card.Last4digits,
                            Token = externalVerifyTransactionResponse.Data.Card.Token,
                            Type = externalVerifyTransactionResponse.Data.Card.Type
                        },
                        ChargedAmount = externalVerifyTransactionResponse.Data.ChargedAmount,
                        CreatedAt = externalVerifyTransactionResponse.Data.CreatedAt,
                        Currency = externalVerifyTransactionResponse.Data.Currency,
                        Customer = new VerifyTransactionResponse.VerifyTransactionCustomerModel
                        {
                            CreatedAt = externalVerifyTransactionResponse.Data.Customer.CreatedAt,
                            Email = externalVerifyTransactionResponse.Data.Customer.Email,
                            Id = externalVerifyTransactionResponse.Data.Customer.Id,
                            Name = externalVerifyTransactionResponse.Data.Customer.Name,
                            PhoneNumber = externalVerifyTransactionResponse.Data.Customer.PhoneNumber
                        },
                        DeviceFingerprint = externalVerifyTransactionResponse.Data.DeviceFingerprint,
                        FlwRef = externalVerifyTransactionResponse.Data.FlwRef,
                        Id = externalVerifyTransactionResponse.Data.Id,
                        Ip = externalVerifyTransactionResponse.Data.Ip,
                        MerchantFee = externalVerifyTransactionResponse.Data.MerchantFee,
                        Meta = externalVerifyTransactionResponse.Data.Meta,
                        Narration = externalVerifyTransactionResponse.Data.Narration,
                        PaymentType = externalVerifyTransactionResponse.Data.PaymentType,
                        ProcessorResponse = externalVerifyTransactionResponse.Data.ProcessorResponse,
                        TxRef = externalVerifyTransactionResponse.Data.TxRef
                    },
                    Message = externalVerifyTransactionResponse.Message,
                    Status = externalVerifyTransactionResponse.Status,
                }


            };


        }

        private static ExternalVerifyTransactionResponse CreateExternalVerifyTransactionResponseResult() =>
                CreateExternalVerifyTransactionResponseFiller().Create();
        private static ExternalTransactionTimelineResponse CreateExternalTransactionTimelineResponseResult() =>
                CreateExternalTransactionTimelineResponseFiller().Create();
        private static ExternalCreateRefundResponse CreateExternalCreateRefundResponseResult() =>
           CreateExternalCreateRefundResponseFiller().Create();
        private static ExternalFetchTransactionFeesResponse CreateExternalFetchTransactionFeesResponseResult() =>
           CreateExternalFetchTransactionFeesResponseFiller().Create();
        private static ExternalFetchRefundDetailsResponse CreateExternalFetchRefundDetailsResponseResult() =>
          CreateExternalFetchRefundDetailsResponseFiller().Create();
        private static ExternalFetchMultipleTransactionsResponse CreateExternalFetchMultipleRefundTransactionResponse() =>
          CreateExternalFetchMultipleRefundTransactionResponseFiller().Create();
        private static ExternalMultipleTransactionResponse CreateExternalMultipleTransactionResponse() =>
          CreateExternalMultipleTransactionResponseFiller().Create();
        private static Filler<ExternalCreateRefundResponse> CreateExternalCreateRefundResponseFiller()
        {
            var filler = new Filler<ExternalCreateRefundResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalTransactionTimelineResponse> CreateExternalTransactionTimelineResponseFiller()
        {
            var filler = new Filler<ExternalTransactionTimelineResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalFetchTransactionFeesResponse> CreateExternalFetchTransactionFeesResponseFiller()
        {
            var filler = new Filler<ExternalFetchTransactionFeesResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalFetchRefundDetailsResponse> CreateExternalFetchRefundDetailsResponseFiller()
        {
            var filler = new Filler<ExternalFetchRefundDetailsResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalMultipleTransactionResponse> CreateExternalMultipleTransactionResponseFiller()
        {
            var filler = new Filler<ExternalMultipleTransactionResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalVerifyTransactionResponse> CreateExternalVerifyTransactionResponseFiller()
        {
            var filler = new Filler<ExternalVerifyTransactionResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalFetchMultipleTransactionsResponse> CreateExternalFetchMultipleRefundTransactionResponseFiller()
        {
            var filler = new Filler<ExternalFetchMultipleTransactionsResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        public void Dispose() => this.wireMockServer.Stop();
    }
}
