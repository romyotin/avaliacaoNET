using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(Guid uid);
        IEnumerable<T> GetAll();
        void Save(T entity);
        void Delete(T entity);
    }
}
