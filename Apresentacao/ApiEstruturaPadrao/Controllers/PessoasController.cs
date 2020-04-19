using System.Collections.Generic;
using Aplicacao.Dominio.Entidades;
using Aplicacao.Interfaces.Pessoa;
using Microsoft.AspNetCore.Mvc;

namespace ApiEstruturaPadrao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        //Injeta PessoaService para diminuir aclopamento
        //Todas dependencias devem ser cadastradas no Startup.cs
        private readonly IPessoaService _pessoaService;

        public PessoasController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public IEnumerable<PessoaEntidade> Get()
        {
            var pessoas = _pessoaService.ListarTodos();
            return pessoas;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public Dictionary<string,string> Cadastrar(PessoaEntidade pessoa)
        {
            var retorno = _pessoaService.Cadastrar(pessoa);
            return new Dictionary<string, string>
            {
                { "Mensagem", retorno }
            };
        }

        [HttpPut]
        [Route("Atualizar")]
        public Dictionary<string, string> Atualizar(PessoaEntidade pessoa)
        {
            var retorno = _pessoaService.Atualizar(pessoa);
            return new Dictionary<string, string>
            {
                { "Mensagem", retorno }
            };
        }

        [HttpDelete]
        [Route("Deletar")]
        public Dictionary<string, string> Deletar(PessoaEntidade pessoa)
        {
            var retorno = _pessoaService.Deletar(pessoa.Id);
            return new Dictionary<string, string>
            {
                { "Mensagem", retorno }
            };
        }

        [HttpGet]
        [Route("ConsultarPorNome")]
        public IEnumerable<PessoaEntidade> ConsultarPorNome(string nome)
        {
            var retorno = _pessoaService.ConsultarPorNome(nome);
            return retorno;
        }

        [HttpGet]
        [Route("ConsultarPorId")]
        public PessoaEntidade ConsultarPorId(int id)
        {
            var retorno = _pessoaService.ConsultarPorId(id);
            return retorno;
        }
    }
}