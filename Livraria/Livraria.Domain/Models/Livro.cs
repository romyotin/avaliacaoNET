using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Models
{
    public class Livro : BaseEntity
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public Livro(Guid uid, string nome, string codigo)
        {
            ValidaLivro(nome, codigo);
            UID = uid;
            Nome = nome;
            Codigo = codigo;
        }

        public Livro()
        {

        }
        public void Update(string nome, string codigo)
        {
            ValidaLivro(nome, codigo);
        }

        private void ValidaLivro(string nome, string codigo)
        {
            if (string.IsNullOrEmpty(nome))
                throw new InvalidOperationException("O nome é inválido");

            if (string.IsNullOrEmpty(codigo))
                throw new InvalidOperationException("O código é inválido");
        }

    }
}
