using Common.Core.Models;
using System;
using IdentityProvider.Dtos;
using IdentityProvider.Models;
using Microsoft.AspNetCore.Identity;
using Common.Core.Logger;
using System.Threading.Tasks;
using IdentityServerHost.Quickstart.UI;
using IdentityServer4.Events;
using System.Security.Policy;

namespace IdentityProvider.Services;

public class AccountService : IAccountService
{

    #region Fields

    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly ILogger logger;


    #endregion


    #region Ctor

    public AccountService(UserManager<ApplicationUser> userManager,
                          SignInManager<ApplicationUser> signInManager,
                          ILogger logger)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.logger = logger;
    }

    #endregion


    #region Implemented Methods

    public async Task<UserCreatedResult> CreateUserAsync(UserRegistrationRequest user)
    {
        var appUser = CreateApplicationUser(user);
        var userCreatedResult = new UserCreatedResult();

        var currentUser = await userManager.FindByEmailAsync(appUser.Email);

        if (currentUser is not null && currentUser.EmailConfirmed)
        {
            userCreatedResult.Succeeded = false;
            userCreatedResult.Message = "An user already exist with this email.";
            return userCreatedResult;
        }
        else if (currentUser is not null && !currentUser.EmailConfirmed)
        {
            logger.Warn(GetType(), "An Account exist with this email but the user is not confirm email yet.So Now, process the user with his/her new information");
        }

        var identityResult = await userManager.CreateAsync(appUser, user.Password);

        if (identityResult.Succeeded)
        {
            logger.Info(GetType(), "User Created Successfully");
        }
        else
        {
            userCreatedResult.Succeeded = false;
            userCreatedResult.Message = "Failed to Create User";
            return userCreatedResult;
        }

        var confirmationEmailSendResult = await SendConfirmationEmailAsync(appUser);

        if (confirmationEmailSendResult.Succeeded)
        {
            logger.Info(GetType(), "Account Confirmation Email sent successfully");
        }
        else
        {
            logger.Error(GetType(), "Failed to sent confirmation email.");
        }

        userCreatedResult.Succeeded = true;
        userCreatedResult.Message = "User Create Successfully. Please check you email for confirm your account.";

        return userCreatedResult;
    }

    public async Task<UserLoginResult> UserLoginAsync(LoginInputModel loginCred)
    {
        var loginResult = new UserLoginResult() { Succeeded = false };

        var appUser = await userManager.FindByEmailAsync(loginCred.Email);
        var result = await signInManager.PasswordSignInAsync(appUser, loginCred.Password, loginCred.RememberLogin, lockoutOnFailure: true);

        if (result.Succeeded)
        {
            logger.Info(GetType(), "User Successfully Logged In");
            loginResult.Succeeded = true;
            loginResult.Message = "Successfully loged in";
            return loginResult;
        }

        return loginResult;
    }


    #endregion


    #region Private Methods

    private async Task<EmailSendingResult> SendConfirmationEmailAsync(ApplicationUser appUser)
    {
        var confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(appUser);

        return new EmailSendingResult
        {
            Succeeded = true
        };
    }

    private static ApplicationUser CreateApplicationUser(UserRegistrationRequest user)
    {
        return new ApplicationUser
        {
            UserName = user.UserName,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }

    #endregion 
}
