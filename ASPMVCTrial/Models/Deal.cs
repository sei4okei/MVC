namespace ASPMVCTrial.Models
{
    public class Deal
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Partner { get; set; }
        public int Profit { get; set; }
        public int ComissionCash { get; set; }
        public int ComissionPercent { get; set; }
    }
}
