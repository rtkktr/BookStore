using BookStore.Domain.Models;
using BookStore.Infrastructure;
using BookStore.Infrastructure.Contracts;
using BookStore.Infrastructure.Services.Statuses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.Controllers
{
    public class OrderHeaderController : Controller
    {
        private readonly IOrderHeaderRepository<Guid?, bool, RepositoryStatus> _orderHeaderRepository;

        public OrderHeaderController(IOrderHeaderRepository<Guid?, bool, RepositoryStatus> orderHeaderRepository)
        {
            _orderHeaderRepository = orderHeaderRepository;
        }

        // GET: OrderHeader
        public async Task<IActionResult> Index()
        {
            var (orderHeaders, orderHeadersStatus) = await _orderHeaderRepository.SelectAllAsync();
            switch (orderHeadersStatus)
            {
                case RepositoryStatus.Success:
                    return View(orderHeaders);
                case RepositoryStatus.DatabaseError:
                case RepositoryStatus.TableIsEmpty:
                    return View(new List<OrderHeader>());
            }
            return View();
        }

        // GET: OrderHeader/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var (orderHeaders, orderHeadersStatus) = await _orderHeaderRepository.SelectAllAsync();
            if (id == null || orderHeaders == null)
            {
                return NotFound();
            }

            var (orderHeader, orderHeaderStatus) = await _orderHeaderRepository.SelectByIdAsync(id);
            if (orderHeader == null)
            {
                return NotFound();
            }

            return View(orderHeader);
        }

        // GET: OrderHeader/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderHeader/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Date,DateCreation,DateModification,IsDeleted,Id")] OrderHeader orderHeader)
        {
            if (ModelState.IsValid)
            {
                orderHeader.Id = Guid.NewGuid();
                await _orderHeaderRepository.InsertAsync(orderHeader);
                return RedirectToAction(nameof(Index));
            }
            return View(orderHeader);
        }

        // GET: OrderHeader/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var (orderHeaders, orderHeadersStatus) = await _orderHeaderRepository.SelectAllAsync();
            if (id == null || orderHeaders == null)
            {
                return NotFound();
            }

            var (orderHeader, orderHeaderStatus) = await _orderHeaderRepository.SelectByIdAsync(id);
            if (orderHeader == null)
            {
                return NotFound();
            }
            return View(orderHeader);
        }

        // POST: OrderHeader/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Code,Date,DateCreation,DateModification,IsDeleted,Id")] OrderHeader orderHeader)
        {
            if (id != orderHeader.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _orderHeaderRepository.UpdateAsync(orderHeader);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderHeaderExists(orderHeader.Id))
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
            return View(orderHeader);
        }

        // GET: OrderHeader/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var (orderHeaders, orderHeadersStatus) = await _orderHeaderRepository.SelectAllAsync();
            if (id == null || orderHeaders == null)
            {
                return NotFound();
            }

            var (orderHeader, orderHeaderStatus) = await _orderHeaderRepository.SelectByIdAsync(id);
            if (orderHeader == null)
            {
                return NotFound();
            }

            return View(orderHeader);
        }

        // POST: OrderHeader/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var (orderHeaders, orderHeadersStatus) = await _orderHeaderRepository.SelectAllAsync();
            if (orderHeaders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OrderHeader'  is null.");
            }
            var (orderHeader, orderHeaderStatus) = await _orderHeaderRepository.SelectByIdAsync(id);
            if (orderHeader != null)
            {
                await _orderHeaderRepository.DeleteByIdAsync(id);
            }
          
            return RedirectToAction(nameof(Index));
        }

        private bool OrderHeaderExists(Guid id)
        {
            var (orderHeaderExist, status) = _orderHeaderRepository.IsExist(id);
            return orderHeaderExist;
        }
    }
}
