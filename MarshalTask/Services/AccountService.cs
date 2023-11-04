using MarshalTask.data;
using MarshalTask.Models;
using Microsoft.AspNetCore.Identity;

namespace MarshalTask.Services
{
    public class AccountService : IAccountService
    {
        MarshalContext context;
        UserManager<IdentityUser> usermanager;
        SignInManager<IdentityUser> signInManager;

        public AccountService(MarshalContext _context, UserManager<IdentityUser> _usermanager, SignInManager<IdentityUser> _signInManager)
        {
            usermanager = _usermanager;
            signInManager = _signInManager;
            context = _context;

        }



        public async Task<IdentityResult> CreateAccount(SignUp signUp)
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = signUp.UserName,
                Email = signUp.UserName,
                //PasswordHash=signUp.Password,
            };

            var result = await usermanager.CreateAsync(user, signUp.Password);
            return result;
        }

        public async Task<SignInResult> SignIn(LogIn signIn)
        {
            var result = await signInManager.PasswordSignInAsync(signIn.Username, signIn.Password, signIn.rememberMe, false);
            return result;

        }





    }


}
