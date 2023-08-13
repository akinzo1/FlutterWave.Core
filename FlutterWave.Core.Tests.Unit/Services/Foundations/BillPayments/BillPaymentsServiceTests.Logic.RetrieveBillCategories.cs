using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.BillPayment
{
    public partial class BillPaymentsServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveBillCategoriesAsync()
        {
            // given 
            dynamic createRandomBillCategoriesProperties =
                 CreateRandomBillCategoriesProperties();

            var RandomExternalBillCategoriesResponse = new ExternalBillCategoriesResponse
            {
                Message = createRandomBillCategoriesProperties.Message,
                Status = createRandomBillCategoriesProperties.Status,
                Data = ((List<dynamic>)createRandomBillCategoriesProperties.Data).Select(data =>
                {
                    return new ExternalBillCategoriesResponse.Datum
                    {
                        Id = data.Id,
                        Amount = data.Amount,
                        BillerCode = data.BillerCode,
                        BillerName = data.BillerName,
                        CommissionOnFee = data.CommissionOnFee,
                        Country = data.Country,
                        DateAdded = data.DateAdded,
                        DefaultCommission = data.DefaultCommission,
                        Fee = data.Fee,
                        IsAirtime = data.IsAirtime,
                        ItemCode = data.ItemCode,
                        LabelName = data.LabelName,
                        Name = data.Name,
                        ShortName = data.ShortName,

                    };
                }).ToList(),

            };

            var RandomExpectedBillCategoriesResponse = new BillCategoriesResponse
            {
                Message = createRandomBillCategoriesProperties.Message,
                Status = createRandomBillCategoriesProperties.Status,
                Data = ((List<dynamic>)createRandomBillCategoriesProperties.Data).Select(data =>
                {
                    return new BillCategoriesResponse.Datum
                    {
                        Id = data.Id,
                        Amount = data.Amount,
                        BillerCode = data.BillerCode,
                        BillerName = data.BillerName,
                        CommissionOnFee = data.CommissionOnFee,
                        Country = data.Country,
                        DateAdded = data.DateAdded,
                        DefaultCommission = data.DefaultCommission,
                        Fee = data.Fee,
                        IsAirtime = data.IsAirtime,
                        ItemCode = data.ItemCode,
                        LabelName = data.LabelName,
                        Name = data.Name,
                        ShortName = data.ShortName,

                    };
                }).ToList(),

            };


            var expectedInputBillCategories = new BillCategories
            {
                Response = RandomExpectedBillCategoriesResponse
            };
            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBillCategoriesAsync())
                    .ReturnsAsync(RandomExternalBillCategoriesResponse);

            // when
            BillCategories actualBillCategories =
                await this.billPaymentsService.GetBillCategoriesAsync();

            // then
            actualBillCategories.Should().BeEquivalentTo(expectedInputBillCategories);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillCategoriesAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}