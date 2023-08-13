using FlutterWave.Core.Models.Clients.ChargeBacks.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using FlutterWave.Core.Services.Foundations.FlutterWave.ChargeBackService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.ChargeBacks
{
    internal class ChargeBackClient : IChargeBackClient
    {
        private readonly IChargeBackService chargeBackService;

        public ChargeBackClient(IChargeBackService chargeBacksService) =>
            this.chargeBackService = chargeBacksService;

        public async ValueTask<AllChargeBacks> RetrieveAllChargeBacksAsync()
        {
            try
            {
                return await chargeBackService.GetAllChargeBacksAsync();
            }
            catch (ChargeBackValidationException chargeBackValidationException)
            {
                throw new ChargeBacksClientValidationException(
                    chargeBackValidationException.InnerException as Xeption);
            }
            catch (ChargeBackDependencyValidationException chargeBackDependencyValidationException)
            {

                var message = chargeBackDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new AllChargeBacks
                    {
                        Response = new AllChargeBacksResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new ChargeBacksClientValidationException(
                    chargeBackDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeBackDependencyException chargeBackDependencyException)
            {
                throw new ChargeBacksClientDependencyException(
                    chargeBackDependencyException.InnerException as Xeption);
            }
            catch (ChargeBackServiceException chargeBackServiceException)
            {
                throw new ChargeBacksClientServiceException(
                    chargeBackServiceException.InnerException as Xeption);
            }
        }


        public async ValueTask<ChargeBack> RetrieveChargeBackAsync(string flutterWaveReference)
        {
            try
            {
                return await chargeBackService.GetChargeBackAsync(flutterWaveReference);
            }
            catch (ChargeBackValidationException chargeBackValidationException)
            {
                throw new ChargeBacksClientValidationException(
                    chargeBackValidationException.InnerException as Xeption);
            }
            catch (ChargeBackDependencyValidationException chargeBackDependencyValidationException)
            {

                var message = chargeBackDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new ChargeBack
                    {
                        Response = new ChargeBackResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new ChargeBacksClientValidationException(
                    chargeBackDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeBackDependencyException chargeBackDependencyException)
            {
                throw new ChargeBacksClientDependencyException(
                    chargeBackDependencyException.InnerException as Xeption);
            }
            catch (ChargeBackServiceException chargeBackServiceException)
            {
                throw new ChargeBacksClientServiceException(
                    chargeBackServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<AcceptDeclineChargeBack> AcceptDeclineChargeBacksAsync(string chargeBackId, AcceptDeclineChargeBack chargeBack)
        {
            try
            {
                return await chargeBackService.PostAcceptDeclineChargeBacksAsync(chargeBackId, chargeBack);
            }
            catch (ChargeBackValidationException chargeBackValidationException)
            {
                throw new ChargeBacksClientValidationException(
                    chargeBackValidationException.InnerException as Xeption);
            }
            catch (ChargeBackDependencyValidationException chargeBackDependencyValidationException)
            {

                var message = chargeBackDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new AcceptDeclineChargeBack
                    {
                        Response = new AcceptDeclineChargeBackResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new ChargeBacksClientValidationException(
                    chargeBackDependencyValidationException.InnerException as Xeption);
            }
            catch (ChargeBackDependencyException chargeBackDependencyException)
            {
                throw new ChargeBacksClientDependencyException(
                    chargeBackDependencyException.InnerException as Xeption);
            }
            catch (ChargeBackServiceException chargeBackServiceException)
            {
                throw new ChargeBacksClientServiceException(
                    chargeBackServiceException.InnerException as Xeption);
            }
        }
    }
}
