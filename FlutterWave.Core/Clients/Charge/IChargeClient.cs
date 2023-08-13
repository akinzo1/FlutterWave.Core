using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.Charge
{
    public interface IChargeClient
    {
        /// <exception cref="ChargeClientValidationException" />
        /// <exception cref="ChargeClientDependencyException" />
        /// <exception cref="ChargeClientServiceException" />
        ValueTask<BankTransfer> ChargeBankTransferAsync(
                BankTransfer bankTransfer);


        ValueTask<ValidateCharge> ValidateChargeAsync(
           ValidateCharge validateCharge);
        ValueTask<CardCharge> ChargeCardAsync(
           CardCharge cardCharge, string encryptionKey);

        ValueTask<NGBankAccounts> ChargeNGBankAccountAsync(
           NGBankAccounts nGBankAccounts);
        ValueTask<Mpesa> ChargeMpesaAsync(
           Mpesa Mpesa);

        ValueTask<GhanaMobileMoney> ChargeGhanaMobileMoneyAsync(
          GhanaMobileMoney ghanaMobileMoney);
        ValueTask<UgandaMobileMoney> ChargeUgandaMobileMoneyAsync(
        UgandaMobileMoney ugandaMobileMoney);

        ValueTask<FrancophoneMobileMoney> ChargeFrancophoneMobileMoneyAsync(
            FrancophoneMobileMoney francophoneMobileMoney);
        ValueTask<TanzaniaMobileMoney> ChargeTanzaniaMobileMoneyAsync(
          TanzaniaMobileMoney tanzaniaMobileMoney);
        ValueTask<RwandaMobileMoney> ChargeRwandaMobileMoneyAsync(
         RwandaMobileMoney rwandaMobileMoney);
        ValueTask<ZambiaMobileMoney> ChargeZambiaMobileMoneyAsync(
           ZambiaMobileMoney zambiaMobileMoney);
        ValueTask<USSD> ChargeUSSDAsync(
          USSD uSSD);
        ValueTask<UkEuBankAccounts> ChargeUkEuBankAccountsAsync(
         UkEuBankAccounts ukEuBankAccounts);
        ValueTask<ACHPayments> ChargeACHPaymentsAsync(
        ACHPayments aCHPayments);
        ValueTask<ApplePay> ChargeApplePayAsync(
        ApplePay applePay);
        ValueTask<GooglePay> ChargeGooglePayAsync(
          GooglePay googlePay);
        ValueTask<ENaira> ChargeENairaAsync(
           ENaira eNaira);
        ValueTask<Fawry> ChargeFawryAsync(
          Fawry fawry);
        ValueTask<PayPal> ChargePayPalAsync(
           PayPal payPal);

    }
}
