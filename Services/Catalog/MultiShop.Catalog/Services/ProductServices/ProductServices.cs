using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductServices : IProductService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        public ProductServices(IMapper mapper , DatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.dataBaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var result = _mapper.Map <Product>(createProductDto);
            await _productCollection.InsertOneAsync(result);
        }

        public async Task DeleteProductAsync(String id)
        {
            await _productCollection.FindOneAndDeleteAsync(x => x.ProductId.Equals(id));
        }

        public async Task<List<ResultProductDto>> GetAllProductsDtosAsync()
        {
            var result = await _productCollection.Find(x=>true).ToListAsync();
            return _mapper.Map <List<ResultProductDto>>(result);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(String id)
        {
           var result = await _productCollection.Find(x => x.ProductId.Equals(id)).FirstOrDefaultAsync();
            return _mapper.Map <GetByIdProductDto>(result);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var result = _mapper.Map <Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId.Equals(updateProductDto.ProductId), result);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();

            foreach (var item in values)
            {
                var category = await _categoryCollection
                    .Find(x => x.CategoryId == item.CategoryId)
                    .FirstOrDefaultAsync();

                item.Category = category;
            }

            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryByCatetegoryIdAsync(string CategoryId)
        {

            var values = await _productCollection
                .Find(x => x.CategoryId == CategoryId)
                .ToListAsync();

            foreach (var item in values)
            {
                var category = await _categoryCollection
                    .Find(x => x.CategoryId == item.CategoryId)
                    .FirstOrDefaultAsync();

                item.Category = category;
            }

            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values); ;
        }

    }
}


