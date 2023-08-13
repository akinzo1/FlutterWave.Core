



using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSubscriptions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscription;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace FlutterWave.Core.Tests.Acceptance.Clients.SubscriptionClient
{
    public partial class SubscriptionClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly IFlutterWaveClient flutterWaveClient;

        public SubscriptionClientTests()
        {
            this.apiKey = GetRandomString();
            this.wireMockServer = WireMockServer.Start();

            var apiConfigurations = new ApiConfigurations
            {
                ApiUrl = this.wireMockServer.Url,
                ApiKey = this.apiKey,

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);
        }

        private static DateTimeOffset GetRandomDate() =>
             new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

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


                    }
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



        private static ExternalSubscriptionResponse CreateExternalSubscriptionResponseResult() =>
                CreateExternalSubscriptionResponseFiller().Create();

        private static ExternalAllSubscriptionsResponse CreateExternalAllSubscriptionsResponseResult() =>
           CreateExternalAllSubscriptionsResponseFiller().Create();


        private static Filler<ExternalAllSubscriptionsResponse> CreateExternalAllSubscriptionsResponseFiller()
        {
            var filler = new Filler<ExternalAllSubscriptionsResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }


        private static Filler<ExternalSubscriptionResponse> CreateExternalSubscriptionResponseFiller()
        {
            var filler = new Filler<ExternalSubscriptionResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }


        public void Dispose() => this.wireMockServer.Stop();
    }
}
