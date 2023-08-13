using FlutterWave.Core.Models.Clients.Preauthorization.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using FlutterWave.Core.Services.Foundations.FlutterWave.PreauthorizationService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.Preauthorization
{
    internal class PreauthorizationClient : IPreauthorizationClient
    {
        private readonly IPreauthorizationService preauthorizationService;

        public PreauthorizationClient(IPreauthorizationService preauthorizationService) =>
              this.preauthorizationService = preauthorizationService;

        public async ValueTask<CaptureCharge> CaptureChargeAsync(string flwRef, CaptureCharge captureCharge)
        {
            try
            {
                return await preauthorizationService.PostCaptureChargeRequestAsync(flwRef, captureCharge);
            }
            catch (PreauthorizationValidationException preauthorizationValidationException)
            {
                throw new PreauthorizationClientValidationException(
                    preauthorizationValidationException.InnerException as Xeption);
            }
            catch (PreauthorizationDependencyValidationException preauthorizationDependencyValidationException)
            {

                var message = preauthorizationDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new CaptureCharge
                    {
                        Response = new CaptureChargeResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PreauthorizationClientValidationException(
                    preauthorizationDependencyValidationException.InnerException as Xeption);
            }
            catch (PreauthorizationDependencyException preauthorizationDependencyException)
            {
                throw new PreauthorizationClientDependencyException(
                    preauthorizationDependencyException.InnerException as Xeption);
            }
            catch (PreauthorizationServiceException preauthorizationServiceException)
            {
                throw new PreauthorizationClientServiceException(
                    preauthorizationServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CapturePayPalCharge> CapturePayPalChargeAsync(CapturePayPalCharge capturePayPalCharge)
        {
            try
            {
                return await preauthorizationService.PostCapturePayPalChargeRequestAsync(capturePayPalCharge);
            }
            catch (PreauthorizationValidationException preauthorizationValidationException)
            {
                throw new PreauthorizationClientValidationException(
                    preauthorizationValidationException.InnerException as Xeption);
            }
            catch (PreauthorizationDependencyValidationException preauthorizationDependencyValidationException)
            {

                var message = preauthorizationDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new CapturePayPalCharge
                    {
                        Response = new CapturePaypalChargeResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PreauthorizationClientValidationException(
                    preauthorizationDependencyValidationException.InnerException as Xeption);
            }
            catch (PreauthorizationDependencyException preauthorizationDependencyException)
            {
                throw new PreauthorizationClientDependencyException(
                    preauthorizationDependencyException.InnerException as Xeption);
            }
            catch (PreauthorizationServiceException preauthorizationServiceException)
            {
                throw new PreauthorizationClientServiceException(
                    preauthorizationServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CreateCharge> CreateChargeAsync(CreateCharge createCharge, string encryptionKey)
        {
            try
            {
                return await preauthorizationService.PostCreateChargeRequestAsync(createCharge, encryptionKey);
            }
            catch (PreauthorizationValidationException preauthorizationValidationException)
            {
                throw new PreauthorizationClientValidationException(
                    preauthorizationValidationException.InnerException as Xeption);
            }
            catch (PreauthorizationDependencyValidationException preauthorizationDependencyValidationException)
            {

                var message = preauthorizationDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new CreateCharge
                    {
                        Response = new CreateChargeResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PreauthorizationClientValidationException(
                    preauthorizationDependencyValidationException.InnerException as Xeption);
            }
            catch (PreauthorizationDependencyException preauthorizationDependencyException)
            {
                throw new PreauthorizationClientDependencyException(
                    preauthorizationDependencyException.InnerException as Xeption);
            }
            catch (PreauthorizationServiceException preauthorizationServiceException)
            {
                throw new PreauthorizationClientServiceException(
                    preauthorizationServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CreatePreauthorizationRefund> CreateRefundAsync(string flwRef, CreatePreauthorizationRefund createPreauthorizationRefund)
        {
            try
            {
                return await preauthorizationService.PostCreateRefundRequestAsync(flwRef, createPreauthorizationRefund);
            }
            catch (PreauthorizationValidationException preauthorizationValidationException)
            {
                throw new PreauthorizationClientValidationException(
                    preauthorizationValidationException.InnerException as Xeption);
            }
            catch (PreauthorizationDependencyValidationException preauthorizationDependencyValidationException)
            {

                var message = preauthorizationDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new CreatePreauthorizationRefund
                    {
                        Response = new CreatePreauthorizationRefundResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PreauthorizationClientValidationException(
                    preauthorizationDependencyValidationException.InnerException as Xeption);
            }
            catch (PreauthorizationDependencyException preauthorizationDependencyException)
            {
                throw new PreauthorizationClientDependencyException(
                    preauthorizationDependencyException.InnerException as Xeption);
            }
            catch (PreauthorizationServiceException preauthorizationServiceException)
            {
                throw new PreauthorizationClientServiceException(
                    preauthorizationServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<VoidCharge> VoidChargeAsync(string flwRef)
        {
            try
            {
                return await preauthorizationService.PostVoidChargeRequestAsync(flwRef);
            }
            catch (PreauthorizationValidationException preauthorizationValidationException)
            {
                throw new PreauthorizationClientValidationException(
                    preauthorizationValidationException.InnerException as Xeption);
            }
            catch (PreauthorizationDependencyValidationException preauthorizationDependencyValidationException)
            {

                var message = preauthorizationDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new VoidCharge
                    {
                        Response = new VoidChargeResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PreauthorizationClientValidationException(
                    preauthorizationDependencyValidationException.InnerException as Xeption);
            }
            catch (PreauthorizationDependencyException preauthorizationDependencyException)
            {
                throw new PreauthorizationClientDependencyException(
                    preauthorizationDependencyException.InnerException as Xeption);
            }
            catch (PreauthorizationServiceException preauthorizationServiceException)
            {
                throw new PreauthorizationClientServiceException(
                    preauthorizationServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<VoidPayPalCharge> VoidPayPalChargeAsync(string flwRef)
        {
            try
            {
                return await preauthorizationService.PostVoidPayPalChargeRequestAsync(flwRef);
            }
            catch (PreauthorizationValidationException preauthorizationValidationException)
            {
                throw new PreauthorizationClientValidationException(
                    preauthorizationValidationException.InnerException as Xeption);
            }
            catch (PreauthorizationDependencyValidationException preauthorizationDependencyValidationException)
            {

                var message = preauthorizationDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new VoidPayPalCharge
                    {
                        Response = new VoidPayPalChargeResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PreauthorizationClientValidationException(
                    preauthorizationDependencyValidationException.InnerException as Xeption);
            }
            catch (PreauthorizationDependencyException preauthorizationDependencyException)
            {
                throw new PreauthorizationClientDependencyException(
                    preauthorizationDependencyException.InnerException as Xeption);
            }
            catch (PreauthorizationServiceException preauthorizationServiceException)
            {
                throw new PreauthorizationClientServiceException(
                    preauthorizationServiceException.InnerException as Xeption);
            }
        }
    }
}
