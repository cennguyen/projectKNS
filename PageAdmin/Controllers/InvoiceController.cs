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
    public class InvoiceController : Controller
    {
        private readonly AdminDbContext _context;

        public InvoiceController(AdminDbContext context)
        {
            _context = context;
        }

        // GET: Invoice
        public async Task<IActionResult> Index()
        {
            var invoice = await _context.Invoice.ToListAsync();
            return View(invoice);
        }

        // GET: Invoice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }
        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.PaymentID == id);
        }
        public List<Invoice> Invoices { get; set; }
        public async Task<IActionResult> Search(string search)
        {
            var invoice = from c in _context.Invoice select c;
            if (!string.IsNullOrEmpty(search))
            {
                invoice = invoice.Where(s => s.PaymentType.Contains(search));
            }
            Invoices = await invoice.ToListAsync();
            return View(Invoices);
        }
    }
}
