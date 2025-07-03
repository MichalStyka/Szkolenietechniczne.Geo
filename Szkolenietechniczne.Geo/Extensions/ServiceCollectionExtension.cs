using Szkolenietechniczne.Geo.Services;
using SzkolenieTechniczne.Geo.Storage;

namespace Szkolenietechniczne.Geo.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddGeoServices(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddTransient<CountryService>();
            serviceCollection.AddTransient<CityService>();
            serviceCollection.AddDbContext<GeoDbContext, GeoDbContext>();
            return serviceCollection;
        }
    }
}
