using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using RelatorioVendas.Web.Services.IService;

namespace RelatorioVendas.Web.Services
{
    public class SellerRegisterService : ISellerRegisterService
    {
        public async Task<string> RegisterSellersAsync(string name, string state)
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "secrets.json");
                string jsonContent = System.IO.File.ReadAllText(filePath);

                var credential = GoogleCredential.FromJson(jsonContent)
                    .CreateScoped(SheetsService.Scope.Spreadsheets); // para permitir editar

                var service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                });

                string spreadsheetId = "1-pV09988ZCsoJamDv7_fdWYcBGR8iAiC3bTLYXqqZtg";
                string range = "Vendedores!A2:B";

                var cadastro = new ValueRange();
                cadastro.Values = new List<IList<object>>
                {
                    new List<object> { name, state }
                };

                var request = service.Spreadsheets.Values.Append(cadastro, spreadsheetId, range);
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                var response = await request.ExecuteAsync();

                return "Sucesso ao cadastrar!";
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro + {ex.Message}");
                return "Falha ao cadastrar!";
            }
            
        }
    }
}
