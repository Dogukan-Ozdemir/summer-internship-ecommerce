using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDal;

        public CargoDetailManager(ICargoDetailDal cargoDal)
        {
            _cargoDal = cargoDal;
        }

        public List<CargoDetail> TGetAll()
        {
           return _cargoDal.GetAll();
           
        }

        public void Tdelete(int id)
        {
            _cargoDal.delete(id);
        }

        public CargoDetail TGetById(int id)
        {
          return  _cargoDal.GetById(id);
        }

        public void Tinsert(CargoDetail entity)
        {
            _cargoDal.insert(entity);
        }

        public void Tupdate(CargoDetail entity)
        {
            _cargoDal.update(entity);
        }
    }
}
