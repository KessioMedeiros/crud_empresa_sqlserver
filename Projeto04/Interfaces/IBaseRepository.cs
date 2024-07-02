using Projeto04.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        List<T> GetAll();
        T? GetById(Guid id);
    }
}
