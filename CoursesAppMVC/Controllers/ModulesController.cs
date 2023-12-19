using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoursesAppMVC.Data;
using CoursesAppMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


namespace CoursesAppMVC.Controllers
{
    // Authorization code has been adapted from:
    // Author:Pranaya Rout 
    // Link: https://dotnettutorials.net/lesson/forms-authentication-in-mvc/
    
    [Authorize]
    public class ModulesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public ModulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Modules
        public async Task<IActionResult> Index()
        {

            // Fetch modules associated with the current user

            var userModules = _context.Modules
                .Where(m => m.StudentID == User.Identity.Name)
                .ToList();

            return View(userModules);

        }

        // GET: Modules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Modules == null)
            {
                return NotFound();
            }

            var modules = await _context.Modules
                .FirstOrDefaultAsync(m => m.ModuleID == id);
            if (modules == null)
            {
                return NotFound();
            }

            return View(modules);
        }

        // GET: Modules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModuleID,ModuleCode,ModuleName,Credits,ClassHoursPerWeek,WeeksInSemester,StartDate,StudentID")] Modules modules)
        {
            if (ModelState.IsValid)
            {
                // Calculate initial SelfStudyHoursPerWeek
                modules.SelfStudyHoursPerWeek = (float)((modules.Credits * 10.0) / modules.WeeksInSemester - modules.ClassHoursPerWeek);

                string? ID = User.Identity.Name;

                modules.StudentID = ID;
                
                _context.Add(modules);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modules);

        }

        // GET: Modules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Modules == null)
            {
                return NotFound();
            }

            var modules = await _context.Modules.FindAsync(id);
            if (modules == null)
            {
                return NotFound();
            }
            return View(modules);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModuleID,ModuleCode,ModuleName,Credits,ClassHoursPerWeek,WeeksInSemester,SelfStudyHoursPerWeek,StartDate,StudentID")] Modules modules)
        {
            if (id != modules.ModuleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modules);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModulesExists(modules.ModuleID))
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
            return View(modules);
        }

        // GET: Modules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Modules == null)
            {
                return NotFound();
            }

            var modules = await _context.Modules
                .FirstOrDefaultAsync(m => m.ModuleID == id);
            if (modules == null)
            {
                return NotFound();
            }

            return View(modules);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Modules == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Modules'  is null.");
            }
            var modules = await _context.Modules.FindAsync(id);
            if (modules != null)
            {
                _context.Modules.Remove(modules);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Code below has been adapted from:
        // Author:Pranaya Rout 
        // Link: https://dotnettutorials.net/lesson/forms-authentication-in-mvc/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStudyHours(int id, float hoursSpent)
        {
            var module = await _context.Modules.FindAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            // Perform the calculation
            module.SelfStudyHoursPerWeek -= hoursSpent;

            // Update the module in the database
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private bool ModulesExists(int id)
        {
          return (_context.Modules?.Any(e => e.ModuleID == id)).GetValueOrDefault();
        }
    }
}
