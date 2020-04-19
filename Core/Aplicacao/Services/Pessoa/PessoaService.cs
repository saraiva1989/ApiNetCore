using System.Collections.Generic;
using Aplicacao.Dominio.Entidades;
using Aplicacao.Interfaces.Pessoa;
using Infraestrutura.Interfaces.Pessoa;

namespace Aplicacao.Services.Pessoa
{
    public class PessoaService : IPessoaService
    {
        //Recebe o Repositorio por Injeção de dependencia.
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaService(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        public string Cadastrar(PessoaEntidade objeto)
        {
            return _pessoaRepositorio.Cadastrar(objeto) > 0 ? "Cadastro realizado com sucesso" : "Erro ao cadastrar";
        }

        public IEnumerable<PessoaEntidade> ConsultarPorNome(string nome)
        {
            return _pessoaRepositorio.ConsultarPorNome(nome);
        }

        public string Deletar(int id)
        {
            return _pessoaRepositorio.Deletar(id) > 0 ? "Deletado com sucesso" : "Erro ao Deletar";
        }

        public PessoaEntidade ConsultarPorId(int id)
        {
            return _pessoaRepositorio.ConsultarPorId(id);
        }

        public IEnumerable<PessoaEntidade> ListarTodos()
        {
            return _pessoaRepositorio.ListarTodos();
        }

        
        public string Atualizar(PessoaEntidade objeto)
        {
            return _pessoaRepositorio.Atualizar(objeto) > 0 ? "Atualização realizado com sucesso" : "Erro ao Atualizar";
        }
    }
}