using System.Collections.Generic;
using Aplicacao.Dominio.Entidades;

namespace Aplicacao.Interfaces.Pessoa
{
    //Interface que é um contrato ao invés de instanciar um objeto
    public interface IPessoaService : IGenericoService<PessoaEntidade>
    {
        IEnumerable<PessoaEntidade> ConsultarPorNome(string nome);
    }
}