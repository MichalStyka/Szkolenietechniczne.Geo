using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage.Entities;

namespace Szkolenietechniczne.Geo.Extensions
{
    public static class CityDtoExtension
    {
        public static City ToEntity(this CityDto dto)
        {
            return new City
            {
                Id = dto.Id,
                CountryId = dto.CountryId,

            };
        }
    }
}
