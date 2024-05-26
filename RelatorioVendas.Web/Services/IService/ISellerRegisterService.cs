namespace RelatorioVendas.Web.Services.IService
{
    public interface ISellerRegisterService
    {
        Task<string> RegisterSellersAsync(string name, string state);
    }
}
