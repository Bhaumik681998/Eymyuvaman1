using Eymyuvaman.Repository;
using Eymyuvaman.Service;

namespace Eymyuvaman.Extensions
{
    public static class AddService
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RouteOptions>(option =>
            {
                option.LowercaseQueryStrings = true;
                option.LowercaseUrls = true;
            });

            services.AddHttpClient();

            services.AddScoped<IAuthRepository, AuthService>();
            services.AddScoped<IUserMasterRepository, UsermasterService>();
            services.AddScoped<IYuvakRepository, YuvakService>();
            services.AddScoped<ISabhaSessionRepository, SabhaSessionService>();
            services.AddScoped<INewYuvakSabhaAttendRepository, NewYuvakSabhaAttendService>();
            services.AddScoped<IEvantRepository, EvantService>();
        }
    }
}
