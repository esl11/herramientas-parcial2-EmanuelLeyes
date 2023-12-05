using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parcial2.Models;
using parcial2.ViewModels;
using parcial2.Services;
using Microsoft.AspNetCore.Authorization;

namespace parcial2.Controllers
{
   // Solicita estar logueado para acceder
   [Authorize]
    public class FootwearController : Controller
    {
        private readonly IFootwearService _footwearService;

        public FootwearController(IFootwearService FootwearService)
        {
            _footwearService = FootwearService;
        }

        // GET: Footwear
        public async Task<IActionResult> Index(string filter)
        { 
            var FootwearListVM = new FootwearListVM();
            var footwearList = await _footwearService.GetAll(filter);
            // Mapeamos la entidad con el view model para enviar a la vista
            foreach (var item in footwearList)
            {
                FootwearListVM.Footwears.Add(new FootwearVM {
                    Id = item.Id,
                    Name = item.Name,
                    Company = item.Company,
                    Gender = item.Gender,
                    Release = item.Release,
                    Image = item.Image,
                    Stock = item.Stock
                });
            }

            return View(FootwearListVM);
        }

          // GET: Product
          // Aplica el atributo AllowAnonymous a la acción Product
        [AllowAnonymous]
        public async Task<IActionResult> Product(string filter)
        { 
            var FootwearListVM = new FootwearListVM();
            var footwearList = await _footwearService.GetAll(filter);
            // Mapeamos la entidad con el view model para enviar a la vista
            foreach (var item in footwearList)
            {
                FootwearListVM.Footwears.Add(new FootwearVM {
                    Id = item.Id,
                    Name = item.Name,
                    Company = item.Company,
                    Gender = item.Gender,
                    Release = item.Release,
                    Image = item.Image,
                    Stock = item.Stock
                });
            }

            return View(FootwearListVM);
        }


        // GET: Footwear/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var Footwear = await _footwearService.GetById(id);
            if (Footwear == null)
            {
                return NotFound();
            }

            return View(Footwear);
        }

        // GET: Footwear/Create
        public async Task<IActionResult> Create()
        {
            var storeList = await _footwearService.GetAllStores();
            if (storeList == null) storeList = new List<Store>();
            ViewData["Stores"] = new SelectList(storeList, "Id", "Name");
            return View();
        }

        // POST: Footwear/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Release,Gender,Price,Company,Image,StoreIds")] FootwearCreateVM Footwear)
        {
            if (ModelState.IsValid)
            {
                var storeList = await _footwearService.GetAllStores();
                var storeFilteredList = storeList.Where(x=> Footwear.StoreIds.Contains(x.Id)).ToList();
                var newFootwear = new Footwear {
                    Name = Footwear.Name,
                    Gender = Footwear.Gender,
                    Price = Footwear.Price,
                    Image = Footwear.Image,
                    Company = Footwear.Company,
                    Release = Footwear.Release,
                    Stores = storeFilteredList
                };
                await _footwearService.Create(newFootwear);
                return RedirectToAction(nameof(Index));
            }
            return View(Footwear);
        }

        // GET: Footwear/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var Footwear = await _footwearService.GetById(id);
            if (Footwear == null)
            {
                return NotFound();
            }
            return View(Footwear);
        }

        // POST: Footwear/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Name,Release,Gender,Price,Company,Image")] Footwear Footwear)
        {
            if (id != Footwear.Id)
            {
                return NotFound();
            }

            
            {
                try
                {
                    await _footwearService.Update(Footwear);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_footwearService.GetById(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Footwear);
        }

        // GET: Footwear/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var Footwear = await _footwearService.GetById(id);
            if (Footwear == null)
            {
                return NotFound();
            }

            return View(Footwear);
        }

        // POST: Footwear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _footwearService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Footwear/Purchase
        public async Task<IActionResult> Purchase(int id)
        {
            var Footwear = await _footwearService.GetById(id);
            if (Footwear == null)
            {
                return NotFound();
            }

            ViewData["Footwear"] = Footwear;

            return View();
        }

        // POST: Footwear/Purchase
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Purchase([Bind("FootwearId,Date,Quantity,InvoiceNumber")] MovementCreateVM purchase)
        {
            if (ModelState.IsValid)
            {
                var newPurchase = new Movement {
                    FootwearId = purchase.FootwearId,
                    Quantity = purchase.Quantity,
                    InvoiceNumber = purchase.InvoiceNumber,
                    Date = purchase.Date,
                    TypeM = Utils.MovementType.purchase
                };
                await _footwearService.Purchase(newPurchase);
                return RedirectToAction(nameof(Index));
            }
            return View(purchase);
        }

        // GET: Footwear/Sale
        public async Task<IActionResult> Sale(int id)
        {
            var Footwear = await _footwearService.GetById(id);
            if (Footwear == null)
            {
                return NotFound();
            }

            ViewData["Footwear"] = Footwear;

            return View();
        }

        // POST: Footwear/Sale
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sale([Bind("FootwearId,Date,Quantity,InvoiceNumber")] MovementCreateVM sale)
        {
            if (ModelState.IsValid)
            {
                var newSale = new Movement {
                    FootwearId = sale.FootwearId,
                    Quantity = sale.Quantity,
                    InvoiceNumber = sale.InvoiceNumber,
                    Date = sale.Date,
                    TypeM = Utils.MovementType.sale
                };
                var response = await _footwearService.Sale(newSale);

                if (string.IsNullOrEmpty(response))
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ErrorMsg"] = response;
            }
            return View(sale);
        }
    }
}
