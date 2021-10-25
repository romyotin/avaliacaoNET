using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using Livraria.Domain.Services;
using Livraria.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Web.Controllers
{
    public class LivroController : BaseController
    {
        private readonly LivroService _livroService;
        private readonly IRepository<Livro> _livroRepository;

        public LivroController(LivroService LivroService,
            IRepository<Livro> LivroRepository)
        {
            _livroService = LivroService;
            _livroRepository = LivroRepository;
        }

        [HttpGet]
        [Route("Get")]
        public ActionResult GetLivros()
        {
            var livros = _livroRepository.GetAll();
            RegistrarLog("Livros/GetLivros", "HttpGet", "Recuperar Lista completa de livros", livros );
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public ActionResult<Livro> GetLivro(Guid Uid)
        {
            RegistrarLog("Livros/{id}", "HttpGet", "Recuperar livro por uid", Uid);
            var Livro = _livroRepository.GetById(Uid);
            if (Livro == null)
            {
                return NotFound(new { message = $"Livro de id={Uid} não encontrado" });
            }
            return Livro;
        }

        [HttpGet]
        [Route("GetLivrosOrdenados")]
        public ActionResult GetLivrosOrdenados(bool ordenarPorNome, bool ordenarPorCodigo)
        {
            var livros = _livroService.RecuperarListaOrdenada(ordenarPorNome, ordenarPorCodigo);
            RegistrarLog("Livros/GetLivrosOrdenados", "HttpGet", "Recuperar lista de livros ordenada", livros);
            return Ok(livros);
        }

        [HttpPost]
        [Route("Post")]
        public ActionResult Post([FromBody]LivroDTO livro)
        {
            RegistrarLog("Livros/Post", "HttpPost", "Salvar o livro ", livro);
            try
            {
                _livroService.Save(livro.UID, livro.Nome, livro.Codigo);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }



        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(Guid uid)
        {
            try
            {
                RegistrarLog("Livros/Delete", "HttpDelete", "Excluir o livro por uid ", uid);
                var livro = _livroRepository.GetById(uid);
                if (livro == null)
                {
                    return NotFound(new { message = $"Livro de id={uid} não encontrado" });
                }

                _livroRepository.Delete(livro);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }
    }
}
