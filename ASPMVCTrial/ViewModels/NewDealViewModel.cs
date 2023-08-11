namespace ASPMVCTrial.ViewModels
{
    public class NewDealViewModel
    {
        public int Amount { get; set; }
        public string Partner { get; set; }
        public int Profit { get; set; }
        public int ComissionCash { get; set; }
        public int ComissionPercent { get; set; }
        public IFormFile Image { get; set; }
    }
}
