using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositeries;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargpCustomerDal : GenericRepositoriy<CargoCustomer>, ICargoCustomerDal
    {
        public EfCargpCustomerDal(CargoCotext context) : base(context)
        {

        }
    }
}
