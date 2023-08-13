



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace FlutterWave.Core.Tests.Acceptance.Clients.TransfersClient
{
    public partial class TransfersClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IFlutterWaveClient flutterWaveClient;

        public TransfersClientTests()
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

        private ExternalInitiateTransferRequest ConvertInitiateTransfersRequest(InitiateTransfers initiateTransferRequest)
        {
            return new ExternalInitiateTransferRequest
            {
                Reference = initiateTransferRequest.Request.Reference,
                Narration = initiateTransferRequest.Request.Narration,
                AccountBank = initiateTransferRequest.Request.AccountBank,
                AccountNumber = initiateTransferRequest.Request.AccountNumber,
                Amount = initiateTransferRequest.Request.Amount,
                CallbackUrl = initiateTransferRequest.Request.CallbackUrl,
                Currency = initiateTransferRequest.Request.Currency,
                DebitCurrency = initiateTransferRequest.Request.DebitCurrency,
            };

        }

        private ExternalCreateBulkTransferRequest ConvertCreateBulkTransfersRequest(BulkCreateTransfers createBulkTransferRequest)
        {
            return new ExternalCreateBulkTransferRequest
            {
                BulkData = createBulkTransferRequest.Request.BulkData.Select(bulkData =>
                {
                    return new ExternalCreateBulkTransferRequest.BulkDatum
                    {
                        AccountNumber = bulkData.AccountNumber,
                        Amount = bulkData.Amount,
                        BankCode = bulkData.BankCode,
                        Currency = bulkData.Currency,
                        Meta = bulkData.Meta.Select(meta =>
                        {
                            return new ExternalCreateBulkTransferRequest.Metum
                            {
                                Email = meta.Email,
                                FirstName = meta.FirstName,
                                LastName = meta.LastName,
                                MobileNumber = meta.MobileNumber,
                                RecipientAddress = meta.RecipientAddress,

                            };
                        }).ToList(),
                        Narration = bulkData.Narration,
                        Reference = bulkData.Reference,
                    };
                }).ToList(),
                Title = createBulkTransferRequest.Request.Title
            };

        }

        private FetchRetryTransfers ConvertToTransfersResponse(ExternalFetchTransferRetryResponse externalFetchTransferRetryResponse)
        {
            return new FetchRetryTransfers
            {
                Response = new FetchTransferRetryResponse
                {
                    Data = externalFetchTransferRetryResponse.Data.Select(data =>
                    {
                        return new FetchTransferRetryResponse.Datum
                        {
                            AccountNumber = data.AccountNumber,
                            Amount = data.Amount,
                            BankCode = data.BankCode,
                            BankName = data.BankName,
                            CompleteMessage = data.CompleteMessage,
                            CreatedAt = data.CreatedAt,
                            Currency = data.Currency,
                            DebitCurrency = data.DebitCurrency,
                            Fee = data.Fee,
                            FullName = data.FullName,
                            Id = data.Id,
                            IsApproved = data.IsApproved,
                            Meta = data.Meta,
                            Reference = data.Reference,
                            RequiresApproval = data.RequiresApproval,
                            Status = data.Status,
                            Narration = data.Narration,
                        };
                    }).ToList(),
                    Message = externalFetchTransferRetryResponse.Message,
                    Status = externalFetchTransferRetryResponse.Status

                }


            };
        }

        private TransferFees ConvertToTransfersResponse(ExternalTransferFeesResponse externalTransferFeesResponse)
        {
            return new TransferFees
            {
                Response = new TransferFeesResponse
                {
                    Data = externalTransferFeesResponse.Data.Select(fees =>
                    {
                        return new TransferFeesResponse.Datum
                        {
                            Currency = fees.Currency,
                            Fee = fees.Fee,
                            FeeType = fees.FeeType,
                        };
                    }).ToList(),
                    Message = externalTransferFeesResponse.Message,
                    Status = externalTransferFeesResponse?.Status,
                }


            };
        }

        private TransferRates ConvertToTransfersResponse(ExternalTransferRatesResponse externalTransferRatesResponse)
        {
            return new TransferRates
            {
                Response = new TransferRatesResponse
                {

                    Data = new TransferRatesResponse.TransferRateModel
                    {
                        Destination = new TransferRatesResponse.Destination
                        {
                            Amount = externalTransferRatesResponse.Data.Destination.Amount,
                            Currency = externalTransferRatesResponse.Data.Destination.Currency
                        },
                        Rate = externalTransferRatesResponse.Data.Rate,
                        Source = new TransferRatesResponse.Source
                        {
                            Currency = externalTransferRatesResponse.Data.Source.Currency,
                            Amount = externalTransferRatesResponse.Data.Source.Amount
                        },
                    },
                    Message = externalTransferRatesResponse.Message,
                    Status = externalTransferRatesResponse?.Status,
                }


            };
        }

        private BulkCreateTransfers ConvertToTransfersResponse(BulkCreateTransfers bulkCreateTransfers, ExternalCreateBulkTransferResponse createBulkTransferResponse)
        {
            bulkCreateTransfers.Response = new CreateBulkTransferResponse
            {
                Data = new CreateBulkTransferResponse.Datum
                {
                    Approver = createBulkTransferResponse.Data.Approver,
                    CreatedAt = createBulkTransferResponse.Data.CreatedAt,
                    Id = createBulkTransferResponse.Data.Id,
                },
                Message = createBulkTransferResponse.Message,
                Status = createBulkTransferResponse.Status,
            };
            return bulkCreateTransfers;
        }

        private FetchTransfers ConvertToTransfersResponse(ExternalFetchTransferResponse externalFetchTransferResponse)
        {
            return new FetchTransfers
            {
                Response = new FetchTransferResponse
                {

                    Message = externalFetchTransferResponse.Message,
                    Status = externalFetchTransferResponse.Status,
                    Data = new FetchTransferResponse.FetchTransferDataModel
                    {
                        Status = externalFetchTransferResponse.Data.Status,
                        Id = externalFetchTransferResponse.Data.Id,
                        AccountNumber = externalFetchTransferResponse.Data.AccountNumber,
                        Amount = externalFetchTransferResponse.Data.Amount,
                        Approver = externalFetchTransferResponse.Data.Approver,
                        BankCode = externalFetchTransferResponse.Data.BankCode,
                        BankName = externalFetchTransferResponse.Data.BankName,
                        CompleteMessage = externalFetchTransferResponse.Data.CompleteMessage,
                        CreatedAt = externalFetchTransferResponse.Data.CreatedAt,
                        Currency = externalFetchTransferResponse.Data.Currency,
                        DebitCurrency = externalFetchTransferResponse.Data.DebitCurrency,
                        Fee = externalFetchTransferResponse.Data.Fee,
                        FullName = externalFetchTransferResponse.Data.FullName,
                        IsApproved = externalFetchTransferResponse.Data.IsApproved,
                        Meta = externalFetchTransferResponse.Data.Meta,
                        Narration = externalFetchTransferResponse.Data.Narration,
                        Reference = externalFetchTransferResponse.Data.Reference,
                        RequiresApproval = externalFetchTransferResponse.Data.RequiresApproval

                    }
                }


            };
        }

        private AllTransfers ConvertToTransfersResponse(ExternalAllTransfersResponse externalAllTransfersResponse)
        {
            return new AllTransfers
            {
                Response = new AllTransfersResponse
                {
                    Data = externalAllTransfersResponse.Data.Select(transfers =>
                    {
                        return new AllTransfersResponse.Datum
                        {
                            Amount = transfers.Amount,
                            Meta = transfers.Meta,
                            AccountNumber = transfers.AccountNumber,
                            Approver = transfers.Approver,
                            BankCode = transfers.BankCode,
                            BankName = transfers.BankName,
                            CompleteMessage = transfers.CompleteMessage,
                            CreatedAt = transfers.CreatedAt,
                            Currency = transfers.Currency,
                            DebitCurrency = transfers.DebitCurrency,
                            Fee = transfers.Fee,
                            FullName = transfers.FullName,
                            Id = transfers.Id,
                            IsApproved = transfers.IsApproved,
                            Narration = transfers.Narration,
                            Reference = transfers.Reference,
                            RequiresApproval = transfers.RequiresApproval,
                            Status = transfers.Status,
                        };

                    }).ToList(),
                    Message = externalAllTransfersResponse.Message,
                    Status = externalAllTransfersResponse.Status,
                    Meta = new AllTransfersResponse.TransfersMetaModel
                    {
                        PageInfo = new AllTransfersResponse.PageInfo
                        {
                            CurrentPage = externalAllTransfersResponse.Meta.PageInfo.CurrentPage,
                            PageSize = externalAllTransfersResponse.Meta.PageInfo.PageSize,
                            Total = externalAllTransfersResponse.Meta.PageInfo.Total,
                            TotalPages = externalAllTransfersResponse.Meta.PageInfo.TotalPages,

                        }
                    }

                }


            };
        }

        private InitiateTransfers ConvertToTransfersResponse(InitiateTransfers initiateTransfer, ExternalInitiateTransferResponse externalInitiateTransferResponse)
        {
            initiateTransfer.Response = new InitiateTransferResponse
            {
                Message = externalInitiateTransferResponse.Message,
                Status = externalInitiateTransferResponse.Status,
                Data = new InitiateTransferResponse.InitiateTransferDataModel
                {
                    Status = externalInitiateTransferResponse.Data.Status,
                    RequiresApproval = externalInitiateTransferResponse.Data.RequiresApproval,
                    AccountNumber = externalInitiateTransferResponse.Data.AccountNumber,
                    Amount = externalInitiateTransferResponse.Data.Amount,
                    BankCode = externalInitiateTransferResponse.Data.BankCode,
                    BankName = externalInitiateTransferResponse.Data.BankName,
                    CompleteMessage = externalInitiateTransferResponse.Data.CompleteMessage,
                    CreatedAt = externalInitiateTransferResponse.Data.CreatedAt,
                    Currency = externalInitiateTransferResponse.Data.Currency,
                    DebitCurrency = externalInitiateTransferResponse.Data.DebitCurrency,
                    Fee = externalInitiateTransferResponse.Data.Fee,
                    FullName = externalInitiateTransferResponse.Data.FullName,
                    Id = externalInitiateTransferResponse.Data.Id,
                    IsApproved = externalInitiateTransferResponse.Data.IsApproved,
                    Meta = externalInitiateTransferResponse.Data.Meta,
                    Narration = externalInitiateTransferResponse.Data.Narration,
                    Reference = externalInitiateTransferResponse.Data.Reference
                }
            };
            return initiateTransfer;
        }

        private FetchBulkTransfers ConvertToTransfersResponse(ExternalFetchBulkTransferResponse externalFetchBulkTransferResponse)
        {
            return new FetchBulkTransfers
            {
                Response = new FetchBulkTransferResponse
                {
                    Data = externalFetchBulkTransferResponse.Data.Select(data =>
                    {
                        return new FetchBulkTransferResponse.Datum
                        {
                            Status = data.Status,
                            AccountNumber = data.AccountNumber,
                            Amount = data.Amount,
                            Approver = data.Approver,
                            BankCode = data.BankCode,
                            BankName = data.BankName,
                            CompleteMessage = data.CompleteMessage,
                            CreatedAt = data.CreatedAt,
                            Currency = data.Currency,
                            DebitCurrency = data.DebitCurrency,
                            Fee = data.Fee,
                            FullName = data.FullName,
                            Id = data.Id,
                            IsApproved = data.IsApproved,
                            Meta = data.Meta,
                            Narration = data.Narration,
                            Reference = data.Reference,
                            RequiresApproval = data.RequiresApproval
                        };
                    }).ToList(),
                    Meta = new FetchBulkTransferResponse.ExternalMeta
                    {
                        PageInfo = new FetchBulkTransferResponse.PageInfo
                        {
                            CurrentPage = externalFetchBulkTransferResponse.Meta.PageInfo.CurrentPage,
                            Total = externalFetchBulkTransferResponse.Meta.PageInfo.Total,
                            TotalPages = externalFetchBulkTransferResponse.Meta.PageInfo.TotalPages
                        }
                    },
                    Message = externalFetchBulkTransferResponse.Message,
                    Status = externalFetchBulkTransferResponse.Status,
                }


            };
        }

        private RetryTransfers ConvertToTransfersResponse(ExternalRetryTransferResponse externalRetryTransferResponse)
        {
            return new RetryTransfers
            {
                Response = new RetryTransferResponse
                {
                    Data = new RetryTransferResponse.Datum
                    {
                        RequiresApproval = externalRetryTransferResponse.Data.RequiresApproval,
                        AccountNumber = externalRetryTransferResponse.Data.AccountNumber,
                        Amount = externalRetryTransferResponse.Data.Amount,
                        BankCode = externalRetryTransferResponse.Data.BankCode,
                        BankName = externalRetryTransferResponse.Data.BankName,
                        CompleteMessage = externalRetryTransferResponse.Data.CompleteMessage,
                        CreatedAt = externalRetryTransferResponse.Data.CreatedAt,
                        Currency = externalRetryTransferResponse.Data.Currency,
                        DebitCurrency = externalRetryTransferResponse.Data.DebitCurrency,
                        Fee = externalRetryTransferResponse.Data.Fee,
                        FullName = externalRetryTransferResponse.Data.FullName,
                        Id = externalRetryTransferResponse.Data.Id,
                        IsApproved = externalRetryTransferResponse.Data.IsApproved,
                        Meta = externalRetryTransferResponse.Data.Meta,
                        Reference = externalRetryTransferResponse.Data.Reference,
                        Status = externalRetryTransferResponse.Data.Status,
                    },
                    Message = externalRetryTransferResponse.Message,
                    Status = externalRetryTransferResponse.Status,
                }





            };
        }


        private static ExternalAllTransfersResponse CreateExternalAllTransfersResponseResult() =>
                CreateExternalAllTransfersResponseFiller().Create();

        private static ExternalInitiateTransferResponse CreateExternalInitiateTransferResponseResult() =>
             CreateExternalInitiateTransferResponseFiller().Create();
        private static ExternalCreateBulkTransferResponse CreateExternalCreateBulkTransferResponseResult() =>
                CreateExternalCreateBulkTransferResponseFiller().Create();
        private static ExternalFetchBulkTransferResponse CreateExternalFetchBulkTransferResponseResult() =>
                CreateExternalFetchBulkTransferResponseFiller().Create();

        private static ExternalRetryTransferResponse CreateExternalRetryTransferResponseResult() =>
                CreateExternalRetryTransferResponseFiller().Create();
        private static ExternalFetchTransferRetryResponse CreateExternalFetchTransferRetryResponseResult() =>
                CreateExternalFetchTransferRetryResponseFiller().Create();
        private static ExternalTransferFeesResponse CreateExternalTransferFeesResponseResult() =>
           CreateExternalTransferFeesResponseFiller().Create();
        private static ExternalTransferRatesResponse CreateExternalTransferRatesResponseResult() =>
           CreateExternalTransferRatesResponseFiller().Create();
        private static ExternalFetchTransferResponse CreateExternalFetchTransferResponseResult() =>
          CreateExternalFetchTransferResponseFiller().Create();
        private static InitiateTransfers CreateRandomInitiateTransfers() =>
          CreateInitiateTransfersFiller().Create();
        private static BulkCreateTransfers CreateRandomBulkCreateTransfers() =>
          CreateBulkCreateTransfersFiller().Create();


        private static Filler<ExternalInitiateTransferResponse> CreateExternalInitiateTransferResponseFiller()
        {
            var filler = new Filler<ExternalInitiateTransferResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalCreateBulkTransferResponse> CreateExternalCreateBulkTransferResponseFiller()
        {
            var filler = new Filler<ExternalCreateBulkTransferResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalFetchBulkTransferResponse> CreateExternalFetchBulkTransferResponseFiller()
        {
            var filler = new Filler<ExternalFetchBulkTransferResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalRetryTransferResponse> CreateExternalRetryTransferResponseFiller()
        {
            var filler = new Filler<ExternalRetryTransferResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalAllTransfersResponse> CreateExternalAllTransfersResponseFiller()
        {
            var filler = new Filler<ExternalAllTransfersResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalTransferFeesResponse> CreateExternalTransferFeesResponseFiller()
        {
            var filler = new Filler<ExternalTransferFeesResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalFetchTransferRetryResponse> CreateExternalFetchTransferRetryResponseFiller()
        {
            var filler = new Filler<ExternalFetchTransferRetryResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalTransferRatesResponse> CreateExternalTransferRatesResponseFiller()
        {
            var filler = new Filler<ExternalTransferRatesResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalFetchTransferResponse> CreateExternalFetchTransferResponseFiller()
        {
            var filler = new Filler<ExternalFetchTransferResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<BulkCreateTransfers> CreateBulkCreateTransfersFiller()
        {
            var filler = new Filler<BulkCreateTransfers>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<InitiateTransfers> CreateInitiateTransfersFiller()
        {
            var filler = new Filler<InitiateTransfers>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        public void Dispose() => this.wireMockServer.Stop();
    }
}
