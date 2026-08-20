using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;

namespace MultiShop.Discount.Context
{
    public class DapperContext :DbContext
    {
        private readonly IConfiguration _configuration;
        String _ConnecctinString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _ConnecctinString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;initial Catalog=MultiShopDiscountDB;User=sa;Password=123456aA*");
        }

        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_ConnecctinString);
    }
}
