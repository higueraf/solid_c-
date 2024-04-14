namespace Solid1SrpApi.Models.ViewModels
{
    public class WineViewModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }

        public string GetInfo() => Name + " " + Brand;
    }
}
