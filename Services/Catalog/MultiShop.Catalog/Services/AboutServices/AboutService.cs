using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<About> _categoriyCollection;

        public AboutService(IMapper mapper , IdataBaseSettings dataBaseSettings )
        {
            var client = new MongoClient(dataBaseSettings.connectionString);
            var database = client.GetDatabase(dataBaseSettings.dataBaseName);
            _categoriyCollection = database.GetCollection<About>(dataBaseSettings.AboutCollectionName);
            _mapper= mapper;

        }

        public async Task CreateAboutAsyn(CreateAboutDto CreateAboutDto)
        {
           var About = _mapper.Map<About>(CreateAboutDto);
            await _categoriyCollection.InsertOneAsync(About);

        }

        public async Task DeleteAboutAsyn(string id)
        {
            await _categoriyCollection.FindOneAndDeleteAsync(x=>x.AboutId.Equals(id));
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var values = await _categoriyCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<ResultAboutDto>>(values);
        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            var result = await _categoriyCollection.Find(x=>x.AboutId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdAboutDto>(result);

        }

        public async Task UpdateAboutAsyn(UpdateAboutDto UpdateAboutDto)
        {
            var result = _mapper.Map<About>(UpdateAboutDto);
            await _categoriyCollection.FindOneAndReplaceAsync(x => x.AboutId.Equals(UpdateAboutDto.AboutId), result);
        }
    }
}
