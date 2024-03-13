using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Auth
{
    internal static class AuthenticationConfiguration
    {
        internal static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<IdentityDbContext>(options => options.UseInMemoryDatabase("sagar"));

            services.AddAuthentication()
                .AddBearerToken(IdentityConstants.BearerScheme);

            services
                .AddIdentityCore<IdentityUser>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddApiEndpoints();

            return services;
        }
    }
}
