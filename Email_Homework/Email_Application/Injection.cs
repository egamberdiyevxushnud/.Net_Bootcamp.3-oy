﻿using Email_Application.AuthServices;
using Email_Application.Serveces;
using Microsoft.Extensions.DependencyInjection;

namespace Email_Application
{
    public static class Injection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ILoginServece, LoginServece>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
