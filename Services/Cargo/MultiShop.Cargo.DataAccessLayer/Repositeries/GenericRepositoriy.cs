using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Cargo.DataAccessLayer.Repositeries
{
    public class GenericRepositoriy<T> : IGenericDal<T> where T : class
    {
        private readonly CargoCotext _context;

        public GenericRepositoriy(CargoCotext context)
        {
            _context = context;
        }

        public void delete(int id)
        {
            var values = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(values);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            var values = _context.Set<T>().ToList();
            return values;
        }

        public T GetById(int id)
        {
            var value = _context.Set<T>().Find(id);
            return value;
        }

        public void insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges() ;
        }
    }
}
