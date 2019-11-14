using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PageAdmin.Models;

namespace PageAdmin.Controllers
{
    public class SalesPersonController : Controller
    {
        private readonly AdminDbContext _context;

        public SalesPersonController(AdminDbContext context)
        {
            _context = context;
        }

        // GET: SalesPerson
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesPerson.ToListAsync());
        }

        // GET: SalesPerson/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesPerson = await _context.SalesPerson
                .FirstOrDefaultAsync(m => m.SalesPersonID == id);
            if (salesPerson == null)
            {
                return NotFound();
            }

            return View(salesPerson);
        }

        // GET: SalesPerson/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesPerson/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesPersonID,FirstName,LastName,Phone,HireDate,Active")] SalesPerson salesPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesPerson);
        }

        // GET: SalesPerson/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesPerson = await _context.SalesPerson.FindAsync(id);
            if (salesPerson == null)
            {
                return NotFound();
            }
            return View(salesPerson);
        }

        // POST: SalesPerson/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesPersonID,FirstName,LastName,Phone,HireDate,Active")] SalesPerson salesPerson)
        {
            if (id != salesPerson.SalesPersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesPersonExists(salesPerson.SalesPersonID))
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
            return View(salesPerson);
        }

        private bool SalesPersonExists(int id)
        {
            return _context.SalesPerson.Any(e => e.SalesPersonID == id);
        }
        public List<SalesPerson> SalesPersons { get; set; }
        public async Task<IActionResult> SearchAsync(string search)
        {
            var sale = from m in _context.SalesPerson select m;
            if (!string.IsNullOrEmpty(search))
            {
                sale = sale.Where(s => s.Phone.Contains(search));
            }
            SalesPersons = await sale.ToListAsync();
            return View(SalesPersons);
        }
    }
}
