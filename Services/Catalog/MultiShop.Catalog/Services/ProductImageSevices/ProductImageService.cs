using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageSevices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper ;
        private readonly IMongoCollection<ProductImage> _productImageCollection ;
        public ProductImageService(IMapper mapper , DatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.dataBaseName);
            _productImageCollection=database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName); 
            _mapper= mapper;
        }

        public async Task CreateProductImage(CreateProductImageDto CreateproductImageDtoAync)
        {
            var result = _mapper.Map < ProductImage>(CreateproductImageDtoAync);
            await _productImageCollection.InsertOneAsync(result);
        }

        public async Task DeleteProductImage(String id)
        {
            await _productImageCollection.FindOneAndDeleteAsync(x => x.ProductImageId.Equals(id));
        }

        public async Task<List<ResultProductImageDto>> GetAllProductsImageAsync()
        {
            var result = await _productImageCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(result);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductAsync(string id)
        {
            var result = await _productImageCollection
                .Find(x => x.ProductId.Equals(id))
                .FirstOrDefaultAsync();

            return _mapper.Map<GetByIdProductImageDto>(result);
        }

        public async Task UpdateProductImage(UpdateProductImageDto UpdateproductImagetoAsync)
        {
            var result = _mapper.Map< ProductImage>(UpdateproductImagetoAsync);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId.Equals(UpdateproductImagetoAsync.ProductImageId), result);
        }
    }
}
