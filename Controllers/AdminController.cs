using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectSupplyManagement.Data;
using ProjectSupplyManagement.Models;

namespace ProjectSupplyManagement.Controllers
{
    /*[Authorize(Roles = "Admin")]*/
    public class AdminController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;
        private readonly SignInManager<IdentityUser> _signInManager;
        private const string DefaultAdminUsername = "admin@example.com";
        private const string DefaultAdminPassword = "Admin@123";
        /*private readonly UserManager<IdentityUser> _userManager;*/
        public AdminController(SignInManager<IdentityUser> signInManager, MVCDemoDbContext mvcDemoDbContext)
        {
            _signInManager = signInManager;
            this.mvcDemoDbContext = mvcDemoDbContext; // Initialize the context
        }


        public IActionResult Dashboard()
        {
            return View();
        }

        /*[AllowAnonymous]*/
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /*[AllowAnonymous]*/
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    if (model.Email == DefaultAdminUsername && model.Password == DefaultAdminPassword)
                    {
                        // Redirect to Admin dashboard when admin logs in.
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    }
                }

            }
            return View(model);
        }

        /*public async Task<IActionResult> ApproveOrReject(Guid id)
        {
            var vendor = await mvcDemoDbContext.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return NotFound(); // Return a 404 Not Found response if vendor is not found
            }
            return View("ApproveOrReject", vendor);
        }*/

        public async Task<IActionResult> ApproveOrReject(Guid id, bool isApproved)
        {
            var vendor = await mvcDemoDbContext.Vendors.FindAsync(id);
            if (vendor != null)
            {
                vendor.IsApproved = isApproved;
                await mvcDemoDbContext.SaveChangesAsync();
            }
            return View("Views/Admin/ApproveOrReject/Index.cshtml", vendor); // Specify the view path explicitly
        }

        public async Task<IActionResult> ApproveVendors()
        {
            var unapprovedVendors = await mvcDemoDbContext.Vendors.Where(v => !v.IsApproved).ToListAsync();
            return View("Views/Admin/ApproveVendors/Index.cshtml", unapprovedVendors);

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            // Redirect to the Home/Index action after logout
            return RedirectToAction("Index", "Home");
        }
    }
}
