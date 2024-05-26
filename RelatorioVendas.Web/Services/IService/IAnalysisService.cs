namespace RelatorioVendas.Web.Services.IService
{
    public interface IAnalysisService
    {
        Task<List<(string, string, decimal, decimal)>?> CompareSellers(string month, int year);
        Task<List<(string, string, decimal, decimal)>?> SalesData(string month, int year);
        Task<IList<IList<object>>> ConnectionWithGoogleSheets(string month, int year);
    }
}
