using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSupplyManagement.Data;
using ProjectSupplyManagement.Models.Domain;
using System.Data;

namespace ProjectSupplyManagement.Controllers
{
	public class VendorController : Controller
	{
		private readonly MVCDemoDbContext mvcDemoDbContext;

        public VendorController(MVCDemoDbContext mvcDemoDbContext)
		{
			this.mvcDemoDbContext = mvcDemoDbContext;
        }

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(Vendor vendor)
		{
			if (ModelState.IsValid)
			{
				vendor.Id = Guid.NewGuid();
				vendor.IsApproved = false;
				mvcDemoDbContext.Vendors.Add(vendor);
				await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
			}
            return View(vendor);
		}
    }
}
