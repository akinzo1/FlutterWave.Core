using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {
        ValueTask<ExternalBankTransferResponse> PostChargeBankTransferAsync(
          ExternalBankTransferRequest externalBankTransferRequest);


        ValueTask<ExternalValidateChargeResponse> PostValidateChargeAsync(
        ExternalValidateChargeRequest externalValidateChargeRequest);


        ValueTask<ExternalCardChargeResponse> PostChargeCardAsync(
         ExternalEncryptedChargeRequest externalEncryptedChargeRequest);

        ValueTask<ExternalNGBankAccountsResponse> PostChargeNGBankAccountAsync(
           ExternalNGBankAccountsRequest externalNGBankAccountsRequest);


        ValueTask<ExternalMpesaResponse> PostChargeMpesaAsync(
        ExternalMpesaRequest externalMpesaRequest);


        ValueTask<ExternalGhanaMobileMoneyResponse> PostChargeGhanaMobileMoneyAsync(
          ExternalGhanaMobileMoneyRequest externalGhanaMobileMoneyRequest);


        ValueTask<ExternalUgandaMobileMoneyResponse> PostChargeUgandaMobileMoneyAsync(
        ExternalUgandaMobileMoneyRequest externalUgandaMobileMoneyRequest);


        ValueTask<ExternalFrancophoneMobileMoneyResponse> PostChargeFrancophoneMobileMoneyAsync(
            ExternalFrancophoneMobileMoneyRequest externalFrancophoneMobileMoneyRequest);


        ValueTask<ExternalTanzaniaMobileMoneyResponse> PostChargeTanzaniaMobileMoneyAsync(
          ExternalTanzaniaMobileMoneyRequest externalTanzaniaMobileMoneyRequest);


        ValueTask<ExternalRwandaMobileMoneyResponse> PostChargeRwandaMobileMoneyAsync(
         ExternalRwandaMobileMoneyRequest externalRwandaMobileMoneyRequest);


        ValueTask<ExternalZambiaMobileMoneyResponse> PostChargeZambiaMobileMoneyAsync(
           ExternalZambiaMobileMoneyRequest externalZambiaMobileMoneyRequest);


        ValueTask<ExternalUSSDResponse> PostChargeUSSDAsync(
          ExternalUSSDRequest externalUSSDRequest);


        ValueTask<ExternalUkEuBankAccountsResponse> PostChargeUkEuBankAccountsAsync(
         ExternalUkEuBankAccountsRequest externalUkEuBankAccountsRequest);


        ValueTask<ExternalACHPaymentsResponse> PostChargeACHPaymentsAsync(
        ExternalACHPaymentsRequest externalACHPaymentsRequest);


        ValueTask<ExternalApplePayResponse> PostChargeApplePayAsync(
        ExternalApplePayRequest externalApplePayRequest);


        ValueTask<ExternalGooglePayResponse> PostChargeGooglePayAsync(
          ExternalGooglePayRequest externalGooglePayRequest);


        ValueTask<ExternalENairaResponse> PostChargeENairaAsync(
           ExternalENairaRequest externalENairaRequest);


        ValueTask<ExternalFawryResponse> PostChargeFawryAsync(
          ExternalFawryRequest externalFawryRequest);

        ValueTask<ExternalPayPalResponse> PostChargePayPalAsync(
           ExternalPayPalRequest externalPayPalRequest);


    }
}
