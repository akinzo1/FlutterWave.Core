using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalChargeBack;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace FlutterWave.Core.Tests.Acceptance.Clients.ChargeBackClient
{
    public partial class ChargeBackClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IFlutterWaveClient flutterWaveClient;

        public ChargeBackClientTests()
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

        private static ExternalAcceptDeclineChargeBackRequest ConvertToAcceptDeclineRequest(AcceptDeclineChargeBack chargeBack)
        {
            return new ExternalAcceptDeclineChargeBackRequest
            {
                Action = chargeBack.Request.Action,
                Comment = chargeBack.Request.Comment,
            };
        }
        private static AllChargeBacks ConvertToChargeBackResponse(ExternalChargeBacksResponse externalChargeBacksResponse)
        {

            return new AllChargeBacks
            {
                Response = new AllChargeBacksResponse
                {
                    Status = externalChargeBacksResponse.Status,
                    Message = externalChargeBacksResponse.Message,
                    Data = externalChargeBacksResponse.Data.Select(data =>
                    {
                        return new AllChargeBacksResponse.Datum
                        {
                            DueDate = data.DueDate,
                            CreatedAt = data.CreatedAt,
                            Comment = data.Comment,
                            FlwRef = data.FlwRef,
                            Amount = data.Amount,
                            Id = data.Id,
                            SettlementId = data.SettlementId,
                            Stage = data.Stage,
                            Status = data.Status,
                            TransactionId = data.TransactionId,
                            TxRef = data.TxRef,
                            Meta = new AllChargeBacksResponse.ChargeBacksMeta
                            {
                                History = data.Meta.History.Select(history =>
                                {
                                    return new AllChargeBacksResponse.History
                                    {
                                        Stage = history.Stage,
                                        Action = history.Action,
                                        Date = history.Date,
                                        Description = history.Description,
                                        Initiator = history.Initiator,
                                        Source = history.Source,
                                    };
                                }).ToList(),
                                PageInfo = new AllChargeBacksResponse.PageInfo
                                {
                                    CurrentPage = data.Meta.PageInfo.CurrentPage,
                                    PageSize = data.Meta.PageInfo.PageSize,
                                    Total = data.Meta.PageInfo.Total,
                                    TotalPages = data.Meta.PageInfo.TotalPages,
                                },
                                UploadedProof = data.Meta.UploadedProof,

                            }
                        };

                    }).ToList(),
                    Meta = new AllChargeBacksResponse.PageInfo
                    {
                        CurrentPage = externalChargeBacksResponse.Meta.CurrentPage,
                        PageSize = externalChargeBacksResponse.Meta.PageSize,
                        Total = externalChargeBacksResponse.Meta.Total,
                        TotalPages = externalChargeBacksResponse.Meta.TotalPages,
                    }






                }
            };
        }
        private static AcceptDeclineChargeBack ConvertToChargeBackResponse(AcceptDeclineChargeBack acceptDeclineChargeBack, ExternalAcceptDeclineChargeBackResponse externalAcceptDeclineChargeBackResponse)
        {
            acceptDeclineChargeBack.Response = new AcceptDeclineChargeBackResponse
            {

                Data = externalAcceptDeclineChargeBackResponse.Data,
                Message = externalAcceptDeclineChargeBackResponse.Message,
                Status = externalAcceptDeclineChargeBackResponse.Status,

            };
            return acceptDeclineChargeBack;


        }
        private static ChargeBack ConvertToChargeBackResponse(ExternalChargeBackResponse externalChargeBackResponse)
        {

            return new ChargeBack
            {
                Response = new ChargeBackResponse
                {
                    Data = externalChargeBackResponse.Data.Select(data =>
                    {
                        return new ChargeBackResponse.Datum
                        {
                            Amount = data.Amount,
                            Comment = data.Comment,
                            CreatedAt = data.CreatedAt,
                            DueDate = data.DueDate,
                            FlwRef = data.FlwRef,
                            Id = data.Id,
                            Meta = new ChargeBackResponse.ChargebackMeta
                            {
                                PageInfo = new ChargeBackResponse.PageInfo
                                {
                                    TotalPages = data.Meta.PageInfo.TotalPages,
                                    Total = data.Meta.PageInfo.Total,
                                    CurrentPage = data.Meta.PageInfo.CurrentPage,
                                    PageSize = data.Meta.PageInfo.PageSize,
                                },
                                History = data.Meta.History.Select(history =>
                                {
                                    return new ChargeBackResponse.History
                                    {
                                        Stage = history.Stage,
                                        Action = history.Action,
                                        Date = history.Date,
                                        Description = history.Description,
                                        Initiator = history.Initiator,
                                        Source = history.Source,
                                    };
                                }).ToList(),
                                UploadedProof = data.Meta.UploadedProof
                            },
                            SettlementId = data.SettlementId,
                            Stage = data.Stage,
                            Status = data.Status,
                            TransactionId = data.TransactionId,
                            TxRef = data.TxRef,
                        };
                    }).ToList(),
                    Message = externalChargeBackResponse.Message,
                    Status = externalChargeBackResponse.Status,
                    Meta = new ChargeBackResponse.PageInfo
                    {
                        TotalPages = externalChargeBackResponse.Meta.TotalPages,
                        Total = externalChargeBackResponse.Meta.Total,
                        CurrentPage = externalChargeBackResponse.Meta.CurrentPage,
                        PageSize = externalChargeBackResponse.Meta.PageSize,
                    }

                }
            };


        }


        private static ExternalChargeBackResponse CreateExternalChargeBackResult() =>
                CreateExternalChargeBackResponseFiller().Create();

        private static ExternalChargeBacksResponse CreateExternalChargeBacksResult() =>
           CreateExternalChargeBacksResponseFiller().Create();

        private static ExternalAcceptDeclineChargeBackResponse CreateRandomAcceptDeclineChargeBackResult() =>
           CreateExternalAcceptDeclineChargeBackResponseFiller().Create();

        private static AcceptDeclineChargeBack CreateRandomAcceptDeclineChargeBack() =>
          CreateAcceptDeclineChargeBackFiller().Create();

        private static Filler<ExternalChargeBackResponse> CreateExternalChargeBackResponseFiller()
        {
            var filler = new Filler<ExternalChargeBackResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalChargeBacksResponse> CreateExternalChargeBacksResponseFiller()
        {
            var filler = new Filler<ExternalChargeBacksResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalAcceptDeclineChargeBackResponse> CreateExternalAcceptDeclineChargeBackResponseFiller()
        {
            var filler = new Filler<ExternalAcceptDeclineChargeBackResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }

        private static Filler<AcceptDeclineChargeBack> CreateAcceptDeclineChargeBackFiller()
        {
            var filler = new Filler<AcceptDeclineChargeBack>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        public void Dispose() => this.wireMockServer.Stop();
    }
}
