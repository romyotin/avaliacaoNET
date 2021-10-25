using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using Livraria.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public virtual T GetById(Guid uid)
        {
            var query = _context.Set<T>().Where(e => e.UID == uid);

            if (query.Any())
                return query.FirstOrDefault();

            return null;
        }

        public virtual IEnumerable<T> GetAll()
        {
            var query = _context.Set<T>();

            if (query.Any())
                return query.ToList();

            return new List<T>();
        }

        public virtual void Save(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
