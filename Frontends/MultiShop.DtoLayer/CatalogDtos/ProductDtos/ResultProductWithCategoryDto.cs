using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public String ProductId { get; set; }
        public String ProductName { get; set; }
        public decimal ProductPrize { get; set; }
        public String ProductImageUrl { get; set; }
        public String ProductDescription { get; set; }
        public String CategoryId { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
