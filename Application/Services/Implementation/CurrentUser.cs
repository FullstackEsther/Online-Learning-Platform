using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.DomainServices.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Domain.DomainServices.Implementation
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetLoggedInUserEmail()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var loggedInUserEmail =  user?.FindFirst(ClaimTypes.Email)?.Value;
            return loggedInUserEmail;
        }

        public List<string> LoggedInUserRoles()
        {
            throw new NotImplementedException();
        }

        // public List<string> LoggedInUserRoles()
        // {
        //     var roles = _httpContextAccessor.HttpContext.User.Claims.Where().ToList();

        // }
    }
}