using Solid1SrpApi.Models.ViewModels;

namespace Solid1SrpApi.Models.Db
{
    public class WineDB
    {
        public void Save(WineViewModel wineViewModel)
        {
            Console.WriteLine("Saved en DB " + wineViewModel.Name);
        }
    }
}
