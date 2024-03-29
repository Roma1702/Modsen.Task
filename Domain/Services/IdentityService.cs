﻿using Domain.Abstractions.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Domain.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public IdentityService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public string GetUserIdentity()
        {
            var userIdentity = _contextAccessor.HttpContext?.User.FindFirst("sub")?.Value;

            return userIdentity ?? string.Empty;
        }
    }
}
