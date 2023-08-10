using ASPMVCTrial.Data.Interfaces;
using ASPMVCTrial.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPMVCTrial.Controllers
{
    public class DealController : Controller
    {
        private readonly IDealService dealService;

        public DealController(IDealService _dealService)
        {
            dealService = _dealService;
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
        public async Task<IActionResult> Create(Deal deal)
        {
            if (!ModelState.IsValid) return View(deal);

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

            return View(deal);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Deal deal)
        {
            if (!ModelState.IsValid) return View(deal);

            var updated = dealService.Update(deal);

            if (!updated) return View("Error");

            return RedirectToAction("Index");
        }
    }
}
