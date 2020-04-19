using System.Collections.Generic;
using Aplicacao.Dominio.Entidades;

namespace Infraestrutura.Interfaces.Pessoa
{
    //Interface para o repositorio.
    public interface IPessoaRepositorio : IGenericoRepositorio<PessoaEntidade>
    {
      IEnumerable<PessoaEntidade> ConsultarPorNome(string nome);
    }
}
