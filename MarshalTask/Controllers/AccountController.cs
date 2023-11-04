using MarshalTask.Models;
using MarshalTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarshalTask.Controllers
{
    public class AccountController : Controller
    {
        IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        public IActionResult Login()
        {
            return View();
        }


        public async Task<IActionResult> SignUP(SignUp signUp)
        {
            var result = await accountService.CreateAccount(signUp);

            return View("Login");

        }


        public IActionResult SignUpPage()
        {
            return View("SignUp");
        }


        public async Task<IActionResult> CheckPassword(LogIn signIn)
        {
            var result = await accountService.SignIn(signIn);
            if (result.Succeeded)
            {
                return RedirectToAction("ToDoList", "Task");  
                //string userId = signIn.Id;
                //return RedirectToAction("ToDoList", "Task", new { id = userId });
            }

            else
            {
                ViewData["result"] = "Invalid Username or Password";
                return View("Login");
            }
        }




    }
}
