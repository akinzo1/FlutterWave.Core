namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan
{
    public class CreatePaymentPlanRequest
    {

        public int Amount { get; set; }
        public string Name { get; set; }
        public string Interval { get; set; }
        public int Duration { get; set; }

    }
}
