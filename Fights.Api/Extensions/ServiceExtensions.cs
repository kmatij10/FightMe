using Microsoft.Extensions.DependencyInjection;
using Fights.Core.Repositories.Cities;
using Fights.Core.Repositories.Fights;
using Fights.Core.Repositories.Donations;
using Fights.Core.Repositories.Swipes;

namespace Fights.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterScopedServices(this IServiceCollection services)
        {
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IFightRepository, FightRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();
            services.AddScoped<ISwipeRepository, SwipeRepository>();
        }
    }
}