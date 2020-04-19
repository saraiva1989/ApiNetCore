using System;
using System.Collections.Generic;

namespace Aplicacao.Interfaces
{
    public interface IGenericoService<T> where T : class
    {
        IEnumerable<T> ListarTodos();
        T ConsultarPorId(int id);
        string Cadastrar(T objeto);
        string Atualizar(T objeto);
        string Deletar(int id);
    }
}
