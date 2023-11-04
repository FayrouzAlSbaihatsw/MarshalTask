using MarshalTask.Models;
using Microsoft.AspNetCore.Identity;

namespace MarshalTask.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateAccount(SignUp signUp);

        Task<SignInResult> SignIn(LogIn signIn);


    }
}
