using FlutterWave.Core.Models.Clients.PaymentPlan.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using FlutterWave.Core.Services.Foundations.FlutterWave.PaymentPlanService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.PaymentPlans
{
    internal class PaymentPlanClient : IPaymentPlanClient
    {
        private readonly IPaymentPlanService paymentPlanService;

        public PaymentPlanClient(IPaymentPlanService paymentPlanService) =>
              this.paymentPlanService = paymentPlanService;

        public async ValueTask<PaymentPlan> FetchPaymentPlanAsync(string paymentPlanId)
        {
            try
            {
                return await paymentPlanService.GetPaymentPlanAsync(paymentPlanId);
            }
            catch (PaymentPlanValidationException PaymentPlanValidationException)
            {
                throw new PaymentPlanClientValidationException(
                    PaymentPlanValidationException.InnerException as Xeption);
            }
            catch (PaymentPlanDependencyValidationException PaymentPlanDependencyValidationException)
            {

                var message = PaymentPlanDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new PaymentPlan
                    {
                        Response = new PaymentPlanResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PaymentPlanClientValidationException(
                    PaymentPlanDependencyValidationException.InnerException as Xeption);
            }
            catch (PaymentPlanDependencyException PaymentPlanDependencyException)
            {
                throw new PaymentPlanClientDependencyException(
                    PaymentPlanDependencyException.InnerException as Xeption);
            }
            catch (PaymentPlanServiceException PaymentPlanServiceException)
            {
                throw new PaymentPlanClientServiceException(
                    PaymentPlanServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<AllPaymentPlans> FetchPaymentPlansAsync()
        {
            try
            {
                return await paymentPlanService.GetPaymentPlansAsync();
            }
            catch (PaymentPlanValidationException PaymentPlanValidationException)
            {
                throw new PaymentPlanClientValidationException(
                    PaymentPlanValidationException.InnerException as Xeption);
            }
            catch (PaymentPlanDependencyValidationException PaymentPlanDependencyValidationException)
            {

                var message = PaymentPlanDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new AllPaymentPlans
                    {
                        Response = new PaymentPlansResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PaymentPlanClientValidationException(
                    PaymentPlanDependencyValidationException.InnerException as Xeption);
            }
            catch (PaymentPlanDependencyException PaymentPlanDependencyException)
            {
                throw new PaymentPlanClientDependencyException(
                    PaymentPlanDependencyException.InnerException as Xeption);
            }
            catch (PaymentPlanServiceException PaymentPlanServiceException)
            {
                throw new PaymentPlanClientServiceException(
                    PaymentPlanServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CreatePaymentPlan> CreatePaymentPlanAsync(CreatePaymentPlan paymentPlan)
        {
            try
            {
                return await paymentPlanService.PostCreatePaymentPlanAsync(paymentPlan);
            }
            catch (PaymentPlanValidationException PaymentPlanValidationException)
            {
                throw new PaymentPlanClientValidationException(
                    PaymentPlanValidationException.InnerException as Xeption);
            }
            catch (PaymentPlanDependencyValidationException PaymentPlanDependencyValidationException)
            {

                var message = PaymentPlanDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new CreatePaymentPlan
                    {
                        Response = new PaymentPlanResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PaymentPlanClientValidationException(
                    PaymentPlanDependencyValidationException.InnerException as Xeption);
            }
            catch (PaymentPlanDependencyException PaymentPlanDependencyException)
            {
                throw new PaymentPlanClientDependencyException(
                    PaymentPlanDependencyException.InnerException as Xeption);
            }
            catch (PaymentPlanServiceException PaymentPlanServiceException)
            {
                throw new PaymentPlanClientServiceException(
                    PaymentPlanServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<PaymentPlan> CancelPaymentPlanAsync(string paymentPlanId)
        {
            try
            {
                return await paymentPlanService.PostCancelPaymentPlanAsync(paymentPlanId);
            }
            catch (PaymentPlanValidationException PaymentPlanValidationException)
            {
                throw new PaymentPlanClientValidationException(
                    PaymentPlanValidationException.InnerException as Xeption);
            }
            catch (PaymentPlanDependencyValidationException PaymentPlanDependencyValidationException)
            {

                var message = PaymentPlanDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new PaymentPlan
                    {
                        Response = new PaymentPlanResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PaymentPlanClientValidationException(
                    PaymentPlanDependencyValidationException.InnerException as Xeption);
            }
            catch (PaymentPlanDependencyException PaymentPlanDependencyException)
            {
                throw new PaymentPlanClientDependencyException(
                    PaymentPlanDependencyException.InnerException as Xeption);
            }
            catch (PaymentPlanServiceException PaymentPlanServiceException)
            {
                throw new PaymentPlanClientServiceException(
                    PaymentPlanServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<UpdatePaymentPlan> SendUpdatePaymentPlanAsync(string paymentPlanId, UpdatePaymentPlan paymentPlan)
        {
            try
            {
                return await paymentPlanService.UpdatePaymentPlanAsync(paymentPlanId, paymentPlan);
            }
            catch (PaymentPlanValidationException PaymentPlanValidationException)
            {
                throw new PaymentPlanClientValidationException(
                    PaymentPlanValidationException.InnerException as Xeption);
            }
            catch (PaymentPlanDependencyValidationException PaymentPlanDependencyValidationException)
            {

                var message = PaymentPlanDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new UpdatePaymentPlan
                    {
                        Response = new PaymentPlanResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PaymentPlanClientValidationException(
                    PaymentPlanDependencyValidationException.InnerException as Xeption);
            }
            catch (PaymentPlanDependencyException PaymentPlanDependencyException)
            {
                throw new PaymentPlanClientDependencyException(
                    PaymentPlanDependencyException.InnerException as Xeption);
            }
            catch (PaymentPlanServiceException PaymentPlanServiceException)
            {
                throw new PaymentPlanClientServiceException(
                    PaymentPlanServiceException.InnerException as Xeption);
            }
        }
    }
}
