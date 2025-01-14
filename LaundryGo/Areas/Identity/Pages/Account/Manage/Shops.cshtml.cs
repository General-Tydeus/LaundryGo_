using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Linq;
using System.Threading.Tasks;
using LaundryGo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using LaundryGo.Data;
using Microsoft.EntityFrameworkCore;

namespace LaundryGo.Areas.Identity.Pages.Account.Manage
{
    public partial class ShopsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ShopsModel(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public List<Shop> Shops { get; set; }

        //public class Shop
        //{
        //    public int Id { get; set; }

        //    //[Required(ErrorMessage = "The field is required.")]
        //    [Display(Name = "Name")]
        //    public string Title { get; set; }

        //    //[Required(ErrorMessage = "The field is required.")]
        //    public string Address { get; set; }

        //    //[Required(ErrorMessage = "The field is required.")]
        //    [Display(Name = "Latitude")]
        //    public string Coord_lat { get; set; }

        //    //[Required(ErrorMessage = "The field is required.")]
        //    [Display(Name = "Longitude")]
        //    public string Coord_long { get; set; }

        //    [Display(Name = "User Id")]
        //    public string UserId { get; set; }

        //    [Display(Name = "Status")]
        //    public int Approve { get; set; }
        //}
        //[TempData]
        //public string StatusMessage { get; set; }

        //[BindProperty]
        //public InputModel Input { get; set; }

        //public class InputModel
        //{
        //    [Required]
        //    [EmailAddress]
        //    [Display(Name = "New email")]
        //    public string NewEmail { get; set; }
        //}

        //private async Task LoadAsync(IdentityUser user)
        //{
        //    var email = await _userManager.GetEmailAsync(user);
        //    Email = email;

        //    Input = new InputModel
        //    {
        //        NewEmail = email,
        //    };

        //    IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);


        //}

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // Retrieve all shops associated with the current user
            Shops = await _context.Shop
                    .Where(r => r.UserId == user.Id) // Use user.Id for filtering
                    .ToListAsync();


            return Page();
        }

        //public async Task<IActionResult> OnPostChangeEmailAsync()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        await LoadAsync(user);
        //        return Page();
        //    }

        //    var email = await _userManager.GetEmailAsync(user);
        //    if (Input.NewEmail != email)
        //    {
        //        var userId = await _userManager.GetUserIdAsync(user);
        //        var code = await _userManager.GenerateChangeEmailTokenAsync(user, Input.NewEmail);
        //        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        //        var callbackUrl = Url.Page(
        //            "/Account/ConfirmEmailChange",
        //            pageHandler: null,
        //            values: new { userId = userId, email = Input.NewEmail, code = code },
        //            protocol: Request.Scheme);
        //        await _emailSender.SendEmailAsync(
        //            Input.NewEmail,
        //            "Confirm your email",
        //            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        //        StatusMessage = "Confirmation link to change email sent. Please check your email.";
        //        return RedirectToPage();
        //    }

        //    StatusMessage = "Your email is unchanged.";
        //    return RedirectToPage();
        //}

        //public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        await LoadAsync(user);
        //        return Page();
        //    }

        //    var userId = await _userManager.GetUserIdAsync(user);
        //    var email = await _userManager.GetEmailAsync(user);
        //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        //    var callbackUrl = Url.Page(
        //        "/Account/ConfirmEmail",
        //        pageHandler: null,
        //        values: new { area = "Identity", userId = userId, code = code },
        //        protocol: Request.Scheme);
        //    await _emailSender.SendEmailAsync(
        //        email,
        //        "Confirm your email",
        //        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        //    StatusMessage = "Verification email sent. Please check your email.";
        //    return RedirectToPage();
        //}
    }
}
