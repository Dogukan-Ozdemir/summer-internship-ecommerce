using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationManager : IcargoOperationService
    {
        private readonly ICargoOperationDal _cargoDal;

        public CargoOperationManager(ICargoOperationDal cargoDal)
        {
            _cargoDal = cargoDal;
        }

        public List<CargoOperation> TGetAll()
        {
            return _cargoDal.GetAll();

        }

        public void Tdelete(int id)
        {
            _cargoDal.delete(id);
        }

        public CargoOperation TGetById(int id)
        {
            return _cargoDal.GetById(id);
        }

        public void Tinsert(CargoOperation entity)
        {
            _cargoDal.insert(entity);
        }

        public void Tupdate(CargoOperation entity)
        {
            _cargoDal.update(entity);
        }
    }
}
