using System.Collections.Generic;

namespace FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks
{
    public class BankResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<BanksData> Data { get; set; }

        public class BanksData
        {
            public int Id { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
        }







    }
}
