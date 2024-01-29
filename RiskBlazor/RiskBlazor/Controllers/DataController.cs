using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shares.Models;
using Shares.Services;

namespace RiskBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : Controller
    {
        private readonly IDataProvider _dataProvider;

        public DataController(IDataProvider dataProvider)
        {
            this._dataProvider = dataProvider;
        }

        [HttpGet("general"), AllowAnonymous]
        public Task<List<General>> GetGeneral()
        {
            return _dataProvider.GetGeneral();
        }

        [HttpGet("holding"), AllowAnonymous]
        public Task<List<Holding>> GetHolding()
        {
            return _dataProvider.GetHolding();
        }

        [HttpGet("sharedata"), AllowAnonymous]
        public Task<List<ShareData>> GetShareData()
        {
            return _dataProvider.GetShareData();
        }
    }
}
