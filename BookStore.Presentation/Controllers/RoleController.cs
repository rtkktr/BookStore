using BookStore.Application.Contracts;
using BookStore.Application.Dtos.Role;
using BookStore.Application.Dtos.Users;
using BookStore.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }


        public async Task<IActionResult> Index()
        {
            var (roles, errors) = await _roleService.GetAllAsync();
            if (errors != null)
                foreach (var e in errors)
                    if (e != null && e.Description != null)
                        ModelState.AddModelError("", e.Description);
            return View(roles);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleService.CreateAsync(createRoleDto);
                if (result == null || result.Count == 0)
                    return RedirectToAction("Index", "Role");
                else
                {
                    foreach (var e in result)
                    {
                        if (e != null && e.Description != null)
                            ModelState.AddModelError("", e.Description);
                    }
                }
            }
            return View(createRoleDto);
        }

    }
}
