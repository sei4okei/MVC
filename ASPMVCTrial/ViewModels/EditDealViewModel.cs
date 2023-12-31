﻿using System.Security.Permissions;

namespace ASPMVCTrial.ViewModels
{
    public class EditDealViewModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Partner { get; set; }
        public int Profit { get; set; }
        public int ComissionCash { get; set; }
        public int ComissionPercent { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
    }
}
