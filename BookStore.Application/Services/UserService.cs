using BookStore.Application.Contracts;
using BookStore.Application.Dtos.Users;
using BookStore.Domain.Models;
using BookStore.Utility.ValidationErrors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<ValidationError?>?> CreateAsync(CreateUserDto user)
        {
            var identityUser = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email,
                NationalCode = user.NatinalCode,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            List<IdentityError?>? errors = new List<IdentityError?>();
            List<ValidationError?>? validationErrors = new();

            if (identityUser == null)
                errors.Add(new IdentityError() { Code = "NullUserExeption", Description = "User shoulden't be null " });

            if (user.Password == null)
                errors.Add(new IdentityError() { Code = "NullPasswordExeption", Description = "Password shoulden't be null " });

            if (identityUser != null && user.Password != null)
            {
                var result = await _userManager.CreateAsync(identityUser, user.Password);
                var roleResult = await _userManager.AddToRoleAsync(identityUser, "User");
                if (!result.Succeeded || !roleResult.Succeeded)
                {
                    errors.AddRange(result.Errors.ToList());
                    errors.AddRange(roleResult.Errors.ToList());
                }
            }


            if (errors.Count > 0)
            {
                foreach (var error in errors)
                {
                    validationErrors.Add(new ValidationError
                    {
                        Code = error.Code,
                        Description = error.Description,
                    });
                }
            }

            return validationErrors;
        }

        public async Task<(List<GetAllUserDto?>?, List<ValidationError?>?)> GetAllAsync()
        {
            List<GetAllUserDto?>? usersDto = new List<GetAllUserDto?>();
            List<ValidationError?>? errors = new();

            List<ApplicationUser> users = await _userManager.Users.ToListAsync();

            if (users.Count == 0)
                errors.Add(new ValidationError
                {
                    Code = "UsersNotFound",
                    Description = "There are no registered users in the app"
                });

            foreach (var user in users)
            {
                usersDto.Add(new GetAllUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Id = user.Id.ToString(),
                });
            }

            return (usersDto, errors);
        }

        public async Task<(GetUserDto ,List<ValidationError?>?)> GetUserByIdAsync(string id)
        {
            GetUserDto? userDto = new GetUserDto();
            List<ValidationError?>? validationErrors = new();
            List<IdentityError> errors = new();
            if (id == null)
            {
                validationErrors.Add(new ValidationError() { Code = "NullUserIdExeption", Description = "Id Shoudnt be null" });
            }
            else
            {
                ApplicationUser? user = await _userManager.FindByIdAsync(id);
                if(user == null) 
                {
                    errors.Add(new IdentityError() { Code = "NullUserExeption", Description = "User is null" });
                }
                else
                {
                    userDto.UserName = user.UserName;
                    userDto.FirstName = user.FirstName;
                    userDto.LastName = user.LastName;
                    userDto.NationalId = user.NationalCode;
                    userDto.Id = user.Id.ToString();
                    userDto.PhoneNumber = user.PhoneNumber;
                    userDto.City = user.City;
                    userDto.StreetAddress = user.StreetAddress;
                    userDto.Email = user.Email;
                }
            }
            if (errors.Count > 0)
            {
                foreach (var error in errors)
                {
                    validationErrors.Add(new ValidationError
                    {
                        Code = error.Code,
                        Description = error.Description,
                    });
                }
            }
            return (userDto, validationErrors);

        }

        public async Task<List<ValidationError?>?> RemoveAsync(RemoveUserDto removeUserDto)
        {
            List<IdentityError?>? errors = new List<IdentityError?>();
            List<ValidationError?>? validationErrors = new List<ValidationError?>();
            if(removeUserDto == null) {
                validationErrors.Add(new ValidationError() { Code = "NullExpetionRemoveUserDto", Description = "Remove dto shuldnt null" });
            }
            if(removeUserDto.Id == null) {
                validationErrors.Add(new ValidationError() { Code = "NullUserIdExeption", Description = "Id shuldnt be null" });
            }
            else
            {
                var user = await _userManager.FindByIdAsync(removeUserDto.Id);
                if (user != null)
                {
                    var result = await _userManager.DeleteAsync(user);
                    if (!result.Succeeded)
                    {
                        errors.AddRange(result.Errors.ToList());
                    }
                }

            }
            foreach (var error in errors)
            {
                validationErrors.Add(new ValidationError { Code = error.Code, Description = error.Description });
            }

            return validationErrors;
        }
        public async Task<List<ValidationError?>?> EditAsync(EditUserDto editUserDto)
        {
            List<ValidationError?>? validationErrors = new();
            List<IdentityError?>? errors = new List<IdentityError?>();
            if (editUserDto == null)
            {
                validationErrors.Add(new ValidationError() { Code = "NullExeptionEditUserDTO", Description = "Edit user shudnt be null" });
            }
            if (editUserDto.Id == null)
            {
                validationErrors.Add(new ValidationError() { Code = "NullExeptionUserDtoId", Description = "Edit User Id shudnt null" });
            }
            else
            {
                ApplicationUser? user = await _userManager.FindByIdAsync(editUserDto.Id);
                if (user != null)
                {
                    user.FirstName = editUserDto.FirstName;
                    user.LastName = editUserDto.FirstName;
                    user.Email = editUserDto.Email;
                    user.PhoneNumber = editUserDto.PhoneNumber;
                    user.UserName = editUserDto.UserName;
                    user.StreetAddress = editUserDto.StreetAddress;
                    user.City = editUserDto.City;
                    user.NationalCode = editUserDto.NationalId;
                    var reault = await _userManager.UpdateAsync(user);
                    if (!reault.Succeeded)
                    {
                        errors.AddRange(reault.Errors.ToList());
                    }
                }
            }
            foreach (var error in errors)
            {
                validationErrors.Add(new ValidationError { Code = error.Code, Description = error.Description });
            }

            return validationErrors;

        }
    }

}