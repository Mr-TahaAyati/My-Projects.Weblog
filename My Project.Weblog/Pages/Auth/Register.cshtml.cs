﻿using CoreLayer.DTOs.Users;
using CoreLayer.Services.Users;
using CoreLayer.Utities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace My_Project.Weblog.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class RegisterModel : PageModel
    {
       private  readonly IUserService _userService;

        #region Properties
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(6, ErrorMessage = "{0} باید بیشتر از 5 کاراکتر باشد")]
        public string Password { get; set; }
        #endregion




        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var result = _userService.RegisterUser(new UserRgesterDto()
            {
                UserName = UserName,
                Password = Password,
                Fullname = FullName
            });
            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("UserName", result.Message);
                return Page();
            }
            return RedirectToPage("Login");
        }
    }
}
