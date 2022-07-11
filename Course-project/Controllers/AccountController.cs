﻿using System.Security.Claims;
using System.Text;
using Course_project.Data;
using Course_project.Helpers;
using Course_project.Models;
using Course_project.Models.Enums;
using Course_project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace Course_project.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;


        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }



        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError(string.Empty, "Account is locked");
                        return View(loginViewModel);
                    }
                }

                ModelState.AddModelError(string.Empty, "Wrong credentials. Please try again");
                return View(loginViewModel);
            }
            //User not found
            ModelState.AddModelError(string.Empty, "Wrong credentials. Please try again");
            return View(loginViewModel);
        }


        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var user = await _userManager.FindByEmailAsync(registerViewModel.Email);
            if (user != null)
            {
                ModelState.AddModelError(string.Empty, "This email address is already in use");
                return View(registerViewModel);
            }

            var newUser = new IdentityUser()
            {
                LockoutEnabled = false,
                Email = registerViewModel.Email,
                UserName = registerViewModel.UserName
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                await _signInManager.SignInAsync(newUser, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in newUserResponse.Errors)
            {
                ModelState.AddModelError(string.Empty,error.Description);
            }
            return View(registerViewModel);
        }



        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



        public async Task<IActionResult> UserPage(CollectionType? type, string id, string name = "defaulf", int page = 1,
                    SortState sortOrder = SortState.NameAsc)
        {
            string userId;
            if (string.IsNullOrEmpty(id))
            {
                userId = GetUserId();
            }
            else { userId = id; }
            name = _context.Users.Find(userId).UserName;
            IQueryable<Collection> collections = _context.Collections.Where(m => m.AuthorId == userId);

            var viewModelOptions = new ViewModelOptions()
            {
                Collections = collections
            }.GetSortedAndFilteredCollection(type, page, sortOrder);
            UserPageViewModel viewModel = new UserPageViewModel
            {
                UserName = name,
                PageViewModel = new PageViewModel(viewModelOptions.Result.Count, page, viewModelOptions.Result.PageSizeCollection),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(viewModelOptions.Result.Items, type, nameof(type)),
                Collections = viewModelOptions.Result.Items
            };
            return View(viewModel);
        }


        public string GetUserId()
        {
            if (User.Identity.IsAuthenticated)
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                var userId = claim.Value;
                return userId;
            }
            return null;
        }
    }
}
