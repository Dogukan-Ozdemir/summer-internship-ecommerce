using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void insert(T entity);
        void update(T entity);
        void delete(int id);
        List<T> GetAll();
        T GetById(int id);
    }
}
