using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCustomerManager : ICargoCustomerService
    {
         
            private readonly ICargoCustomerDal _cargoDal;

            public CargoCustomerManager(ICargoCustomerDal cargoDal)
            {
                _cargoDal = cargoDal;
            }

            public List<CargoCustomer> TGetAll()
            {
                return _cargoDal.GetAll();

            }

            public void Tdelete(int id)
            {
                _cargoDal.delete(id);
            }

            public CargoCustomer TGetById(int id)
            {
                return _cargoDal.GetById(id);
            }

            public void Tinsert(CargoCustomer entity)
            {
                _cargoDal.insert(entity);
            }

            public void Tupdate(CargoCustomer entity)
            {
                _cargoDal.update(entity);
            }
        }
}
