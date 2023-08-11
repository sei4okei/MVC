using ASPMVCTrial.Data.Interfaces;
using ASPMVCTrial.Models;
using ASPMVCTrial.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPMVCTrial.Controllers
{
    public class DealController : Controller
    {
        private readonly IDealService dealService;
        private readonly IPhotoService photoService;

        public DealController(IDealService _dealService, IPhotoService _photoService)
        {
            dealService = _dealService;
            photoService = _photoService;
        }

        public async Task<IActionResult> Index()
        {
            var deals = await dealService.GetAll();
            return View(deals);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewDealViewModel dealViewModel)
        {
            if (!ModelState.IsValid) return View(dealViewModel);

            var addedPhoto = await photoService.AddPhotoAsync(dealViewModel.Image);

            var deal = new Deal
            {
                Amount = dealViewModel.Amount,
                Partner = dealViewModel.Partner,
                Profit = dealViewModel.Profit,
                ComissionCash = dealViewModel.ComissionCash,
                ComissionPercent = dealViewModel.ComissionPercent,
                Image = addedPhoto.Url.ToString()
            };

            var added = dealService.Add(deal);

            if (!added) return View("Error");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var deal = await dealService.GetById(id);

            if (deal == null) return View("Error");

            return View(deal);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteDeal(int id)
        {
            var deal = await dealService.GetById(id);

            if (deal == null) return View("Error");

            var deleted = dealService.Delete(deal);

            if (!deleted) return View("Error");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var deal = await dealService.GetById(id);

            if (deal == null) return View("Error");

            var dealVM = new EditDealViewModel
            {
                Id = id,
                Amount = deal.Amount,
                Partner = deal.Partner,
                Profit = deal.Profit,
                ComissionCash = deal.ComissionCash,
                ComissionPercent = deal.ComissionPercent,
                URL = deal.Image
            };

            return View(dealVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditDealViewModel dealVM)
        {
            if (!ModelState.IsValid) return View(dealVM);

            var deal = await dealService.GetByIdNoTracking(dealVM.Id);

            if (deal == null) return View("Error");

            var editPhoto = await photoService.AddPhotoAsync(dealVM.Image);

            if (editPhoto.Error != null) return View(dealVM);

            if (!string.IsNullOrEmpty(deal.Image))
            {
                _ = photoService.DeletePhotoAsync(deal.Image);
            }

            var newDeal = new Deal
            {
                Id = dealVM.Id,
                Amount = dealVM.Amount,
                Partner = dealVM.Partner,
                Profit = dealVM.Profit,
                ComissionCash = dealVM.ComissionCash,
                ComissionPercent = dealVM.ComissionPercent,
                Image = editPhoto.Url.ToString()
            };

            dealService.Update(newDeal);

            return RedirectToAction("Index");
        }
    }
}
