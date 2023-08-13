using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalChargeBack;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.ChargeBacks
{
    public partial class ChargeBackServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveAllChargeBackAsync()
        {
            // given 


            dynamic createRandomChargeBacksProperties =
                CreateRandomAllChargeBackProperties();

            var randomExternalChargeBacksResponse = new ExternalChargeBacksResponse
            {
                Status = createRandomChargeBacksProperties.Status,
                Meta = new ExternalChargeBacksResponse.PageInfo
                {
                    CurrentPage = createRandomChargeBacksProperties.Meta.CurrentPage,
                    PageSize = createRandomChargeBacksProperties.Meta.PageSize,
                    Total = createRandomChargeBacksProperties.Meta.Total,
                    TotalPages = createRandomChargeBacksProperties.Meta.TotalPages
                },
                Message = createRandomChargeBacksProperties.Message,
                Data = ((List<dynamic>)createRandomChargeBacksProperties.Data).Select(data =>
                {
                    return new ExternalChargeBacksResponse.Datum
                    {
                        Id = data.Id,
                        Meta = new ExternalChargeBacksResponse.ExternalChargeBacksMeta
                        {
                            PageInfo = new ExternalChargeBacksResponse.PageInfo
                            {
                                TotalPages = data.Meta.PageInfo.TotalPages,
                                Total = data.Meta.PageInfo.Total,
                                CurrentPage = data.Meta.PageInfo.CurrentPage,
                                PageSize = data.Meta.PageInfo.PageSize


                            },
                            UploadedProof = data.Meta.UploadedProof,
                            History = ((List<dynamic>)data.Meta.History).Select(history =>
                            {
                                return new ExternalChargeBacksResponse.History
                                {
                                    Action = history.Action,
                                    Date = history.Date,
                                    Description = history.Description,
                                    Initiator = history.Initiator,
                                    Source = history.Source,
                                    Stage = history.Stage,
                                };

                            }).ToList(),
                        },
                        FlwRef = data.FlwRef,
                        DueDate = data.DueDate,
                        CreatedAt = data.CreatedAt,
                        Comment = data.Comment,
                        Amount = data.Amount,
                        SettlementId = data.SettlementId,
                        Stage = data.Stage,
                        Status = data.Status,
                        TransactionId = data.TransactionId,
                        TxRef = data.TxRef,

                    };
                }).ToList(),

            };

            var randomExpectedChargeBackResponse = new AllChargeBacksResponse
            {
                Status = createRandomChargeBacksProperties.Status,
                Meta = new AllChargeBacksResponse.PageInfo
                {
                    CurrentPage = createRandomChargeBacksProperties.Meta.CurrentPage,
                    PageSize = createRandomChargeBacksProperties.Meta.PageSize,
                    Total = createRandomChargeBacksProperties.Meta.Total,
                    TotalPages = createRandomChargeBacksProperties.Meta.TotalPages
                },
                Message = createRandomChargeBacksProperties.Message,
                Data = ((List<dynamic>)createRandomChargeBacksProperties.Data).Select(data =>
                {
                    return new AllChargeBacksResponse.Datum
                    {
                        Id = data.Id,
                        Meta = new AllChargeBacksResponse.ChargeBacksMeta
                        {
                            PageInfo = new AllChargeBacksResponse.PageInfo
                            {
                                TotalPages = data.Meta.PageInfo.TotalPages,
                                Total = data.Meta.PageInfo.Total,
                                CurrentPage = data.Meta.PageInfo.CurrentPage,
                                PageSize = data.Meta.PageInfo.PageSize


                            },
                            UploadedProof = data.Meta.UploadedProof,
                            History = ((List<dynamic>)data.Meta.History).Select(history =>
                            {
                                return new AllChargeBacksResponse.History
                                {
                                    Action = history.Action,
                                    Date = history.Date,
                                    Description = history.Description,
                                    Initiator = history.Initiator,
                                    Source = history.Source,
                                    Stage = history.Stage,
                                };

                            }).ToList(),
                        },
                        FlwRef = data.FlwRef,
                        DueDate = data.DueDate,
                        CreatedAt = data.CreatedAt,
                        Comment = data.Comment,
                        Amount = data.Amount,
                        SettlementId = data.SettlementId,
                        Stage = data.Stage,
                        Status = data.Status,
                        TransactionId = data.TransactionId,
                        TxRef = data.TxRef,

                    };
                }).ToList(),

            };

            var expectedChargeBack = new AllChargeBacks
            {
                Response = randomExpectedChargeBackResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllChargeBacksAsync())
                    .ReturnsAsync(randomExternalChargeBacksResponse);

            // when
            AllChargeBacks actualBillPaymentsStatus =
               await this.chargeBackService.GetAllChargeBacksAsync();

            // then
            actualBillPaymentsStatus.Should().BeEquivalentTo(expectedChargeBack);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllChargeBacksAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}