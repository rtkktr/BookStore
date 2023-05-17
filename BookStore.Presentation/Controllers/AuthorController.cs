using BookStore.Domain.Models;
using BookStore.Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStore.Presentation.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository<Guid?, bool?> _authorRepository;

        public AuthorController(IAuthorRepository<Guid?, bool?> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _authorRepository.SelectAllAsync();
            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName, Description")] Author author)
        {
            await _authorRepository.InsertAsync(author);
            return View(author);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var author = await _authorRepository.SelectByIdAsync(id);
            if(author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("Id,FirstName,LastName, Description")] Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }
            await _authorRepository.UpdateAsync(author);
            return View(author);
        }
    }
}
