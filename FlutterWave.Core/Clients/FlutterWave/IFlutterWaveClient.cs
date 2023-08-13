using FlutterWave.Core.Clients.Banks;
using FlutterWave.Core.Clients.BillPayment;
using FlutterWave.Core.Clients.Charge;
using FlutterWave.Core.Clients.ChargeBacks;
using FlutterWave.Core.Clients.CollectionSubaccounts;
using FlutterWave.Core.Clients.Misc;
using FlutterWave.Core.Clients.OTP;
using FlutterWave.Core.Clients.PaymentPlans;
using FlutterWave.Core.Clients.PayoutSubaccounts;
using FlutterWave.Core.Clients.Preauthorization;
using FlutterWave.Core.Clients.SettlementClient;
using FlutterWave.Core.Clients.Tokenization;
using FlutterWave.Core.Clients.Transaction;
using FlutterWave.Core.Clients.Transfer;
using FlutterWave.Core.Clients.VirtualAccount;
using FlutterWave.Core.Clients.VirtualCards;

namespace FlutterWave.Core
{
    public interface IFlutterWaveClient
    {
        IBanksClient Banks { get; }

        IVirtualAccountsClient VirtualAccounts { get; }

        IBillPaymentsClient BillPayments { get; }

        IChargeBackClient ChargeBack { get; }

        IMiscellaneousClient Miscellaneous { get; }

        IOtpClient Otp { get; }

        IPaymentPlanClient PaymentPlan { get; }

        ISettlementClient Settlements { get; }

        ISubscriptionsClient Subscriptions { get; }

        ITransactionsClient Transactions { get; }

        ITransfersClient Transfers { get; }

        IPayoutSubaccountsClient PayoutSubaccounts { get; }
        ICollectionSubaccountsClient CollectionSubaccounts { get; }
        IPreauthorizationClient Preauthorization { get; }
        IChargeClient Charge { get; }
        ITokenizedChargeClient TokenizedCharge { get; }
        IVirtualCardsClient VirtualCards { get; }
    }
}
