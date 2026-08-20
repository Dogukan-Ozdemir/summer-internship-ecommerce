using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface IgenericService<T> where T : class
    {
        
        
            void Tinsert(T entity);
            void Tupdate(T entity);
            void Tdelete(int id);
            List<T> TGetAll();
             T TGetById(int id);
        }
    }

