using System;
using System.ComponentModel.DataAnnotations;

namespace NewYearMusic.Web.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email{get;set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password{get;set;}

        [Display(Name = "Запомнить?")]
        public bool RememberMe{get;set;}
    }
}