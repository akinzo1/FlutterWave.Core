using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSubscriptions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscription;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.SubscriptionService
{
    internal partial class SubscriptionService : ISubscriptionService
    {
        private readonly IFlutterWaveBroker flutterWaveBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public SubscriptionService(
            IFlutterWaveBroker flutterWaveBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.flutterWaveBroker = flutterWaveBroker;
            this.dateTimeBroker = dateTimeBroker;
        }


        public ValueTask<AllSubscription> GetAllSubscriptionsAsync() =>
        TryCatch(async () =>
        {

            ExternalAllSubscriptionsResponse externalSubscriptionsResponse =
            await flutterWaveBroker.GetAllSubscriptionsAsync();
            return ConvertToSubscriptionResponse(externalSubscriptionsResponse);
        });

        public ValueTask<Subscription> PostActivateSubscriptionAsync(string subscriptionId) =>
        TryCatch(async () =>
        {

            ValidateSubscriptionId(subscriptionId);
            ExternalSubscriptionResponse externalActivateSubscriptionResponse =
            await flutterWaveBroker.PostActivateSubscriptionAsync(subscriptionId);
            return ConvertToSubscriptionResponse(externalActivateSubscriptionResponse);
        });

        public ValueTask<Subscription> PostDeactivateSubscriptionAsync(string subscriptionId) =>
        TryCatch(async () =>
        {
            ValidateSubscriptionId(subscriptionId);
            ExternalSubscriptionResponse externalDeactivateSubscriptionResponse =
            await flutterWaveBroker.PostDeactivateSubscriptionAsync(subscriptionId);
            return ConvertToSubscriptionResponse(externalDeactivateSubscriptionResponse);
        });


        private static Subscription ConvertToSubscriptionResponse(ExternalSubscriptionResponse externalActivateSubscriptionResponse)
        {

            return new Subscription
            {
                Response = new SubscriptionResponse
                {
                    Status = externalActivateSubscriptionResponse.Status,
                    Message = externalActivateSubscriptionResponse.Message,
                    Data = new SubscriptionResponse.SubscriptionData
                    {
                        Amount = externalActivateSubscriptionResponse.Data.Amount,
                        CreatedAt = externalActivateSubscriptionResponse.Data.CreatedAt,
                        Customer = new SubscriptionResponse.Customer
                        {
                            CustomerEmail = externalActivateSubscriptionResponse.Data.Customer.CustomerEmail,
                            Id = externalActivateSubscriptionResponse.Data.Customer.Id,

                        },
                        Id = externalActivateSubscriptionResponse.Data.Id,
                        Plan = externalActivateSubscriptionResponse.Data.Plan,
                        Status = externalActivateSubscriptionResponse.Data.Status,



                    },

                }
            };


        }



        private static AllSubscription ConvertToSubscriptionResponse(ExternalAllSubscriptionsResponse externalSubscriptionsResponse)
        {

            return new AllSubscription
            {
                Response = new AllSubscriptionsResponse
                {
                    Status = externalSubscriptionsResponse.Status,
                    Message = externalSubscriptionsResponse.Message,
                    Meta = new AllSubscriptionsResponse.SubscriptionsMeta
                    {
                        PageInfo = new AllSubscriptionsResponse.PageInfo
                        {
                            CurrentPage = externalSubscriptionsResponse.Meta.PageInfo.CurrentPage,
                            Total = externalSubscriptionsResponse.Meta.PageInfo.Total,
                            TotalPages = externalSubscriptionsResponse.Meta.PageInfo.TotalPages
                        }
                    },
                    Data = externalSubscriptionsResponse.Data.Select(data =>
                    {
                        return new AllSubscriptionsResponse.Datum
                        {
                            Status = data.Status,
                            Amount = data.Amount,
                            CreatedAt = data.CreatedAt,
                            Customer = new AllSubscriptionsResponse.Customer
                            {
                                Id = data.Customer.Id,
                                CustomerEmail = data.Customer.CustomerEmail,

                            },
                            Id = data.Id,
                            Plan = data.Plan
                        };
                    }).ToList(),



                }
            };


        }



    }
}
