using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.ChargeService
{
    internal interface IChargeService
    {
        ValueTask<BankTransfer> PostChargeBankTransferRequestAsync(
            BankTransfer bankTransfer);


        ValueTask<ValidateCharge> PostValidateChargeRequestAsync(
           ValidateCharge validateCharge);
        ValueTask<CardCharge> PostChargeCardRequestAsync(
           CardCharge cardCharge, string encryptionKey);

        ValueTask<NGBankAccounts> PostChargeNGBankAccountRequestAsync(
           NGBankAccounts nGBankAccounts);
        ValueTask<Mpesa> PostChargeMpesaRequestAsync(
           Mpesa Mpesa);

        ValueTask<GhanaMobileMoney> PostChargeGhanaMobileMoneyRequestAsync(
          GhanaMobileMoney ghanaMobileMoney);
        ValueTask<UgandaMobileMoney> PostChargeUgandaMobileMoneyRequestAsync(
        UgandaMobileMoney ugandaMobileMoney);

        ValueTask<FrancophoneMobileMoney> PostChargeFrancophoneMobileMoneyRequestAsync(
            FrancophoneMobileMoney francophoneMobileMoney);
        ValueTask<TanzaniaMobileMoney> PostChargeTanzaniaMobileMoneyRequestAsync(
          TanzaniaMobileMoney tanzaniaMobileMoney);
        ValueTask<RwandaMobileMoney> PostChargeRwandaMobileMoneyRequestAsync(
         RwandaMobileMoney rwandaMobileMoney);
        ValueTask<ZambiaMobileMoney> PostChargeZambiaMobileMoneyRequestAsync(
           ZambiaMobileMoney zambiaMobileMoney);
        ValueTask<USSD> PostChargeUSSDRequestAsync(
          USSD uSSD);
        ValueTask<UkEuBankAccounts> PostChargeUkEuBankAccountsRequestAsync(
         UkEuBankAccounts ukEuBankAccounts);
        ValueTask<ACHPayments> PostChargeACHPaymentsRequestAsync(
        ACHPayments aCHPayments);
        ValueTask<ApplePay> PostChargeApplePayRequestAsync(
        ApplePay applePay);
        ValueTask<GooglePay> PostChargeGooglePayRequestAsync(
          GooglePay googlePay);
        ValueTask<ENaira> PostChargeENairaRequestAsync(
           ENaira eNaira);
        ValueTask<Fawry> PostChargeFawryRequestAsync(
          Fawry fawry);
        ValueTask<PayPal> PostChargePayPalRequestAsync(
           PayPal payPal);
    }
}
