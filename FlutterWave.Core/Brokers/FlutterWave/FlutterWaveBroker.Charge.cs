using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {


        public async ValueTask<ExternalBankTransferResponse> PostChargeBankTransferAsync(
          ExternalBankTransferRequest externalBankTransferRequest)
        {
            return await PostAsync<ExternalBankTransferRequest, ExternalBankTransferResponse>(
                relativeUrl: "v3/charges?type=bank_transfer",
                content: externalBankTransferRequest);
        }

        public async ValueTask<ExternalValidateChargeResponse> PostValidateChargeAsync(
        ExternalValidateChargeRequest externalValidateChargeRequest)
        {
            return await PostAsync<ExternalValidateChargeRequest, ExternalValidateChargeResponse>(
                relativeUrl: "v3/validate-charge",
                content: externalValidateChargeRequest);
        }

        public async ValueTask<ExternalCardChargeResponse> PostChargeCardAsync(
         ExternalEncryptedChargeRequest externalEncryptedChargeRequest)
        {
            return await PostAsync<ExternalEncryptedChargeRequest, ExternalCardChargeResponse>(
                relativeUrl: "v3/charges?type=card",
                content: externalEncryptedChargeRequest);
        }

        public async ValueTask<ExternalNGBankAccountsResponse> PostChargeNGBankAccountAsync(
           ExternalNGBankAccountsRequest externalNGBankAccountsRequest)
        {
            return await PostAsync<ExternalNGBankAccountsRequest, ExternalNGBankAccountsResponse>(
                relativeUrl: "v3/charges?type=mono",
                content: externalNGBankAccountsRequest);
        }

        public async ValueTask<ExternalMpesaResponse> PostChargeMpesaAsync(
        ExternalMpesaRequest externalMpesaRequest)
        {
            return await PostAsync<ExternalMpesaRequest, ExternalMpesaResponse>(
                relativeUrl: "v3/charges?type=mpesa",
                content: externalMpesaRequest);
        }

        public async ValueTask<ExternalGhanaMobileMoneyResponse> PostChargeGhanaMobileMoneyAsync(
          ExternalGhanaMobileMoneyRequest externalGhanaMobileMoneyRequest)
        {
            return await PostAsync<ExternalGhanaMobileMoneyRequest, ExternalGhanaMobileMoneyResponse>(
                relativeUrl: "v3/charges?type=mobile_money_ghana",
                content: externalGhanaMobileMoneyRequest);
        }

        public async ValueTask<ExternalUgandaMobileMoneyResponse> PostChargeUgandaMobileMoneyAsync(
        ExternalUgandaMobileMoneyRequest externalUgandaMobileMoneyRequest)
        {
            return await PostAsync<ExternalUgandaMobileMoneyRequest, ExternalUgandaMobileMoneyResponse>(
                relativeUrl: "v3/charges?type=mobile_money_uganda",
                content: externalUgandaMobileMoneyRequest);
        }

        public async ValueTask<ExternalFrancophoneMobileMoneyResponse> PostChargeFrancophoneMobileMoneyAsync(
            ExternalFrancophoneMobileMoneyRequest externalFrancophoneMobileMoneyRequest)
        {
            return await PostAsync<ExternalFrancophoneMobileMoneyRequest, ExternalFrancophoneMobileMoneyResponse>(
                relativeUrl: "v3/charges?type=mobile_money_franco",
                content: externalFrancophoneMobileMoneyRequest);
        }

        public async ValueTask<ExternalTanzaniaMobileMoneyResponse> PostChargeTanzaniaMobileMoneyAsync(
          ExternalTanzaniaMobileMoneyRequest externalTanzaniaMobileMoneyRequest)
        {
            return await PostAsync<ExternalTanzaniaMobileMoneyRequest, ExternalTanzaniaMobileMoneyResponse>(
                relativeUrl: "v3/charges?type=mobile_money_tanzania",
                content: externalTanzaniaMobileMoneyRequest);
        }

        public async ValueTask<ExternalRwandaMobileMoneyResponse> PostChargeRwandaMobileMoneyAsync(
         ExternalRwandaMobileMoneyRequest externalRwandaMobileMoneyRequest)
        {
            return await PostAsync<ExternalRwandaMobileMoneyRequest, ExternalRwandaMobileMoneyResponse>(
                relativeUrl: "v3/charges?type=mobile_money_rwanda",
                content: externalRwandaMobileMoneyRequest);
        }

        public async ValueTask<ExternalZambiaMobileMoneyResponse> PostChargeZambiaMobileMoneyAsync(
           ExternalZambiaMobileMoneyRequest externalZambiaMobileMoneyRequest)
        {
            return await PostAsync<ExternalZambiaMobileMoneyRequest, ExternalZambiaMobileMoneyResponse>(
                relativeUrl: "v3/charges?type=mobile_money_zambia",
                content: externalZambiaMobileMoneyRequest);
        }

        public async ValueTask<ExternalUSSDResponse> PostChargeUSSDAsync(
          ExternalUSSDRequest externalUSSDRequest)
        {
            return await PostAsync<ExternalUSSDRequest, ExternalUSSDResponse>(
                relativeUrl: "v3/charges?type=ussd",
                content: externalUSSDRequest);
        }

        public async ValueTask<ExternalUkEuBankAccountsResponse> PostChargeUkEuBankAccountsAsync(
         ExternalUkEuBankAccountsRequest externalUkEuBankAccountsRequest)
        {
            return await PostAsync<ExternalUkEuBankAccountsRequest, ExternalUkEuBankAccountsResponse>(
                relativeUrl: "v3/charges?type=account-ach-uk",
                content: externalUkEuBankAccountsRequest);
        }

        public async ValueTask<ExternalACHPaymentsResponse> PostChargeACHPaymentsAsync(
        ExternalACHPaymentsRequest externalACHPaymentsRequest)
        {
            return await PostAsync<ExternalACHPaymentsRequest, ExternalACHPaymentsResponse>(
                relativeUrl: "v3/charges?type=ach_payment",
                content: externalACHPaymentsRequest);
        }

        public async ValueTask<ExternalApplePayResponse> PostChargeApplePayAsync(
        ExternalApplePayRequest externalApplePayRequest)
        {
            return await PostAsync<ExternalApplePayRequest, ExternalApplePayResponse>(
                relativeUrl: "v3/charges?type=applepay",
                content: externalApplePayRequest);
        }

        public async ValueTask<ExternalGooglePayResponse> PostChargeGooglePayAsync(
          ExternalGooglePayRequest externalGooglePayRequest)
        {
            return await PostAsync<ExternalGooglePayRequest, ExternalGooglePayResponse>(
                relativeUrl: "v3/charges?type=googlepay",
                content: externalGooglePayRequest);
        }

        public async ValueTask<ExternalENairaResponse> PostChargeENairaAsync(
           ExternalENairaRequest externalENairaRequest)
        {
            return await PostAsync<ExternalENairaRequest, ExternalENairaResponse>(
                relativeUrl: "v3/charges?type=enaira",
                content: externalENairaRequest);
        }

        public async ValueTask<ExternalFawryResponse> PostChargeFawryAsync(
          ExternalFawryRequest externalFawryRequest)
        {
            return await PostAsync<ExternalFawryRequest, ExternalFawryResponse>(
                relativeUrl: "v3/charges?type=fawry_pay",
                content: externalFawryRequest);
        }

        public async ValueTask<ExternalPayPalResponse> PostChargePayPalAsync(
         ExternalPayPalRequest externalPayPalRequest)
        {
            return await PostAsync<ExternalPayPalRequest, ExternalPayPalResponse>(
                relativeUrl: "v3/charges?type=paypal",
                content: externalPayPalRequest);
        }

    }
}
