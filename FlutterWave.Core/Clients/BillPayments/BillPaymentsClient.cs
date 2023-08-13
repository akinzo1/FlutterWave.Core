using FlutterWave.Core.Models.Clients.BillPayments.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayment;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using FlutterWave.Core.Services.Foundations.FlutterWave.BillPaymentService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.BillPayment
{
    internal class BillPaymentsClient : IBillPaymentsClient
    {
        private readonly IBillPaymentService billPaymentsService;

        public BillPaymentsClient(IBillPaymentService billPaymentService) =>
            this.billPaymentsService = billPaymentService;

        public async ValueTask<BillCategories> FetchBillCategoriesAsync()
        {
            try
            {
                return await billPaymentsService.GetBillCategoriesAsync();
            }
            catch (BillPaymentValidationException billPaymentsValidationException)
            {

                throw new BillPaymentsClientValidationException(
                    billPaymentsValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyValidationException billPaymentsDependencyValidationException)
            {
                var message = billPaymentsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new BillCategories
                    {
                        Response = new BillCategoriesResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new BillPaymentsClientValidationException(
                    billPaymentsDependencyValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyException billPaymentsDependencyException)
            {
                throw new BillPaymentsClientDependencyException(
                    billPaymentsDependencyException.InnerException as Xeption);
            }
            catch (BillPaymentServiceException billPaymentsServiceException)
            {
                throw new BillPaymentsClientServiceException(
                    billPaymentsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BillPayments> FetchBillPaymentsAsync()
        {
            try
            {
                return await billPaymentsService.GetBillPaymentsAsync();
            }
            catch (BillPaymentValidationException billPaymentsValidationException)
            {
                throw new BillPaymentsClientValidationException(
                    billPaymentsValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyValidationException billPaymentsDependencyValidationException)
            {
                var message = billPaymentsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new BillPayments
                    {
                        Response = new BillPaymentsResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new BillPaymentsClientValidationException(
                    billPaymentsDependencyValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyException billPaymentsDependencyException)
            {
                throw new BillPaymentsClientDependencyException(
                    billPaymentsDependencyException.InnerException as Xeption);
            }
            catch (BillPaymentServiceException billPaymentsServiceException)
            {
                throw new BillPaymentsClientServiceException(
                    billPaymentsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BillPaymentsStatus> FetchBillStatusPaymentAsync(string reference)
        {
            try
            {
                return await billPaymentsService.GetBillStatusPaymentAsync(reference);
            }
            catch (BillPaymentValidationException billPaymentsValidationException)
            {
                throw new BillPaymentsClientValidationException(
                    billPaymentsValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyValidationException billPaymentsDependencyValidationException)
            {
                var message = billPaymentsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new BillPaymentsStatus
                    {
                        Response = new BillStatusPaymentResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new BillPaymentsClientValidationException(
                    billPaymentsDependencyValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyException billPaymentsDependencyException)
            {
                throw new BillPaymentsClientDependencyException(
                    billPaymentsDependencyException.InnerException as Xeption);
            }
            catch (BillPaymentServiceException billPaymentsServiceException)
            {
                throw new BillPaymentsClientServiceException(
                    billPaymentsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<ValidateBillService> FetchValidateBillServiceAsync(string itemCode, string code, string customer)
        {
            try
            {
                return await billPaymentsService.GetValidateBillServiceAsync(itemCode, code, customer);
            }
            catch (BillPaymentValidationException billPaymentsValidationException)
            {
                throw new BillPaymentsClientValidationException(
                    billPaymentsValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyValidationException billPaymentsDependencyValidationException)
            {
                var message = billPaymentsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new ValidateBillService
                    {
                        Response = new ValidateBillServiceResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new BillPaymentsClientValidationException(
                    billPaymentsDependencyValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyException billPaymentsDependencyException)
            {
                throw new BillPaymentsClientDependencyException(
                    billPaymentsDependencyException.InnerException as Xeption);
            }
            catch (BillPaymentServiceException billPaymentsServiceException)
            {
                throw new BillPaymentsClientServiceException(
                    billPaymentsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<PostBillPayments> SendCreateBillPaymentAsync(PostBillPayments billPayments)
        {
            try
            {
                return await billPaymentsService.PostCreateBillPaymentAsync(billPayments);
            }
            catch (BillPaymentValidationException billPaymentsValidationException)
            {
                throw new BillPaymentsClientValidationException(
                    billPaymentsValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyValidationException billPaymentsDependencyValidationException)
            {
                var message = billPaymentsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new PostBillPayments
                    {
                        Response = new CreateBillPaymentResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new BillPaymentsClientValidationException(
                    billPaymentsDependencyValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyException billPaymentsDependencyException)
            {
                throw new BillPaymentsClientDependencyException(
                    billPaymentsDependencyException.InnerException as Xeption);
            }
            catch (BillPaymentServiceException billPaymentsServiceException)
            {
                throw new BillPaymentsClientServiceException(
                    billPaymentsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BulkBillPayments> SendCreateBulkBillAsync(BulkBillPayments billPayments)
        {
            try
            {
                return await billPaymentsService.PostCreateBulkBillAsync(billPayments);
            }
            catch (BillPaymentValidationException billPaymentsValidationException)
            {
                throw new BillPaymentsClientValidationException(
                    billPaymentsValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyValidationException billPaymentsDependencyValidationException)
            {
                var message = billPaymentsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new BulkBillPayments
                    {
                        Response = new BulkBillPaymentsResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new BillPaymentsClientValidationException(
                    billPaymentsDependencyValidationException.InnerException as Xeption);
            }
            catch (BillPaymentDependencyException billPaymentsDependencyException)
            {


                throw new BillPaymentsClientDependencyException(
                    billPaymentsDependencyException.InnerException as Xeption);
            }
            catch (BillPaymentServiceException billPaymentsServiceException)
            {
                throw new BillPaymentsClientServiceException(
                    billPaymentsServiceException.InnerException as Xeption);
            }
        }
    }
}
