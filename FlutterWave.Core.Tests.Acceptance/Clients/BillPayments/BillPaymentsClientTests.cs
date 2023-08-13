



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace FlutterWave.Core.Tests.Acceptance.Clients.BillPaymentsClient
{
    public partial class BillPaymentsClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IFlutterWaveClient flutterWaveClient;

        public BillPaymentsClientTests()
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


        private static ExternalBulkBillPaymentsRequest ConvertToBulkBillPaymentRequest(BulkBillPayments billPayments)
        {

            return new ExternalBulkBillPaymentsRequest
            {
                BulkData = billPayments.Request.BulkData.Select(data =>
                {
                    return new ExternalBulkBillPaymentsRequest.BulkDatum
                    {
                        Amount = data.Amount,
                        Country = data.Country,
                        Customer = data.Customer,
                        Recurrence = data.Recurrence,
                        Reference = data.Reference,
                        Type = data.Type,
                    };
                }).ToList(),
                BulkReference = billPayments.Request.BulkReference,
                CallbackUrl = billPayments.Request.CallbackUrl
            };


        }
        private static ExternalCreateBillPaymentRequest ConvertToBillPaymentRequest(PostBillPayments billPayments)
        {

            return new ExternalCreateBillPaymentRequest
            {
                Amount = billPayments.Request.Amount,
                BillerName = billPayments.Request.BillerName,
                Country = billPayments.Request.Country,
                Customer = billPayments.Request.Customer,
                Recurrence = billPayments.Request.Recurrence,
                Reference = billPayments.Request.Reference,
                Type = billPayments.Request.Type
            };


        }

        private static PostBillPayments ConvertToBillPaymentResponse(PostBillPayments postBillPayments, ExternalCreateBillPaymentResponse externalCreateBillPaymentResponse)
        {
            postBillPayments.Response = new CreateBillPaymentResponse
            {
                Message = externalCreateBillPaymentResponse.Message,
                Status = externalCreateBillPaymentResponse.Status,
                Data = new CreateBillPaymentResponse.Datum
                {
                    Amount = externalCreateBillPaymentResponse.Data.Amount,
                    FlwRef = externalCreateBillPaymentResponse.Data.FlwRef,
                    Network = externalCreateBillPaymentResponse.Data.Network,
                    TxRef = externalCreateBillPaymentResponse.Data.TxRef,
                    PhoneNumber = externalCreateBillPaymentResponse.Data.PhoneNumber,
                    Reference = externalCreateBillPaymentResponse.Data.Reference

                }
            };
            return postBillPayments;

        }

        private static BillPayments ConvertToBillPaymentResponse(ExternalBillPaymentsResponse externalBillPaymentsResponse)
        {

            return new BillPayments
            {
                Response = new BillPaymentsResponse
                {
                    Message = externalBillPaymentsResponse.Message,
                    Status = externalBillPaymentsResponse.Status,
                    Data = new BillPaymentsResponse.Datum
                    {
                        Reference = externalBillPaymentsResponse.Data.Reference,
                        TotalPages = externalBillPaymentsResponse.Data.TotalPages,
                        Summary = externalBillPaymentsResponse.Data.Summary.Select(summary =>
                        {
                            return new BillPaymentsResponse.Summary
                            {
                                CountAirtime = summary.CountAirtime,
                                CountDstv = summary.CountDstv,
                                Currency = summary.Currency,
                                SumAirtime = summary.SumAirtime,
                                SumBills = summary.SumBills,
                                SumCommission = summary.SumCommission,
                                SumDstv = summary.SumDstv,

                            };
                        }).ToList(),
                        Total = externalBillPaymentsResponse.Data.Total
                    }



                }
            };


        }

        private static BillPaymentsStatus ConvertToBillPaymentResponse(ExternalBillStatusPaymentResponse externalBillStatusPaymentResponse)
        {

            return new BillPaymentsStatus
            {
                Response = new BillStatusPaymentResponse
                {
                    Message = externalBillStatusPaymentResponse.Message,
                    Status = externalBillStatusPaymentResponse.Status,
                    Data = new BillStatusPaymentResponse.Datum
                    {
                        Amount = externalBillStatusPaymentResponse.Data.Amount,
                        Currency = externalBillStatusPaymentResponse.Data.Currency,
                        Extra = externalBillStatusPaymentResponse.Data.Extra,
                        Fee = externalBillStatusPaymentResponse.Data.Fee,
                        FlwRef = externalBillStatusPaymentResponse.Data.Fee,
                        Token = externalBillStatusPaymentResponse.Data.Fee,
                        TxRef = externalBillStatusPaymentResponse.Data.TxRef
                    }



                }
            };


        }

        private static BulkBillPayments ConvertToBillPaymentResponse(BulkBillPayments bulkBillPayments, ExternalBulkBillPaymentsResponse externalBulkBillPaymentsResponse)
        {
            bulkBillPayments.Response = new BulkBillPaymentsResponse
            {
                Message = externalBulkBillPaymentsResponse.Message,
                Status = externalBulkBillPaymentsResponse.Status,
                Data = new BulkBillPaymentsResponse.Datum
                {
                    BatchReference = externalBulkBillPaymentsResponse.Data.BatchReference,

                }
            };

            return bulkBillPayments;

        }


        private static ValidateBillService ConvertToBillPaymentResponse(ExternalValidateBillServiceResponse externalValidateBillServiceResponse)
        {

            return new ValidateBillService
            {
                Response = new ValidateBillServiceResponse
                {
                    Data = new ValidateBillServiceResponse.Datum
                    {
                        Address = externalValidateBillServiceResponse.Data.Address,
                        BillerCode = externalValidateBillServiceResponse.Data.BillerCode,
                        Customer = externalValidateBillServiceResponse.Data.Customer,
                        Email = externalValidateBillServiceResponse.Data.Email,
                        Fee = externalValidateBillServiceResponse.Data.Fee,
                        Maximum = externalValidateBillServiceResponse.Data.Maximum,
                        Minimum = externalValidateBillServiceResponse.Data.Minimum,
                        Name = externalValidateBillServiceResponse.Data.Name,
                        ProductCode = externalValidateBillServiceResponse.Data.ProductCode,
                        ResponseCode = externalValidateBillServiceResponse.Data.ResponseCode,
                        ResponseMessage = externalValidateBillServiceResponse.Data.ResponseMessage,

                    },
                    Message = externalValidateBillServiceResponse.Message,
                    Status = externalValidateBillServiceResponse.Status,
                }
            };


        }

        private static BillCategories ConvertToBillPaymentResponse(ExternalBillCategoriesResponse externalBillCategoriesResponse)
        {

            return new BillCategories
            {
                Response = new BillCategoriesResponse
                {
                    Data = externalBillCategoriesResponse.Data.Select(data =>
                    {
                        return new BillCategoriesResponse.Datum
                        {
                            Amount = data.Amount,
                            BillerCode = data.BillerCode,
                            BillerName = data.BillerName,
                            CommissionOnFee = data.CommissionOnFee,
                            Country = data.Country,
                            DateAdded = data.DateAdded,
                            DefaultCommission = data.DefaultCommission,
                            Fee = data.Fee,
                            Id = data.Id,
                            IsAirtime = data.IsAirtime,
                            ItemCode = data.ItemCode,
                            LabelName = data.LabelName,
                            Name = data.Name,
                            ShortName = data.ShortName,
                        };

                    }).ToList(),
                    Message = externalBillCategoriesResponse.Message,
                    Status = externalBillCategoriesResponse.Status,
                }
            };


        }

        private static ExternalBillPaymentsResponse CreateExternalBillPaymentsResult() =>
                CreateExternalBillPaymentsResponseFiller().Create();

        private static ExternalCreateBillPaymentResponse CreateExternalCreateBillPaymentResponseResult() =>
           CreateExternalCreateBillPaymentResponseFiller().Create();

        private static ExternalBulkBillPaymentsResponse CreateExternalBulkBillPaymentsResponseResult() =>
           CreateExternalExternalBulkBillPaymentsResponseFiller().Create();

        private static ExternalBillCategoriesResponse CreateExternalBillCategoriesResponseResult() =>
          CreateExternalBillCategoriesResponseFiller().Create();

        private static ExternalValidateBillServiceResponse CreateExternalValidateBillServiceResponseResult() =>
          CreateExternalValidateBillServiceResponseFiller().Create();

        private static ExternalBillStatusPaymentResponse CreateExternalBillStatusPaymentResponseResult() =>
            CreateExternalBillStatusPaymentResponseFiller().Create();

        private static PostBillPayments CreateRandomPostBillPaymentsResult() =>
            CreateRandomPostBillPaymentsFiller().Create();

        private static BulkBillPayments CreateRandomBulkBillPaymentsResult() =>
          CreateRandomBulkBillPaymentsFiller().Create();

        private static Filler<ExternalBillPaymentsResponse> CreateExternalBillPaymentsResponseFiller()
        {
            var filler = new Filler<ExternalBillPaymentsResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalCreateBillPaymentResponse> CreateExternalCreateBillPaymentResponseFiller()
        {
            var filler = new Filler<ExternalCreateBillPaymentResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalBulkBillPaymentsResponse> CreateExternalExternalBulkBillPaymentsResponseFiller()
        {
            var filler = new Filler<ExternalBulkBillPaymentsResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalBillCategoriesResponse> CreateExternalBillCategoriesResponseFiller()
        {
            var filler = new Filler<ExternalBillCategoriesResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalValidateBillServiceResponse> CreateExternalValidateBillServiceResponseFiller()
        {
            var filler = new Filler<ExternalValidateBillServiceResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<ExternalBillStatusPaymentResponse> CreateExternalBillStatusPaymentResponseFiller()
        {
            var filler = new Filler<ExternalBillStatusPaymentResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<PostBillPayments> CreateRandomPostBillPaymentsFiller()
        {
            var filler = new Filler<PostBillPayments>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<BulkBillPayments> CreateRandomBulkBillPaymentsFiller()
        {
            var filler = new Filler<BulkBillPayments>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        public void Dispose() => this.wireMockServer.Stop();
    }
}
