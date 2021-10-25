using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Domain.Models;
using Livraria.Infra.Context;

namespace Livraria.Infra.Repositories
{
    public class LivroRepository : Repository<Livro>
    {

        public LivroRepository(AppDbContext context) : base(context)
        { }

        public override Livro GetById(Guid uid)
        {
            var query = _context.Set<Livro>().Where(e => e.UID == uid);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Livro> GetAll()
        {
            var query = _context.Set<Livro>();

            return query.Any() ? query.ToList() : new List<Livro>();
        }

        public override void  Delete(Livro livro)
        {
            _context.Set<Livro>().Remove(livro);
        }
    }
}
