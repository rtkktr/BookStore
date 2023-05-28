using BookStore.Domain.Models;
using BookStore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Test.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderDetail
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrderDetail.Include(o => o.Book).Include(o => o.OrderHeader);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrderDetail/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.OrderDetail == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetail
                .Include(o => o.Book)
                .Include(o => o.OrderHeader)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: OrderDetail/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "ShortDescription");
            ViewData["OrderHeaderId"] = new SelectList(_context.OrderHeader, "Id", "Code");
            return View();
        }

        // POST: OrderDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderHeaderId,BookId,Quantity,UnitPrice,DateCreation,DateModification,IsDeleted")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                orderDetail.BookId = Guid.NewGuid();
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "ShortDescription", orderDetail.BookId);
            ViewData["OrderHeaderId"] = new SelectList(_context.OrderHeader, "Id", "Code", orderDetail.OrderHeaderId);
            return View(orderDetail);
        }

        // GET: OrderDetail/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.OrderDetail == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetail.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "ShortDescription", orderDetail.BookId);
            ViewData["OrderHeaderId"] = new SelectList(_context.OrderHeader, "Id", "Code", orderDetail.OrderHeaderId);
            return View(orderDetail);
        }

        // POST: OrderDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OrderHeaderId,BookId,Quantity,UnitPrice,DateCreation,DateModification,IsDeleted")] OrderDetail orderDetail)
        {
            if (id != orderDetail.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.BookId))
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
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "ShortDescription", orderDetail.BookId);
            ViewData["OrderHeaderId"] = new SelectList(_context.OrderHeader, "Id", "Code", orderDetail.OrderHeaderId);
            return View(orderDetail);
        }

        // GET: OrderDetail/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.OrderDetail == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetail
                .Include(o => o.Book)
                .Include(o => o.OrderHeader)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.OrderDetail == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OrderDetail'  is null.");
            }
            var orderDetail = await _context.OrderDetail.FindAsync(id);
            if (orderDetail != null)
            {
                _context.OrderDetail.Remove(orderDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(Guid id)
        {
          return (_context.OrderDetail?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
