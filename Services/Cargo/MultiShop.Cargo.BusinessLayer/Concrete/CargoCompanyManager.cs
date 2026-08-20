using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoDal;

        public CargoCompanyManager(ICargoCompanyDal cargoDal)
        {
            _cargoDal = cargoDal;
        }

        public List<CargoCompany> TGetAll()
        {
            return _cargoDal.GetAll();

        }

        public void Tdelete(int id)
        {
            _cargoDal.delete(id);
        }

        public CargoCompany TGetById(int id)
        {
            return _cargoDal.GetById(id);
        }

        public void Tinsert(CargoCompany entity)
        {
            _cargoDal.insert(entity);
        }

        public void Tupdate(CargoCompany entity)
        {
            _cargoDal.update(entity);
        }
    }
}
