﻿using IdentityModel;
using IdentityServer4.Validation;
using MicroserviceProject.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroserviceProject.IdentityServer.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existUser = await _userManager.FindByEmailAsync(context.UserName);
            if (existUser == null)
            {
                var errors =  new Dictionary<string, object>();
                errors.Add("error",new List<string>() {"Email ya da Şifreniz Yanlış!"});
                return;
            }
            var passwordCheck = await _userManager.CheckPasswordAsync(existUser, context.Password);
            if (passwordCheck==false)
            {
                var errors = new Dictionary<string, object>();
                errors.Add("error", new List<string>() { "Email ya da Şifreniz Yanlış!" });
                return;
            }
            context.Result = new GrantValidationResult(existUser.Id.ToString(),OidcConstants.AuthenticationMethods.Password);
        }
    }
}
