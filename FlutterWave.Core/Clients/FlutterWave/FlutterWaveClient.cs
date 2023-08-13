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
using FlutterWave.Core.Services.Foundations.FlutterWave.BanksService;
using FlutterWave.Core.Services.Foundations.FlutterWave.BillPaymentService;
using FlutterWave.Core.Services.Foundations.FlutterWave.ChargeBackService;
using FlutterWave.Core.Services.Foundations.FlutterWave.ChargeService;
using FlutterWave.Core.Services.Foundations.FlutterWave.CollectionSubaccountsService;
using FlutterWave.Core.Services.Foundations.FlutterWave.MiscService;
using FlutterWave.Core.Services.Foundations.FlutterWave.OtpService;
using FlutterWave.Core.Services.Foundations.FlutterWave.PaymentPlanService;
using FlutterWave.Core.Services.Foundations.FlutterWave.PayoutSubaccountsService;
using FlutterWave.Core.Services.Foundations.FlutterWave.PreauthorizationService;
using FlutterWave.Core.Services.Foundations.FlutterWave.SettlementsService;
using FlutterWave.Core.Services.Foundations.FlutterWave.SubscriptionService;
using FlutterWave.Core.Services.Foundations.FlutterWave.TokenizedChargeService;
using FlutterWave.Core.Services.Foundations.FlutterWave.TransactionsService;
using FlutterWave.Core.Services.Foundations.FlutterWave.TransfersService;
using FlutterWave.Core.Services.Foundations.FlutterWave.VirtualAccountsService;
using FlutterWave.Core.Services.Foundations.FlutterWave.VirtualCardsService;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FlutterWave.Core
{
    public class FlutterWaveClient : IFlutterWaveClient
    {
        public FlutterWaveClient(ApiConfigurations apiConfigurations)
        {
            IServiceProvider serviceProvider = RegisterServices(apiConfigurations);
            InitializeClients(serviceProvider);
        }

        public IFlutterWaveClient FlutterWave { get; set; }
        public IBanksClient Banks { get; set; }

        public IVirtualAccountsClient VirtualAccounts { get; set; }

        public IBillPaymentsClient BillPayments { get; set; }

        public IChargeBackClient ChargeBack { get; set; }

        public IMiscellaneousClient Miscellaneous { get; set; }

        public IOtpClient Otp { get; set; }

        public IPaymentPlanClient PaymentPlan { get; set; }

        public ISettlementClient Settlements { get; set; }

        public ISubscriptionsClient Subscriptions { get; set; }

        public ITransactionsClient Transactions { get; set; }

        public ITransfersClient Transfers { get; set; }

        public IPayoutSubaccountsClient PayoutSubaccounts { get; set; }

        public ICollectionSubaccountsClient CollectionSubaccounts { get; set; }

        public IPreauthorizationClient Preauthorization { get; set; }

        public IChargeClient Charge { get; set; }

        public ITokenizedChargeClient TokenizedCharge { get; set; }

        public IVirtualCardsClient VirtualCards { get; set; }

        private void InitializeClients(IServiceProvider serviceProvider)
        {

            Banks = serviceProvider.GetRequiredService<IBanksClient>();
            BillPayments = serviceProvider.GetRequiredService<IBillPaymentsClient>();
            Transfers = serviceProvider.GetRequiredService<ITransfersClient>();
            Transactions = serviceProvider.GetRequiredService<ITransactionsClient>();
            Subscriptions = serviceProvider.GetRequiredService<ISubscriptionsClient>();
            Settlements = serviceProvider.GetRequiredService<ISettlementClient>();
            PaymentPlan = serviceProvider.GetRequiredService<IPaymentPlanClient>();
            Otp = serviceProvider.GetRequiredService<IOtpClient>();
            Miscellaneous = serviceProvider.GetRequiredService<IMiscellaneousClient>();
            ChargeBack = serviceProvider.GetRequiredService<IChargeBackClient>();
            VirtualAccounts = serviceProvider.GetRequiredService<IVirtualAccountsClient>();
            CollectionSubaccounts = serviceProvider.GetRequiredService<ICollectionSubaccountsClient>();
            PayoutSubaccounts = serviceProvider.GetRequiredService<IPayoutSubaccountsClient>();
            VirtualCards = serviceProvider.GetRequiredService<IVirtualCardsClient>();
            TokenizedCharge = serviceProvider.GetRequiredService<ITokenizedChargeClient>();
            Preauthorization = serviceProvider.GetRequiredService<IPreauthorizationClient>();
            Charge = serviceProvider.GetRequiredService<IChargeClient>();

        }


        private static IServiceProvider RegisterServices(ApiConfigurations apiConfigurations)
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<IFlutterWaveBroker, FlutterWaveBroker>()
                .AddTransient<IDateTimeBroker, DateTimeBroker>()
                .AddTransient<ITransactionsService, TransactionsService>()
                .AddTransient<IBillPaymentService, BillPaymentService>()
                .AddTransient<IBanksService, BanksService>()
                .AddTransient<IChargeBackService, ChargeBackService>()
                .AddTransient<IMiscellaneousService, MiscellaneousService>()
                .AddTransient<IOtpService, OtpService>()
                .AddTransient<IPaymentPlanService, PaymentPlanService>()
                .AddTransient<ISettlementsService, SettlementsService>()
                .AddTransient<ISubscriptionService, SubscriptionService>()
                .AddTransient<ITransfersService, TransfersService>()
                .AddTransient<IVirtualAccountsService, VirtualAccountsService>()
                .AddTransient<ICollectionSubaccountsService, CollectionSubaccountsService>()
                .AddTransient<IPayoutSubaccountsService, PayoutSubaccountsService>()
                .AddTransient<ITokenizedChargeService, TokenizedChargeService>()
                .AddTransient<IChargeService, ChargeService>()
                .AddTransient<IVirtualCardsService, VirtualCardsService>()
                .AddTransient<IPreauthorizationService, PreauthorizationService>()

                .AddTransient<IFlutterWaveClient, FlutterWaveClient>()
                .AddTransient<IBillPaymentsClient, BillPaymentsClient>()
                .AddTransient<IChargeBackClient, ChargeBackClient>()
                .AddTransient<IMiscellaneousClient, MiscellaneousClient>()
                .AddTransient<IOtpClient, OtpClient>()
                .AddTransient<IBillPaymentsClient, BillPaymentsClient>()
                .AddTransient<ISettlementClient, SettlementClient>()
                .AddTransient<ISubscriptionsClient, SubscriptionsClient>()
                .AddTransient<ITransactionsClient, TransactionsClient>()
                .AddTransient<ITransfersClient, TransfersClient>()
                .AddTransient<IBanksClient, BanksClient>()
                .AddTransient<IPaymentPlanClient, PaymentPlanClient>()
                .AddTransient<IDateTimeBroker, DateTimeBroker>()
                .AddTransient<IVirtualAccountsClient, VirtualAccountsClient>()
                .AddTransient<IPayoutSubaccountsClient, PayoutSubaccountsClient>()
                .AddTransient<ICollectionSubaccountsClient, CollectionSubaccountsClient>()
                .AddTransient<ITokenizedChargeClient, TokenizedChargeClient>()
                .AddTransient<IVirtualCardsClient, VirtualCardsClient>()
                .AddTransient<IChargeClient, ChargeClient>()
                .AddTransient<IPreauthorizationClient, PreauthorizationClient>()
                .AddSingleton(apiConfigurations);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
