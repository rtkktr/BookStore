
using BookStore.Application.Contracts;
using BookStore.Application.Dtos.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.Presentation.Controllers
{
    public class UserController : Controller
    {
        #region [- Constructor -]

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region [- Index -]

        public async Task<IActionResult> Index()
        {
            var (users, errors) = await _userService.GetAllAsync();
            if (errors != null)
                foreach (var e in errors)
                    if (e != null && e.Description != null)
                        ModelState.AddModelError("", e.Description);
            return View(users);
        }

        #endregion

        #region [- Register -]

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserDto createUserDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateAsync(createUserDto);
                if (result == null || result.Count == 0)
                {
                    TempData["success"] = "User Register successfully";
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    foreach (var e in result)
                    {
                        if (e != null && e.Description != null)
                            ModelState.AddModelError("", e.Description);
                    }
                }
            }
            return View(createUserDto);
        }

        #endregion

        #region [- Delete -]

        public async Task<IActionResult> Delete(string userId)
        {
            var (getUserDto, errors) = await _userService.GetUserById(userId);
            if (errors.Count> 0)
            {
                foreach (var e in errors)
                {
                    if (e != null && e.Description != null)
                    {
                        ModelState.AddModelError("", e.Description);
                    }
                }
                return RedirectToAction("Index", "User");
            }
            return View(getUserDto);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(GetUserDto userDto)
        {
            RemoveUserDto removeUserDto = new RemoveUserDto() {Id = userDto.Id };
            var result = await _userService.RemoveById(removeUserDto); 
            if(result.Count > 0) 
            {
                foreach(var e in result)
                {
                    if (e != null && e.Description != null)
                        ModelState.AddModelError("", e.Description);
                }
            }
            TempData["success"] = "User Delete successfully";
            return RedirectToAction("Index","User");
        }
        #endregion

        #region [- Edit -]
        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            var (getUserDto, errors) = await _userService.GetUserById(userId);
            if(errors.Count > 0)
            {
                foreach (var e in errors)
                {
                    if(e != null && e.Description != null)
                    {
                        ModelState.AddModelError("", e.Description);
                    }
                }
                return RedirectToAction("Index", "User");
            }
            return View(getUserDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(GetUserDto getUserDto)
        {
            EditUserDto editUserDto = new EditUserDto() { 
                Id=getUserDto.Id,
                FirstName = getUserDto.FirstName,
                LastName = getUserDto.LastName,
                Email = getUserDto.Email,
                NationalId = getUserDto.NationalId,
                PhoneNumber = getUserDto.PhoneNumber,
                UserName = getUserDto.UserName,
                City = getUserDto.City,
                StreetAddress = getUserDto.StreetAddress,
            };
            var result = await _userService.EditById(editUserDto);
            if (result.Count > 0)
            {
                foreach(var e in result)
                {
                    if(e!= null && e.Description != null)
                    {
                        ModelState.AddModelError("", e.Description);
                    }
                }
            }
            TempData["success"] = "User updated successfully";
            return RedirectToAction("Index", "User");
        }
        #endregion
    }
}