



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.PaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace FlutterWave.Core.Tests.Acceptance.Clients.PaymentPlanClient
{
    public partial class PaymentPlanClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IFlutterWaveClient flutterWaveClient;

        public PaymentPlanClientTests()
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

        private ExternalCreatePaymentPlanRequest ConvertToPaymentPlanRequest(CreatePaymentPlan paymentPlan)
        {
            return new ExternalCreatePaymentPlanRequest
            {
                Name = paymentPlan.Request.Name,
                Amount = paymentPlan.Request.Amount,
                Duration = paymentPlan.Request.Duration,
                Interval = paymentPlan.Request.Interval,
            };
        }
        private ExternalUpdatePaymentPlanRequest ConvertToPaymentPlanRequest(UpdatePaymentPlan paymentPlan)
        {
            return new ExternalUpdatePaymentPlanRequest
            {
                Name = paymentPlan.Request.Name,
                Status = paymentPlan.Request.Status,

            };
        }
        private PaymentPlan ConvertToPaymentPlanResponse(ExternalPaymentPlanResponse externalPaymentPlanResponse)
        {
            return new PaymentPlan
            {

                Response = new PaymentPlanResponse
                {


                    Status = externalPaymentPlanResponse.Status,
                    Message = externalPaymentPlanResponse.Message,
                    Data = new PaymentPlanResponse.Datum
                    {
                        Status = externalPaymentPlanResponse.Data.Status,
                        Amount = externalPaymentPlanResponse.Data.Amount,
                        CreatedAt = externalPaymentPlanResponse.Data.CreatedAt,
                        Currency = externalPaymentPlanResponse.Data.Currency,
                        Duration = externalPaymentPlanResponse.Data.Duration,
                        Id = externalPaymentPlanResponse.Data.Id,
                        Interval = externalPaymentPlanResponse.Data.Interval,
                        Name = externalPaymentPlanResponse.Data.Name,
                        PlanToken = externalPaymentPlanResponse.Data.PlanToken,

                    }
                }
            };
        }
        private AllPaymentPlans ConvertToPaymentPlanResponse(ExternalPaymentPlansResponse externalPaymentPlansResponse)
        {
            return new AllPaymentPlans
            {

                Response = new PaymentPlansResponse
                {


                    Status = externalPaymentPlansResponse.Status,
                    Message = externalPaymentPlansResponse.Message,
                    Data = externalPaymentPlansResponse.Data.Select(data =>
                    {
                        return new PaymentPlansResponse.Datum
                        {
                            Status = data.Status,
                            Amount = data.Amount,
                            CreatedAt = data.CreatedAt,
                            Currency = data.Currency,
                            Duration = data.Duration,
                            Id = data.Id,
                            Interval = data.Interval,
                            Name = data.Name,
                            PlanToken = data.PlanToken

                        };
                    }).ToList()

                }
            };
        }
        private CreatePaymentPlan ConvertToPaymentPlanResponse(
            CreatePaymentPlan paymentPlan, ExternalPaymentPlanResponse externalCreatePaymentPlanResponse)
        {
            paymentPlan.Response = new PaymentPlanResponse
            {
                Status = externalCreatePaymentPlanResponse.Status,
                Message = externalCreatePaymentPlanResponse.Message,
                Data = new PaymentPlanResponse.Datum
                {
                    Status = externalCreatePaymentPlanResponse.Data.Status,
                    Amount = externalCreatePaymentPlanResponse.Data.Amount,
                    CreatedAt = externalCreatePaymentPlanResponse.Data.CreatedAt,
                    Currency = externalCreatePaymentPlanResponse.Data.Currency,
                    Duration = externalCreatePaymentPlanResponse.Data.Duration,
                    Id = externalCreatePaymentPlanResponse.Data.Id,
                    Interval = externalCreatePaymentPlanResponse.Data.Interval,
                    Name = externalCreatePaymentPlanResponse.Data.Name,
                    PlanToken = externalCreatePaymentPlanResponse.Data.PlanToken

                }
            };
            return paymentPlan;
        }
        private UpdatePaymentPlan ConvertToUpdatePaymentPlanResponse(
            UpdatePaymentPlan paymentPlan, ExternalPaymentPlanResponse externalUpdatePaymentPlanResponse)
        {

            paymentPlan.Response = new PaymentPlanResponse
            {
                Status = externalUpdatePaymentPlanResponse.Status,
                Message = externalUpdatePaymentPlanResponse.Message,
                Data = new PaymentPlanResponse.Datum
                {
                    Status = externalUpdatePaymentPlanResponse.Data.Status,
                    Amount = externalUpdatePaymentPlanResponse.Data.Amount,
                    CreatedAt = externalUpdatePaymentPlanResponse.Data.CreatedAt,
                    Currency = externalUpdatePaymentPlanResponse.Data.Currency,
                    Duration = externalUpdatePaymentPlanResponse.Data.Duration,
                    Id = externalUpdatePaymentPlanResponse.Data.Id,
                    Interval = externalUpdatePaymentPlanResponse.Data.Interval,
                    Name = externalUpdatePaymentPlanResponse.Data.Name,
                    PlanToken = externalUpdatePaymentPlanResponse.Data.PlanToken

                }
            };
            return paymentPlan;
        }


        private static ExternalUpdatePaymentPlanResponse CreateExternalUpdatePaymentPlanResponseResult() =>
                CreateExternalUpdatePaymentPlanResponseFiller().Create();
        private static ExternalCreatePaymentPlanResponse CreateExternalCreatePaymentPlanResponseResult() =>
           CreateExternalCreatePaymentPlanResponseFiller().Create();
        private static ExternalPaymentPlanResponse CreateExternalPaymentPlanResponseResult() =>
           CreateExternalPaymentPlanResponseFiller().Create();
        private static ExternalPaymentPlansResponse CreateExternalPaymentPlansResponseResult() =>
          CreateExternalPaymentPlansResponseFiller().Create();
        private static CreatePaymentPlan CreateRandomCreatePaymentPlan() =>
          CreateCreatePaymentPlanFiller().Create();
        private static UpdatePaymentPlan CreateRandomUpdatePaymentPlan() =>
          CreateUpdatePaymentPlanFiller().Create();
        private static Filler<ExternalCreatePaymentPlanResponse> CreateExternalCreatePaymentPlanResponseFiller()
        {
            var filler = new Filler<ExternalCreatePaymentPlanResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalUpdatePaymentPlanResponse> CreateExternalUpdatePaymentPlanResponseFiller()
        {
            var filler = new Filler<ExternalUpdatePaymentPlanResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalPaymentPlanResponse> CreateExternalPaymentPlanResponseFiller()
        {
            var filler = new Filler<ExternalPaymentPlanResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalPaymentPlansResponse> CreateExternalPaymentPlansResponseFiller()
        {
            var filler = new Filler<ExternalPaymentPlansResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<UpdatePaymentPlan> CreateUpdatePaymentPlanFiller()
        {
            var filler = new Filler<UpdatePaymentPlan>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<CreatePaymentPlan> CreateCreatePaymentPlanFiller()
        {
            var filler = new Filler<CreatePaymentPlan>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        public void Dispose() => this.wireMockServer.Stop();
    }
}
