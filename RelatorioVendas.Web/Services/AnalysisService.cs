using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using RelatorioVendas.Web.Services.IService;

namespace RelatorioVendas.Web.Services
{
    public class AnalysisService : IAnalysisService
    {
        public async Task<List<(string, string, decimal, decimal)>?> CompareSellers(string month, int year)
        {
            List<(string, string, decimal, decimal)>? salesData = await SalesData(month, year);

            if (salesData != null)
            {
                List<(string, string, decimal, decimal)> salesBySeller = salesData
                    .GroupBy(item => item.Item1)
                    .SelectMany(group => group
                    .OrderByDescending(item => item.Item3 - item.Item4))
                    .OrderByDescending(item => item.Item3 - item.Item4)
                    .ToList();

                return salesBySeller;
            }
            else
            {
                return null;
            }
        }


        public async Task<List<(string, string, decimal, decimal)>?> SalesData(string month, int year)
        {
            var values = await ConnectionWithGoogleSheets(month, year);

            if (values != null && values.Count > 0)
            {
                List<(string, string, decimal, decimal)> salesData = new List<(string, string, decimal, decimal)>();

                for (int i = 0; i < values.Count; i++)
                {
                    (string, string, decimal, decimal) allSales = (
                        (string)values[i][0] ?? "", // Se o valor for nulo, atribui uma string vazia
                        (string)values[i][1] ?? "", // Se o valor for nulo, atribui uma string vazia
                        values[i][2] != null ? Convert.ToDecimal(values[i][2]) : 0, // Se for nulo, atribui zero
                        values[i][3] != null ? Convert.ToDecimal(values[i][3]) : 0 // Se for nulo, atribui zero
                    );


                    salesData.Add(allSales);
                }

                return salesData;
            }
            else
            {
                return null;
            }
    
        }

        public async Task<IList<IList<object>>> ConnectionWithGoogleSheets(string month, int year)
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "secrets.json");
                string jsonContent = System.IO.File.ReadAllText(filePath);

                var credential = GoogleCredential.FromJson(jsonContent)
                .CreateScoped(SheetsService.Scope.SpreadsheetsReadonly);

                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                });

                string spreadsheetId = "1-pV09988ZCsoJamDv7_fdWYcBGR8iAiC3bTLYXqqZtg";
                string range = $"Vendas {month}-{year}!A2:D"; 
            
                var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
                var response = await request.ExecuteAsync();

                IList<IList<object>> values = response.Values;

                return values;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A tabela não foi encontrada. Verifique o ID da planilha e o intervalo. + {ex.Message}");
                IList<IList<object>> values = new List<IList<object>>();

                return values;
            }
            
        }
    }
}
