using Shares.Models;

namespace Shares.Services
{
    public interface IDataProvider
    {
        Task<List<General>> GetGeneral();
        Task<List<Holding>> GetHolding();
        Task<List<ShareData>> GetShareData();
    }
}