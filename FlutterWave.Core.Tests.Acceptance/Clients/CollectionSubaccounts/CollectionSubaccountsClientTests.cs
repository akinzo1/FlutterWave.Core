using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCollectionSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace FlutterWave.Core.Tests.Acceptance.Clients.CollectionSubaccountClient
{
    public partial class CollectionSubaccountsClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IFlutterWaveClient flutterWaveClient;

        public CollectionSubaccountsClientTests()
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

        private static double GetRandomDouble() => 0.5;

        private static int GetRandomNumber() =>
          new IntRange(min: 2, max: 10).GetValue();

        private FetchSubaccount ConvertToCollectionSubaccountResponse(ExternalFetchSubaccountResponse externalFetchSubaccountResponse)
        {
            return new FetchSubaccount
            {
                Response = new FetchSubaccountResponse
                {
                    Message = externalFetchSubaccountResponse.Message,
                    Data = new FetchSubaccountResponse.FetchSubaccountData
                    {
                        AccountId = externalFetchSubaccountResponse.Data.AccountId,
                        AccountBank = externalFetchSubaccountResponse.Data.AccountBank,
                        AccountNumber = externalFetchSubaccountResponse.Data.AccountNumber,
                        BankName = externalFetchSubaccountResponse.Data.BankName,
                        BusinessName = externalFetchSubaccountResponse.Data.BusinessName,
                        Country = externalFetchSubaccountResponse.Data.Country,
                        CreatedAt = externalFetchSubaccountResponse.Data.CreatedAt,
                        FullName = externalFetchSubaccountResponse.Data.FullName,
                        Id = externalFetchSubaccountResponse.Data.Id,
                        Meta = externalFetchSubaccountResponse.Data.Meta,
                        SplitRatio = externalFetchSubaccountResponse.Data.SplitRatio,
                        SplitType = externalFetchSubaccountResponse.Data.SplitType,
                        SplitValue = externalFetchSubaccountResponse.Data.SplitValue,
                        SubaccountId = externalFetchSubaccountResponse.Data.SubaccountId


                    },
                    Status = externalFetchSubaccountResponse.Status,


                }

            };
        }
        private FetchSubaccounts ConvertToCollectionSubaccountResponse(ExternalFetchSubaccountsResponse externalFetchSubaccountsResponse)
        {
            return new FetchSubaccounts
            {
                Response = new FetchSubaccountsResponse
                {
                    Message = externalFetchSubaccountsResponse.Message,
                    Data = externalFetchSubaccountsResponse.Data.Select(data =>
                    {
                        return new FetchSubaccountsResponse.Datum
                        {
                            AccountId = data.AccountId,
                            SubaccountId = data.SubaccountId,
                            SplitValue = data.SplitValue,
                            SplitType = data.SplitType,
                            SplitRatio = data.SplitRatio,
                            Meta = data.Meta.Select(data =>
                            {
                                return new FetchSubaccountsResponse.Metum
                                {
                                    MetaName = data.MetaName,
                                    MetaValue = data.MetaValue,
                                };
                            }).ToList(),
                            AccountBank = data.AccountBank,
                            AccountNumber = data.AccountNumber,
                            BankName = data.BankName,
                            BusinessName = data.BusinessName,
                            Country = data.Country,
                            CreatedAt = data.CreatedAt,
                            FullName = data.FullName,
                            Id = data.Id
                        };


                    }).ToList(),
                    Meta = new FetchSubaccountsResponse.FetchSubaccountsMeta
                    {
                        MetaName = externalFetchSubaccountsResponse.Meta.MetaName,
                        MetaValue = externalFetchSubaccountsResponse.Meta.MetaValue,
                        SwiftCode = externalFetchSubaccountsResponse.Meta.SwiftCode,
                        PageInfo = new FetchSubaccountsResponse.PageInfo
                        {
                            TotalPages = externalFetchSubaccountsResponse.Meta.PageInfo.TotalPages,
                            Total = externalFetchSubaccountsResponse.Meta.PageInfo.Total,
                            CurrentPage = externalFetchSubaccountsResponse.Meta.PageInfo.CurrentPage
                        }
                    },
                    Status = externalFetchSubaccountsResponse.Status,


                }

            };
        }
        private DeleteSubaccount ConvertToCollectionSubaccountResponse(ExternalDeleteSubaccountResponse externalDeleteSubaccountResponse)
        {
            return new DeleteSubaccount
            {
                Response = new DeleteSubaccountResponse
                {
                    Message = externalDeleteSubaccountResponse.Message,
                    Data = externalDeleteSubaccountResponse.Data,
                    Status = externalDeleteSubaccountResponse.Status,


                }

            };
        }
        private ExternalCreateCollectionSubaccountRequest ConvertToCollectionSubaccountRequest(CreateCollectionSubaccount createCollectionSubaccount)
        {
            return new ExternalCreateCollectionSubaccountRequest
            {
                AccountBank = createCollectionSubaccount.Request.AccountBank,
                SplitValue = createCollectionSubaccount.Request.SplitValue,
                BusinessName = createCollectionSubaccount.Request.BusinessName,
                BusinessMobile = createCollectionSubaccount.Request.BusinessMobile,
                AccountNumber = createCollectionSubaccount.Request.AccountNumber,
                BusinessContact = createCollectionSubaccount.Request.BusinessContact,
                BusinessContactMobile = createCollectionSubaccount.Request.BusinessContactMobile,
                BusinessEmail = createCollectionSubaccount.Request.BusinessEmail,
                Country = createCollectionSubaccount.Request.Country,
                Meta = createCollectionSubaccount.Request.Meta.Select(data =>
                {
                    return new ExternalCreateCollectionSubaccountRequest.Metum
                    {
                        MetaName = data.MetaName,
                        MetaValue = data.MetaValue,
                    };
                }).ToList(),

                SplitType = createCollectionSubaccount.Request.SplitType,


            };
        }
        private CreateCollectionSubaccount ConvertToCollectionSubaccountResponse(
            CreateCollectionSubaccount createCollectionSubaccount,
            ExternalCreateCollectionSubaccountResponse externalCreateCollectionSubaccountResponse)
        {

            createCollectionSubaccount.Response = new CreateCollectionSubaccountResponse
            {
                Message = externalCreateCollectionSubaccountResponse.Message,
                Data = new CreateCollectionSubaccountResponse.CreateCollectionSubaccountData
                {
                    SplitType = externalCreateCollectionSubaccountResponse.Data.SplitType,
                    AccountBank = externalCreateCollectionSubaccountResponse.Data.AccountBank,
                    AccountNumber = externalCreateCollectionSubaccountResponse.Data.AccountNumber,
                    BankName = externalCreateCollectionSubaccountResponse.Data.BankName,
                    CreatedAt = externalCreateCollectionSubaccountResponse.Data.CreatedAt,
                    FullName = externalCreateCollectionSubaccountResponse.Data.FullName,
                    Id = externalCreateCollectionSubaccountResponse.Data.Id,
                    SplitValue = externalCreateCollectionSubaccountResponse.Data.SplitValue,
                    SubaccountId = externalCreateCollectionSubaccountResponse.Data.SubaccountId


                },

                Status = externalCreateCollectionSubaccountResponse.Status,


            };
            return createCollectionSubaccount;

        }
        private ExternalUpdateSubaccountRequest ConvertToCollectionSubaccountRequest(UpdateSubaccount updateSubaccount)
        {
            return new ExternalUpdateSubaccountRequest
            {
                SplitValue = updateSubaccount.Request.SplitValue,
                AccountBank = updateSubaccount.Request.AccountBank,
                AccountNumber = updateSubaccount.Request.AccountNumber,
                BusinessEmail = updateSubaccount.Request.BusinessEmail,
                BusinessName = updateSubaccount.Request.BusinessName,
                SplitType = updateSubaccount.Request.SplitType,



            };
        }
        private UpdateSubaccount ConvertToCollectionSubaccountResponse(
            UpdateSubaccount updateSubaccount,
            ExternalUpdateSubaccountResponse externalUpdateSubaccountResponse)
        {

            updateSubaccount.Response = new UpdateSubaccountResponse
            {
                Message = externalUpdateSubaccountResponse.Message,
                Data = new UpdateSubaccountResponse.UpdateSubaccountData
                {
                    SplitType = externalUpdateSubaccountResponse.Data.SplitType,
                    BusinessName = externalUpdateSubaccountResponse.Data.BusinessName,
                    AccountNumber = externalUpdateSubaccountResponse.Data.AccountNumber,
                    AccountBank = externalUpdateSubaccountResponse.Data.AccountBank,
                    AccountId = externalUpdateSubaccountResponse.Data.AccountId,
                    BankName = externalUpdateSubaccountResponse.Data.BankName,
                    Country = externalUpdateSubaccountResponse.Data.Country,
                    CreatedAt = externalUpdateSubaccountResponse.Data.CreatedAt,
                    FullName = externalUpdateSubaccountResponse.Data.FullName,
                    Id = externalUpdateSubaccountResponse.Data.Id,
                    Meta = externalUpdateSubaccountResponse.Data.Meta.Select(data =>
                    {
                        return new UpdateSubaccountResponse.Metum
                        {
                            MetaName = data.MetaName,
                            MetaValue = data.MetaValue,
                        };
                    }).ToList(),
                    SplitRatio = externalUpdateSubaccountResponse.Data.SplitRatio,
                    SplitValue = externalUpdateSubaccountResponse.Data.SplitValue,
                    SubaccountId = externalUpdateSubaccountResponse.Data.SubaccountId
                },
                Status = externalUpdateSubaccountResponse.Status,


            };
            return updateSubaccount;

        }




        private static ExternalFetchSubaccountResponse CreateRandomExternalFetchSubaccountResponseResult() =>
         CreateExternalFetchSubaccountResponseFiller().Create();
        private static ExternalFetchSubaccountsResponse CreateRandomExternalFetchSubaccountsResponseResult() =>
         CreateExternalFetchSubaccountsResponseFiller().Create();
        private static ExternalDeleteSubaccountResponse CreateRandomExternalDeleteSubaccountResponseResult() =>
         CreateExternalDeleteSubaccountResponseFiller().Create();
        private static ExternalUpdateSubaccountResponse CreateRandomExternalUpdateSubaccountResponseResult() =>
         CreateExternalUpdateSubaccountResponseFiller().Create();
        private static ExternalCreateCollectionSubaccountResponse CreateRandomExternalCreateCollectionSubaccountResponseResult() =>
            CreateExternalCreateCollectionSubaccountResponseFiller().Create();



        private static UpdateSubaccount CreateRandomUpdateSubaccountResult() =>
         CreateUpdateSubaccountFiller().Create();
        private static CreateCollectionSubaccount CreateRandomCreateCollectionSubaccountResult() =>
            CreateCreateCollectionSubaccountFiller().Create();



        private static Filler<ExternalFetchSubaccountResponse> CreateExternalFetchSubaccountResponseFiller()
        {
            var filler = new Filler<ExternalFetchSubaccountResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalFetchSubaccountsResponse> CreateExternalFetchSubaccountsResponseFiller()
        {
            var filler = new Filler<ExternalFetchSubaccountsResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalDeleteSubaccountResponse> CreateExternalDeleteSubaccountResponseFiller()
        {
            var filler = new Filler<ExternalDeleteSubaccountResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<CreateCollectionSubaccount> CreateCreateCollectionSubaccountFiller()
        {
            var filler = new Filler<CreateCollectionSubaccount>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<double>().Use(GetRandomDouble())
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<UpdateSubaccount> CreateUpdateSubaccountFiller()
        {
            var filler = new Filler<UpdateSubaccount>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<double>().Use(GetRandomDouble())
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<ExternalCreateCollectionSubaccountResponse> CreateExternalCreateCollectionSubaccountResponseFiller()
        {
            var filler = new Filler<ExternalCreateCollectionSubaccountResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<double>().Use(GetRandomDouble())
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalUpdateSubaccountResponse> CreateExternalUpdateSubaccountResponseFiller()
        {
            var filler = new Filler<ExternalUpdateSubaccountResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<double>().Use(GetRandomDouble())
                .OnType<DateTime>().Use(GetRandomDate());

            return filler;
        }
        public void Dispose() => this.wireMockServer.Stop();
    }
}
