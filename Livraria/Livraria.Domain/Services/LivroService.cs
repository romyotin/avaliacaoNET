using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Services
{
    public class LivroService
    {
        private readonly IRepository<Livro> _livroRepository;

        public LivroService(IRepository<Livro> livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public void Save(Guid uid, string nome, string codigo)
        {
            Livro livro = _livroRepository.GetById(uid);

            if (livro == null)
            {
                livro = new Livro(Guid.NewGuid(), nome, codigo);
                _livroRepository.Save(livro);
            }
            else
                livro.Update(nome, codigo);
        }

        public List<Livro> RecuperarListaOrdenada(bool ordNome, bool ordCod)
        {
            if(ordNome == true)
            {
                return _livroRepository.GetAll().OrderBy(x => x.Nome).ToList();
            }

            if (ordCod == true)
            {
                return _livroRepository.GetAll().OrderBy(x => x.Codigo).ToList();
            }

            return _livroRepository.GetAll().ToList();
        }

    }
}
