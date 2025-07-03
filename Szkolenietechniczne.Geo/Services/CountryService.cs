using Microsoft.EntityFrameworkCore;
using Szkolenietechniczne.Geo.Extensions;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage;
using SzkolenieTechniczne.Geo.Storage.Entities;

namespace Szkolenietechniczne.Geo.Services
{
    public class CountryService
    {
        private GeoDbContext _geoDbContext;

        public CountryService(GeoDbContext geoDbContext) 
        { 
            _geoDbContext = geoDbContext;
        }

        public async Task<CountryDto> GetById(Guid id)
        {
            var country = await _geoDbContext
                .Set<Country>()
                .Include(x=>x.Translations)
                .AsNoTracking()
                .Where(e=> e.Id!.Equals(id))
                .SingleOrDefaultAsync();

            return country.ToDto();
        }

        public async Task<IEnumerable<CountryDto>> Get()
        {
            var cities = await _geoDbContext
                .Set<Country>()
                .Include(x => x.Translations)
                .AsNoTracking()
                .Select(e=> e.ToDto())
                .ToListAsync();
            return cities;
        }

        public async Task<CrudOperationResult<CountryDto>> Create(CountryDto dto)
        {
            var entity = dto.ToEntity();

            _geoDbContext
                .Set<Country>()
                .Add(entity);

            await _geoDbContext .SaveChangesAsync();

            var newDto = await GetById(entity.Id);

            return new CrudOperationResult<CountryDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }
    }
}
