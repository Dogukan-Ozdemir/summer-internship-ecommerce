using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoriyCollection;

        public CategoryService(IMapper mapper , IdataBaseSettings dataBaseSettings )
        {
            var client = new MongoClient(dataBaseSettings.connectionString);
            var database = client.GetDatabase(dataBaseSettings.dataBaseName);
            _categoriyCollection = database.GetCollection<Category>(dataBaseSettings.CategoryCollectionName);
            _mapper= mapper;

        }

        public async Task CreateCategoryAsyn(CreateCategoryDto CreateCategoryDto)
        {
           var category = _mapper.Map<Category>(CreateCategoryDto);
            await _categoriyCollection.InsertOneAsync(category);

        }

        public async Task DeleteCategoryAsyn(string id)
        {
            await _categoriyCollection.FindOneAndDeleteAsync(x=>x.CategoryId.Equals(id));
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            var values = await _categoriyCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByCategoryIDto> GetByIdCategoryAsync(string id)
        {
            var result = await _categoriyCollection.Find(x=>x.CategoryId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByCategoryIDto>(result);

        }

        public async Task UpdateCategoryAsyn(UpdateCategoryDto UpdateCategoryDto)
        {
            var result = _mapper.Map<Category>(UpdateCategoryDto);
            await _categoriyCollection.FindOneAndReplaceAsync(x => x.CategoryId.Equals(UpdateCategoryDto.CategoryId), result);
        }
    }
}
