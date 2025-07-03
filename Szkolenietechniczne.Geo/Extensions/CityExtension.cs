using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage.Entities;

namespace Szkolenietechniczne.Geo.Extensions
{
    public static class CityExtension
    {
        public static CityDto ToDto(this City entity)
        {
            //if (entity == null)
            //    return null;

            var result = new CityDto
            {
                Id = entity.Id,
                
                Name = new LocalizedString(entity.Translations?.Select(t =>
                    new KeyValuePair<string, string>(t.LanguageCode, t.Name)) ??
                    Enumerable.Empty<KeyValuePair<string, string>>()),
                CountryId = entity.CountryId,
              
                CountryName = entity.Country?.Translations?.FirstOrDefault()?.Name
            };

            return result;
        }

        //public static IEnumerable<CityDto> ToDtos(this IEnumerable<City> entities)
        //{
        //    if (entities == null)
        //        return Enumerable.Empty<CityDto>();

        //    return entities.Select(e => e.ToDto());
        //}
    }
}
