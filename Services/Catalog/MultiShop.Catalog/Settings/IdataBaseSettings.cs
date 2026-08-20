namespace MultiShop.Catalog.Settings
{
    public interface IdataBaseSettings
    {
        public String CategoryCollectionName { get; set; }
        public String ProductCollectionName { get; set; }
        public String ProductDetailCollectionName { get; set; }
        public String ProductImageCollectionName { get; set; }
        public String AboutCollectionName { get; set; }
        public String OfferDiscountCollectionName { get; set; }
        public String connectionString { get; set; }
        public String dataBaseName { get; set; }
    }
}
