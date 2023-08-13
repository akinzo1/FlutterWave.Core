using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.PaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using System.Linq;
using System.Threading.Tasks;


namespace FlutterWave.Core.Services.Foundations.FlutterWave.PaymentPlanService
{
    internal partial class PaymentPlanService : IPaymentPlanService
    {
        private readonly IFlutterWaveBroker flutterWaveBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public PaymentPlanService(
            IFlutterWaveBroker flutterWaveBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.flutterWaveBroker = flutterWaveBroker;
            this.dateTimeBroker = dateTimeBroker;
        }


        public ValueTask<PaymentPlan> GetPaymentPlanAsync(string paymentPlanId) =>
        TryCatch(async () =>
        {
            ValidatePaymentPlanId(paymentPlanId);
            ExternalPaymentPlanResponse externalPaymentPlanResponse = await flutterWaveBroker.GetPaymentPlanAsync(paymentPlanId);
            return ConvertToPaymentPlanResponse(externalPaymentPlanResponse);
        });

        public ValueTask<AllPaymentPlans> GetPaymentPlansAsync() =>
        TryCatch(async () =>
        {
            ExternalPaymentPlansResponse externalPaymentPlansResponse = await flutterWaveBroker.GetPaymentPlansAsync();
            return ConvertToPaymentPlanResponse(externalPaymentPlansResponse);
        });

        public ValueTask<PaymentPlan> PostCancelPaymentPlanAsync(string paymentPlanId) =>
        TryCatch(async () =>
        {
            ValidatePaymentPlanId(paymentPlanId);
            ExternalPaymentPlanResponse externalCancelPaymentPlanResponse = await flutterWaveBroker.PostCancelPaymentPlanAsync(paymentPlanId);
            return ConvertToPaymentPlanResponse(externalCancelPaymentPlanResponse);
        });

        public ValueTask<CreatePaymentPlan> PostCreatePaymentPlanAsync(CreatePaymentPlan paymentPlan) =>
        TryCatch(async () =>
        {
            ValidateCreatePaymentPlan(paymentPlan);
            ExternalCreatePaymentPlanRequest externalCreatePaymentPlanRequest = ConvertToCreatePaymentPlanRequest(paymentPlan);
            ExternalPaymentPlanResponse externalCreatePaymentPlanResponse = await flutterWaveBroker.PostCreatePaymentPlanAsync(externalCreatePaymentPlanRequest);
            return ConvertToPaymentPlanResponse(paymentPlan, externalCreatePaymentPlanResponse);
        });


        public ValueTask<UpdatePaymentPlan> UpdatePaymentPlanAsync(string paymentPlanId, UpdatePaymentPlan paymentPlan) =>
        TryCatch(async () =>
        {
            ValidateUpdatePaymentPlan(paymentPlan);
            ExternalUpdatePaymentPlanRequest externalUpdatePaymentPlanRequest = ConvertToPaymentPlanRequest(paymentPlan);
            ExternalPaymentPlanResponse externalUpdatePaymentPlanResponse = await flutterWaveBroker.UpdatePaymentPlanAsync(
                paymentPlanId, externalUpdatePaymentPlanRequest);
            return ConvertToUpdatePaymentPlanResponse(paymentPlan, externalUpdatePaymentPlanResponse);
        });


        private ExternalCreatePaymentPlanRequest ConvertToCreatePaymentPlanRequest(CreatePaymentPlan paymentPlan)
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
                Status = paymentPlan.Request.Status
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
                        PlanToken = externalPaymentPlanResponse.Data.PlanToken

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



    }
}
