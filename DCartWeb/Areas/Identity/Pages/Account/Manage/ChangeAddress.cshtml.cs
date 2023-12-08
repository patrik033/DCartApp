// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using DCartWeb.Data;
using DCartWeb.Email;
using DCartWeb.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace DCartWeb.Areas.Identity.Pages.Account.Manage
{
    public class ChangeAddressModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly DCartWebContext _context;

        public ChangeAddressModel(
            UserManager<User> userManager, DCartWebContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        [BindProperty]
        public Address? Address { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }






        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }







        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>


            [Required]
            [Display(Name = "Street Address")]
            public string StreetAddress { get; set; }
            [Required]
            public string City { get; set; }
            [Required]
            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }
            public string UserId { get; set; }
        }




        private async Task LoadAsync(User user)
        {



            var userId = user.Id;
            var contextUser = _context.Users.Include(x => x.Address).FirstOrDefault(x => x.Id == userId);
            Address = contextUser.Address;
            if (contextUser.Address != null)
            {
                var city = user.Address.City;
                var address = user.Address.StreetAddress;
                var zipCode = user.Address.ZipCode;
                Input = new InputModel
                {
                    ZipCode = zipCode,
                    StreetAddress = address,
                    City = city,
                };
            }


            await Task.CompletedTask;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            await LoadAsync(user);
            return Page();
        }





        public async Task<IActionResult> OnPostChangeAddressAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            if (Input.City != null && Input.StreetAddress != null && Input.ZipCode != null)
            {
                var users = _context.Users.Include(x => x.Address).FirstOrDefault(x => x.Id == userId);
                var contextUser = _context.Users.FirstOrDefault(x => x.Id == user.Id);


                users.Address.StreetAddress = Input.StreetAddress;
                users.Address.ZipCode = Input.ZipCode;
                users.Address.City = Input.City;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }


            return Page();
        }

        public async Task<IActionResult> OnPostAddAddressAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;



            var users = _context.Users.Include(x => x.Address).FirstOrDefault(x => x.Id == userId);
            var contextUser = _context.Users.FirstOrDefault(x => x.Id == user.Id);

            var address = new Address
            {
                StreetAddress = Input.StreetAddress,
                ZipCode = Input.ZipCode,
                City = Input.City,
                UserId = userId,
            };

            contextUser.Address = address;
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
            return Page();
        }
    }
}
