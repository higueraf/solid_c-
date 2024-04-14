using Solid1SrpApi.Models.Db;
using Solid1SrpApi.Models.ViewModels;
using Solid1SrpApi.Utils;

namespace Solid1SrpApi.Services
{
    public class WineService
    {
        public string Create(WineViewModel wineViewModel) {
            var wineDB = new WineDB();
            var log = new Log();
            wineDB.Save(wineViewModel);
            string Message = "Wine Saved " + wineViewModel.GetInfo();
            log.Save(Message);
            return Message;
        }
    }
}
