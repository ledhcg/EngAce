﻿using Microsoft.AspNetCore.Http;

namespace Helper
{
    public static class HttpContextHelper
    {
        private static IHttpContextAccessor _accessor;

        public static void Configure(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public static string? GetAccessKey()
        {
            if (!_accessor.HttpContext.Request.Headers.TryGetValue("Authentication", out var apiKey))
            {
                throw new NullReferenceException("Cannot find the access key");
            }
            return apiKey;
        }
    }
}
